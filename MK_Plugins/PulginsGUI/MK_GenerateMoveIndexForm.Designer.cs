namespace MK_Plugins.PulginsGUI
{
    partial class MK_GenerateMoveIndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MK_GenerateMoveIndexForm));
            MoveIndex_Box = new RichTextBox();
            Generate_Button = new Button();
            menuStrip = new MenuStrip();
            OtherMode_MenuItem = new ToolStripMenuItem();
            pkInfoToolStripMenuItem = new ToolStripMenuItem();
            OtherMode_TSMI = new ToolStripMenuItem();
            Copy_Button = new Button();
            _Label = new Label();
            avatarPath_TextBox = new TextBox();
            BrowsePath_Button = new Button();
            OtherMode_comboBox = new ComboBox();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MoveIndex_Box
            // 
            MoveIndex_Box.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MoveIndex_Box.Location = new Point(12, 69);
            MoveIndex_Box.Name = "MoveIndex_Box";
            MoveIndex_Box.ReadOnly = true;
            MoveIndex_Box.Size = new Size(697, 279);
            MoveIndex_Box.TabIndex = 0;
            MoveIndex_Box.Text = "";
            // 
            // Generate_Button
            // 
            Generate_Button.Location = new Point(43, 354);
            Generate_Button.Name = "Generate_Button";
            Generate_Button.Size = new Size(300, 31);
            Generate_Button.TabIndex = 1;
            Generate_Button.Text = "生成";
            Generate_Button.UseVisualStyleBackColor = true;
            Generate_Button.Click += Generate_Button_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Azure;
            menuStrip.Items.AddRange(new ToolStripItem[] { OtherMode_MenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(721, 28);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            // 
            // OtherMode_MenuItem
            // 
            OtherMode_MenuItem.DropDownItems.AddRange(new ToolStripItem[] { pkInfoToolStripMenuItem, OtherMode_TSMI });
            OtherMode_MenuItem.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            OtherMode_MenuItem.Name = "OtherMode_MenuItem";
            OtherMode_MenuItem.Size = new Size(49, 24);
            OtherMode_MenuItem.Text = "更多";
            // 
            // pkInfoToolStripMenuItem
            // 
            pkInfoToolStripMenuItem.Name = "pkInfoToolStripMenuItem";
            pkInfoToolStripMenuItem.Size = new Size(148, 24);
            pkInfoToolStripMenuItem.Text = "宝可梦字典";
            pkInfoToolStripMenuItem.Visible = false;
            pkInfoToolStripMenuItem.Click += pkInfoToolStripMenuItem_Click;
            // 
            // OtherMode_TSMI
            // 
            OtherMode_TSMI.Name = "OtherMode_TSMI";
            OtherMode_TSMI.Size = new Size(148, 24);
            OtherMode_TSMI.Text = "其他模式";
            OtherMode_TSMI.Click += OtherMode_TSMI_Click;
            // 
            // Copy_Button
            // 
            Copy_Button.Location = new Point(366, 354);
            Copy_Button.Name = "Copy_Button";
            Copy_Button.Size = new Size(296, 31);
            Copy_Button.TabIndex = 3;
            Copy_Button.Text = "复制";
            Copy_Button.UseVisualStyleBackColor = true;
            Copy_Button.Click += Copy_Button_Click;
            // 
            // _Label
            // 
            _Label.AutoSize = true;
            _Label.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            _Label.Location = new Point(12, 40);
            _Label.Name = "_Label";
            _Label.Size = new Size(82, 20);
            _Label.TabIndex = 4;
            _Label.Text = "头像文件夹:";
            // 
            // avatarPath_TextBox
            // 
            avatarPath_TextBox.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            avatarPath_TextBox.Location = new Point(100, 37);
            avatarPath_TextBox.Name = "avatarPath_TextBox";
            avatarPath_TextBox.Size = new Size(517, 25);
            avatarPath_TextBox.TabIndex = 5;
            // 
            // BrowsePath_Button
            // 
            BrowsePath_Button.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            BrowsePath_Button.Location = new Point(623, 35);
            BrowsePath_Button.Name = "BrowsePath_Button";
            BrowsePath_Button.Size = new Size(86, 29);
            BrowsePath_Button.TabIndex = 6;
            BrowsePath_Button.Text = "浏览";
            BrowsePath_Button.UseVisualStyleBackColor = true;
            BrowsePath_Button.Click += BrowsePath_Button_Click;
            // 
            // OtherMode_comboBox
            // 
            OtherMode_comboBox.FormattingEnabled = true;
            OtherMode_comboBox.Items.AddRange(new object[] { "道具字典", "特性字典", "技能字典" });
            OtherMode_comboBox.Location = new Point(100, 37);
            OtherMode_comboBox.Name = "OtherMode_comboBox";
            OtherMode_comboBox.Size = new Size(599, 25);
            OtherMode_comboBox.TabIndex = 7;
            OtherMode_comboBox.Visible = false;
            // 
            // MK_GenerateMoveIndexForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(721, 397);
            Controls.Add(OtherMode_comboBox);
            Controls.Add(BrowsePath_Button);
            Controls.Add(avatarPath_TextBox);
            Controls.Add(_Label);
            Controls.Add(Copy_Button);
            Controls.Add(Generate_Button);
            Controls.Add(MoveIndex_Box);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "MK_GenerateMoveIndexForm";
            Text = "PS网页字典生成器";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox MoveIndex_Box;
        private Button Generate_Button;
        private MenuStrip menuStrip;
        private ToolStripMenuItem OtherMode_MenuItem;
        private Button Copy_Button;
        private ToolStripMenuItem pkInfoToolStripMenuItem;
        private ToolStripMenuItem itemInfoToolStripMenuItem;
        private ToolStripMenuItem ablilitieInfoToolStripMenuItem;
        private ToolStripMenuItem OtherMode_TSMI;
        private Label _Label;
        private TextBox avatarPath_TextBox;
        private Button BrowsePath_Button;
        private ComboBox OtherMode_comboBox;
    }
}