using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerialPortDebugger
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm w;
            w = new MainForm();
            
            DateTime dt = System.IO.File.GetLastWriteTimeUtc(Application.ExecutablePath);
            w.Text = "Serial Port Debugger - Version: " + dt.ToString("ddd MMM d H:mm:ss UTC yyyy");

            if(w.openSerialSettings() == DialogResult.OK)
            {
                Application.Run(w);
            }
            
        }
    }
}
