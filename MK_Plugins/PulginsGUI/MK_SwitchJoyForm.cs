using SysBot.Base;
using MK_Plugins.Properties;
using System.Net.Sockets;
using MK_Plugins.Structures;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using PKHeX.Core;
using MK_Plugins.Subforms;
using static SysBot.Base.SwitchButton;
using System.Windows.Forms;

namespace MK_Plugins.PulginsGUI
{
    public partial class MK_SwitchControllerForm : Form
    {
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = Settings.Default.SwitchPort };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);
        private static SwitchSocketAsync? CON { get; set; }
        private static CancellationTokenSource? SOUR { get; set; }
        private CancellationTokenSource Source = new();
        private bool isDragging = false;
        private Point startPosition;
        public MK_SwitchControllerForm()
        {
            Text = "Switch | 未连接！！";
            ClientSize = new Size(587, 709);
            MaximizeBox = false; // 禁用最大化按钮
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            // 处理 WM_SIZE 消息
            if (m.Msg == 0x0051)
            {
                // 禁止调整窗口大小
                m.Result = (IntPtr)0x1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            InputSwitchIP.Text = Settings.Default.SwitchIP;
            InputSwitchPort.Text = Settings.Default.SwitchPort.ToString();
            pictureBox5.BackgroundImage = Resource.Switch_0;
            SwitchPicture.Image = Resource.SwitchKing;
            OperatingInterface.BackgroundImage = Settings.Default.Skin switch
            {
                0 => Resource.R_C_0,
                1 => Resource.R_C_1,
                2 => Resource.R_C_2,
                3 => Resource.R_C_3,
                _ => Resource.R_C_0
            };
            pictureBox5.BackgroundImage = Settings.Default.Skin2 switch
            {
                0 => Resource.Switch_0,
                1 => Resource.Switch_1,
                2 => Resource.Switch_2,
                3 => Resource.Switch_3,
                4 => Resource.Switch_4,
                5 => Resource.Switch_5,
                6 => Resource.Switch_6,
                _ => Resource.Switch_0
            };
            Settings.Default.ImagePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Settings.Default.Save();
            KeyPreview = true; // 启用窗体的键盘事件预览
            KeyDown += Switch_KeyDown; // 将 KeyDown 事件处理程序绑定到窗体
        }
        //自动刷新
        //private async void RefreshScreen()
        //{
        //    while (SwitchConnection.Connected)
        //    {
        //        SwitchPicturetransfer();
        //        await Task.Delay(5000, CancellationToken.None).ConfigureAwait(false);
        //    }
        //}
        private void InputSwitchIP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "192.168.0.0")
            {
                Settings.Default.SwitchIP = textBox.Text;
            }
            Settings.Default.Save();
        }
        private void InputSwitchPort_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "6000" && textBox.Text.Length > 0 )
            {
                var flag = int.TryParse(textBox.Text, out int port);
                if (!flag)
                    InputSwitchPort.Text = "6000";
                else
                    Settings.Default.SwitchPort = port;
            }
            Settings.Default.Save();
        }
        private async void ButtonConnect_Click(object sender, EventArgs e)
        {
            InputSwitchIP.ReadOnly = true;
            InputSwitchPort.ReadOnly = true;
            CON = SwitchConnection;
            SOUR = Source;
            ButtonStop.Enabled = true;
            ShowScreen_BTN.Enabled = true;
            Connect();
            await Task.Delay(500, CancellationToken.None).ConfigureAwait(false);
            SwitchPicturetransfer();
            //await Task.Delay(2000, CancellationToken.None).ConfigureAwait(false);
            //RefreshScreen();
        }

        private async void ButtonStop_Click(object sender, EventArgs e)
        {
            ButtonStop.Enabled = false;
            ShowScreen_BTN.Enabled = false;
            InputSwitchIP.ReadOnly = false;
            InputSwitchPort.ReadOnly = false;
            if (SwitchConnection.Connected)
                SwitchConnection.Disconnect();
            else
            {
                Source.Cancel();
                Source = new CancellationTokenSource();
                SOUR = Source;
            }
            StopPilotLamp();
            SwitchPicture.Image = Resource.SwitchKing;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            Text = "Switch | 已断开连接！！";
            ButtonConnect.Enabled = true;
        }

        private async void Connect()
        {
            ButtonConnect.Enabled = false;
            if (!SwitchConnection.Connected)
            {
                try
                {
                    SwitchConnection.Connect();
                    if (SwitchConnection.Connected)
                    {
                        Text = "Switch | 正在连接...";
                        await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
                        ConnectPilotLamp();
                        string id = await SwitchConnection.GetTitleID(CancellationToken.None).ConfigureAwait(false);
                        if (id != "0000000000000000")
                            Text = $"Switch | 已连接成功 | {id}";
                        else
                            Text = $"Switch | 已连接成功 | 未启动游戏";
                    }
                }
                catch (SocketException ex)
                {
                    if (SwitchConnection.Connected) await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
                    SwitchConnection.Disconnect();
                    // a bit hacky but it works
                    if (ex.Message.Contains("未能响应") || ex.Message.Contains("主动拒绝"))
                    {
                        MessageBox.Show($"连接失败：{ex.Message}");
                    }
                }
            }
        }
        private async void StopPilotLamp()
        {
            pictureBox4.Image = Resource.gray;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            pictureBox3.Image = Resource.gray;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            pictureBox2.Image = Resource.gray;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            pictureBox1.Image = Resource.gray;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
        }
        private async void ConnectPilotLamp()
        {
            pictureBox1.Image = Resource.green1;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            pictureBox2.Image = Resource.green1;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            pictureBox3.Image = Resource.green1;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            pictureBox4.Image = Resource.green1;
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
        }
        private async void ShinyPilotLamp()
        {
            pictureBox4.Image = Resource.gray;
            pictureBox3.Image = Resource.gray;
            pictureBox2.Image = Resource.gray;
            pictureBox1.Image = Resource.gray;
            await Task.Delay(200, CancellationToken.None).ConfigureAwait(false);
            pictureBox1.Image = Resource.green1;
            pictureBox2.Image = Resource.green1;
            pictureBox3.Image = Resource.green1;
            pictureBox4.Image = Resource.green1;
        }
        public new async Task Click(SwitchButton b, int delay, CancellationToken token)
        {
            if (CON != null && SwitchConnection.Connected)
            {
                await CON.SendAsync(SwitchCommand.Click(b), token).ConfigureAwait(false);
                await Task.Delay(delay, token).ConfigureAwait(false);
                ShinyPilotLamp();
                SwitchPicturetransfer();
            }
            else
                MessageBox.Show("暂未连接switch，请在连接完成后再使用！！");
        }
        public async Task SetStick(SwitchStick stick, short x, short y, int delay, CancellationToken token)
        {
            if (SwitchConnection != null && SwitchConnection.Connected)
            {
                var cmd = SwitchCommand.SetStick(stick, x, y, true);
                await SwitchConnection.SendAsync(cmd, token).ConfigureAwait(false);
                await Task.Delay(delay, token).ConfigureAwait(false);
            }
            else
                MessageBox.Show("暂未连接switch，请在连接完成后再使用！！");
        }
        public async Task HoldDown(SwitchButton b, CancellationToken token)
        {
            if (CON != null && SwitchConnection.Connected)
            {
                await CON.SendAsync(SwitchCommand.Hold(b), token).ConfigureAwait(false);
                pictureBox4.Image = Resource.gray;
                pictureBox3.Image = Resource.gray;
                pictureBox2.Image = Resource.gray;
                pictureBox1.Image = Resource.gray;
            }
            else
                MessageBox.Show("暂未连接switch，请在连接完成后再使用！！");
        }
        public async Task HoldUp(SwitchButton b, int delay, CancellationToken token)
        {
            if (CON != null && SwitchConnection.Connected)
            {
                await CON.SendAsync(SwitchCommand.Release(b), token).ConfigureAwait(false);
                await Task.Delay(delay, token).ConfigureAwait(false);
                pictureBox1.Image = Resource.green1;
                pictureBox2.Image = Resource.green1;
                pictureBox3.Image = Resource.green1;
                pictureBox4.Image = Resource.green1;
                SwitchPicturetransfer();
            }
            else
                MessageBox.Show("暂未连接switch，请在连接完成后再使用！！");
        }
        public async Task PressAndHold(SwitchButton b, int hold, int delay, CancellationToken token)
        {
            if (CON != null && SwitchConnection.Connected)
            {
                await CON.SendAsync(SwitchCommand.Hold(b), token).ConfigureAwait(false);
                await Task.Delay(hold, token).ConfigureAwait(false);
                ShinyPilotLamp();
                await CON.SendAsync(SwitchCommand.Release(b), token).ConfigureAwait(false);
                await Task.Delay(delay, token).ConfigureAwait(false);
                SwitchPicturetransfer();
            }
            else
                MessageBox.Show("暂未连接switch，请在连接完成后再使用！！");
        }

        private async void X_BTN_Click(object sender, EventArgs e)
        {
            await Click(X, 800, SOUR.Token).ConfigureAwait(false);
        }

        private async void Y_BTN_Click(object sender, EventArgs e)
        {
            await Click(Y, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void B_BTN_Click(object sender, EventArgs e)
        {
            await Click(B, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void A_BTN_Click(object sender, EventArgs e)
        {
            await Click(A, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void DUP_BTN_Click(object sender, EventArgs e)
        {
            await Click(DUP, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void DDOWN_BTN_Click(object sender, EventArgs e)
        {
            await Click(DDOWN, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void DLEFT_BTN_Click(object sender, EventArgs e)
        {
            await Click(DLEFT, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void DRIGHT_BTN_Click(object sender, EventArgs e)
        {
            await Click(DRIGHT, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void PLUS_BTN_Click(object sender, EventArgs e)
        {
            await Click(PLUS, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void MINUS_BTN_Click(object sender, EventArgs e)
        {
            await Click(MINUS, 300, SOUR.Token).ConfigureAwait(false);
        }


        private async void L_BTN_Click(object sender, EventArgs e)
        {
            await Click(L, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void ZR_BTN_Click(object sender, EventArgs e)
        {
            await Click(ZR, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void R_BTN_Click(object sender, EventArgs e)
        {
            await Click(R, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void LSTICK_BTN_Click(object sender, EventArgs e)
        {
            await PressAndHold(LSTICK, 1200, 0, SOUR.Token).ConfigureAwait(false);
        }

        private async void RSTICK_BTN_Click(object sender, EventArgs e)
        {
            await PressAndHold(RSTICK, 800, 0, SOUR.Token).ConfigureAwait(false);
        }
        private async void CAPTURE_BTN_MouseDown(object sender, MouseEventArgs e)
        {
            await HoldDown(CAPTURE, SOUR.Token).ConfigureAwait(false);
        }

        private async void CAPTURE_BTN_MouseUp(object sender, MouseEventArgs e)
        {
            await HoldUp(CAPTURE, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void HOME_BTN_MouseDown(object sender, MouseEventArgs e)
        {
            await HoldDown(HOME, SOUR.Token).ConfigureAwait(false);
        }

        private async void HOME_BTN_MouseUp(object sender, MouseEventArgs e)
        {
            await HoldUp(HOME, 300, SOUR.Token).ConfigureAwait(false);
        }

        private async void ZL_BTN_MouseDown(object sender, MouseEventArgs e)
        {
            await HoldDown(ZL, SOUR.Token).ConfigureAwait(false);
        }

        private async void ZL_BTN_MouseUp(object sender, MouseEventArgs e)
        {
            await HoldUp(ZL, 300, SOUR.Token).ConfigureAwait(false);
        }



        private void ChangeSkin_BTN_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Skin <= 2)
                Settings.Default.Skin++;
            else
                Settings.Default.Skin = 0;
            Settings.Default.Save();
            OperatingInterface.BackgroundImage = Settings.Default.Skin switch
            {
                0 => Resource.R_C_0,
                1 => Resource.R_C_1,
                2 => Resource.R_C_2,
                3 => Resource.R_C_3,
                _ => Resource.R_C_0
            };
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Skin2 <= 5)
                Settings.Default.Skin2++;
            else
                Settings.Default.Skin2 = 0;
            Settings.Default.Save();
            pictureBox5.BackgroundImage = Settings.Default.Skin2 switch
            {
                0 => Resource.Switch_0,
                1 => Resource.Switch_1,
                2 => Resource.Switch_2,
                3 => Resource.Switch_3,
                4 => Resource.Switch_4,
                5 => Resource.Switch_5,
                6 => Resource.Switch_6,
                _ => Resource.Switch_0
            };
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private async void SwitchPicturetransfer()
        {
            await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
            byte[] pic = await SwitchConnection.Screengrab(SOUR.Token).ConfigureAwait(false) ?? Array.Empty<byte>();
            var image = ByteToImage(pic);
            var destimgae = ResizeImage(image, 356, 205);
            SwitchPicture.Image = destimgae;
        }
        private void ShowScreen_BTN_Click(object sender, EventArgs e)
        {
            SwitchPicturetransfer();
        }

        private void Menu_Settings_Click(object sender, EventArgs e)
        {
            var form = new SettingEditor();
            form.Show();
        }

        private async void SaveImage_Item_Click(object sender, EventArgs e)
        {
            if (!SwitchConnection.Connected)
            {
                MessageBox.Show("保存失败，你还未连接Switch！！");
                return;
            }
            var data = await SwitchConnection.Screengrab(SOUR.Token).ConfigureAwait(false) ?? Array.Empty<byte>();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (Settings.Default.ImagePath != "")
                desktopPath = Settings.Default.ImagePath;
            string filePath = Path.Combine(desktopPath, "Switch_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png");
            File.WriteAllBytes(filePath, data);
            MessageBox.Show($"截图已保存：{filePath}");
        }
        private void Switch_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Settings.Default.KeyBool) { return; }
            var keyButtonMap = new Dictionary<int, Button>
            {
                { Settings.Default.Key_A, A_BTN },
                { Settings.Default.Key_B, B_BTN },
                { Settings.Default.Key_X, X_BTN },
                { Settings.Default.Key_Y, Y_BTN },
                { Settings.Default.Key_R, R_BTN },
                { Settings.Default.Key_L, L_BTN },
                { Settings.Default.Key_ZR, ZR_BTN },
                { Settings.Default.Key_ZL, ZL_BTN },
                { Settings.Default.Key_RSTICK, RSTICK_BTN },
                { Settings.Default.Key_LSTICK, LSTICK_BTN },
                { Settings.Default.Key_PLUS, PLUS_BTN },
                { Settings.Default.Key_MINUS, MINUS_BTN },
                { Settings.Default.Key_DUP, DUP_BTN },
                { Settings.Default.Key_DDOWN, DDOWN_BTN },
                { Settings.Default.Key_DLEFT, DLEFT_BTN },
                { Settings.Default.Key_DRIGHT, DRIGHT_BTN },
                { Settings.Default.Key_HOME, HOME_BTN },
                { Settings.Default.Key_CAPTURE, CAPTURE_BTN }
            };

            if (keyButtonMap.ContainsKey(e.KeyValue) && Settings.Default.KeyBool)
            {
                if (!SwitchConnection.Connected)
                {
                    MessageBox.Show("你还未连接Switch！！");
                    return;
                }
                keyButtonMap[e.KeyValue].PerformClick();
            }
        }

        private void MK_SwitchControllerForm_StyleChanged(object sender, EventArgs e)
        {

        }

        

        //private void LSTICK_BTN_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        isDragging = true;
        //        startPosition = e.Location;
        //        pictureBox4.Image = Resource.gray;
        //        pictureBox3.Image = Resource.gray;
        //        pictureBox2.Image = Resource.gray;
        //        pictureBox1.Image = Resource.gray;
        //    }
        //}

        //private async void LSTICK_BTN_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isDragging)
        //    {
        //        int deltaX = e.X - startPosition.X;
        //        int deltaY = e.Y - startPosition.Y;
        //        if (deltaX >= 32)
        //            deltaX = 32;
        //        else if (deltaX <= -32)
        //            deltaX = -32;
        //        if (deltaY >= 32)
        //            deltaY = 32;
        //        else if (deltaY <= -32)
        //            deltaY = -32;
        //        short Lx = (short)(deltaX * 1000);
        //        short Ly = (short)(-deltaY * 1000);
        //        // 在这里可以根据 deltaX 和 deltaY 的值来模拟摇杆的操作
        //        // 这里只是简单地输出移动的距离，可以根据实际需求进行处理
        //        await SetStick(SwitchStick.LEFT, Lx, Ly, 300, SOUR.Token).ConfigureAwait(false);
        //    }
        //}

        //private async void LSTICK_BTN_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isDragging = false;
        //    await SetStick(SwitchStick.LEFT, 0, 0, 300, SOUR.Token).ConfigureAwait(false);
        //    await Task.Delay(300, CancellationToken.None).ConfigureAwait(false);
        //    pictureBox1.Image = Resource.green1;
        //    pictureBox2.Image = Resource.green1;
        //    pictureBox3.Image = Resource.green1;
        //    pictureBox4.Image = Resource.green1;
        //    SwitchPicturetransfer();
        //}
    }
}
