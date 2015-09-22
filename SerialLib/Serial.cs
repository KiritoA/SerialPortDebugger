using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;


namespace SerialLib
{
    public class Serial : SerialPort
    {
        SerialSettings settings;
        private bool Listening = false;//是否没有执行完invoke相关操作
        private bool ClosingComm = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke
        private const int rxBufSize = 128;
        private byte[] rxBuffer = new byte[rxBufSize];
        private int rxHead;
        private int rxTail;

        public Serial()
        {
            settings = new SerialSettings();

            NewLine = "\r\n";

            openSettings();
        }

        public void openSettings()
        {
            settings.ShowDialog();
        }

        public String GetSerialPortInfo()
        {
            if (IsOpen)
            {
                return "Status: " + PortName + ", " + BaudRate + ", "
                    + Parity + ", " + DataBits + ", " + StopBits + ", " + Encoding.BodyName.ToUpper();
            }
            else
                return "Status: Closed";
        }

        public bool OpenSerialPort(String portName,int baud)
        {
            try
            {
                PortName = portName;
                BaudRate = baud;

                Open();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public void CloseSerialPort()
        {
            ClosingComm = true;
            while (Listening) Application.DoEvents();
            try
            { Close(); }
            catch (Exception ex)
            {
                //捕获到异常信息，创建一个新的comm对象，之前的不能用了。 
                //InitSerialPort();
                //现实异常信息给客户。  
                MessageBox.Show(ex.Message);

            }
            finally
            {
                ClosingComm = false;
            }
        }

        public void SerialPortWrite(byte[] buffer, int offset, int count)
        {
            Write(buffer, offset, count);
        }

        public int SerialPortRxAvailable()
        {
            return BytesToRead;
        }

        public int SerialPortRead()
        {
            return ReadByte();
        }

        public int SerialPortReadBuf(byte[] buffer, int count)
        {
            return Read(buffer, 0, count);
        }

        /*
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (ClosingComm) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环 
            byte ch;
            try
            {
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。
                //int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致

                while (comm.BytesToRead > 0)
                {
                    ch = (byte)(comm.ReadByte() & 0xFF);
                    rxBuffer[rxTail++] = ch;
                    if (rxTail >= rxBufSize)
                    {
                        rxTail = 0;
                    }
                }

            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。
            }
        }*/
    }
}
