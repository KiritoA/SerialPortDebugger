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
    public partial class SerialSettingsDialog : Form
    {
        public struct SerialSettings
        {
            String portName;
            public String PortName
            {
                get { return portName; }
                set { portName = value; }
            }
            int baudRate;
            public int BaudRate
            {
                get { return baudRate; }
                set { baudRate = value; }
            }
            int dataBits;
            public int DataBits
            {
                get { return dataBits; }
                set { dataBits = value; }
            }
            Parity parity;
            public Parity Parity
            {
                get { return parity; }
                set { parity = value; }
            }
            StopBits stopBits;
            public StopBits StopBits
            {
                get { return stopBits; }
                set { stopBits = value; }
            }
            Encoding encoding;
            public Encoding Encoding
            {
                get { return encoding; }
                set { encoding = value; }
            }
        }

        SerialSettings currentset;

        public SerialSettingsDialog()
        {
            InitializeComponent();
            this.comboBox_ports.TextChanged += comboBox_ports_TextChanged;
            this.comboBaudRate.TextChanged += comboBaudRate_TextChanged;
            this.comboBoxEncoding.TextChanged += comboBoxEncoding_TextChanged;
        }
        
        public SerialSettings Settings()
        {
            return currentset;
        }

        private void SerialSettings_Load(object sender, EventArgs e)
        {
            updatePortsInfo();
            loadParameters();
        }

        void comboBox_ports_TextChanged(object sender, EventArgs e)
        {
            checkPortNamePolicy(comboBox_ports.Text);
        }

        void comboBaudRate_TextChanged(object sender, EventArgs e)
        {
            checkBaudRatePolicy(comboBaudRate.Text);
        }

        void comboBoxEncoding_TextChanged(object sender, EventArgs e)
        {
            checkEncodingPolicy(comboBoxEncoding.Text);
        }

        bool checkPortNamePolicy(String text)
        {

            if (text != String.Empty && text.StartsWith("COM") && text.Length > 3)
            {
                int result;
                bool valid = int.TryParse(text.Substring(3), out result);

                if (valid)
                {
                    button_apply.Enabled = true;
                    return true;
                }
            }
            button_apply.Enabled = false;
            return false;
        }

        bool checkBaudRatePolicy(String text)
        {
            int res;
            if (int.TryParse(comboBaudRate.Text, out res))
            {
                button_apply.Enabled = true;
                return true;
            }
            button_apply.Enabled = false;
            return false;
        }

        bool checkEncodingPolicy(String text)
        {
            if (text != string.Empty)
            {
                button_apply.Enabled = true;
                return true;
            }
            else
            {
                button_apply.Enabled = false;
                return false;
            }
        }

        void updatePortsInfo()
        {
            comboBox_ports.Items.Clear();
            String[] ports = SerialPort.GetPortNames();

            ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBox_ports.Items.AddRange(ports);

            comboBox_ports.SelectedIndex = comboBox_ports.Items.Count > 0 ? 0 : -1;
        }

        void loadParameters()
        {
            int idx = -1;
            DataTable parity = new DataTable();
            parity.Columns.Add(new DataColumn("name",typeof(string)));
            parity.Columns.Add(new DataColumn("value",typeof(Parity)));
            parity.Rows.Add("None", Parity.None);
            parity.Rows.Add("Odd", Parity.Odd);
            parity.Rows.Add("Even", Parity.Even);
            parity.Rows.Add("Mark", Parity.Mark);
            parity.Rows.Add("Space", Parity.Space);

            comboParity.DisplayMember = "name";
            comboParity.ValueMember = "value";
            comboParity.DataSource = parity;

            idx = Properties.Settings.Default.Parity;
            comboParity.SelectedIndex = (idx < comboParity.Items.Count ? idx : 0);

            DataTable stopBits = new DataTable();
            stopBits.Columns.Add(new DataColumn("name", typeof(string)));
            stopBits.Columns.Add(new DataColumn("value", typeof(StopBits)));
            stopBits.Rows.Add("1", StopBits.One);
            stopBits.Rows.Add("1.5", StopBits.OnePointFive);
            stopBits.Rows.Add("2", StopBits.Two);

            comboStopBits.DisplayMember = "name";
            comboStopBits.ValueMember = "value";
            comboStopBits.DataSource = stopBits;

            idx = Properties.Settings.Default.StopBits;
            comboStopBits.SelectedIndex = (idx < comboStopBits.Items.Count ? idx : 0);

            DataTable dataBits = new DataTable();
            dataBits.Columns.Add(new DataColumn("name", typeof(string)));
            dataBits.Columns.Add(new DataColumn("value", typeof(int)));
            dataBits.Rows.Add("5", 5);
            dataBits.Rows.Add("6", 6);
            dataBits.Rows.Add("7", 7);
            dataBits.Rows.Add("8", 8);

            comboDataBits.DisplayMember = "name";
            comboDataBits.ValueMember = "value";
            comboDataBits.DataSource = dataBits;

            idx = Properties.Settings.Default.DataBits;
            comboDataBits.SelectedIndex = (idx < comboDataBits.Items.Count ? idx : 0);

            comboBox_ports.Text = Properties.Settings.Default.PortName;
            comboBaudRate.Text = Properties.Settings.Default.BaudRate.ToString();
            comboBoxEncoding.Text = Properties.Settings.Default.Encoding;
        }

        bool checkAllPolicy()
        {
            try
            {
                 Encoding.GetEncoding(comboBoxEncoding.Text);
            }
            catch
            {
                MessageBox.Show("Encoding 参数无效", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            if (checkAllPolicy())
            {
                updateSettings();
                Properties.Settings.Default.PortName = comboBox_ports.Text;
                Properties.Settings.Default.BaudRate = int.Parse(comboBaudRate.Text);
                Properties.Settings.Default.Parity = comboParity.SelectedIndex;
                Properties.Settings.Default.DataBits = comboDataBits.SelectedIndex;
                Properties.Settings.Default.StopBits = comboStopBits.SelectedIndex;
                Properties.Settings.Default.Encoding = comboBoxEncoding.Text;
                Properties.Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
            }
        }

        void updateSettings()
        {
            currentset.PortName = comboBox_ports.Text;
            currentset.BaudRate = int.Parse(comboBaudRate.Text);
            currentset.Parity = (Parity)comboParity.SelectedValue;
            currentset.DataBits = (int)comboDataBits.SelectedValue;
            currentset.StopBits = (StopBits)comboStopBits.SelectedValue;
            currentset.Encoding = Encoding.GetEncoding(comboBoxEncoding.Text);
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            updatePortsInfo();
            loadParameters();
            System.GC.Collect();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            updatePortsInfo();
        }
    }
}
