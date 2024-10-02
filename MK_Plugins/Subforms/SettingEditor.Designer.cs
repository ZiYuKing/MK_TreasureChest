namespace MK_Plugins.Subforms
{
    partial class SettingEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingEditor));
            SavePath_Text = new Label();
            SavePath_TextBox = new TextBox();
            BrowsePath_BTN = new Button();
            grpSAV = new GroupBox();
            ResetKeys_BTN = new Button();
            EnableKeys_BTN = new Button();
            SaveKey_BTN = new Button();
            Key_X = new TextBox();
            Key_Y = new TextBox();
            Key_R = new TextBox();
            Key_L = new TextBox();
            Key_HOME = new TextBox();
            Key_DRIGHT = new TextBox();
            Key_DLEFT = new TextBox();
            Key_DDOWN = new TextBox();
            Key_CAPTURE = new TextBox();
            Key_DUP = new TextBox();
            Key_MINUS = new TextBox();
            Key_LSTICK = new TextBox();
            Key_PLUS = new TextBox();
            Key_RSTICK = new TextBox();
            Key_ZL = new TextBox();
            Key_ZR = new TextBox();
            Key_B = new TextBox();
            Key_A = new TextBox();
            KetText_HOME = new Label();
            KetText_CAPTURE = new Label();
            KetText_DRIGHT = new Label();
            KetText_DLEFT = new Label();
            KetText_DUP = new Label();
            KetText_DDOWN = new Label();
            KetText_PLUS = new Label();
            KetText_MINUS = new Label();
            KetText_ZR = new Label();
            KetText_ZL = new Label();
            KetText_R = new Label();
            KetText_LSTICK = new Label();
            KetText_L = new Label();
            KetText_RSTICK = new Label();
            KetText_Y = new Label();
            KetText_X = new Label();
            KetText_B = new Label();
            KetText_A = new Label();
            label1 = new Label();
            grpSAV.SuspendLayout();
            SuspendLayout();
            // 
            // SavePath_Text
            // 
            SavePath_Text.AutoSize = true;
            SavePath_Text.Location = new Point(12, 9);
            SavePath_Text.Margin = new Padding(4, 0, 4, 0);
            SavePath_Text.Name = "SavePath_Text";
            SavePath_Text.Size = new Size(83, 17);
            SavePath_Text.TabIndex = 81;
            SavePath_Text.Text = "截图保存路径:";
            // 
            // SavePath_TextBox
            // 
            SavePath_TextBox.Cursor = Cursors.IBeam;
            SavePath_TextBox.Location = new Point(102, 6);
            SavePath_TextBox.Name = "SavePath_TextBox";
            SavePath_TextBox.Size = new Size(267, 23);
            SavePath_TextBox.TabIndex = 82;
            // 
            // BrowsePath_BTN
            // 
            BrowsePath_BTN.Location = new Point(375, 3);
            BrowsePath_BTN.Name = "BrowsePath_BTN";
            BrowsePath_BTN.Size = new Size(71, 29);
            BrowsePath_BTN.TabIndex = 84;
            BrowsePath_BTN.Text = "浏览";
            BrowsePath_BTN.UseVisualStyleBackColor = true;
            BrowsePath_BTN.Click += BrowsePath_BTN_Click;
            // 
            // grpSAV
            // 
            grpSAV.Controls.Add(label1);
            grpSAV.Controls.Add(ResetKeys_BTN);
            grpSAV.Controls.Add(EnableKeys_BTN);
            grpSAV.Controls.Add(SaveKey_BTN);
            grpSAV.Controls.Add(Key_X);
            grpSAV.Controls.Add(Key_Y);
            grpSAV.Controls.Add(Key_R);
            grpSAV.Controls.Add(Key_L);
            grpSAV.Controls.Add(Key_HOME);
            grpSAV.Controls.Add(Key_DRIGHT);
            grpSAV.Controls.Add(Key_DLEFT);
            grpSAV.Controls.Add(Key_DDOWN);
            grpSAV.Controls.Add(Key_CAPTURE);
            grpSAV.Controls.Add(Key_DUP);
            grpSAV.Controls.Add(Key_MINUS);
            grpSAV.Controls.Add(Key_LSTICK);
            grpSAV.Controls.Add(Key_PLUS);
            grpSAV.Controls.Add(Key_RSTICK);
            grpSAV.Controls.Add(Key_ZL);
            grpSAV.Controls.Add(Key_ZR);
            grpSAV.Controls.Add(Key_B);
            grpSAV.Controls.Add(Key_A);
            grpSAV.Controls.Add(KetText_HOME);
            grpSAV.Controls.Add(KetText_CAPTURE);
            grpSAV.Controls.Add(KetText_DRIGHT);
            grpSAV.Controls.Add(KetText_DLEFT);
            grpSAV.Controls.Add(KetText_DUP);
            grpSAV.Controls.Add(KetText_DDOWN);
            grpSAV.Controls.Add(KetText_PLUS);
            grpSAV.Controls.Add(KetText_MINUS);
            grpSAV.Controls.Add(KetText_ZR);
            grpSAV.Controls.Add(KetText_ZL);
            grpSAV.Controls.Add(KetText_R);
            grpSAV.Controls.Add(KetText_LSTICK);
            grpSAV.Controls.Add(KetText_L);
            grpSAV.Controls.Add(KetText_RSTICK);
            grpSAV.Controls.Add(KetText_Y);
            grpSAV.Controls.Add(KetText_X);
            grpSAV.Controls.Add(KetText_B);
            grpSAV.Controls.Add(KetText_A);
            grpSAV.Location = new Point(12, 35);
            grpSAV.Name = "grpSAV";
            grpSAV.Size = new Size(434, 374);
            grpSAV.TabIndex = 85;
            grpSAV.TabStop = false;
            grpSAV.Text = "热键";
            // 
            // ResetKeys_BTN
            // 
            ResetKeys_BTN.Location = new Point(351, 22);
            ResetKeys_BTN.Name = "ResetKeys_BTN";
            ResetKeys_BTN.Size = new Size(71, 28);
            ResetKeys_BTN.TabIndex = 119;
            ResetKeys_BTN.Text = "重置";
            ResetKeys_BTN.UseVisualStyleBackColor = true;
            ResetKeys_BTN.Click += ResetKeys_BTN_Click;
            // 
            // EnableKeys_BTN
            // 
            EnableKeys_BTN.Location = new Point(9, 22);
            EnableKeys_BTN.Name = "EnableKeys_BTN";
            EnableKeys_BTN.Size = new Size(71, 28);
            EnableKeys_BTN.TabIndex = 118;
            EnableKeys_BTN.Text = "启用热键";
            EnableKeys_BTN.UseVisualStyleBackColor = true;
            EnableKeys_BTN.Click += EnableKeys_BTN_Click;
            // 
            // SaveKey_BTN
            // 
            SaveKey_BTN.Location = new Point(90, 22);
            SaveKey_BTN.Name = "SaveKey_BTN";
            SaveKey_BTN.Size = new Size(71, 28);
            SaveKey_BTN.TabIndex = 86;
            SaveKey_BTN.Text = "保存";
            SaveKey_BTN.UseVisualStyleBackColor = true;
            SaveKey_BTN.Click += SaveKey_BTN_Click;
            // 
            // Key_X
            // 
            Key_X.Cursor = Cursors.IBeam;
            Key_X.Location = new Point(82, 118);
            Key_X.Name = "Key_X";
            Key_X.ReadOnly = true;
            Key_X.Size = new Size(96, 23);
            Key_X.TabIndex = 117;
            Key_X.KeyDown += Key_X_KeyDown;
            // 
            // Key_Y
            // 
            Key_Y.Cursor = Cursors.IBeam;
            Key_Y.Location = new Point(82, 147);
            Key_Y.Name = "Key_Y";
            Key_Y.ReadOnly = true;
            Key_Y.Size = new Size(96, 23);
            Key_Y.TabIndex = 116;
            Key_Y.KeyDown += Key_Y_KeyDown;
            // 
            // Key_R
            // 
            Key_R.Cursor = Cursors.IBeam;
            Key_R.Location = new Point(82, 176);
            Key_R.Name = "Key_R";
            Key_R.ReadOnly = true;
            Key_R.Size = new Size(96, 23);
            Key_R.TabIndex = 115;
            Key_R.KeyDown += Key_R_KeyDown;
            // 
            // Key_L
            // 
            Key_L.Cursor = Cursors.IBeam;
            Key_L.Location = new Point(82, 204);
            Key_L.Name = "Key_L";
            Key_L.ReadOnly = true;
            Key_L.Size = new Size(96, 23);
            Key_L.TabIndex = 114;
            Key_L.KeyDown += Key_L_KeyDown;
            // 
            // Key_HOME
            // 
            Key_HOME.Cursor = Cursors.IBeam;
            Key_HOME.Location = new Point(82, 290);
            Key_HOME.Name = "Key_HOME";
            Key_HOME.ReadOnly = true;
            Key_HOME.Size = new Size(96, 23);
            Key_HOME.TabIndex = 113;
            Key_HOME.KeyDown += Key_HOME_KeyDown;
            // 
            // Key_DRIGHT
            // 
            Key_DRIGHT.Cursor = Cursors.IBeam;
            Key_DRIGHT.Location = new Point(326, 261);
            Key_DRIGHT.Name = "Key_DRIGHT";
            Key_DRIGHT.ReadOnly = true;
            Key_DRIGHT.Size = new Size(96, 23);
            Key_DRIGHT.TabIndex = 112;
            Key_DRIGHT.KeyDown += Key_DRIGHT_KeyDown;
            // 
            // Key_DLEFT
            // 
            Key_DLEFT.Cursor = Cursors.IBeam;
            Key_DLEFT.Location = new Point(326, 232);
            Key_DLEFT.Name = "Key_DLEFT";
            Key_DLEFT.ReadOnly = true;
            Key_DLEFT.Size = new Size(96, 23);
            Key_DLEFT.TabIndex = 111;
            Key_DLEFT.KeyDown += Key_DLEFT_KeyDown;
            // 
            // Key_DDOWN
            // 
            Key_DDOWN.Cursor = Cursors.IBeam;
            Key_DDOWN.Location = new Point(326, 204);
            Key_DDOWN.Name = "Key_DDOWN";
            Key_DDOWN.ReadOnly = true;
            Key_DDOWN.Size = new Size(96, 23);
            Key_DDOWN.TabIndex = 110;
            Key_DDOWN.KeyDown += Key_DDOWN_KeyDown;
            // 
            // Key_CAPTURE
            // 
            Key_CAPTURE.Cursor = Cursors.IBeam;
            Key_CAPTURE.Location = new Point(326, 290);
            Key_CAPTURE.Name = "Key_CAPTURE";
            Key_CAPTURE.ReadOnly = true;
            Key_CAPTURE.Size = new Size(96, 23);
            Key_CAPTURE.TabIndex = 109;
            Key_CAPTURE.KeyDown += Key_CAPTURE_KeyDown;
            // 
            // Key_DUP
            // 
            Key_DUP.Cursor = Cursors.IBeam;
            Key_DUP.Location = new Point(326, 176);
            Key_DUP.Name = "Key_DUP";
            Key_DUP.ReadOnly = true;
            Key_DUP.Size = new Size(96, 23);
            Key_DUP.TabIndex = 108;
            Key_DUP.KeyDown += Key_DUP_KeyDown;
            // 
            // Key_MINUS
            // 
            Key_MINUS.Cursor = Cursors.IBeam;
            Key_MINUS.Location = new Point(326, 147);
            Key_MINUS.Name = "Key_MINUS";
            Key_MINUS.ReadOnly = true;
            Key_MINUS.Size = new Size(96, 23);
            Key_MINUS.TabIndex = 107;
            Key_MINUS.KeyDown += Key_MINUS_KeyDown;
            // 
            // Key_LSTICK
            // 
            Key_LSTICK.Cursor = Cursors.IBeam;
            Key_LSTICK.Location = new Point(326, 89);
            Key_LSTICK.Name = "Key_LSTICK";
            Key_LSTICK.ReadOnly = true;
            Key_LSTICK.Size = new Size(96, 23);
            Key_LSTICK.TabIndex = 106;
            Key_LSTICK.KeyDown += Key_LSTICK_KeyDown;
            // 
            // Key_PLUS
            // 
            Key_PLUS.Cursor = Cursors.IBeam;
            Key_PLUS.Location = new Point(326, 118);
            Key_PLUS.Name = "Key_PLUS";
            Key_PLUS.ReadOnly = true;
            Key_PLUS.Size = new Size(96, 23);
            Key_PLUS.TabIndex = 105;
            Key_PLUS.KeyDown += Key_PLUS_KeyDown;
            // 
            // Key_RSTICK
            // 
            Key_RSTICK.Cursor = Cursors.IBeam;
            Key_RSTICK.Location = new Point(326, 60);
            Key_RSTICK.Name = "Key_RSTICK";
            Key_RSTICK.ReadOnly = true;
            Key_RSTICK.Size = new Size(96, 23);
            Key_RSTICK.TabIndex = 104;
            Key_RSTICK.KeyDown += Key_RSTICK_KeyDown;
            // 
            // Key_ZL
            // 
            Key_ZL.Cursor = Cursors.IBeam;
            Key_ZL.Location = new Point(82, 261);
            Key_ZL.Name = "Key_ZL";
            Key_ZL.ReadOnly = true;
            Key_ZL.Size = new Size(96, 23);
            Key_ZL.TabIndex = 103;
            Key_ZL.KeyDown += Key_ZL_KeyDown;
            // 
            // Key_ZR
            // 
            Key_ZR.Cursor = Cursors.IBeam;
            Key_ZR.Location = new Point(82, 232);
            Key_ZR.Name = "Key_ZR";
            Key_ZR.ReadOnly = true;
            Key_ZR.Size = new Size(96, 23);
            Key_ZR.TabIndex = 102;
            Key_ZR.KeyDown += Key_ZR_KeyDown;
            // 
            // Key_B
            // 
            Key_B.Cursor = Cursors.IBeam;
            Key_B.Location = new Point(82, 89);
            Key_B.Name = "Key_B";
            Key_B.ReadOnly = true;
            Key_B.Size = new Size(96, 23);
            Key_B.TabIndex = 101;
            Key_B.KeyDown += Key_B_KeyDown;
            // 
            // Key_A
            // 
            Key_A.Cursor = Cursors.IBeam;
            Key_A.Location = new Point(82, 60);
            Key_A.Name = "Key_A";
            Key_A.ReadOnly = true;
            Key_A.Size = new Size(96, 23);
            Key_A.TabIndex = 100;
            Key_A.KeyDown += Key_A_KeyDown;
            // 
            // KetText_HOME
            // 
            KetText_HOME.AutoSize = true;
            KetText_HOME.Location = new Point(10, 293);
            KetText_HOME.Margin = new Padding(4, 0, 4, 0);
            KetText_HOME.Name = "KetText_HOME";
            KetText_HOME.Size = new Size(53, 17);
            KetText_HOME.TabIndex = 99;
            KetText_HOME.Text = "HOME :";
            // 
            // KetText_CAPTURE
            // 
            KetText_CAPTURE.AutoSize = true;
            KetText_CAPTURE.Location = new Point(231, 293);
            KetText_CAPTURE.Margin = new Padding(4, 0, 4, 0);
            KetText_CAPTURE.Name = "KetText_CAPTURE";
            KetText_CAPTURE.Size = new Size(69, 17);
            KetText_CAPTURE.TabIndex = 98;
            KetText_CAPTURE.Text = "CAPTURE :";
            // 
            // KetText_DRIGHT
            // 
            KetText_DRIGHT.AutoSize = true;
            KetText_DRIGHT.Location = new Point(231, 264);
            KetText_DRIGHT.Margin = new Padding(4, 0, 4, 0);
            KetText_DRIGHT.Name = "KetText_DRIGHT";
            KetText_DRIGHT.Size = new Size(61, 17);
            KetText_DRIGHT.TabIndex = 97;
            KetText_DRIGHT.Text = "DRIGHT :";
            // 
            // KetText_DLEFT
            // 
            KetText_DLEFT.AutoSize = true;
            KetText_DLEFT.Location = new Point(231, 236);
            KetText_DLEFT.Margin = new Padding(4, 0, 4, 0);
            KetText_DLEFT.Name = "KetText_DLEFT";
            KetText_DLEFT.Size = new Size(50, 17);
            KetText_DLEFT.TabIndex = 96;
            KetText_DLEFT.Text = "DLEFT :";
            // 
            // KetText_DUP
            // 
            KetText_DUP.AutoSize = true;
            KetText_DUP.Location = new Point(231, 182);
            KetText_DUP.Margin = new Padding(4, 0, 4, 0);
            KetText_DUP.Name = "KetText_DUP";
            KetText_DUP.Size = new Size(40, 17);
            KetText_DUP.TabIndex = 95;
            KetText_DUP.Text = "DUP :";
            // 
            // KetText_DDOWN
            // 
            KetText_DDOWN.AutoSize = true;
            KetText_DDOWN.Location = new Point(231, 211);
            KetText_DDOWN.Margin = new Padding(4, 0, 4, 0);
            KetText_DDOWN.Name = "KetText_DDOWN";
            KetText_DDOWN.Size = new Size(65, 17);
            KetText_DDOWN.TabIndex = 94;
            KetText_DDOWN.Text = "DDOWN :";
            // 
            // KetText_PLUS
            // 
            KetText_PLUS.AutoSize = true;
            KetText_PLUS.Location = new Point(231, 121);
            KetText_PLUS.Margin = new Padding(4, 0, 4, 0);
            KetText_PLUS.Name = "KetText_PLUS";
            KetText_PLUS.Size = new Size(44, 17);
            KetText_PLUS.TabIndex = 93;
            KetText_PLUS.Text = "PLUS :";
            // 
            // KetText_MINUS
            // 
            KetText_MINUS.AutoSize = true;
            KetText_MINUS.Location = new Point(231, 150);
            KetText_MINUS.Margin = new Padding(4, 0, 4, 0);
            KetText_MINUS.Name = "KetText_MINUS";
            KetText_MINUS.Size = new Size(57, 17);
            KetText_MINUS.TabIndex = 92;
            KetText_MINUS.Text = "MINUS :";
            // 
            // KetText_ZR
            // 
            KetText_ZR.AutoSize = true;
            KetText_ZR.Location = new Point(10, 235);
            KetText_ZR.Margin = new Padding(4, 0, 4, 0);
            KetText_ZR.Name = "KetText_ZR";
            KetText_ZR.Size = new Size(30, 17);
            KetText_ZR.TabIndex = 91;
            KetText_ZR.Text = "ZR :";
            // 
            // KetText_ZL
            // 
            KetText_ZL.AutoSize = true;
            KetText_ZL.Location = new Point(10, 264);
            KetText_ZL.Margin = new Padding(4, 0, 4, 0);
            KetText_ZL.Name = "KetText_ZL";
            KetText_ZL.Size = new Size(28, 17);
            KetText_ZL.TabIndex = 90;
            KetText_ZL.Text = "ZL :";
            // 
            // KetText_R
            // 
            KetText_R.AutoSize = true;
            KetText_R.Location = new Point(10, 177);
            KetText_R.Margin = new Padding(4, 0, 4, 0);
            KetText_R.Name = "KetText_R";
            KetText_R.Size = new Size(23, 17);
            KetText_R.TabIndex = 89;
            KetText_R.Text = "R :";
            // 
            // KetText_LSTICK
            // 
            KetText_LSTICK.AutoSize = true;
            KetText_LSTICK.Location = new Point(231, 92);
            KetText_LSTICK.Margin = new Padding(4, 0, 4, 0);
            KetText_LSTICK.Name = "KetText_LSTICK";
            KetText_LSTICK.Size = new Size(55, 17);
            KetText_LSTICK.TabIndex = 88;
            KetText_LSTICK.Text = "LSTICK :";
            // 
            // KetText_L
            // 
            KetText_L.AutoSize = true;
            KetText_L.Location = new Point(10, 206);
            KetText_L.Margin = new Padding(4, 0, 4, 0);
            KetText_L.Name = "KetText_L";
            KetText_L.Size = new Size(21, 17);
            KetText_L.TabIndex = 87;
            KetText_L.Text = "L :";
            // 
            // KetText_RSTICK
            // 
            KetText_RSTICK.AutoSize = true;
            KetText_RSTICK.Location = new Point(231, 63);
            KetText_RSTICK.Margin = new Padding(4, 0, 4, 0);
            KetText_RSTICK.Name = "KetText_RSTICK";
            KetText_RSTICK.Size = new Size(57, 17);
            KetText_RSTICK.TabIndex = 86;
            KetText_RSTICK.Text = "RSTICK :";
            // 
            // KetText_Y
            // 
            KetText_Y.AutoSize = true;
            KetText_Y.Location = new Point(10, 150);
            KetText_Y.Margin = new Padding(4, 0, 4, 0);
            KetText_Y.Name = "KetText_Y";
            KetText_Y.Size = new Size(22, 17);
            KetText_Y.TabIndex = 85;
            KetText_Y.Text = "Y :";
            // 
            // KetText_X
            // 
            KetText_X.AutoSize = true;
            KetText_X.Location = new Point(9, 121);
            KetText_X.Margin = new Padding(4, 0, 4, 0);
            KetText_X.Name = "KetText_X";
            KetText_X.Size = new Size(23, 17);
            KetText_X.TabIndex = 84;
            KetText_X.Text = "X :";
            // 
            // KetText_B
            // 
            KetText_B.AutoSize = true;
            KetText_B.Location = new Point(9, 92);
            KetText_B.Margin = new Padding(4, 0, 4, 0);
            KetText_B.Name = "KetText_B";
            KetText_B.Size = new Size(23, 17);
            KetText_B.TabIndex = 83;
            KetText_B.Text = "B :";
            // 
            // KetText_A
            // 
            KetText_A.AutoSize = true;
            KetText_A.Location = new Point(10, 63);
            KetText_A.Margin = new Padding(4, 0, 4, 0);
            KetText_A.Name = "KetText_A";
            KetText_A.Size = new Size(23, 17);
            KetText_A.TabIndex = 82;
            KetText_A.Text = "A :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 336);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(392, 17);
            label1.TabIndex = 120;
            label1.Text = "注意：若出现按键已被使用，但上方并没有此按键，请保存后再修改！！";
            // 
            // SettingEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 421);
            Controls.Add(grpSAV);
            Controls.Add(BrowsePath_BTN);
            Controls.Add(SavePath_TextBox);
            Controls.Add(SavePath_Text);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "设置";
            Load += MainWindow_Load;
            grpSAV.ResumeLayout(false);
            grpSAV.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SavePath_Text;
        private TextBox SavePath_TextBox;
        private Button BrowsePath_BTN;
        private GroupBox grpSAV;
        private Label KetText_A;
        private Label KetText_HOME;
        private Label KetText_CAPTURE;
        private Label KetText_DRIGHT;
        private Label KetText_DLEFT;
        private Label KetText_DUP;
        private Label KetText_DDOWN;
        private Label KetText_PLUS;
        private Label KetText_MINUS;
        private Label KetText_ZR;
        private Label KetText_ZL;
        private Label KetText_R;
        private Label KetText_LSTICK;
        private Label KetText_L;
        private Label KetText_RSTICK;
        private Label KetText_Y;
        private Label KetText_X;
        private Label KetText_B;
        private TextBox Key_B;
        private TextBox Key_A;
        private TextBox Key_X;
        private TextBox Key_Y;
        private TextBox Key_R;
        private TextBox Key_L;
        private TextBox Key_HOME;
        private TextBox Key_DRIGHT;
        private TextBox Key_DLEFT;
        private TextBox Key_DDOWN;
        private TextBox Key_CAPTURE;
        private TextBox Key_DUP;
        private TextBox Key_MINUS;
        private TextBox Key_LSTICK;
        private TextBox Key_PLUS;
        private TextBox Key_RSTICK;
        private TextBox Key_ZL;
        private TextBox Key_ZR;
        private Button SaveKey_BTN;
        private Button EnableKeys_BTN;
        private Button ResetKeys_BTN;
        private Label label1;
    }
}