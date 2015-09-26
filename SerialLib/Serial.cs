using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;


namespace SerialLib
{
    public class Serial : SerialPort
    {
        SerialSettingsDialog settings;

        public Serial()
        {
            settings = new SerialSettingsDialog();
        }

        public void loadSettings()
        {
            SerialSettingsDialog.SerialSettings cfg = settings.Settings();

            PortName = cfg.PortName;
            BaudRate = cfg.BaudRate;
            Parity = cfg.Parity;
            DataBits = cfg.DataBits;
            StopBits = cfg.StopBits;
            Encoding = cfg.Encoding;
        }

        public DialogResult showSettingsDialog()
        {
            return settings.ShowDialog();
        }

        public SerialSettingsDialog.SerialSettings getSettings()
        {
            return settings.Settings();
        }

    }
}
