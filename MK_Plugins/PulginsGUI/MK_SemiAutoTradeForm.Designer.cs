namespace MK_Plugins.PulginsGUI
{
    partial class MK_SemiAutoTradeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MK_SemiAutoTradeForm));
            InputSwitchIP = new TextBox();
            Connect_BTN = new Button();
            Stop_BTN = new Button();
            Code_label = new Label();
            Code_Text = new TextBox();
            Log_Box = new RichTextBox();
            CreateTrade_BTN = new Button();
            Basic_GroupBox = new GroupBox();
            EndTrade_BTN = new Button();
            PKM_CheckBox = new CheckedListBox();
            Trade_GroupBox = new GroupBox();
            ID_CheckBox = new CheckBox();
            TradeInfo_Box = new RichTextBox();
            ContinuousTrade_Check = new CheckBox();
            StartTrade_BTN = new Button();
            ReadList_BTN = new Button();
            Clear_BTN = new Button();
            Basic_GroupBox.SuspendLayout();
            Trade_GroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // InputSwitchIP
            // 
            InputSwitchIP.Location = new Point(6, 22);
            InputSwitchIP.Name = "InputSwitchIP";
            InputSwitchIP.Size = new Size(156, 23);
            InputSwitchIP.TabIndex = 0;
            InputSwitchIP.Text = "192.168.0.0";
            InputSwitchIP.TextAlign = HorizontalAlignment.Center;
            InputSwitchIP.TextChanged += InputSwitchIP_TextChanged;
            // 
            // Connect_BTN
            // 
            Connect_BTN.Location = new Point(6, 51);
            Connect_BTN.Name = "Connect_BTN";
            Connect_BTN.Size = new Size(75, 23);
            Connect_BTN.TabIndex = 1;
            Connect_BTN.Text = "连接";
            Connect_BTN.UseVisualStyleBackColor = true;
            Connect_BTN.Click += Connect_BTN_Click;
            // 
            // Stop_BTN
            // 
            Stop_BTN.Enabled = false;
            Stop_BTN.Location = new Point(87, 51);
            Stop_BTN.Name = "Stop_BTN";
            Stop_BTN.Size = new Size(75, 23);
            Stop_BTN.TabIndex = 2;
            Stop_BTN.Text = "断开";
            Stop_BTN.UseVisualStyleBackColor = true;
            Stop_BTN.Click += Stop_BTN_Click;
            // 
            // Code_label
            // 
            Code_label.Location = new Point(6, 82);
            Code_label.Name = "Code_label";
            Code_label.Size = new Size(45, 17);
            Code_label.TabIndex = 12;
            Code_label.Text = "密码:";
            // 
            // Code_Text
            // 
            Code_Text.Location = new Point(48, 79);
            Code_Text.Name = "Code_Text";
            Code_Text.Size = new Size(114, 23);
            Code_Text.TabIndex = 13;
            Code_Text.TextChanged += Code_Text_TextChanged;
            // 
            // Log_Box
            // 
            Log_Box.Location = new Point(186, 20);
            Log_Box.Name = "Log_Box";
            Log_Box.Size = new Size(277, 167);
            Log_Box.TabIndex = 14;
            Log_Box.Text = "";
            // 
            // CreateTrade_BTN
            // 
            CreateTrade_BTN.Location = new Point(6, 108);
            CreateTrade_BTN.Name = "CreateTrade_BTN";
            CreateTrade_BTN.Size = new Size(156, 23);
            CreateTrade_BTN.TabIndex = 15;
            CreateTrade_BTN.Text = "创建交易";
            CreateTrade_BTN.UseVisualStyleBackColor = true;
            CreateTrade_BTN.Click += CreateTrade_BTN_Click;
            // 
            // Basic_GroupBox
            // 
            Basic_GroupBox.Controls.Add(EndTrade_BTN);
            Basic_GroupBox.Controls.Add(InputSwitchIP);
            Basic_GroupBox.Controls.Add(CreateTrade_BTN);
            Basic_GroupBox.Controls.Add(Connect_BTN);
            Basic_GroupBox.Controls.Add(Stop_BTN);
            Basic_GroupBox.Controls.Add(Code_Text);
            Basic_GroupBox.Controls.Add(Code_label);
            Basic_GroupBox.Location = new Point(12, 12);
            Basic_GroupBox.Name = "Basic_GroupBox";
            Basic_GroupBox.Size = new Size(168, 176);
            Basic_GroupBox.TabIndex = 16;
            Basic_GroupBox.TabStop = false;
            Basic_GroupBox.Text = "基础";
            // 
            // EndTrade_BTN
            // 
            EndTrade_BTN.Location = new Point(6, 137);
            EndTrade_BTN.Name = "EndTrade_BTN";
            EndTrade_BTN.Size = new Size(156, 23);
            EndTrade_BTN.TabIndex = 17;
            EndTrade_BTN.Text = "结束交易";
            EndTrade_BTN.UseVisualStyleBackColor = true;
            EndTrade_BTN.Click += EndTrade_BTN_Click;
            // 
            // PKM_CheckBox
            // 
            PKM_CheckBox.AllowDrop = true;
            PKM_CheckBox.Font = new Font("黑体", 9F);
            PKM_CheckBox.FormattingEnabled = true;
            PKM_CheckBox.Location = new Point(186, 193);
            PKM_CheckBox.Name = "PKM_CheckBox";
            PKM_CheckBox.Size = new Size(277, 292);
            PKM_CheckBox.TabIndex = 18;
            PKM_CheckBox.DragDrop += PKM_CheckBox_DragDrop;
            PKM_CheckBox.DragEnter += PKM_CheckBox_DragEnter;
            // 
            // Trade_GroupBox
            // 
            Trade_GroupBox.Controls.Add(ID_CheckBox);
            Trade_GroupBox.Controls.Add(TradeInfo_Box);
            Trade_GroupBox.Controls.Add(ContinuousTrade_Check);
            Trade_GroupBox.Controls.Add(StartTrade_BTN);
            Trade_GroupBox.Controls.Add(ReadList_BTN);
            Trade_GroupBox.Controls.Add(Clear_BTN);
            Trade_GroupBox.Location = new Point(12, 194);
            Trade_GroupBox.Name = "Trade_GroupBox";
            Trade_GroupBox.Size = new Size(168, 291);
            Trade_GroupBox.TabIndex = 19;
            Trade_GroupBox.TabStop = false;
            Trade_GroupBox.Text = "交易";
            // 
            // ID_CheckBox
            // 
            ID_CheckBox.AutoSize = true;
            ID_CheckBox.Checked = true;
            ID_CheckBox.CheckState = CheckState.Checked;
            ID_CheckBox.Location = new Point(112, 260);
            ID_CheckBox.Name = "ID_CheckBox";
            ID_CheckBox.Size = new Size(52, 21);
            ID_CheckBox.TabIndex = 23;
            ID_CheckBox.Text = "自ID";
            ID_CheckBox.UseVisualStyleBackColor = true;
            // 
            // TradeInfo_Box
            // 
            TradeInfo_Box.Location = new Point(6, 83);
            TradeInfo_Box.Name = "TradeInfo_Box";
            TradeInfo_Box.ReadOnly = true;
            TradeInfo_Box.Size = new Size(156, 125);
            TradeInfo_Box.TabIndex = 22;
            TradeInfo_Box.Text = "";
            // 
            // ContinuousTrade_Check
            // 
            ContinuousTrade_Check.AutoSize = true;
            ContinuousTrade_Check.Location = new Point(12, 260);
            ContinuousTrade_Check.Name = "ContinuousTrade_Check";
            ContinuousTrade_Check.Size = new Size(99, 21);
            ContinuousTrade_Check.TabIndex = 21;
            ContinuousTrade_Check.Text = "自动连续交换";
            ContinuousTrade_Check.UseVisualStyleBackColor = true;
            // 
            // StartTrade_BTN
            // 
            StartTrade_BTN.Location = new Point(6, 214);
            StartTrade_BTN.Name = "StartTrade_BTN";
            StartTrade_BTN.Size = new Size(156, 40);
            StartTrade_BTN.TabIndex = 20;
            StartTrade_BTN.Text = "开始交换";
            StartTrade_BTN.UseVisualStyleBackColor = true;
            StartTrade_BTN.Click += StartTrade_BTN_Click;
            // 
            // ReadList_BTN
            // 
            ReadList_BTN.Location = new Point(6, 24);
            ReadList_BTN.Name = "ReadList_BTN";
            ReadList_BTN.Size = new Size(156, 23);
            ReadList_BTN.TabIndex = 19;
            ReadList_BTN.Text = "读取已选宝可梦";
            ReadList_BTN.UseVisualStyleBackColor = true;
            ReadList_BTN.Click += ReadList_BTN_Click;
            // 
            // Clear_BTN
            // 
            Clear_BTN.Location = new Point(6, 54);
            Clear_BTN.Name = "Clear_BTN";
            Clear_BTN.Size = new Size(156, 23);
            Clear_BTN.TabIndex = 18;
            Clear_BTN.Text = "清空列表";
            Clear_BTN.UseVisualStyleBackColor = true;
            Clear_BTN.Click += Clear_BTN_Click;
            // 
            // MK_SemiAutoTradeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 495);
            Controls.Add(Trade_GroupBox);
            Controls.Add(PKM_CheckBox);
            Controls.Add(Basic_GroupBox);
            Controls.Add(Log_Box);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MK_SemiAutoTradeForm";
            Load += Form_Load;
            Basic_GroupBox.ResumeLayout(false);
            Basic_GroupBox.PerformLayout();
            Trade_GroupBox.ResumeLayout(false);
            Trade_GroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox InputSwitchIP;
        private Button Connect_BTN;
        private Button Stop_BTN;
        private Label Code_label;
        private TextBox Code_Text;
        private RichTextBox Log_Box;
        private Button CreateTrade_BTN;
        private GroupBox Basic_GroupBox;
        private CheckedListBox PKM_CheckBox;
        private Button EndTrade_BTN;
        private GroupBox Trade_GroupBox;
        private Button Clear_BTN;
        private Button ReadList_BTN;
        private Button StartTrade_BTN;
        private CheckBox ContinuousTrade_Check;
        private RichTextBox TradeInfo_Box;
        private CheckBox ID_CheckBox;
    }
}