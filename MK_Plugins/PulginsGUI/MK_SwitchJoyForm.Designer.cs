using System.Windows.Forms;
using MK_Plugins.Properties;

namespace MK_Plugins.PulginsGUI
{
    partial class MK_SwitchControllerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MK_SwitchControllerForm));
            ButtonConnect = new Button();
            InputSwitchIP = new TextBox();
            ButtonStop = new Button();
            OperatingInterface = new Panel();
            pictureBox4 = new PictureBox();
            L_BTN = new Button();
            R_BTN = new Button();
            pictureBox3 = new PictureBox();
            ZR_BTN = new Button();
            pictureBox2 = new PictureBox();
            MINUS_BTN = new Button();
            PLUS_BTN = new Button();
            pictureBox1 = new PictureBox();
            ChangeSkin_BTN = new Button();
            LSTICK_BTN = new Button();
            RSTICK_BTN = new Button();
            DUP_BTN = new Button();
            DDOWN_BTN = new Button();
            DLEFT_BTN = new Button();
            B_BTN = new Button();
            X_BTN = new Button();
            A_BTN = new Button();
            DRIGHT_BTN = new Button();
            Y_BTN = new Button();
            CAPTURE_BTN = new Button();
            HOME_BTN = new Button();
            ZL_BTN = new Button();
            ShowScreen_BTN = new Button();
            SwitchPicture = new PictureBox();
            pictureBox5 = new PictureBox();
            menuStrip1 = new MenuStrip();
            Menu_Client = new ToolStripMenuItem();
            Menu_Settings = new ToolStripMenuItem();
            SaveImage_Item = new ToolStripMenuItem();
            label6 = new Label();
            InputSwitchPort = new TextBox();
            OperatingInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SwitchPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonConnect
            // 
            ButtonConnect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonConnect.Location = new Point(142, 631);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(72, 29);
            ButtonConnect.TabIndex = 0;
            ButtonConnect.Text = "连接";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // InputSwitchIP
            // 
            InputSwitchIP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputSwitchIP.ImeMode = ImeMode.NoControl;
            InputSwitchIP.Location = new Point(161, 28);
            InputSwitchIP.Name = "InputSwitchIP";
            InputSwitchIP.RightToLeft = RightToLeft.No;
            InputSwitchIP.Size = new Size(147, 23);
            InputSwitchIP.TabIndex = 1;
            InputSwitchIP.TabStop = false;
            InputSwitchIP.Text = "192.168.0.0";
            InputSwitchIP.TextAlign = HorizontalAlignment.Center;
            InputSwitchIP.TextChanged += InputSwitchIP_TextChanged;
            // 
            // ButtonStop
            // 
            ButtonStop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonStop.Enabled = false;
            ButtonStop.Location = new Point(349, 631);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(72, 29);
            ButtonStop.TabIndex = 2;
            ButtonStop.Text = "断开";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // OperatingInterface
            // 
            OperatingInterface.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OperatingInterface.BackgroundImage = Resource.R_C_0;
            OperatingInterface.BackgroundImageLayout = ImageLayout.Center;
            OperatingInterface.Controls.Add(pictureBox4);
            OperatingInterface.Controls.Add(L_BTN);
            OperatingInterface.Controls.Add(R_BTN);
            OperatingInterface.Controls.Add(pictureBox3);
            OperatingInterface.Controls.Add(ZR_BTN);
            OperatingInterface.Controls.Add(pictureBox2);
            OperatingInterface.Controls.Add(MINUS_BTN);
            OperatingInterface.Controls.Add(PLUS_BTN);
            OperatingInterface.Controls.Add(pictureBox1);
            OperatingInterface.Controls.Add(ChangeSkin_BTN);
            OperatingInterface.Controls.Add(LSTICK_BTN);
            OperatingInterface.Controls.Add(RSTICK_BTN);
            OperatingInterface.Controls.Add(DUP_BTN);
            OperatingInterface.Controls.Add(DDOWN_BTN);
            OperatingInterface.Controls.Add(DLEFT_BTN);
            OperatingInterface.Controls.Add(B_BTN);
            OperatingInterface.Controls.Add(X_BTN);
            OperatingInterface.Controls.Add(A_BTN);
            OperatingInterface.Controls.Add(DRIGHT_BTN);
            OperatingInterface.Controls.Add(Y_BTN);
            OperatingInterface.Controls.Add(CAPTURE_BTN);
            OperatingInterface.Controls.Add(HOME_BTN);
            OperatingInterface.Controls.Add(ZL_BTN);
            OperatingInterface.Location = new Point(10, 324);
            OperatingInterface.Name = "OperatingInterface";
            OperatingInterface.Size = new Size(553, 301);
            OperatingInterface.TabIndex = 3;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImageLayout = ImageLayout.None;
            pictureBox4.Image = Resource.gray;
            pictureBox4.Location = new Point(277, 117);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(8, 8);
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            // 
            // L_BTN
            // 
            L_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            L_BTN.BackColor = Color.Transparent;
            L_BTN.BackgroundImageLayout = ImageLayout.Center;
            L_BTN.Cursor = Cursors.Hand;
            L_BTN.FlatAppearance.BorderSize = 0;
            L_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            L_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            L_BTN.FlatStyle = FlatStyle.Flat;
            L_BTN.ForeColor = Color.Transparent;
            L_BTN.Location = new Point(120, 24);
            L_BTN.Name = "L_BTN";
            L_BTN.Size = new Size(92, 30);
            L_BTN.TabIndex = 10;
            L_BTN.UseVisualStyleBackColor = false;
            L_BTN.Click += L_BTN_Click;
            // 
            // R_BTN
            // 
            R_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            R_BTN.BackColor = Color.Transparent;
            R_BTN.BackgroundImageLayout = ImageLayout.Center;
            R_BTN.Cursor = Cursors.Hand;
            R_BTN.FlatAppearance.BorderSize = 0;
            R_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            R_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            R_BTN.FlatStyle = FlatStyle.Flat;
            R_BTN.ForeColor = Color.Transparent;
            R_BTN.Location = new Point(338, 24);
            R_BTN.Name = "R_BTN";
            R_BTN.Size = new Size(92, 30);
            R_BTN.TabIndex = 11;
            R_BTN.UseVisualStyleBackColor = false;
            R_BTN.Click += R_BTN_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Resource.gray;
            pictureBox3.Location = new Point(287, 117);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(8, 8);
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // ZR_BTN
            // 
            ZR_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ZR_BTN.BackColor = Color.Transparent;
            ZR_BTN.BackgroundImageLayout = ImageLayout.Center;
            ZR_BTN.Cursor = Cursors.Hand;
            ZR_BTN.FlatAppearance.BorderSize = 0;
            ZR_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ZR_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ZR_BTN.FlatStyle = FlatStyle.Flat;
            ZR_BTN.ForeColor = Color.Transparent;
            ZR_BTN.Location = new Point(11, 24);
            ZR_BTN.Name = "ZR_BTN";
            ZR_BTN.Size = new Size(92, 30);
            ZR_BTN.TabIndex = 12;
            ZR_BTN.UseVisualStyleBackColor = false;
            ZR_BTN.Click += ZR_BTN_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = Resource.gray;
            pictureBox2.Location = new Point(267, 117);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(8, 8);
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // MINUS_BTN
            // 
            MINUS_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MINUS_BTN.BackColor = Color.Transparent;
            MINUS_BTN.BackgroundImageLayout = ImageLayout.Center;
            MINUS_BTN.Cursor = Cursors.Hand;
            MINUS_BTN.FlatAppearance.BorderSize = 0;
            MINUS_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            MINUS_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            MINUS_BTN.FlatStyle = FlatStyle.Flat;
            MINUS_BTN.ForeColor = Color.Transparent;
            MINUS_BTN.Location = new Point(190, 75);
            MINUS_BTN.Name = "MINUS_BTN";
            MINUS_BTN.Size = new Size(25, 29);
            MINUS_BTN.TabIndex = 5;
            MINUS_BTN.UseVisualStyleBackColor = false;
            MINUS_BTN.Click += MINUS_BTN_Click;
            // 
            // PLUS_BTN
            // 
            PLUS_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PLUS_BTN.BackColor = Color.Transparent;
            PLUS_BTN.BackgroundImageLayout = ImageLayout.Center;
            PLUS_BTN.Cursor = Cursors.Hand;
            PLUS_BTN.FlatAppearance.BorderSize = 0;
            PLUS_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            PLUS_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PLUS_BTN.FlatStyle = FlatStyle.Flat;
            PLUS_BTN.ForeColor = Color.Transparent;
            PLUS_BTN.Location = new Point(336, 75);
            PLUS_BTN.Name = "PLUS_BTN";
            PLUS_BTN.Size = new Size(25, 29);
            PLUS_BTN.TabIndex = 4;
            PLUS_BTN.UseVisualStyleBackColor = false;
            PLUS_BTN.Click += PLUS_BTN_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Resource.gray;
            pictureBox1.Location = new Point(256, 117);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(8, 8);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // ChangeSkin_BTN
            // 
            ChangeSkin_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChangeSkin_BTN.BackColor = Color.Transparent;
            ChangeSkin_BTN.BackgroundImageLayout = ImageLayout.Center;
            ChangeSkin_BTN.Cursor = Cursors.Hand;
            ChangeSkin_BTN.FlatAppearance.BorderSize = 0;
            ChangeSkin_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ChangeSkin_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ChangeSkin_BTN.FlatStyle = FlatStyle.Flat;
            ChangeSkin_BTN.ForeColor = Color.Transparent;
            ChangeSkin_BTN.Location = new Point(263, 75);
            ChangeSkin_BTN.Name = "ChangeSkin_BTN";
            ChangeSkin_BTN.Size = new Size(25, 29);
            ChangeSkin_BTN.TabIndex = 8;
            ChangeSkin_BTN.UseVisualStyleBackColor = false;
            ChangeSkin_BTN.Click += ChangeSkin_BTN_Click;
            // 
            // LSTICK_BTN
            // 
            LSTICK_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LSTICK_BTN.BackColor = Color.Transparent;
            LSTICK_BTN.BackgroundImageLayout = ImageLayout.Center;
            LSTICK_BTN.Cursor = Cursors.Hand;
            LSTICK_BTN.FlatAppearance.BorderSize = 0;
            LSTICK_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LSTICK_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LSTICK_BTN.FlatStyle = FlatStyle.Flat;
            LSTICK_BTN.ForeColor = Color.Transparent;
            LSTICK_BTN.Location = new Point(52, 84);
            LSTICK_BTN.Name = "LSTICK_BTN";
            LSTICK_BTN.Size = new Size(64, 68);
            LSTICK_BTN.TabIndex = 17;
            LSTICK_BTN.UseVisualStyleBackColor = false;
            LSTICK_BTN.Click += LSTICK_BTN_Click;
            // 
            // RSTICK_BTN
            // 
            RSTICK_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RSTICK_BTN.BackColor = Color.Transparent;
            RSTICK_BTN.BackgroundImageLayout = ImageLayout.Center;
            RSTICK_BTN.Cursor = Cursors.Hand;
            RSTICK_BTN.FlatAppearance.BorderSize = 0;
            RSTICK_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            RSTICK_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RSTICK_BTN.FlatStyle = FlatStyle.Flat;
            RSTICK_BTN.ForeColor = Color.Transparent;
            RSTICK_BTN.Location = new Point(378, 187);
            RSTICK_BTN.Name = "RSTICK_BTN";
            RSTICK_BTN.Size = new Size(64, 68);
            RSTICK_BTN.TabIndex = 18;
            RSTICK_BTN.UseVisualStyleBackColor = false;
            RSTICK_BTN.Click += RSTICK_BTN_Click;
            // 
            // DUP_BTN
            // 
            DUP_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DUP_BTN.BackColor = Color.Transparent;
            DUP_BTN.BackgroundImageLayout = ImageLayout.Center;
            DUP_BTN.Cursor = Cursors.Hand;
            DUP_BTN.FlatAppearance.BorderSize = 0;
            DUP_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DUP_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DUP_BTN.FlatStyle = FlatStyle.Flat;
            DUP_BTN.ForeColor = Color.Transparent;
            DUP_BTN.Location = new Point(123, 153);
            DUP_BTN.Name = "DUP_BTN";
            DUP_BTN.Size = new Size(18, 36);
            DUP_BTN.TabIndex = 15;
            DUP_BTN.UseVisualStyleBackColor = false;
            DUP_BTN.Click += DUP_BTN_Click;
            // 
            // DDOWN_BTN
            // 
            DDOWN_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DDOWN_BTN.BackColor = Color.Transparent;
            DDOWN_BTN.BackgroundImageLayout = ImageLayout.Center;
            DDOWN_BTN.Cursor = Cursors.Hand;
            DDOWN_BTN.FlatAppearance.BorderSize = 0;
            DDOWN_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DDOWN_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DDOWN_BTN.FlatStyle = FlatStyle.Flat;
            DDOWN_BTN.ForeColor = Color.Transparent;
            DDOWN_BTN.Location = new Point(123, 232);
            DDOWN_BTN.Name = "DDOWN_BTN";
            DDOWN_BTN.Size = new Size(18, 36);
            DDOWN_BTN.TabIndex = 16;
            DDOWN_BTN.UseVisualStyleBackColor = false;
            DDOWN_BTN.Click += DDOWN_BTN_Click;
            // 
            // DLEFT_BTN
            // 
            DLEFT_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DLEFT_BTN.BackColor = Color.Transparent;
            DLEFT_BTN.BackgroundImageLayout = ImageLayout.Center;
            DLEFT_BTN.Cursor = Cursors.Hand;
            DLEFT_BTN.FlatAppearance.BorderSize = 0;
            DLEFT_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DLEFT_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DLEFT_BTN.FlatStyle = FlatStyle.Flat;
            DLEFT_BTN.ForeColor = Color.Transparent;
            DLEFT_BTN.Location = new Point(77, 200);
            DLEFT_BTN.Name = "DLEFT_BTN";
            DLEFT_BTN.Size = new Size(32, 22);
            DLEFT_BTN.TabIndex = 14;
            DLEFT_BTN.UseVisualStyleBackColor = false;
            DLEFT_BTN.Click += DLEFT_BTN_Click;
            // 
            // B_BTN
            // 
            B_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            B_BTN.BackColor = Color.Transparent;
            B_BTN.BackgroundImageLayout = ImageLayout.Center;
            B_BTN.Cursor = Cursors.Hand;
            B_BTN.FlatAppearance.BorderSize = 0;
            B_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            B_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            B_BTN.FlatStyle = FlatStyle.Flat;
            B_BTN.ForeColor = Color.Transparent;
            B_BTN.Location = new Point(463, 165);
            B_BTN.Name = "B_BTN";
            B_BTN.Size = new Size(25, 29);
            B_BTN.TabIndex = 2;
            B_BTN.UseVisualStyleBackColor = false;
            B_BTN.Click += B_BTN_Click;
            // 
            // X_BTN
            // 
            X_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            X_BTN.BackColor = Color.Transparent;
            X_BTN.BackgroundImageLayout = ImageLayout.Center;
            X_BTN.Cursor = Cursors.Hand;
            X_BTN.FlatAppearance.BorderSize = 0;
            X_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            X_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            X_BTN.FlatStyle = FlatStyle.Flat;
            X_BTN.ForeColor = Color.Transparent;
            X_BTN.Location = new Point(463, 74);
            X_BTN.Name = "X_BTN";
            X_BTN.Size = new Size(25, 29);
            X_BTN.TabIndex = 0;
            X_BTN.UseVisualStyleBackColor = false;
            X_BTN.Click += X_BTN_Click;
            // 
            // A_BTN
            // 
            A_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            A_BTN.BackColor = Color.Transparent;
            A_BTN.BackgroundImageLayout = ImageLayout.Center;
            A_BTN.Cursor = Cursors.Hand;
            A_BTN.FlatAppearance.BorderSize = 0;
            A_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            A_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            A_BTN.FlatStyle = FlatStyle.Flat;
            A_BTN.ForeColor = Color.Transparent;
            A_BTN.Location = new Point(502, 120);
            A_BTN.Name = "A_BTN";
            A_BTN.Size = new Size(25, 29);
            A_BTN.TabIndex = 3;
            A_BTN.UseVisualStyleBackColor = false;
            A_BTN.Click += A_BTN_Click;
            // 
            // DRIGHT_BTN
            // 
            DRIGHT_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DRIGHT_BTN.BackColor = Color.Transparent;
            DRIGHT_BTN.BackgroundImageLayout = ImageLayout.Center;
            DRIGHT_BTN.Cursor = Cursors.Hand;
            DRIGHT_BTN.FlatAppearance.BorderSize = 0;
            DRIGHT_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DRIGHT_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DRIGHT_BTN.FlatStyle = FlatStyle.Flat;
            DRIGHT_BTN.ForeColor = Color.Transparent;
            DRIGHT_BTN.Location = new Point(154, 200);
            DRIGHT_BTN.Name = "DRIGHT_BTN";
            DRIGHT_BTN.Size = new Size(32, 22);
            DRIGHT_BTN.TabIndex = 13;
            DRIGHT_BTN.UseVisualStyleBackColor = false;
            DRIGHT_BTN.Click += DRIGHT_BTN_Click;
            // 
            // Y_BTN
            // 
            Y_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Y_BTN.BackColor = Color.Transparent;
            Y_BTN.BackgroundImageLayout = ImageLayout.Center;
            Y_BTN.Cursor = Cursors.Hand;
            Y_BTN.FlatAppearance.BorderSize = 0;
            Y_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Y_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Y_BTN.FlatStyle = FlatStyle.Flat;
            Y_BTN.ForeColor = Color.Transparent;
            Y_BTN.Location = new Point(418, 120);
            Y_BTN.Name = "Y_BTN";
            Y_BTN.Size = new Size(25, 29);
            Y_BTN.TabIndex = 1;
            Y_BTN.UseVisualStyleBackColor = false;
            Y_BTN.Click += Y_BTN_Click;
            // 
            // CAPTURE_BTN
            // 
            CAPTURE_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CAPTURE_BTN.BackColor = Color.Transparent;
            CAPTURE_BTN.BackgroundImageLayout = ImageLayout.Center;
            CAPTURE_BTN.Cursor = Cursors.Hand;
            CAPTURE_BTN.FlatAppearance.BorderSize = 0;
            CAPTURE_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            CAPTURE_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            CAPTURE_BTN.FlatStyle = FlatStyle.Flat;
            CAPTURE_BTN.ForeColor = Color.Transparent;
            CAPTURE_BTN.Location = new Point(235, 144);
            CAPTURE_BTN.Name = "CAPTURE_BTN";
            CAPTURE_BTN.Size = new Size(20, 23);
            CAPTURE_BTN.TabIndex = 6;
            CAPTURE_BTN.UseVisualStyleBackColor = false;
            CAPTURE_BTN.MouseDown += CAPTURE_BTN_MouseDown;
            CAPTURE_BTN.MouseUp += CAPTURE_BTN_MouseUp;
            // 
            // HOME_BTN
            // 
            HOME_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HOME_BTN.BackColor = Color.Transparent;
            HOME_BTN.BackgroundImageLayout = ImageLayout.Center;
            HOME_BTN.Cursor = Cursors.Hand;
            HOME_BTN.FlatAppearance.BorderSize = 0;
            HOME_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HOME_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HOME_BTN.FlatStyle = FlatStyle.Flat;
            HOME_BTN.ForeColor = Color.Transparent;
            HOME_BTN.Location = new Point(298, 144);
            HOME_BTN.Name = "HOME_BTN";
            HOME_BTN.Size = new Size(20, 23);
            HOME_BTN.TabIndex = 7;
            HOME_BTN.UseVisualStyleBackColor = false;
            HOME_BTN.MouseDown += HOME_BTN_MouseDown;
            HOME_BTN.MouseUp += HOME_BTN_MouseUp;
            // 
            // ZL_BTN
            // 
            ZL_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ZL_BTN.BackColor = Color.Transparent;
            ZL_BTN.BackgroundImageLayout = ImageLayout.Center;
            ZL_BTN.Cursor = Cursors.Hand;
            ZL_BTN.FlatAppearance.BorderSize = 0;
            ZL_BTN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ZL_BTN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ZL_BTN.FlatStyle = FlatStyle.Flat;
            ZL_BTN.ForeColor = Color.Transparent;
            ZL_BTN.Location = new Point(447, 24);
            ZL_BTN.Name = "ZL_BTN";
            ZL_BTN.Size = new Size(92, 30);
            ZL_BTN.TabIndex = 9;
            ZL_BTN.UseVisualStyleBackColor = false;
            ZL_BTN.MouseDown += ZL_BTN_MouseDown;
            ZL_BTN.MouseUp += ZL_BTN_MouseUp;
            // 
            // ShowScreen_BTN
            // 
            ShowScreen_BTN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ShowScreen_BTN.Enabled = false;
            ShowScreen_BTN.Location = new Point(239, 631);
            ShowScreen_BTN.Name = "ShowScreen_BTN";
            ShowScreen_BTN.Size = new Size(84, 29);
            ShowScreen_BTN.TabIndex = 4;
            ShowScreen_BTN.Text = "刷新画面";
            ShowScreen_BTN.UseVisualStyleBackColor = true;
            ShowScreen_BTN.Click += ShowScreen_BTN_Click;
            // 
            // SwitchPicture
            // 
            SwitchPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SwitchPicture.BackColor = Color.Transparent;
            SwitchPicture.BackgroundImageLayout = ImageLayout.None;
            SwitchPicture.Image = Resource.SwitchKing;
            SwitchPicture.Location = new Point(113, 89);
            SwitchPicture.Name = "SwitchPicture";
            SwitchPicture.Size = new Size(355, 201);
            SwitchPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            SwitchPicture.TabIndex = 20;
            SwitchPicture.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = Resource.Switch_1;
            pictureBox5.BackgroundImageLayout = ImageLayout.Center;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Location = new Point(10, 59);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(553, 259);
            pictureBox5.TabIndex = 21;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.AccessibleDescription = "Main Window Menustrip";
            menuStrip1.AccessibleName = "Main Window Menustrip";
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu_Client });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(571, 25);
            menuStrip1.TabIndex = 22;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Client
            // 
            Menu_Client.DropDownItems.AddRange(new ToolStripItem[] { Menu_Settings, SaveImage_Item });
            Menu_Client.Name = "Menu_Client";
            Menu_Client.Size = new Size(68, 21);
            Menu_Client.Text = "更多选项";
            // 
            // Menu_Settings
            // 
            Menu_Settings.Name = "Menu_Settings";
            Menu_Settings.ShortcutKeys = Keys.Control | Keys.O;
            Menu_Settings.ShowShortcutKeys = false;
            Menu_Settings.Size = new Size(124, 22);
            Menu_Settings.Text = "&设置";
            Menu_Settings.Click += Menu_Settings_Click;
            // 
            // SaveImage_Item
            // 
            SaveImage_Item.Name = "SaveImage_Item";
            SaveImage_Item.Size = new Size(124, 22);
            SaveImage_Item.Text = "保存截图";
            SaveImage_Item.Click += SaveImage_Item_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(312, 31);
            label6.Name = "label6";
            label6.Size = new Size(11, 17);
            label6.TabIndex = 23;
            label6.Text = ":";
            // 
            // InputSwitchPort
            // 
            InputSwitchPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputSwitchPort.ImeMode = ImeMode.NoControl;
            InputSwitchPort.Location = new Point(329, 28);
            InputSwitchPort.Name = "InputSwitchPort";
            InputSwitchPort.RightToLeft = RightToLeft.No;
            InputSwitchPort.Size = new Size(69, 23);
            InputSwitchPort.TabIndex = 25;
            InputSwitchPort.TabStop = false;
            InputSwitchPort.Text = "6000";
            InputSwitchPort.TextAlign = HorizontalAlignment.Center;
            InputSwitchPort.TextChanged += InputSwitchPort_TextChanged;
            // 
            // MK_SwitchControllerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 670);
            Controls.Add(InputSwitchPort);
            Controls.Add(label6);
            Controls.Add(SwitchPicture);
            Controls.Add(menuStrip1);
            Controls.Add(ShowScreen_BTN);
            Controls.Add(ButtonStop);
            Controls.Add(InputSwitchIP);
            Controls.Add(ButtonConnect);
            Controls.Add(pictureBox5);
            Controls.Add(OperatingInterface);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MK_SwitchControllerForm";
            Load += MainWindow_Load;
            StyleChanged += MK_SwitchControllerForm_StyleChanged;
            OperatingInterface.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SwitchPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonConnect;
        private TextBox InputSwitchIP;
        private Button ButtonStop;
        private Panel OperatingInterface;
        private Button X_BTN;
        private Button Y_BTN;
        private Button B_BTN;
        private Button A_BTN;
        private Button HOME_BTN;
        private Button CAPTURE_BTN;
        private Button MINUS_BTN;
        private Button PLUS_BTN;
        private Button DUP_BTN;
        private Button DLEFT_BTN;
        private Button DRIGHT_BTN;
        private Button ZR_BTN;
        private Button R_BTN;
        private Button L_BTN;
        private Button ZL_BTN;
        private Button ChangeSkin_BTN;
        private Button RSTICK_BTN;
        private Button LSTICK_BTN;
        private Button DDOWN_BTN;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button ShowScreen_BTN;
        private PictureBox SwitchPicture;
        private PictureBox pictureBox5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu_Client;
        private ToolStripMenuItem Menu_Settings;
        private ToolStripMenuItem SaveImage_Item;
        private Label label6;
        private TextBox InputSwitchPort;
    }
}