using PKHeX.Core;
using SysBot.Base;
using System.ComponentModel;
using System.Net.Sockets;
using MK_Plugins.Properties;
using MK_Plugins.Structures;
using MK_Plugins.PulginEnums;

namespace MK_Plugins.PulginsGUI
{
    public partial class MK_TradePartnerViewerForm : Form
    {
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = Settings.Default.SwitchPort };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);

        private static string OT = string.Empty;
        private static int DisplayTID;
        private static int DisplaySID;

        private static string GameVersions = "";
        private static ulong TradePartnerNIDOffset;
        readonly string CachedText = string.Empty;
        private bool Stop = false;
        private static readonly string[] languages =
        {
        "JPN(日本語)",
        "JPN(日本語)",
        "ENG(English)",
        "FRE(Français)",
        "ITA(Italiano)",
        "GER(Deutsch)",
        "ESP(Español)",
        "ESP(Español)",
        "KOR(한국어)",
        "CHS(简体中文)",
        "CHT(繁體中文)"
        };
        public enum BOX
        {
            ONE,
            BOX,
        }
        public BOX BoxIndex = BOX.ONE;
        private ISaveFileProvider? SAV { get; }
        private IPKMView? Editor { get; }
        public static Trainer trade = new() { TID16 = 201216, SID16 = 1216, OT_Name = "King", Language = 9, Gender = 0, Versions = 43 };
        public MK_TradePartnerViewerForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            CachedText = "交易对象查询器";
            Text = CachedText;
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            InputSwitchIP.Text = Settings.Default.SwitchIP;
            CheckAutoCopy.Checked = Settings.Default.AutoCopy;
            ButtonCopy.Enabled = !CheckAutoCopy.Checked;
            OutOT.Text = string.Empty;
            OutTID.Text = string.Empty;
            OutVersion.Text = string.Empty;
            OutNID.Text = string.Empty;
        }
        private void InputSwitchIP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "192.168.0.0")
            {
                Settings.Default.SwitchIP = textBox.Text;
                //Config.IP = textBox.Text;
            }
            Settings.Default.Save();
        }

        private void InputSwitchPort_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (int.TryParse(textBox.Text, out int port) && port > 0 && port < 65536)
            {
                Settings.Default.SwitchPort = port;
                //Config.Port = textBox.Text;
            }
            Settings.Default.Save();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            ButtonStop.Enabled = true;
            PrintButton.Enabled = true;
            Stop = false;
            Connect();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Stop = true;
            ButtonStop.Enabled = false;
            PrintButton.Enabled = false;
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            CopyOutputToClipboard(CheckPSWiFi.Checked);
        }

        private void CheckAutoCopy_CheckedChanged(object sender, EventArgs e)
        {
            ButtonCopy.Enabled = !CheckAutoCopy.Checked;
            Settings.Default.AutoCopy = CheckAutoCopy.Checked;
            Settings.Default.Save();
            if (SwitchConnection.Connected) CopyOutputToClipboard(CheckPSWiFi.Checked);
        }

        private void CheckPSWiFi_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PSWiFi = CheckPSWiFi.Checked;
            Settings.Default.Save();
        }
        private void CopyOutputToClipboard(bool IsPS = false)
        {
            string n = Environment.NewLine;
            string OutString = IsPS ? $"{OutOT.Text}\t{OutGender.Text}\t{OutTID.Text.Split("-")[1]}\t{OutNID.Text}" : $"名称: {OutOT.Text}{n}性别: {OutGender.Text}{n}表里ID: {OutTID.Text}{n}游戏语言: {OutLanguage.Text}{n}游戏版本: {OutVersion.Text}";
            Clipboard.SetText(OutString);
        }
        private async void Connect()
        {
            ButtonConnect.Enabled = false;
            if (!SwitchConnection.Connected)
            {
                try
                {
                    textLog.Text = "正在连接...";
                    try
                    {
                        var connectTask = Task.Run(() => SwitchConnection.Connect());
                        var completedTask = await Task.WhenAny(connectTask, Task.Delay(3000));

                        if (completedTask != connectTask)
                        {
                            // 连接超时
                            MessageBox.Show("连接服务器超时，请关闭重启！！");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("连接服务器失败：" + ex.Message);
                        return;
                    }
                    string id = await GetGameID(CancellationToken.None);
                    textLog.Text = "正在识别主机训练家数据...";
                    if (id is Offsets.ScarletID or Offsets.VioletID)
                    {
                        var sav = await IdentifyTrainer_SV(CancellationToken.None);
                        OT = sav.OT;
                        DisplayTID = (int)sav.DisplayTID;
                        DisplaySID = (int)sav.DisplaySID;

                        if (id is Offsets.ScarletID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：朱";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "SC";
                        }
                        else if (id is Offsets.VioletID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：紫";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "VI";
                        }
                    }
                    else if (id is Offsets.LegendsArceusID)
                    {
                        var sav = await IdentifyTrainer_LA(CancellationToken.None);
                        OT = sav.OT;
                        DisplayTID = (int)sav.DisplayTID;
                        DisplaySID = (int)sav.DisplaySID;
                        textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：传说阿尔宙斯";
                        Text = CachedText + $" | " + textLog.Text;
                        GameVersions = "LA";
                    }
                    else if (id is Offsets.SwordID or Offsets.ShieldID)
                    {
                        var sav = await IdentifyTrainer_SWSH(CancellationToken.None);
                        OT = sav.OT;
                        DisplayTID = (int)sav.DisplayTID;
                        DisplaySID = (int)sav.DisplaySID;

                        if (id is Offsets.SwordID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：剑";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "SW";
                        }
                        else if (id is Offsets.ShieldID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：盾";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "SH";
                        }
                    }
                    else if (id is Offsets.ShiningPearlID or Offsets.BrilliantDiamondID)
                    {
                        var sav = await IdentifyTrainer_BS(CancellationToken.None);
                        OT = sav.OT;
                        DisplayTID = (int)sav.DisplayTID;
                        DisplaySID = (int)sav.DisplaySID;

                        if (id is Offsets.ShiningPearlID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：明亮珍珠";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "SP";
                        }
                        else if (id is Offsets.BrilliantDiamondID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：晶灿钻石";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "BD";
                        }
                    }
                    else if (id is Offsets.LetsGoPikachuID or Offsets.LetsGoEeveeID)
                    {
                        var sav = await IdentifyTrainer_LGPE(CancellationToken.None);
                        OT = sav.OT;
                        DisplayTID = (int)sav.DisplayTID;
                        DisplaySID = (int)sav.DisplaySID;

                        if (id is Offsets.LetsGoPikachuID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：Let's Go! 皮卡丘";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "LP";
                        }
                        else if (id is Offsets.LetsGoEeveeID)
                        {
                            textLog.Text = $"{OT} ({DisplaySID:D4}-{DisplayTID:D6})已连接-游戏版本：Let's Go! 伊布";
                            Text = CachedText + $" | " + textLog.Text;
                            GameVersions = "LE";
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有检测到Switch上正在运行宝可梦!");
                        SwitchConnection.Disconnect();
                    }

                    if (SwitchConnection.Connected)
                    {
                        textLog.Text = "正在读取交易对象信息...";

                        while (!Stop && SwitchConnection.Connected)
                        {
                            if (GameVersions == "SC" || GameVersions == "VI")
                            {
                                TradePartnerNIDOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerNIDPointer_SV, CancellationToken.None);
                                ulong NID = await GetTradePartnerNID(TradePartnerNIDOffset, CancellationToken.None);
                                if (NID == 0)
                                {
                                    await Task.Delay(1_000);
                                    continue;
                                }

                                var trader = await GetTradePartnerMyStatus_SV(Offsets.Trader1MyStatusPointer_SV, CancellationToken.None);
                                if (trader.OT == OT && trader.DisplayTID == DisplayTID && trader.DisplaySID == DisplaySID)
                                    trader = await GetTradePartnerMyStatus_SV(Offsets.Trader2MyStatusPointer_SV, CancellationToken.None);

                                string languageZh = trader.Language >= 0 && trader.Language < languages.Length ? languages[trader.Language] : $"未知{trader.Language}";

                                trade.OT_Name = trader.OT;
                                trade.TID16 = trader.DisplayTID;
                                trade.SID16 = trader.DisplaySID;
                                trade.Versions = trader.Game;
                                trade.Gender = trader.Gender;
                                trade.Language = trader.Language;

                                OutOT.Text = trader.OT;
                                OutTID.Text = $"({trader.DisplaySID:D4})-{trader.DisplayTID:D6}";
                                OutVersion.Text = $"{(trader.Game == 50 ? "朱" : trader.Game == 51 ? "紫" : "未知")}";
                                OutNID.Text = $"{NID:X16}";
                                OutGender.Text = $"{(trader.Gender == 0 ? "男" : "女")}";
                                OutLanguage.Text = languageZh;
                                PkmClipboard.Text = $".Version={trader.Game}\n" +
                                    $".OriginalTrainerName={trader.OT}\n" +
                                    $".OriginalTrainerGender={trader.Gender}\n" +
                                    $".DisplayTID={trader.DisplayTID:D6}\n" +
                                    $".DisplaySID={trader.DisplaySID:D4}\n" +
                                    $".Language={trader.Language}\n" +
                                    $".IsNicknamed=false\n";
                                if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                                await ClearTradePartnerNID_ulong(TradePartnerNIDOffset, CancellationToken.None);
                            }
                            else if (GameVersions == "LA")
                            {
                                TradePartnerNIDOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerNIDPointer_LA, CancellationToken.None);
                                ulong NID = await GetTradePartnerNID(TradePartnerNIDOffset, CancellationToken.None);
                                if (NID == 0)
                                {
                                    await Task.Delay(1_000);
                                    continue;
                                }

                                var tradePartner = await GetTradePartnerMyStatus_LA(CancellationToken.None).ConfigureAwait(false);

                                string languageZh = tradePartner.Language >= 0 && tradePartner.Language < languages.Length ? languages[tradePartner.Language] : $"未知{tradePartner.Language}";
                                if (tradePartner.Game != 0)
                                {
                                    trade.OT_Name = tradePartner.TrainerName;
                                    trade.TID16 = Convert.ToUInt32(tradePartner.TID7);
                                    trade.SID16 = Convert.ToUInt32(tradePartner.SID7);
                                    trade.Versions = tradePartner.Game;
                                    trade.Gender = tradePartner.Gender;
                                    trade.Language = tradePartner.Language;

                                    OutOT.Text = tradePartner.TrainerName;
                                    OutTID.Text = $"({tradePartner.SID7:D4})-{tradePartner.TID7:D6}";
                                    OutVersion.Text = $"{(tradePartner.Game == 47 ? "传说阿尔宙斯" : "未知")}";
                                    OutNID.Text = $"{NID:X16}";
                                    OutGender.Text = $"{(tradePartner.Gender == 0 ? "男" : "女")}";
                                    OutLanguage.Text = languageZh;
                                    PkmClipboard.Text = $".Version={tradePartner.Game}\n" +
                                        $".OriginalTrainerName={tradePartner.TrainerName}\n" +
                                        $".OriginalTrainerGender={tradePartner.Gender}\n" +
                                        $".DisplayTID={tradePartner.TID7:D6}\n" +
                                        $".DisplaySID={tradePartner.SID7:D4}\n" +
                                        $".Language={tradePartner.Language}\n" +
                                        $".IsNicknamed=false\n";
                                }
                                if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                                await ClearTradePartnerNID_ulong(TradePartnerNIDOffset, CancellationToken.None);
                            }
                            else if (GameVersions == "SW" || GameVersions == "SH")
                            {
                                var data = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNIDOffset_SWSH, 8, CancellationToken.None).ConfigureAwait(false);
                                ulong NID = BitConverter.ToUInt64(data, 0);
                                ulong firstSixDigits = NID & 0xFC00000000000000UL;
                                if (firstSixDigits == 0)
                                {
                                    await Task.Delay(1_000);
                                    continue;
                                }

                                var tradePartner = await GetTradePartnerMyStatus_SWSH(CancellationToken.None).ConfigureAwait(false);

                                string languageZh = tradePartner.Language >= 0 && tradePartner.Language < languages.Length ? languages[tradePartner.Language] : $"未知{tradePartner.Language}";

                                trade.OT_Name = tradePartner.TrainerName;
                                trade.TID16 = Convert.ToUInt32(tradePartner.TID7);
                                trade.SID16 = Convert.ToUInt32(tradePartner.SID7);
                                trade.Versions = tradePartner.Game;
                                trade.Gender = tradePartner.Gender;
                                trade.Language = tradePartner.Language;

                                OutOT.Text = tradePartner.TrainerName;
                                OutTID.Text = $"({tradePartner.SID7:D4})-{tradePartner.TID7:D6}";
                                OutVersion.Text = $"{(tradePartner.Game == 44 ? "剑" : tradePartner.Game == 45 ? "盾" : "未知")}";
                                OutNID.Text = $"{NID:X16}";
                                OutGender.Text = $"{(tradePartner.Gender == 0 ? "男" : "女")}";
                                OutLanguage.Text = languageZh;
                                PkmClipboard.Text = $".Version={tradePartner.Game}\n" +
                                    $".OriginalTrainerName={tradePartner.TrainerName}\n" +
                                    $".OriginalTrainerGender={tradePartner.Gender}\n" +
                                    $".DisplayTID={tradePartner.TID7:D6}\n" +
                                    $".DisplaySID={tradePartner.SID7:D4}\n" +
                                    $".Language={tradePartner.Language}\n" +
                                    $".IsNicknamed=false\n";
                                if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                                await ClearTradePartnerNID_uint(Offsets.LinkTradePartnerNIDOffset_SWSH, CancellationToken.None);
                            }
                            else if (GameVersions == "BD")
                            {
                                TradePartnerNIDOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerNIDPointer_BS_BD, CancellationToken.None);
                                var LinkTradePokemonOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerPokemonPointer_BS_BD, CancellationToken.None).ConfigureAwait(false);
                                var tradePartner = await GetTradePartnerMyStatus_BS_BD(CancellationToken.None).ConfigureAwait(false);
                                var NID = GetFakeNID(tradePartner.TrainerName, tradePartner.TrainerID);
                                if (NID == 0)
                                {
                                    await Task.Delay(1_000);
                                    continue;
                                }
                                var offered = await ReadInfo(LinkTradePokemonOffset, 0x158, CancellationToken.None).ConfigureAwait(false);

                                string languageZh = tradePartner.Language >= 0 && tradePartner.Language < languages.Length ? languages[tradePartner.Language] : $"未知{tradePartner.Language}";

                                trade.OT_Name = tradePartner.TrainerName;
                                trade.TID16 = Convert.ToUInt32(tradePartner.TID7);
                                trade.SID16 = Convert.ToUInt32(tradePartner.SID7);
                                trade.Versions = tradePartner.Game;
                                trade.Gender = offered.HandlingTrainerGender;
                                trade.Language = tradePartner.Language;

                                OutOT.Text = tradePartner.TrainerName;
                                OutTID.Text = $"({tradePartner.SID7:D4})-{tradePartner.TID7:D6}";
                                OutVersion.Text = $"{(tradePartner.Game == 48 ? "晶灿钻石" : tradePartner.Game == 49 ? "明亮珍珠" : $"{tradePartner.Game}")}";
                                OutNID.Text = $"{NID:X16}";
                                OutGender.Text = $"{(offered.HandlingTrainerGender == 0 ? "男" : "女")}";
                                OutLanguage.Text = languageZh;
                                PkmClipboard.Text = $".Version={tradePartner.Game}\n" +
                                    $".OriginalTrainerName={tradePartner.TrainerName}\n" +
                                    $".OriginalTrainerGender={offered.HandlingTrainerGender}\n" +
                                    $".DisplayTID={tradePartner.TID7:D6}\n" +
                                    $".DisplaySID={tradePartner.SID7:D4}\n" +
                                    $".Language={tradePartner.Language}\n" +
                                    $".IsNicknamed=false\n";
                                if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                                await ClearTradePartnerNID_ulong(TradePartnerNIDOffset, CancellationToken.None);
                            }
                            else if (GameVersions == "SP")
                            {
                                TradePartnerNIDOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerNIDPointer_BS_SP, CancellationToken.None);
                                var LinkTradePokemonOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerPokemonPointer_BS_SP, CancellationToken.None).ConfigureAwait(false);
                                var tradePartner = await GetTradePartnerMyStatus_BS_SP(CancellationToken.None).ConfigureAwait(false);
                                var NID = GetFakeNID(tradePartner.TrainerName, tradePartner.TrainerID);
                                if (NID == 0)
                                {
                                    await Task.Delay(1_000);
                                    continue;
                                }
                                var offered = await ReadInfo(LinkTradePokemonOffset, 0x158, CancellationToken.None).ConfigureAwait(false);

                                string languageZh = tradePartner.Language >= 0 && tradePartner.Language < languages.Length ? languages[tradePartner.Language] : $"未知{tradePartner.Language}";

                                trade.OT_Name = tradePartner.TrainerName;
                                trade.TID16 = Convert.ToUInt32(tradePartner.TID7);
                                trade.SID16 = Convert.ToUInt32(tradePartner.SID7);
                                trade.Versions = tradePartner.Game;
                                trade.Gender = offered.HandlingTrainerGender;
                                trade.Language = tradePartner.Language;

                                OutOT.Text = tradePartner.TrainerName;
                                OutTID.Text = $"({tradePartner.SID7:D4})-{tradePartner.TID7:D6}";
                                OutVersion.Text = $"{(tradePartner.Game == 48 ? "晶灿钻石" : tradePartner.Game == 49 ? "明亮珍珠" : $"{tradePartner.Game}")}";
                                OutNID.Text = $"{NID:X16}";
                                OutGender.Text = $"{(offered.HandlingTrainerGender == 0 ? "男" : "女")}";
                                OutLanguage.Text = languageZh;
                                PkmClipboard.Text = $".Version={tradePartner.Game}\n" +
                                    $".OriginalTrainerName={tradePartner.TrainerName}\n" +
                                    $".OriginalTrainerGender={offered.HandlingTrainerGender}\n" +
                                    $".DisplayTID={tradePartner.TID7:D6}\n" +
                                    $".DisplaySID={tradePartner.SID7:D4}\n" +
                                    $".Language={tradePartner.Language}\n" +
                                    $".IsNicknamed=false\n";
                                if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                                await ClearTradePartnerNID_ulong(TradePartnerNIDOffset, CancellationToken.None);
                            }
                            else if (GameVersions == "LP" || GameVersions == "LE")
                            {
                                var tradepartnersav = new SAV7b();
                                var tradepartnersav2 = new SAV7b();
                                var tpsarray = await SwitchConnection.ReadBytesAsync(Offsets.TradePartnerData_LGPE, 0x168, CancellationToken.None);
                                tpsarray.CopyTo(tradepartnersav.Blocks.Status.Data);
                                var tpsarray2 = await SwitchConnection.ReadBytesAsync(Offsets.TradePartnerData2_LGPE, 0x168, CancellationToken.None);
                                tpsarray2.CopyTo(tradepartnersav2.Blocks.Status.Data);

                                var trader = tradepartnersav;
                                if (trader.OT == OT && trader.DisplayTID == DisplayTID && trader.DisplaySID == DisplaySID)
                                    trader = tradepartnersav2;

                                var NID = GetFakeNID(trader.OT, trader.TrainerTID7);
                                if (NID == 0)
                                {
                                    await Task.Delay(1_000);
                                    continue;
                                }

                                string languageZh = trader.Language >= 0 && trader.Language < languages.Length ? languages[trader.Language] : $"未知{trader.Language}";

                                trade.OT_Name = trader.OT;
                                trade.TID16 = trader.DisplayTID;
                                trade.SID16 = trader.DisplaySID;
                                trade.Versions = trader.Version == GameVersion.GP ? 42 : trader.Version == GameVersion.GE ? 43 : 42;
                                trade.Gender = trader.Gender;
                                trade.Language = trader.Language;

                                OutOT.Text = trader.OT;
                                OutTID.Text = $"({trader.DisplaySID:D4})-{trader.DisplayTID:D6}";
                                OutVersion.Text = $"{(trader.Version == GameVersion.GP ? "Let's Go! 皮卡丘" : trader.Version == GameVersion.GE ? "Let's Go! 伊布" : "未知")}";
                                OutNID.Text = $"{NID:X16}";
                                OutGender.Text = $"{(trader.Gender == 0 ? "男" : "女")}";
                                OutLanguage.Text = languageZh;
                                PkmClipboard.Text = $".Version={(trader.Version == GameVersion.GP ? "42" : trader.Version == GameVersion.GE ? "43" : $"{trader.Version}")}\n" +
                                    $".OriginalTrainerName={trader.OT}\n" +
                                    $".OriginalTrainerGender={trader.Gender}\n" +
                                    $".DisplayTID={trader.DisplayTID:D6}\n" +
                                    $".DisplaySID={trader.DisplaySID:D4}\n" +
                                    $".Language={trader.Language}\n" +
                                    $".IsNicknamed=false\n";
                                if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                            }
                        }

                        textLog.Text = $"已断开连接！！";
                        if (SwitchConnection.Connected) SwitchConnection.Disconnect();
                    }
                }
                catch (SocketException err)
                {
                    textLog.Text = "连接失败!";
                    if (SwitchConnection.Connected) await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
                    SwitchConnection.Disconnect();
                    // a bit hacky but it works
                    if (err.Message.Contains("未能响应") || err.Message.Contains("主动拒绝"))
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            ButtonConnect.Enabled = true;
        }
        private static async Task<string> GetGameID(CancellationToken token) => await SwitchConnection.GetTitleID(token).ConfigureAwait(false);

        #region 朱紫
        private static async Task<TradeMyStatusSV> GetTradePartnerMyStatus_SV(IReadOnlyList<long> pointer, CancellationToken token)
        {
            var info = new TradeMyStatusSV();
            var read = await SwitchConnection.PointerPeek(info.Data.Length, pointer, token).ConfigureAwait(false);
            read.CopyTo(info.Data, 0);
            return info;
        }
        private static async Task<SAV9SV> IdentifyTrainer_SV(CancellationToken token)
        {
            // Check title so we can warn if mode is incorrect.
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not (Offsets.ScarletID or Offsets.VioletID))
                throw new Exception($"{title}不是支持的版本. 你确定打开了支持的宝可梦吗?");

            return await GetFakeTrainerSAV_SV(token).ConfigureAwait(false);
        }

        private static async Task<SAV9SV> GetFakeTrainerSAV_SV(CancellationToken token)
        {
            var sav = new SAV9SV();
            var info = sav.MyStatus;
            var read = await SwitchConnection.PointerPeek(info.Data.Length, Offsets.MyStatusPointer_SV, token).ConfigureAwait(false);
            read.CopyTo(info.Data);
            return sav;
        }
        #endregion
        #region 珍珠钻石
        private static async Task<SAV8BS> IdentifyTrainer_BS(CancellationToken token)
        {
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not (Offsets.ShiningPearlID or Offsets.BrilliantDiamondID))
                throw new Exception($"{title}不是支持的版本. 你确定打开了支持的宝可梦吗?");

            if (title is Offsets.ShiningPearlID)
                return await GetFakeTrainerSAV_BS_SP(token).ConfigureAwait(false);
            else
                return await GetFakeTrainerSAV_BS_BD(token).ConfigureAwait(false);
        }
        private static async Task<SAV8BS> GetFakeTrainerSAV_BS_SP(CancellationToken token)
        {
            var sav = new SAV8BS();
            var info = sav.MyStatus;
            //设置训练家
            var name = await SwitchConnection.PointerPeek(TradePartnerBS.MaxByteLengthStringObject, Offsets.MyStatusTrainerPointer_BS_SP, token).ConfigureAwait(false);
            info.OT = TradePartnerBS.ReadStringFromRAMObject(name);
            //设置TID、SID和语言
            var offset = await SwitchConnection.PointerAll(Offsets.MyStatusTIDPointer_BS_SP, token).ConfigureAwait(false);
            var tid = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 2, token).ConfigureAwait(false);
            var sid = await SwitchConnection.ReadBytesAbsoluteAsync(offset + 2, 2, token).ConfigureAwait(false);

            info.TID16 = System.Buffers.Binary.BinaryPrimitives.ReadUInt16LittleEndian(tid);
            info.SID16 = System.Buffers.Binary.BinaryPrimitives.ReadUInt16LittleEndian(sid);

            var lang = await SwitchConnection.PointerPeek(1, Offsets.ConfigLanguagePointer_BS_SP, token).ConfigureAwait(false);
            sav.Language = lang[0];
            return sav;
        }
        private static async Task<SAV8BS> GetFakeTrainerSAV_BS_BD(CancellationToken token)
        {
            var sav = new SAV8BS();
            var info = sav.MyStatus;
            //设置训练家
            var name = await SwitchConnection.PointerPeek(TradePartnerBS.MaxByteLengthStringObject, Offsets.MyStatusTrainerPointer_BS_BD, token).ConfigureAwait(false);
            info.OT = TradePartnerBS.ReadStringFromRAMObject(name);
            //设置TID、SID和语言
            var offset = await SwitchConnection.PointerAll(Offsets.MyStatusTIDPointer_BS_BD, token).ConfigureAwait(false);
            var tid = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 2, token).ConfigureAwait(false);
            var sid = await SwitchConnection.ReadBytesAbsoluteAsync(offset + 2, 2, token).ConfigureAwait(false);

            info.TID16 = System.Buffers.Binary.BinaryPrimitives.ReadUInt16LittleEndian(tid);
            info.SID16 = System.Buffers.Binary.BinaryPrimitives.ReadUInt16LittleEndian(sid);

            var lang = await SwitchConnection.PointerPeek(1, Offsets.ConfigLanguagePointer_BS_BD, token).ConfigureAwait(false);
            sav.Language = lang[0];
            return sav;
        }
        private async Task<TradePartnerBS> GetTradePartnerMyStatus_BS_SP(CancellationToken token)
        {
            var id = await SwitchConnection.PointerPeek(4, Offsets.LinkTradePartnerIDPointer_BS_SP, token).ConfigureAwait(false);
            var name = await SwitchConnection.PointerPeek(TradePartnerBS.MaxByteLengthStringObject, Offsets.LinkTradePartnerNamePointer_BS_SP, token).ConfigureAwait(false);
            var langbytes = await SwitchConnection.PointerPeek(1, Offsets.LinkTradePartnerLanguagePointer_BS_SP, CancellationToken.None).ConfigureAwait(false);
            var gamebytes = await SwitchConnection.PointerPeek(1, Offsets.LinkTradePartnerVersionPointer_BS_SP, CancellationToken.None).ConfigureAwait(false);
            return new TradePartnerBS(id, name, gamebytes, langbytes);
        }
        private async Task<TradePartnerBS> GetTradePartnerMyStatus_BS_BD(CancellationToken token)
        {
            var id = await SwitchConnection.PointerPeek(4, Offsets.LinkTradePartnerIDPointer_BS_BD, token).ConfigureAwait(false);
            var name = await SwitchConnection.PointerPeek(TradePartnerBS.MaxByteLengthStringObject, Offsets.LinkTradePartnerNamePointer_BS_BD, token).ConfigureAwait(false);
            var langbytes = await SwitchConnection.PointerPeek(1, Offsets.LinkTradePartnerLanguagePointer_BS_BD, CancellationToken.None).ConfigureAwait(false);
            var gamebytes = await SwitchConnection.PointerPeek(1, Offsets.LinkTradePartnerVersionPointer_BS_BD, CancellationToken.None).ConfigureAwait(false);
            return new TradePartnerBS(id, name, gamebytes, langbytes);
        }
        public async Task<PB8> ReadInfo(ulong offset, int size, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, size, token).ConfigureAwait(false);
            return new PB8(data);
        }
        #endregion
        #region 传说阿尔宙斯
        private async Task<TradePartnerLA> GetTradePartnerMyStatus_LA(CancellationToken token)
        {
            var id = await SwitchConnection.PointerPeek(4, Offsets.LinkTradePartnerTIDPointer_LA, token).ConfigureAwait(false);
            var name = await SwitchConnection.PointerPeek(TradePartnerLA.MaxByteLengthStringObject, Offsets.LinkTradePartnerNamePointer_LA, token).ConfigureAwait(false);
            var traderOffset = await SwitchConnection.PointerAll(Offsets.LinkTradePartnerTIDPointer_LA, token).ConfigureAwait(false);
            var idbytes = await SwitchConnection.ReadBytesAbsoluteAsync(traderOffset + 0x04, 4, token).ConfigureAwait(false);

            return new TradePartnerLA(id, name, idbytes);
        }
        private static async Task<SAV8LA> IdentifyTrainer_LA(CancellationToken token)
        {
            // Check title so we can warn if mode is incorrect.
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not Offsets.LegendsArceusID)
                throw new Exception($"{title}不是支持的版本. 你确定打开了支持的宝可梦吗?");

            return await GetFakeTrainerSAV_LA(token).ConfigureAwait(false);
        }
        private static async Task<SAV8LA> GetFakeTrainerSAV_LA(CancellationToken token)
        {
            var sav = new SAV8LA();
            var info = sav.MyStatus;
            var read = await SwitchConnection.PointerPeek(info.Data.Length, Offsets.MyStatusPointer_LA, token).ConfigureAwait(false);
            read.CopyTo(info.Data);
            return sav;
        }
        #endregion
        #region 剑盾
        private static async Task<SAV8SWSH> IdentifyTrainer_SWSH(CancellationToken token)
        {
            // Check title so we can warn if mode is incorrect.
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not (Offsets.SwordID or Offsets.ShieldID))
                throw new Exception($"{title}不是支持的版本. 你确定打开了支持的宝可梦吗?");

            return await GetFakeTrainerSAV_SWSH(token).ConfigureAwait(false);
        }
        private static async Task<SAV8SWSH> GetFakeTrainerSAV_SWSH(CancellationToken token)
        {
            var sav = new SAV8SWSH();
            var info = sav.MyStatus;
            var read = await SwitchConnection.ReadBytesAsync(Offsets.TrainerDataOffset_SWSH, Offsets.TrainerDataLength_SWSH, token).ConfigureAwait(false);
            read.CopyTo(info.Data);
            return sav;
        }
        private async Task<TradePartnerSWSH> GetTradePartnerMyStatus_SWSH(CancellationToken token)
        {
            var id = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH - 0x8, 8, token).ConfigureAwait(false);
            var name = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH, TradePartnerSWSH.MaxByteLengthStringObject, token).ConfigureAwait(false);
            var idbytes = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH - 0x8, 8, token).ConfigureAwait(false);

            return new TradePartnerSWSH(id, name, idbytes);
        }
        #endregion
        #region 去皮去伊
        private static async Task<SAV7b> IdentifyTrainer_LGPE(CancellationToken token)
        {
            // Check title so we can warn if mode is incorrect.
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not (Offsets.LetsGoPikachuID or Offsets.LetsGoEeveeID))
                throw new Exception($"{title}不是支持的版本. 你确定打开了支持的宝可梦吗?");

            return await GetFakeTrainerSAV_LGPE(token).ConfigureAwait(false);
        }
        private static async Task<SAV7b> GetFakeTrainerSAV_LGPE(CancellationToken token)
        {
            var sav = new SAV7b();
            byte[]? data = await SwitchConnection.ReadBytesAsync(Offsets.TrainerData_LGPE, Offsets.TrainerSize_LGPE, token).ConfigureAwait(false);
            data.CopyTo(sav.Blocks.Status.Data);
            return sav;
        }
        #endregion

        private static async Task<ulong> GetTradePartnerNID(ulong offset, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 8, token).ConfigureAwait(false);
            return BitConverter.ToUInt64(data, 0);
        }

        private static ulong GetFakeNID(string trainerName, uint trainerID)
        {
            var nameHash = trainerName.GetHashCode();
            return ((ulong)trainerID << 32) | (uint)nameHash;
        }
        private static async Task ClearTradePartnerNID_ulong(ulong offset, CancellationToken token)
        {
            var data = new byte[8];
            await SwitchConnection.WriteBytesAbsoluteAsync(data, offset, token).ConfigureAwait(false);
        }

        private static async Task ClearTradePartnerNID_uint(uint offset, CancellationToken token)
        {
            var data = new byte[8];
            await SwitchConnection.WriteBytesAsync(data, offset, token).ConfigureAwait(false);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            CopyOutput();
        }
        private void CopyOutput()
        {
            string n = Environment.NewLine;
            string OT_Name = OutOT.Text;
            int version = OutVersion.Text switch
            {
                "紫" => 51,
                "朱" => 50,
                "明亮珍珠" => 49,
                "晶灿钻石" => 48,
                "传说阿尔宙斯" => 47,
                "盾" => 45,
                "剑" => 44,
                "Let's Go！伊布" => 43,
                "Let's Go！皮卡丘" => 42,
                _ => 0
            };
            int Gender = OutGender.Text == "男" ? 0 : 1;
            string TID = "";
            string SID = "";
            if (!string.IsNullOrEmpty(OutTID.Text))
            {
                TID = OutTID.Text.Split("-")[1];
                SID = OutTID.Text.Split("-")[0][1..^1];
            }
            int Language = GetLanguageCode(OutLanguage.Text);
            Clipboard.SetText(PkmClipboard.Text);
            PkmClipboard.Text = $".Version={version}{n}.OriginalTrainerName={OT_Name}{n}.OriginalTrainerGender={Gender}{n}.DisplayTID={TID}{n}.DisplaySID={SID}{n}.Language={Language}{n}.IsNicknamed=false";
        }
        public static int GetLanguageCode(string language)
        {

            for (int i = 0; i < languages.Length; i++)
            {
                if (languages[i] == language)
                {
                    return i;
                }
            }
            return -1; // 如果没有找到匹配的语言，返回 -1 表示未知
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            if (BoxIndex == BOX.ONE)
                SetOne();
            else if (BoxIndex == BOX.BOX)
                SetBox();
        }
        private void SetOne()
        {
            bool flag = false;
            var pkm = Editor.Data;
            if (pkm.IsShiny)
            {
                flag = true;
            }
            pkm = setID(Editor.Data);
            if (flag)
                CommonEdits.SetShiny(pkm, (Shiny)0);
            Editor.PopulateFields(pkm);
        }
        private void SetBox()
        {
            int n = SAV.CurrentBox;
            PKM[] PKL = SAV.SAV.GetBoxData(n);
            for (int i = 0; i < PKL.Count(); i++)
            {

                var pk = PKL[i];
                bool flag = false;
                if (pk.IsShiny)
                {
                    flag = true;
                }
                PKL[i] = setID(pk);
                if (flag)
                    CommonEdits.SetShiny(pk, (Shiny)0);
                PKL[i] = pk;
            }
            if (PKL.Count() != 0)
            {
                SAV.SAV.SetBoxData(PKL, n);
            }
            SAV.ReloadSlots();
        }
        private PKM setID(PKM pk)
        {
            pk.OriginalTrainerName = trade.OT_Name;
            pk.DisplayTID = trade.TID16;
            pk.DisplaySID = trade.SID16;
            pk.OriginalTrainerGender = (byte)trade.Gender;
            pk.Language = trade.Language;
            pk.ClearNickname();
            return pk;
        }

        private void Number_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Number_Box.SelectedIndex == 0)
                BoxIndex = BOX.ONE;
            else if (Number_Box.SelectedIndex == 1)
                BoxIndex = BOX.BOX;
        }
    }
}
