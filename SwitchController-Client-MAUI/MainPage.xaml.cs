using SysBot.Base;
using System.Net.Sockets;
using static SysBot.Base.SwitchButton;
using CommunityToolkit.Maui.Storage;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using Microsoft.Maui.Storage;

namespace SwitchController_Client_MAUI
{
    public partial class MainPage : ContentPage
    {
        private static SwitchConnectionConfig Config;
        private static SwitchSocketAsync SwitchConnection;
        private CancellationTokenSource Source = new();
        private CancellationToken Token = new();
        private bool IsRunning = false;
        public MainPage()
        {
            InitializeComponent();
            var ip = Preferences.Default.Get("IP", "192.168.1.1");
            var port = Preferences.Default.Get("Port", 6000);
            if (port == 6000)
                SwitchIP_Text.Text = ip;
            else
                SwitchIP_Text.Text = ip + ":" + port.ToString();
            Token = Source.Token;

        }

        private void SwitchIP_Text_Changed(object sender, EventArgs e)
        {
            var text = SwitchIP_Text.Text;
            string pattern = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(?::([0-9]{1,5}))?$";
            bool isValid = Regex.IsMatch(text, pattern);
            if (!isValid)
            {
                return;
            }
            string[] parts = text.Split(':');
            string ip = parts[0];
            int port = parts.Length > 1 ? int.Parse(parts[1]) : 6000;
            if (port < 0 || port > 65535)
            {
                port = 6000;
            }
            Preferences.Set("IP", ip);
            Preferences.Set("Port", port);
            Config = new SwitchConnectionConfig
            {
                Protocol = SwitchProtocol.WiFi, // 假设您使用的是 WiFi
                IP = ip,
                Port = port // 假设您的端口是 6000
            };
            SwitchConnection = SwitchSocketAsync.CreateInstance(Config);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (CounterBtn.Text == "连接")
            {
                Connect();
                CounterBtn.Text = "断开";
            }
            else if (CounterBtn.Text == "断开")
            {
                if (SwitchConnection.Connected)
                    SwitchConnection.Disconnect();
                DisplayAlert("成功", $"Switch已断开连接！！", "ok");
                SwitchPicture.Source = "dotnet_bot.png";
                SwitchIP_Text.IsVisible = true;
                Title = $"Switch";
                CounterBtn.Text = "连接";
            }
        }
        private async void Connect()
        {
            if (!SwitchConnection.Connected)
            {
                try
                {
                    SwitchConnection.Connect();
                    if (SwitchConnection.Connected)
                    {
                        //string id = await SwitchConnection.GetTitleID(CancellationToken.None).ConfigureAwait(false);
                        await DisplayAlert("成功", $"Switch已连接！！", "ok");
                        Title += $" | {SwitchIP_Text.Text}";
                        SwitchIP_Text.IsVisible = false;
                        await SwitchPicturetransfer(Token);
                    }
                }
                catch (SocketException ex)
                {
                    if (SwitchConnection.Connected) await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
                    SwitchConnection.Disconnect();
                    // a bit hacky but it works
                    if (ex.Message.Contains("未能响应") || ex.Message.Contains("主动拒绝"))
                    {
                        await DisplayAlert("失败", $"连接失败：{ex.Message}", "取消");
                    }
                }
            }
        }
        private async Task SwitchPicturetransfer(CancellationToken token)
        {
            byte[] pic = await SwitchConnection.Screengrab(Token).ConfigureAwait(false) ?? Array.Empty<byte>();
            ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(pic));
            SwitchPicture.Source = imageSource;
            IsRunning = false;
        }

        public async Task Click(SwitchButton b, int delay, CancellationToken token)
        {
            if (SwitchConnection != null && SwitchConnection.Connected)
            {
                if (IsRunning) 
                    return;
                IsRunning = true;
                await SwitchConnection.SendAsync(SwitchCommand.Click(b), token).ConfigureAwait(false);
                await SwitchPicturetransfer(token);
            }
            else
                await DisplayAlert("警告", "暂未连接switch，请在连接完成后再使用！！", "取消");
        }
        public async Task HoldDown(SwitchButton b, CancellationToken token)
        {
            if (SwitchConnection != null && SwitchConnection.Connected)
            {
                await SwitchConnection.SendAsync(SwitchCommand.Hold(b), token).ConfigureAwait(false);
            }
            else
                await DisplayAlert("警告", "暂未连接switch，请在连接完成后再使用！！", "取消");
        }
        public async Task HoldUp(SwitchButton b, int delay, CancellationToken token)
        {
            if (SwitchConnection != null && SwitchConnection.Connected)
            {
                await SwitchConnection.SendAsync(SwitchCommand.Release(b), token).ConfigureAwait(false);
                await SwitchPicturetransfer(token);
            }
            else
                await DisplayAlert("警告", "暂未连接switch，请在连接完成后再使用！！", "取消");
        }
        public async Task PressAndHold(SwitchButton b, int hold, int delay, CancellationToken token)
        {
            if (SwitchConnection != null && SwitchConnection.Connected)
            {
                await SwitchConnection.SendAsync(SwitchCommand.Hold(b), token).ConfigureAwait(false);
                await Task.Delay(hold, token).ConfigureAwait(false);
                await SwitchConnection.SendAsync(SwitchCommand.Release(b), token).ConfigureAwait(false);
                await Task.Delay(delay, token).ConfigureAwait(false);
            }
            else
                await DisplayAlert("警告", "暂未连接switch，请在连接完成后再使用！！", "取消");
        }
        public async Task SetStick(SwitchStick stick, short x, short y, CancellationToken token)
        {
            if (SwitchConnection != null && SwitchConnection.Connected)
            {
                var cmd = SwitchCommand.SetStick(stick, x, y, true);
                await SwitchConnection.SendAsync(cmd, token).ConfigureAwait(false);
            }
            else
                await DisplayAlert("警告", "暂未连接switch，请在连接完成后再使用！！", "取消");
        }

        private async void X_BTN_Click(object sender, EventArgs e)
        {
            await Click(SwitchButton.X, 300, Token).ConfigureAwait(false);
        }

        private async void Y_BTN_Click(object sender, EventArgs e)
        {
            await Click(SwitchButton.Y, 300, Token).ConfigureAwait(false);
        }

        private async void B_BTN_Click(object sender, EventArgs e)
        {
            await Click(B, 300, Token).ConfigureAwait(false);
        }

        private async void A_BTN_Click(object sender, EventArgs e)
        {
            await Click(A, 300, Token).ConfigureAwait(false);
        }

        private async void DUP_BTN_Click(object sender, EventArgs e)
        {
            await Click(DUP, 300, Token).ConfigureAwait(false);
        }

        private async void DDOWN_BTN_Click(object sender, EventArgs e)
        {
            await Click(DDOWN, 300, Token).ConfigureAwait(false);
        }

        private async void DLEFT_BTN_Click(object sender, EventArgs e)
        {
            await Click(DLEFT, 300, Token).ConfigureAwait(false);
        }

        private async void DRIGHT_BTN_Click(object sender, EventArgs e)
        {
            await Click(DRIGHT, 300, Token).ConfigureAwait(false);
        }

        private async void PLUS_BTN_Click(object sender, EventArgs e)
        {
            await Click(PLUS, 300, Token).ConfigureAwait(false);
        }

        private async void MINUS_BTN_Click(object sender, EventArgs e)
        {
            await Click(MINUS, 300, Token).ConfigureAwait(false);
        }

        private async void L_BTN_Click(object sender, EventArgs e)
        {
            await Click(L, 300, Token).ConfigureAwait(false);
        }

        private async void ZR_BTN_Click(object sender, EventArgs e)
        {
            await Click(ZR, 300, Token).ConfigureAwait(false);
        }

        private async void R_BTN_Click(object sender, EventArgs e)
        {
            await Click(R, 300, Token).ConfigureAwait(false);
        }
        private async void ZL_BTN_Pressed(object sender, EventArgs e)
        {
            await HoldDown(ZL, Token).ConfigureAwait(false);
        }
        private async void ZL_BTN_Released(object sender, EventArgs e)
        {
            await HoldUp(ZL, 300, Token).ConfigureAwait(false);
        }
        private async void LSTICK_BTN_Pressed(object sender, EventArgs e)
        {
            await HoldDown(LSTICK, Token).ConfigureAwait(false);
        }
        private async void LSTICK_BTN_Released(object sender, EventArgs e)
        {
            await HoldUp(LSTICK, 300, Token).ConfigureAwait(false);
        }
        private async void RSTICK_BTN_Pressed(object sender, EventArgs e)
        {
            await HoldDown(RSTICK, Token).ConfigureAwait(false);
        }
        private async void RSTICK_BTN_Released(object sender, EventArgs e)
        {
            await HoldUp(RSTICK, 300, Token).ConfigureAwait(false);
        }
        private async void CAPTURE_BTN_Pressed(object sender, EventArgs e)
        {
            await HoldDown(CAPTURE, Token).ConfigureAwait(false);
        }
        private async void CAPTURE_BTN_Released(object sender, EventArgs e)
        {
            await HoldUp(CAPTURE, 300, Token).ConfigureAwait(false);
        }
        private async void HOME_BTN_Pressed(object sender, EventArgs e)
        {
            await HoldDown(HOME, Token).ConfigureAwait(false);
        }
        private async void HOME_BTN_Released(object sender, EventArgs e)
        {
            await HoldUp(HOME, 300, Token).ConfigureAwait(false);
        }
        //左摇杆
        private async void LSTICK_LEFTUP_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, -16000, 16000, Token).ConfigureAwait(false);
        }
        private async void LSTICK_UP_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, 0, 32000, Token).ConfigureAwait(false);
        }
        private async void LSTICK_RIGHTUP_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, 16000, 16000, Token).ConfigureAwait(false);
        }
        private async void LSTICK_LEFT_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, -32000, 0, Token).ConfigureAwait(false);
        }
        private async void LSTICK_RIGHT_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, 32000, 0, Token).ConfigureAwait(false);
        }
        private async void LSTICK_LEFTDOWN_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, -16000, -16000, Token).ConfigureAwait(false);
        }
        private async void LSTICK_DOWN_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, 0, -32000, Token).ConfigureAwait(false);
        }
        private async void LSTICK_RIGHTDOWN_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, 16000, -16000, Token).ConfigureAwait(false);
        }
        private async void LSTICK_Released(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.LEFT, 0, 0, Token).ConfigureAwait(false);
            await SwitchPicturetransfer(Token);
        }
        //右摇杆
        private async void RSTICK_LEFTUP_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, -16000, 16000, Token).ConfigureAwait(false);
        }
        private async void RSTICK_UP_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, 0, 32000, Token).ConfigureAwait(false);
        }
        private async void RSTICK_RIGHTUP_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, 16000, 16000, Token).ConfigureAwait(false);
        }
        private async void RSTICK_LEFT_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, -32000, 0, Token).ConfigureAwait(false);
        }
        private async void RSTICK_RIGHT_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, 32000, 0, Token).ConfigureAwait(false);
        }
        private async void RSTICK_LEFTDOWN_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, -16000, -16000, Token).ConfigureAwait(false);
        }
        private async void RSTICK_DOWN_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, 0, -32000, Token).ConfigureAwait(false);
        }
        private async void RSTICK_RIGHTDOWN_BTN_Pressed(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, 16000, -16000, Token).ConfigureAwait(false);
        }
        private async void RSTICK_Released(object sender, EventArgs e)
        {
            await SetStick(SwitchStick.RIGHT, 0, 0, Token).ConfigureAwait(false);
            await SwitchPicturetransfer(Token);
        }


        private async void ShowScreen_BTN_Click(object sender, EventArgs e)
        {
            if (SwitchConnection == null || !SwitchConnection.Connected) 
                await DisplayAlert("警告", "暂未连接switch，请在连接完成后再使用！！", "取消");

            if (IsRunning)
                return;
            IsRunning = true;
            await SwitchPicturetransfer(Token);
        }
        private async void SaveImage_BTN_Click(object sender, EventArgs e)
        {
            var data = await SwitchConnection.Screengrab(Token).ConfigureAwait(false) ?? Array.Empty<byte>();
            if (data.Length == 0)
            {
                // 这里处理数据为空的情况，比如显示警告或日志记录
                await DisplayAlert("失败", "未能获取到数据", "取消");
                return;
            }
            using var CrossedStreams = new MemoryStream(data);
            var result = await FileSaver.Default.SaveAsync($"Switch_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.png", CrossedStreams, Token);
            if (result.IsSuccessful)
                await DisplayAlert("已保存", $"{"Switch_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png"} 文件已保存到{result.FilePath}", "ok");
            else
                await DisplayAlert("失败", $"由于{result.Exception.Message}，{"Switch_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png"}文件未保存", "取消");
        }
    }

}
