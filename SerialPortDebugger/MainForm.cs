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
using SerialPortDebugger;
using SerialLib;

namespace SerialPortDebugger
{
    public partial class MainForm : Form
    {
        private int rx_bytes = 0;//接收计数  
        private int tx_bytes = 0;//发送计数
        private byte[] rxBuffer = null;
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。  
        private Serial serial;

        private bool Listening = false;//是否没有执行完invoke相关操作
        private bool ClosingCom = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke
       
        static System.Timers.Timer rxTimer;

        System.Timers.Timer timer;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            serial = new Serial();
            serial.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            serial.ErrorReceived += serial_ErrorReceived;
            serial.PinChanged += serial_PinChanged;

        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serial.IsOpen)
                closeSerialPort();

            Properties.Settings.Default.HexDisplay = checkBoxHexDisplay.Checked;
            Properties.Settings.Default.HexSend = checkBoxHexSend.Checked;
            Properties.Settings.Default.SendNewLine = checkBoxNewline.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            checkBoxHexDisplay.Checked = Properties.Settings.Default.HexDisplay;
            checkBoxHexSend.Checked = Properties.Settings.Default.HexSend;
            checkBoxNewline.Checked = Properties.Settings.Default.SendNewLine;

            rxTimer = new System.Timers.Timer(50);
            rxTimer.Elapsed += new ElapsedEventHandler(rxTimer_Elapsed);
            rxTimer.AutoReset = false;

            toolTip1.SetToolTip(checkBoxDirectDisplay, "立即模式：接收数据到立即刷新显示，此模式可能会导致中文无法显示\r\n非立即模式：接收完成再显示，此模式在连续接收大量数据情况下会导致无法立即刷新显示。\r\n16进制显示模式该选项无效");



            textBoxTx.KeyPress += new KeyPressEventHandler(textBoxTx_KeyPress);

            UpdateReceiveCount();
            UpdateSendCount();
        }

        public DialogResult openSerialSettings()
        {
            DialogResult result = serial.showSettingsDialog();

            if (result == DialogResult.OK)
            {
                label_port.Text = "Selected Port: " + serial.getSettings().PortName;
            }

            return result;
        }

        void serial_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void serial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show(e.EventType.ToString());
        }

        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (ClosingCom) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环 
            bool directDisplay = checkBoxDirectDisplay.Checked;
            try
            {
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。
                int n = serial.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                rx_bytes += n;//增加接收计数

                if (rxBuffer == null)
                {
                    rxBuffer = new byte[n];//声明一个临时数组存储当前来的串口数据
                    serial.Read(rxBuffer, 0, n);//读取缓冲数据 
                }
                else
                {
                    int len = rxBuffer.Length;
                    Array.Resize(ref rxBuffer, rxBuffer.Length + n);
                    serial.Read(rxBuffer, len, n);//读取缓冲数据 
                }

                if (checkBoxHexDisplay.Checked || directDisplay)
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
                if (checkBoxHexDisplay.Checked)
                {
                    //依次的拼接出16进制字符串  
                    foreach (byte b in rxBuffer)
                    {
                        builder.Append(b.ToString("X2"));
                        builder.Append(" ");
                    }

                }
                else
                {
                    builder.Append(serial.Encoding.GetString(rxBuffer));
                }

                this.textBoxRx.AppendText(builder.ToString());

                rxBuffer = null;
                builder.Clear();
                //更新接收计数  
                UpdateReceiveCount();

            }));
        }

        void rxTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            updateRxDisplay();
        }

        private void openSerialPort()
        {
            try
            {
                serial.loadSettings();
                serial.Open();
            }
            catch (Exception ex)
            {
                closeSerialPort();
                MessageBox.Show(ex.Message);
                return;
            }

            buttonOpen.Text = "Close";
            toolStripStatusLabel1.Text = "Status: " + serial.PortName + ", " + serial.BaudRate + ", "
                + serial.Parity + ", " + serial.DataBits + ", " + serial.StopBits + ", " + serial.Encoding.BodyName.ToUpper();
        }

        private void closeSerialPort()
        {
            ClosingCom = true;
            while (Listening) Application.DoEvents();
            try
            { serial.Close(); }
            catch (Exception ex)
            {
                //捕获到异常信息，创建一个新的serial对象，之前的不能用了。 
                //initUart();
                //现实异常信息给客户。  
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClosingCom = false;

                buttonOpen.Text = "Open";
                toolStripStatusLabel1.Text = "Status: Disconnected";
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
            {
                closeSerialPort();
            }
            else
            {
                openSerialPort();
            }
            
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!serial.IsOpen || textBoxTx.Text == string.Empty)
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
                serial.Write(buf.ToArray(), 0, buf.Count);
                //记录发送的字节数  
                n = buf.Count; 

            }
            else//ascii编码直接发送  
            {
                Encoding encoding = serial.Encoding;
                byte[] gb = encoding.GetBytes(textBoxTx.Text);

                serial.Write(gb, 0, gb.Length);
                n = gb.Length;

                if (checkBoxNewline.Checked)
                {
                    serial.Write("\r\n");
                    n += 2;
                }
                
            }
            tx_bytes += n;//累加发送字节数  
            UpdateSendCount();
            
        }

        void UpdateSendCount()
        {
            labelTxCount.Text = string.Format("Sent {0:G} Byte", tx_bytes);
        }

        void UpdateReceiveCount()
        {
            labelRxCount.Text = string.Format("Received {0:G} Byte", rx_bytes);
        }

        private void buttonClearTx_Click(object sender, EventArgs e)
        {
            textBoxTx.Clear();
            tx_bytes = 0;
            UpdateSendCount();
        }

        private void buttonClearRx_Click(object sender, EventArgs e)
        {
            textBoxRx.Clear();
            rx_bytes = 0;
            UpdateReceiveCount();
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

        private void button_dtr_Click(object sender, EventArgs e)
        {
            serial.DtrEnable=true;
            timer = new System.Timers.Timer(100);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.AutoReset = false;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            serial.DtrEnable = false;
            timer.Dispose();
            
        }

        private void button_configure_Click(object sender, EventArgs e)
        {
            openSerialSettings();
        }
    }
}
