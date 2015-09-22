using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialLib
{
    public partial class SerialSettings : Form
    {
        struct setttings
        {
            String portName;
            int baudRate;
            int dataBits;
            Parity parity;
            Encoding encoding;
        }

        setttings currentset;

        public SerialSettings()
        {
            InitializeComponent();
        }

        private void SerialSettings_Load(object sender, EventArgs e)
        {
            
            SerialPort.GetPortNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
