using System.Globalization;

namespace MK_Plugins.PulginsGUI
{
    partial class MK_TradePartnerViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MK_TradePartnerViewerForm));
            InputSwitchIP = new TextBox();
            ButtonConnect = new Button();
            groupBox1 = new GroupBox();
            CheckAutoCopy = new CheckBox();
            OutVersion = new TextBox();
            CheckPSWiFi = new CheckBox();
            label5 = new Label();
            OutNID = new TextBox();
            label4 = new Label();
            OutTID = new TextBox();
            OutOT = new TextBox();
            OutGender = new TextBox();
            OutLanguage = new TextBox();
            label7 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ButtonCopy = new Button();
            ButtonStop = new Button();
            textLog = new TextBox();
            PkmClipboard = new RichTextBox();
            PrintButton = new Button();
            WriteButton = new Button();
            Number_Box = new ComboBox();
            InputSwitchPort = new TextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // InputSwitchIP
            // 
            InputSwitchIP.Font = new Font("Consolas", 9F);
            InputSwitchIP.Location = new Point(112, 21);
            InputSwitchIP.Name = "InputSwitchIP";
            InputSwitchIP.Size = new Size(160, 22);
            InputSwitchIP.TabIndex = 0;
            InputSwitchIP.Text = "192.168.0.0";
            InputSwitchIP.TextAlign = HorizontalAlignment.Center;
            InputSwitchIP.TextChanged += InputSwitchIP_TextChanged;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Location = new Point(77, 325);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(72, 25);
            ButtonConnect.TabIndex = 1;
            ButtonConnect.Text = "读取";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CheckAutoCopy);
            groupBox1.Controls.Add(OutVersion);
            groupBox1.Controls.Add(CheckPSWiFi);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(OutNID);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(OutTID);
            groupBox1.Controls.Add(OutOT);
            groupBox1.Controls.Add(OutGender);
            groupBox1.Controls.Add(OutLanguage);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(450, 239);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "交易对象信息";
            // 
            // CheckAutoCopy
            // 
            CheckAutoCopy.AutoSize = true;
            CheckAutoCopy.Location = new Point(87, 190);
            CheckAutoCopy.Name = "CheckAutoCopy";
            CheckAutoCopy.Size = new Size(75, 21);
            CheckAutoCopy.TabIndex = 4;
            CheckAutoCopy.Text = "自动复制";
            CheckAutoCopy.UseVisualStyleBackColor = true;
            CheckAutoCopy.CheckedChanged += CheckAutoCopy_CheckedChanged;
            // 
            // OutVersion
            // 
            OutVersion.Location = new Point(282, 144);
            OutVersion.Name = "OutVersion";
            OutVersion.Size = new Size(133, 23);
            OutVersion.TabIndex = 5;
            // 
            // CheckPSWiFi
            // 
            CheckPSWiFi.AutoSize = true;
            CheckPSWiFi.Location = new Point(257, 190);
            CheckPSWiFi.Name = "CheckPSWiFi";
            CheckPSWiFi.Size = new Size(97, 21);
            CheckPSWiFi.TabIndex = 5;
            CheckPSWiFi.Text = "PS! WiFi模式";
            CheckPSWiFi.UseVisualStyleBackColor = true;
            CheckPSWiFi.CheckedChanged += CheckPSWiFi_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(240, 147);
            label5.Name = "label5";
            label5.Size = new Size(48, 17);
            label5.TabIndex = 8;
            label5.Text = "版 本：";
            // 
            // OutNID
            // 
            OutNID.Font = new Font("Consolas", 9F);
            OutNID.Location = new Point(282, 94);
            OutNID.Name = "OutNID";
            OutNID.Size = new Size(133, 22);
            OutNID.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(239, 96);
            label4.Name = "label4";
            label4.Size = new Size(51, 17);
            label4.TabIndex = 6;
            label4.Text = "N I D：";
            // 
            // OutTID
            // 
            OutTID.Location = new Point(282, 42);
            OutTID.Name = "OutTID";
            OutTID.Size = new Size(133, 23);
            OutTID.TabIndex = 4;
            // 
            // OutOT
            // 
            OutOT.Location = new Point(65, 42);
            OutOT.Name = "OutOT";
            OutOT.Size = new Size(133, 23);
            OutOT.TabIndex = 3;
            // 
            // OutGender
            // 
            OutGender.Location = new Point(65, 94);
            OutGender.Name = "OutGender";
            OutGender.Size = new Size(133, 23);
            OutGender.TabIndex = 9;
            // 
            // OutLanguage
            // 
            OutLanguage.Location = new Point(65, 144);
            OutLanguage.Name = "OutLanguage";
            OutLanguage.Size = new Size(133, 23);
            OutLanguage.TabIndex = 10;
            // 
            // label7
            // 
            label7.Location = new Point(26, 148);
            label7.Name = "label7";
            label7.Size = new Size(45, 17);
            label7.TabIndex = 11;
            label7.Text = "语 言:";
            // 
            // label3
            // 
            label3.Location = new Point(26, 96);
            label3.Name = "label3";
            label3.Size = new Size(45, 17);
            label3.TabIndex = 12;
            label3.Text = "性 别:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, 45);
            label2.Name = "label2";
            label2.Size = new Size(57, 17);
            label2.TabIndex = 1;
            label2.Text = "表里ID：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 45);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 0;
            label1.Text = "名 称：";
            // 
            // ButtonCopy
            // 
            ButtonCopy.Location = new Point(294, 325);
            ButtonCopy.Name = "ButtonCopy";
            ButtonCopy.Size = new Size(72, 25);
            ButtonCopy.TabIndex = 2;
            ButtonCopy.Text = "复制信息";
            ButtonCopy.UseVisualStyleBackColor = true;
            ButtonCopy.Click += ButtonCopy_Click;
            // 
            // ButtonStop
            // 
            ButtonStop.Enabled = false;
            ButtonStop.Location = new Point(183, 325);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(72, 25);
            ButtonStop.TabIndex = 3;
            ButtonStop.Text = "停止";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // textLog
            // 
            textLog.BackColor = SystemColors.Control;
            textLog.BorderStyle = BorderStyle.None;
            textLog.Location = new Point(123, 49);
            textLog.Name = "textLog";
            textLog.ReadOnly = true;
            textLog.ScrollBars = ScrollBars.Horizontal;
            textLog.Size = new Size(243, 16);
            textLog.TabIndex = 5;
            textLog.TextAlign = HorizontalAlignment.Center;
            // 
            // PkmClipboard
            // 
            PkmClipboard.Location = new Point(471, 80);
            PkmClipboard.Name = "PkmClipboard";
            PkmClipboard.Size = new Size(219, 230);
            PkmClipboard.TabIndex = 6;
            PkmClipboard.Text = "你还没有连接到对象...";
            // 
            // PrintButton
            // 
            PrintButton.Enabled = false;
            PrintButton.Location = new Point(493, 325);
            PrintButton.Name = "PrintButton";
            PrintButton.Size = new Size(72, 25);
            PrintButton.TabIndex = 7;
            PrintButton.Text = "打印";
            PrintButton.UseVisualStyleBackColor = true;
            PrintButton.Click += PrintButton_Click;
            // 
            // WriteButton
            // 
            WriteButton.Location = new Point(583, 325);
            WriteButton.Name = "WriteButton";
            WriteButton.Size = new Size(82, 25);
            WriteButton.TabIndex = 8;
            WriteButton.Text = "写入";
            WriteButton.UseVisualStyleBackColor = true;
            WriteButton.Click += WriteButton_Click;
            // 
            // Number_Box
            // 
            Number_Box.FormattingEnabled = true;
            Number_Box.Items.AddRange(new object[] { "写入主界面", "写入盒子" });
            Number_Box.Location = new Point(471, 46);
            Number_Box.Name = "Number_Box";
            Number_Box.Size = new Size(219, 25);
            Number_Box.TabIndex = 18;
            Number_Box.SelectedIndexChanged += Number_Box_SelectedIndexChanged;
            // 
            // InputSwitchPort
            // 
            InputSwitchPort.Font = new Font("Consolas", 9F);
            InputSwitchPort.Location = new Point(293, 21);
            InputSwitchPort.Name = "InputSwitchPort";
            InputSwitchPort.Size = new Size(80, 22);
            InputSwitchPort.TabIndex = 19;
            InputSwitchPort.Text = "6000";
            InputSwitchPort.TextAlign = HorizontalAlignment.Center;
            InputSwitchPort.TextChanged += InputSwitchPort_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(276, 22);
            label6.Name = "label6";
            label6.Size = new Size(11, 17);
            label6.TabIndex = 13;
            label6.Text = ":";
            // 
            // MK_TradePartnerViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 362);
            Controls.Add(label6);
            Controls.Add(InputSwitchPort);
            Controls.Add(Number_Box);
            Controls.Add(WriteButton);
            Controls.Add(PrintButton);
            Controls.Add(PkmClipboard);
            Controls.Add(textLog);
            Controls.Add(groupBox1);
            Controls.Add(ButtonCopy);
            Controls.Add(InputSwitchIP);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonConnect);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MK_TradePartnerViewerForm";
            Load += Form_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputSwitchIP;
        private Button ButtonConnect;
        private GroupBox groupBox1;
        private TextBox OutVersion;
        private Label label4;
        private TextBox OutTID;
        private TextBox OutOT;
        private TextBox OutGender;
        private Label label2;
        private Label label1;
        private Button ButtonCopy;
        private Button ButtonStop;
        private CheckBox CheckAutoCopy;
        private CheckBox CheckPSWiFi;
        private Label label3;
        private TextBox OutLanguage;
        private Label label7;
        private TextBox textLog;
        private Label label5;
        private RichTextBox PkmClipboard;
        private Button PrintButton;
        private TextBox OutNID;
        private Button WriteButton;
        private ComboBox Number_Box;
        private TextBox InputSwitchPort;
        private Label label6;
    }
}