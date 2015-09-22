namespace SerialDebugger
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxRx = new System.Windows.Forms.TextBox();
            this.checkBoxHexDisplay = new System.Windows.Forms.CheckBox();
            this.textBoxTx = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.checkBoxHexSend = new System.Windows.Forms.CheckBox();
            this.labelTxCount = new System.Windows.Forms.Label();
            this.labelRxCount = new System.Windows.Forms.Label();
            this.checkBoxNewline = new System.Windows.Forms.CheckBox();
            this.buttonClearTx = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.checkBoxDirectDisplay = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_dtr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.comboBoxEncoder = new System.Windows.Forms.ComboBox();
            this.comboStopBits = new System.Windows.Forms.ComboBox();
            this.buttonClearRx = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboDataBits = new System.Windows.Forms.ComboBox();
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.button_configure = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxRx
            // 
            this.textBoxRx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRx.Location = new System.Drawing.Point(14, 13);
            this.textBoxRx.Multiline = true;
            this.textBoxRx.Name = "textBoxRx";
            this.textBoxRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRx.Size = new System.Drawing.Size(756, 266);
            this.textBoxRx.TabIndex = 4;
            // 
            // checkBoxHexDisplay
            // 
            this.checkBoxHexDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHexDisplay.AutoSize = true;
            this.checkBoxHexDisplay.Location = new System.Drawing.Point(809, 282);
            this.checkBoxHexDisplay.Name = "checkBoxHexDisplay";
            this.checkBoxHexDisplay.Size = new System.Drawing.Size(86, 17);
            this.checkBoxHexDisplay.TabIndex = 6;
            this.checkBoxHexDisplay.Text = "16进制显示";
            this.checkBoxHexDisplay.UseVisualStyleBackColor = true;
            this.checkBoxHexDisplay.CheckedChanged += new System.EventHandler(this.checkBoxHexView_CheckedChanged);
            // 
            // textBoxTx
            // 
            this.textBoxTx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTx.Location = new System.Drawing.Point(14, 3);
            this.textBoxTx.Multiline = true;
            this.textBoxTx.Name = "textBoxTx";
            this.textBoxTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTx.Size = new System.Drawing.Size(756, 126);
            this.textBoxTx.TabIndex = 8;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(778, 74);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(117, 27);
            this.buttonSend.TabIndex = 9;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // checkBoxHexSend
            // 
            this.checkBoxHexSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHexSend.AutoSize = true;
            this.checkBoxHexSend.Location = new System.Drawing.Point(776, 26);
            this.checkBoxHexSend.Name = "checkBoxHexSend";
            this.checkBoxHexSend.Size = new System.Drawing.Size(86, 17);
            this.checkBoxHexSend.TabIndex = 10;
            this.checkBoxHexSend.Text = "16进制发送";
            this.checkBoxHexSend.UseVisualStyleBackColor = true;
            this.checkBoxHexSend.CheckedChanged += new System.EventHandler(this.checkBoxHexSend_CheckedChanged);
            // 
            // labelTxCount
            // 
            this.labelTxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTxCount.AutoSize = true;
            this.labelTxCount.Location = new System.Drawing.Point(12, 133);
            this.labelTxCount.Name = "labelTxCount";
            this.labelTxCount.Size = new System.Drawing.Size(47, 13);
            this.labelTxCount.TabIndex = 11;
            this.labelTxCount.Text = "TxCount";
            // 
            // labelRxCount
            // 
            this.labelRxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRxCount.AutoSize = true;
            this.labelRxCount.Location = new System.Drawing.Point(12, 283);
            this.labelRxCount.Name = "labelRxCount";
            this.labelRxCount.Size = new System.Drawing.Size(48, 13);
            this.labelRxCount.TabIndex = 12;
            this.labelRxCount.Text = "RxCount";
            // 
            // checkBoxNewline
            // 
            this.checkBoxNewline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNewline.AutoSize = true;
            this.checkBoxNewline.Location = new System.Drawing.Point(776, 49);
            this.checkBoxNewline.Name = "checkBoxNewline";
            this.checkBoxNewline.Size = new System.Drawing.Size(93, 17);
            this.checkBoxNewline.TabIndex = 13;
            this.checkBoxNewline.Text = "结尾发送\\r\\n";
            this.checkBoxNewline.UseVisualStyleBackColor = true;
            // 
            // buttonClearTx
            // 
            this.buttonClearTx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearTx.Location = new System.Drawing.Point(778, 107);
            this.buttonClearTx.Name = "buttonClearTx";
            this.buttonClearTx.Size = new System.Drawing.Size(117, 27);
            this.buttonClearTx.TabIndex = 14;
            this.buttonClearTx.Text = "Clear";
            this.buttonClearTx.UseVisualStyleBackColor = true;
            this.buttonClearTx.Click += new System.EventHandler(this.buttonClearTx_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(907, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel1.Text = "Status: Closed";
            // 
            // checkBoxDirectDisplay
            // 
            this.checkBoxDirectDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDirectDisplay.AutoSize = true;
            this.checkBoxDirectDisplay.Location = new System.Drawing.Point(705, 282);
            this.checkBoxDirectDisplay.Name = "checkBoxDirectDisplay";
            this.checkBoxDirectDisplay.Size = new System.Drawing.Size(98, 17);
            this.checkBoxDirectDisplay.TabIndex = 25;
            this.checkBoxDirectDisplay.Text = "立即显示模式";
            this.checkBoxDirectDisplay.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_configure);
            this.splitContainer1.Panel1.Controls.Add(this.button_dtr);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpen);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxEncoder);
            this.splitContainer1.Panel1.Controls.Add(this.comboStopBits);
            this.splitContainer1.Panel1.Controls.Add(this.buttonClearRx);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.comboParity);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.comboDataBits);
            this.splitContainer1.Panel1.Controls.Add(this.comboPortName);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.comboBaudRate);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxDirectDisplay);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxRx);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHexDisplay);
            this.splitContainer1.Panel1.Controls.Add(this.labelRxCount);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTx);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend);
            this.splitContainer1.Panel2.Controls.Add(this.buttonClearTx);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHexSend);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxNewline);
            this.splitContainer1.Panel2.Controls.Add(this.labelTxCount);
            this.splitContainer1.Size = new System.Drawing.Size(907, 460);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 26;
            // 
            // button_dtr
            // 
            this.button_dtr.Location = new System.Drawing.Point(708, 246);
            this.button_dtr.Name = "button_dtr";
            this.button_dtr.Size = new System.Drawing.Size(117, 30);
            this.button_dtr.TabIndex = 41;
            this.button_dtr.Text = "DTR Pulse";
            this.button_dtr.UseVisualStyleBackColor = true;
            this.button_dtr.Click += new System.EventHandler(this.button_dtr_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(776, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "可用串口";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(776, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Encoding";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(778, 186);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(52, 26);
            this.buttonOpen.TabIndex = 30;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // comboBoxEncoder
            // 
            this.comboBoxEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEncoder.FormattingEnabled = true;
            this.comboBoxEncoder.Items.AddRange(new object[] {
            "GB2312",
            "UTF-8"});
            this.comboBoxEncoder.Location = new System.Drawing.Point(832, 219);
            this.comboBoxEncoder.Name = "comboBoxEncoder";
            this.comboBoxEncoder.Size = new System.Drawing.Size(63, 21);
            this.comboBoxEncoder.TabIndex = 39;
            // 
            // comboStopBits
            // 
            this.comboStopBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStopBits.FormattingEnabled = true;
            this.comboStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "1.5"});
            this.comboStopBits.Location = new System.Drawing.Point(823, 158);
            this.comboStopBits.Name = "comboStopBits";
            this.comboStopBits.Size = new System.Drawing.Size(72, 21);
            this.comboStopBits.TabIndex = 38;
            // 
            // buttonClearRx
            // 
            this.buttonClearRx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearRx.Location = new System.Drawing.Point(835, 186);
            this.buttonClearRx.Name = "buttonClearRx";
            this.buttonClearRx.Size = new System.Drawing.Size(60, 26);
            this.buttonClearRx.TabIndex = 31;
            this.buttonClearRx.Text = "Clear";
            this.buttonClearRx.UseVisualStyleBackColor = true;
            this.buttonClearRx.Click += new System.EventHandler(this.buttonClearRx_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(776, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "停止位";
            // 
            // comboParity
            // 
            this.comboParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParity.FormattingEnabled = true;
            this.comboParity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN",
            "MARK",
            "SPACE"});
            this.comboParity.Location = new System.Drawing.Point(823, 102);
            this.comboParity.Name = "comboParity";
            this.comboParity.Size = new System.Drawing.Size(72, 21);
            this.comboParity.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "波特率";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(776, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "校验位";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(778, 41);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(117, 26);
            this.buttonRefresh.TabIndex = 27;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboDataBits
            // 
            this.comboDataBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataBits.FormattingEnabled = true;
            this.comboDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboDataBits.Location = new System.Drawing.Point(823, 130);
            this.comboDataBits.Name = "comboDataBits";
            this.comboDataBits.Size = new System.Drawing.Size(72, 21);
            this.comboDataBits.TabIndex = 34;
            // 
            // comboPortName
            // 
            this.comboPortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(835, 13);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(60, 21);
            this.comboPortName.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(776, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "数据位";
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.comboBaudRate.Location = new System.Drawing.Point(823, 74);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(72, 21);
            this.comboBaudRate.TabIndex = 32;
            // 
            // button_configure
            // 
            this.button_configure.Location = new System.Drawing.Point(584, 77);
            this.button_configure.Name = "button_configure";
            this.button_configure.Size = new System.Drawing.Size(122, 31);
            this.button_configure.TabIndex = 42;
            this.button_configure.Text = "Configure";
            this.button_configure.UseVisualStyleBackColor = true;
            this.button_configure.Click += new System.EventHandler(this.button_configure_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 482);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialPortDebugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRx;
        private System.Windows.Forms.CheckBox checkBoxHexDisplay;
        private System.Windows.Forms.TextBox textBoxTx;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.CheckBox checkBoxHexSend;
        private System.Windows.Forms.Label labelTxCount;
        private System.Windows.Forms.Label labelRxCount;
        private System.Windows.Forms.CheckBox checkBoxNewline;
        private System.Windows.Forms.Button buttonClearTx;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox checkBoxDirectDisplay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ComboBox comboBoxEncoder;
        private System.Windows.Forms.ComboBox comboStopBits;
        private System.Windows.Forms.Button buttonClearRx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboParity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboDataBits;
        private System.Windows.Forms.ComboBox comboPortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Button button_dtr;
        private System.Windows.Forms.Button button_configure;
    }
}

