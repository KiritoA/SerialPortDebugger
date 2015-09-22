using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Timers;
using SerialDebugger;
using SerialLib;

namespace SerialDebugger
{
    public partial class Form1 : Form
    {
        private int rxCount = 0;//接收计数  
        private int txCount = 0;//发送计数
        private byte[] rxBuffer = null;
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。  
        private Serial comm;
        //private Serial serial;

        private bool Listening = false;//是否没有执行完invoke相关操作
        private bool ClosingCom = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke
       
        static System.Timers.Timer rxTimer;

        System.Timers.Timer timer;

        bool hexMode = false;
        String textEncoding;
        public Form1()
        {
            InitializeComponent();
            //serial = new Serial();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.HexDisplay = checkBoxHexDisplay.Checked;
            Properties.Settings.Default.HexSend = checkBoxHexSend.Checked;
            Properties.Settings.Default.SendNewLine = checkBoxNewline.Checked;
            Properties.Settings.Default.PortName = comboPortName.Text;
            Properties.Settings.Default.BaudRate = comboBaudRate.SelectedIndex;
            Properties.Settings.Default.Parity = comboParity.SelectedIndex;
            Properties.Settings.Default.DataBits = comboDataBits.SelectedIndex;
            Properties.Settings.Default.StopBits = comboStopBits.SelectedIndex;
            Properties.Settings.Default.Encoder = comboBoxEncoder.Text;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBoxHexDisplay.Checked = Properties.Settings.Default.HexDisplay;
            hexMode = checkBoxHexDisplay.Checked;
            checkBoxHexSend.Checked = Properties.Settings.Default.HexSend;
            checkBoxNewline.Checked = Properties.Settings.Default.SendNewLine;
            comboBaudRate.SelectedIndex = Properties.Settings.Default.BaudRate;
            comboParity.SelectedIndex = Properties.Settings.Default.Parity;
            comboDataBits.SelectedIndex = Properties.Settings.Default.DataBits;
            comboStopBits.SelectedIndex = Properties.Settings.Default.StopBits;
            comboBoxEncoder.Text = Properties.Settings.Default.Encoder;

            DateTime dt = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location);
            this.Text = "串口调试助手 - 生成时间:"
                + dt.ToString("yyyy/MM/dd HH:mm:ss");

            rxTimer = new System.Timers.Timer(50);
            rxTimer.Elapsed += new ElapsedEventHandler(rxTimer_Elapsed);
            rxTimer.AutoReset = false;

            toolTip1.SetToolTip(checkBoxDirectDisplay, "立即模式：接收数据到立即刷新显示，此模式可能会导致中文无法显示\r\n非立即模式：接收完成再显示，此模式在连续接收大量数据情况下会导致无法立即刷新显示。\r\n16进制显示模式该选项无效");

            initUart();
            textBoxTx.KeyPress += new KeyPressEventHandler(textBoxTx_KeyPress);
            getSerialPortNames();

            UpdateReceiveCount();
            UpdateSendCount();
        }

        private void initUart()
        {
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            comm = new Serial();
            comm.NewLine = "\r\n";
            comm.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (ClosingCom) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环 
            bool directDisplay = checkBoxDirectDisplay.Checked;
            try
            {
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。
                int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                rxCount += n;//增加接收计数

                if (rxBuffer == null)
                {
                    rxBuffer = new byte[n];//声明一个临时数组存储当前来的串口数据
                    comm.Read(rxBuffer, 0, n);//读取缓冲数据 
                }
                else
                {
                    int len = rxBuffer.Length;
                    Array.Resize(ref rxBuffer, rxBuffer.Length + n);
                    comm.Read(rxBuffer, len, n);//读取缓冲数据 
                }

                if (hexMode || directDisplay)
                {
                    updateRxDisplay();
                }
                else
                {
                    if (rxTimer.Enabled == true)
                    {
                        rxTimer.Stop();
                    }
                    rxTimer.Start();
                }

            }
            finally    
            {
                Listening = false;//我用完了，ui可以关闭串口了。
            }
        }

        void updateRxDisplay()
        {

            //因为要访问ui资源，所以需要使用invoke方式同步ui。  
            this.Invoke((EventHandler)(delegate
            {
                //判断是否是显示为16进制  
                if (hexMode)
                {
                    //依次的拼接出16进制字符串  
                    foreach (byte b in rxBuffer)
                    {
                        builder.Append(b.ToString("X2") + " ");
                    }

                }
                else
                {
                    builder.Append(Encoding.GetEncoding(comboBoxEncoder.Text).GetString(rxBuffer));
                }

                this.textBoxRx.AppendText(builder.ToString());

                rxBuffer = null;
                builder.Remove(0, builder.Length);//清除字符串构造器的内容  
                //修改接收计数  
                UpdateReceiveCount();

            }));
        }

        void rxTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            updateRxDisplay();
        }

        void getSerialPortNames()
        {
            String[] ports = null;
            comboPortName.Items.Clear();
            ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboPortName.Items.AddRange(ports);
            comboPortName.SelectedIndex = comboPortName.Items.Count > 0 ? 0 : -1;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (comm.IsOpen)
            {
                ClosingCom = true;
                while (Listening) Application.DoEvents();
                try
                { comm.Close(); }
                catch (Exception ex)
                {
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了。 
                    initUart();
                    //现实异常信息给客户。  
                    MessageBox.Show(ex.Message);
                }
                ClosingCom = false;
                buttonRefresh.Enabled = true;

                comboPortName.Enabled = true;
                comboBaudRate.Enabled = true;
                comboParity.Enabled = true;
                comboDataBits.Enabled = true;
                comboStopBits.Enabled = true;
                comboBoxEncoder.Enabled = true;

                toolStripStatusLabel1.Text = "Status: Closed";
            }
            else
            {
                textEncoding = comboBoxEncoder.Text;
                try
                {
                    comm.Encoding = Encoding.GetEncoding(textEncoding);
                    comm.PortName = comboPortName.Text;
                    comm.BaudRate = int.Parse(comboBaudRate.Text);
                    comm.DataBits = comboDataBits.SelectedIndex + 5;
                    comm.Parity = (Parity)comboParity.SelectedIndex;
                    comm.StopBits = (StopBits)comboStopBits.SelectedIndex + 1;

                    comm.Open();
                    
                }
                catch (Exception ex)
                {
                    initUart();
                    MessageBox.Show(ex.Message);
                    return;
                }
                buttonRefresh.Enabled = false;

                comboPortName.Enabled = false;
                comboBaudRate.Enabled = false;
                comboParity.Enabled = false;
                comboDataBits.Enabled = false;
                comboStopBits.Enabled = false;
                comboBoxEncoder.Enabled = false;

                toolStripStatusLabel1.Text = "Status: " + comm.PortName + ", " + comm.BaudRate + ", " 
                    + comm.Parity + ", " + comm.DataBits + ", " + comm.StopBits + ", " + comm.Encoding.BodyName.ToUpper();
            }
            buttonOpen.Text = comm.IsOpen ? "Close" : "Open";
        }

        private void buttonClearRx_Click(object sender, EventArgs e)
        {
            builder.Clear();
            textBoxRx.Clear();
            rxCount = 0;
            UpdateReceiveCount();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!comm.IsOpen)
                return;

            //定义一个变量，记录发送了几个字节  
            int n = 0;
            //16进制发送  
            if (checkBoxHexSend.Checked)
            {
                //我们不管规则了。如果写错了一些，我们允许的，只用正则得到有效的十六进制数  
                MatchCollection mc = Regex.Matches(textBoxTx.Text, @"(?i)[\da-f]{2}");
                List<byte> buf = new List<byte>();//填充到这个临时列表中  
                //依次添加到列表中  
                foreach (Match m in mc)
                {
                    buf.Add(byte.Parse(m.Value, System.Globalization.NumberStyles.HexNumber));
                }

                if (checkBoxNewline.Checked)
                {
                    buf.Add((byte)'\r');
                    buf.Add((byte)'\n');
                }
                //转换列表为数组后发送  
                comm.Write(buf.ToArray(), 0, buf.Count);
                //记录发送的字节数  
                n = buf.Count; 

            }
            else//ascii编码直接发送  
            {
                String text = textBoxTx.Text;
                if (checkBoxNewline.Checked)
                    text += "\r\n";
                Encoding encoding = System.Text.Encoding.GetEncoding(textEncoding);
                byte[] gb = encoding.GetBytes(text);

                comm.Write(gb, 0, gb.Length);
                n = text.Length;
                
            }
            txCount += n;//累加发送字节数  
            UpdateSendCount();
            
        }

        void textBoxTx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkBoxHexSend.Checked)
            {
                //textBoxTx.Text.Length;
                char key = e.KeyChar;
                if (key >= '0' && key <= '9' || key >= 'A' && key <= 'F' || key == 8)
                {
                    
                }
                else if (key >= 'a' && key <= 'f')
                {
                    e.KeyChar = key.ToString().ToUpper().ToCharArray()[0];
                }
                else
                    e.Handled = true;
            }
        }

        void UpdateSendCount()
        {
            labelTxCount.Text = "已发送 " + txCount.ToString() +" Byte";//更新界面
        }

        void UpdateReceiveCount()
        {
            labelRxCount.Text = "已接收 " + rxCount.ToString() + " Byte";
        }

        private void buttonClearTx_Click(object sender, EventArgs e)
        {
            textBoxTx.Clear();
            txCount = 0;
            UpdateSendCount();
        }

        private void checkBoxHexSend_CheckedChanged(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            if (checkBoxHexSend.Checked)
            {
                byte[] buf = Encoding.Default.GetBytes(textBoxTx.Text);
                //依次的拼接出16进制字符串  
                foreach (byte b in buf)
                {
                    builder.Append(b.ToString("X2") + " ");
                }
                textBoxTx.Text = "";
                textBoxTx.AppendText(builder.ToString());
            }
            else
            {

                //我们不管规则了。如果写错了一些，我们允许的，只用正则得到有效的十六进制数  
                MatchCollection mc = Regex.Matches(textBoxTx.Text, @"(?i)[\da-f]{2}");
                List<byte> buf = new List<byte>();//填充到这个临时列表中  
                //依次添加到列表中  
                foreach (Match m in mc)
                {
                    buf.Add(byte.Parse(m.Value, System.Globalization.NumberStyles.HexNumber));
                    
                }
                textBoxTx.Text = "";
                textBoxTx.AppendText(Encoding.Default.GetString(buf.ToArray()));
            }
        }

        private void checkBoxHexView_CheckedChanged(object sender, EventArgs e)
        {
            hexMode = checkBoxHexDisplay.Checked;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            getSerialPortNames();
        }

        private void button_dtr_Click(object sender, EventArgs e)
        {
            comm.DtrEnable=true;
            timer = new System.Timers.Timer(100);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.AutoReset = false;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            comm.DtrEnable = false;
            timer.Dispose();
            
        }

        private void button_configure_Click(object sender, EventArgs e)
        {

        }
    }
}
