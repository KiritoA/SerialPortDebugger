namespace SerialPortDebugger
{
    partial class MainForm
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
            this.label_port = new System.Windows.Forms.Label();
            this.button_configure = new System.Windows.Forms.Button();
            this.button_dtr = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClearRx = new System.Windows.Forms.Button();
            this.textBoxRx = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxHexDisplay
            // 
            this.checkBoxHexDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHexDisplay.AutoSize = true;
            this.checkBoxHexDisplay.Location = new System.Drawing.Point(434, 182);
            this.checkBoxHexDisplay.Name = "checkBoxHexDisplay";
            this.checkBoxHexDisplay.Size = new System.Drawing.Size(86, 17);
            this.checkBoxHexDisplay.TabIndex = 6;
            this.checkBoxHexDisplay.Text = "16进制显示";
            this.checkBoxHexDisplay.UseVisualStyleBackColor = true;
            // 
            // textBoxTx
            // 
            this.textBoxTx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTx.Location = new System.Drawing.Point(3, 3);
            this.textBoxTx.Multiline = true;
            this.textBoxTx.Name = "textBoxTx";
            this.textBoxTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTx.Size = new System.Drawing.Size(621, 164);
            this.textBoxTx.TabIndex = 8;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(645, 317);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(116, 31);
            this.buttonSend.TabIndex = 9;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // checkBoxHexSend
            // 
            this.checkBoxHexSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHexSend.AutoSize = true;
            this.checkBoxHexSend.Location = new System.Drawing.Point(439, 178);
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
            this.labelTxCount.Location = new System.Drawing.Point(3, 179);
            this.labelTxCount.Name = "labelTxCount";
            this.labelTxCount.Size = new System.Drawing.Size(47, 13);
            this.labelTxCount.TabIndex = 11;
            this.labelTxCount.Text = "TxCount";
            // 
            // labelRxCount
            // 
            this.labelRxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRxCount.AutoSize = true;
            this.labelRxCount.Location = new System.Drawing.Point(3, 183);
            this.labelRxCount.Name = "labelRxCount";
            this.labelRxCount.Size = new System.Drawing.Size(48, 13);
            this.labelRxCount.TabIndex = 12;
            this.labelRxCount.Text = "RxCount";
            // 
            // checkBoxNewline
            // 
            this.checkBoxNewline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNewline.AutoSize = true;
            this.checkBoxNewline.Location = new System.Drawing.Point(531, 178);
            this.checkBoxNewline.Name = "checkBoxNewline";
            this.checkBoxNewline.Size = new System.Drawing.Size(93, 17);
            this.checkBoxNewline.TabIndex = 13;
            this.checkBoxNewline.Text = "结尾发送\\r\\n";
            this.checkBoxNewline.UseVisualStyleBackColor = true;
            // 
            // buttonClearTx
            // 
            this.buttonClearTx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearTx.Location = new System.Drawing.Point(645, 354);
            this.buttonClearTx.Name = "buttonClearTx";
            this.buttonClearTx.Size = new System.Drawing.Size(116, 31);
            this.buttonClearTx.TabIndex = 14;
            this.buttonClearTx.Text = "Clear";
            this.buttonClearTx.UseVisualStyleBackColor = true;
            this.buttonClearTx.Click += new System.EventHandler(this.buttonClearTx_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(773, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // checkBoxDirectDisplay
            // 
            this.checkBoxDirectDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDirectDisplay.AutoSize = true;
            this.checkBoxDirectDisplay.Location = new System.Drawing.Point(526, 182);
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
            // label_port
            // 
            this.label_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(645, 24);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(71, 13);
            this.label_port.TabIndex = 43;
            this.label_port.Text = "Selected Port";
            // 
            // button_configure
            // 
            this.button_configure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_configure.Location = new System.Drawing.Point(645, 46);
            this.button_configure.Name = "button_configure";
            this.button_configure.Size = new System.Drawing.Size(116, 31);
            this.button_configure.TabIndex = 42;
            this.button_configure.Text = "Configure";
            this.button_configure.UseVisualStyleBackColor = true;
            this.button_configure.Click += new System.EventHandler(this.button_configure_Click);
            // 
            // button_dtr
            // 
            this.button_dtr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dtr.Location = new System.Drawing.Point(645, 120);
            this.button_dtr.Name = "button_dtr";
            this.button_dtr.Size = new System.Drawing.Size(116, 31);
            this.button_dtr.TabIndex = 41;
            this.button_dtr.Text = "DTR Pulse";
            this.button_dtr.UseVisualStyleBackColor = true;
            this.button_dtr.Click += new System.EventHandler(this.button_dtr_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(645, 83);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(52, 31);
            this.buttonOpen.TabIndex = 30;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClearRx
            // 
            this.buttonClearRx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearRx.Location = new System.Drawing.Point(703, 83);
            this.buttonClearRx.Name = "buttonClearRx";
            this.buttonClearRx.Size = new System.Drawing.Size(58, 31);
            this.buttonClearRx.TabIndex = 31;
            this.buttonClearRx.Text = "Clear";
            this.buttonClearRx.UseVisualStyleBackColor = true;
            this.buttonClearRx.Click += new System.EventHandler(this.buttonClearRx_Click);
            // 
            // textBoxRx
            // 
            this.textBoxRx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRx.Location = new System.Drawing.Point(3, 3);
            this.textBoxRx.Multiline = true;
            this.textBoxRx.Name = "textBoxRx";
            this.textBoxRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRx.Size = new System.Drawing.Size(621, 173);
            this.textBoxRx.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxRx);
            this.splitContainer1.Panel1.Controls.Add(this.labelRxCount);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHexDisplay);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxDirectDisplay);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHexSend);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxNewline);
            this.splitContainer1.Panel2.Controls.Add(this.labelTxCount);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTx);
            this.splitContainer1.Size = new System.Drawing.Size(627, 404);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 46;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.button_configure);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.button_dtr);
            this.Controls.Add(this.buttonClearTx);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonClearRx);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialPortDebugger";
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
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClearRx;
        private System.Windows.Forms.Button button_dtr;
        private System.Windows.Forms.Button button_configure;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBoxRx;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

