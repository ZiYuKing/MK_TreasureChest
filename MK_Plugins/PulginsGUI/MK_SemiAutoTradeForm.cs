using MK_Plugins.Properties;
using MK_Plugins.Structures;
using PKHeX.Core;
using SysBot.Base;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Net.Sockets;
using System.Text;
using MK_Plugins.PulginEnums;
using static SysBot.Base.SwitchButton;
using System.Security.Cryptography;
using System.Drawing;


namespace MK_Plugins.PulginsGUI
{
    public partial class MK_SemiAutoTradeForm : Form
    {
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = 6000 };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);

        private CancellationTokenSource Source = new();
        protected uint PokePortalLoadedValue = 0xA;
        private static List<PKM> BD = new List<PKM>();
        protected TradePartnerSV OurTrainer = new TradePartnerSV();
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        private LanguageID gameLang;

        public LanguageID GetGameLang()
        {
            return gameLang;
        }

        private void SetGameLang(LanguageID value)
        {
            gameLang = value;
        }

        public bool tradelink = false;
        private int j = 0;
        private int n = 0;
        private string GamesModel = "";
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
        CancellationToken token;
        private bool trading = false;
        public MK_SemiAutoTradeForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            Text = "半自动交易器";
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            token = Source.Token;
            InputSwitchIP.Text = Settings.Default.SwitchIP;
            Code_Text.Text = Settings.Default.teadecode;
            PKM_CheckBox.DisplayMember = "Species";

            PKM_CheckBox.Format += (sender, e) =>
            {
                if (e.ListItem != null)
                {
                    ushort species = (ushort)e.ListItem.GetType().GetProperty("Species").GetValue(e.ListItem, null);
                    e.Value = GameInfo.GetStrings("zh").Species[species];
                }
            };
        }
        private void InputSwitchIP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "192.168.0.0")
            {
                Settings.Default.SwitchIP = textBox.Text;
            }
            Settings.Default.Save();
        }

        private void Connect_BTN_Click(object sender, EventArgs e)
        {
            Stop_BTN.Enabled = true;
            InputSwitchIP.ReadOnly = true;
            Connect();
        }
        private async void Connect()
        {
            Connect_BTN.Enabled = false;
            if (!SwitchConnection.Connected)
            {
                try
                {
                    SwitchConnection.Connect();
                    if (SwitchConnection.Connected)
                    {
                        Text = "Switch | 正在连接...";
                        string id = await SwitchConnection.GetTitleID(CancellationToken.None).ConfigureAwait(false);
                        if (id != "0000000000000000")
                        {
                            if (id is Offsets.ScarletID or Offsets.VioletID)
                            {
                                Text = $"Switch | 已连接成功 | 朱紫模式"; 
                                GamesModel = "朱紫";
                            }
                            else if (id is Offsets.ShieldID or Offsets.SwordID)
                            {
                                Text = $"Switch | 已连接成功 | 剑盾模式";
                                GamesModel = "剑盾";
                                var idbytes = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH - 0x8, 8, token).ConfigureAwait(false);
                                SetGameLang((LanguageID)idbytes[5]);
                            }
                            else
                            {
                                Text = $"Switch | 已连接成功 | {id}";
                                GamesModel = "";
                            }
                            Log_Box.Text += ("Switch已连接成功！！\n");
                        }
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

        private void Stop_BTN_Click(object sender, EventArgs e)
        {
            Stop_BTN.Enabled = false;
            InputSwitchIP.ReadOnly = false;

            if (SwitchConnection.Connected)
            {
                SwitchConnection.Disconnect();
                Source.Cancel();
                Source = new CancellationTokenSource();
            }
            Text = "Switch | 已断开连接！！";
            Log_Box.Text += ("Switch已断开连接！！\n");
            Connect_BTN.Enabled = true;
        }

        private async void ReturnMain()
        {
            if (!SwitchConnection.Connected)
            {
                Log_Box.Text += ("Switch未连接，无法返回主世界！！\n");
                return;
            }
            (var Boxvalid, var Boxoffs) = await ValidatePointerAll(Offsets.PortalBoxStatusPointer_SV, token).ConfigureAwait(false);
            if (await IsInBox(Boxoffs, token).ConfigureAwait(false))
            {
                Log_Box.Text += ("交易正在进行中，请在结束后再返回主世界！！\n");
                return;
            }
            (var valid, var offs) = await ValidatePointerAll(Offsets.OverworldPointer_SV, token).ConfigureAwait(false);
            if (!valid)
                return;
            if (await IsOnOverworld(offs, token).ConfigureAwait(false))
            {
                return;
            }

            var attempts = 0;
            var n = 0;
            while (!await IsOnOverworld(offs, token).ConfigureAwait(false))
            {
                attempts++;
                if (attempts < 7)
                {
                    await Click(B, 1_000, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                    await Click(B, 1_000, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                }
                else if (attempts >= 7 && attempts < 15)
                {
                    for (int i = 0; i < 3; i++)
                        await Click(B, 2_500, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                    await Click(A, 2_500, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                }
                else if (attempts >= 15)
                    break;
            }
            if (!await IsOnOverworld(offs, token).ConfigureAwait(false))
            {
                for (int i = 0; i < 10; i++)
                {
                    n++;
                    Log_Box.Text += ($"启动紧急救援程序，第{n}次尝试返回主世界\n");
                    await Click(B, 1_500, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                    await Click(B, 1_500, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                    await Click(B, 1_500, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                    await Click(A, 1_500, token).ConfigureAwait(false);
                    if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                        break;
                }
            }
            if (!await IsOnOverworld(offs, token).ConfigureAwait(false))
            {
                Log_Box.Text += ("无法关闭所有界面，请重新启动游戏。\n");
            }
        }

        private async void CreateTrade_BTN_Click(object sender, EventArgs e)
        {
            if (!SwitchConnection.Connected)
            {
                Log_Box.Text += ("Switch未连接，无法创建交易！！\n");
                return;
            }
            if (Code_Text.Text == "")
            {
                Log_Box.Text += ("未输入连接密码，不可创建交易！！\n");
                return;
            }
            if (GamesModel == "朱紫")
            {
                (var Boxvalid, var Boxoffs) = await ValidatePointerAll(Offsets.PortalBoxStatusPointer_SV, token).ConfigureAwait(false);
                if (await IsInBox(Boxoffs, token).ConfigureAwait(false))
                {
                    Log_Box.Text += ("交易正在进行中，请在结束后再创建！！\n");
                    return;
                }
                await SwitchConnection.PointerPoke(new byte[16], Offsets.LinkTradePartnerNIDPointer_SV, token).ConfigureAwait(false);
                if (tradelink)
                {
                    tradelink = false;
                    for (int i = 0; i < 5; i++)
                        await Click(A, 0_600, token).ConfigureAwait(false);
                }
                else
                {
                    (var valid, var offs) = await ValidatePointerAll(Offsets.OverworldPointer_SV, token).ConfigureAwait(false);
                    if (!valid)
                        return;
                    if (!await IsOnOverworld(offs, token).ConfigureAwait(false))
                    {
                        ReturnMain();
                        await Task.Delay(4_000, token).ConfigureAwait(false);
                    }
                    Log_Box.Text += ("打开宝可站\n");

                    await Click(X, 1_000, token).ConfigureAwait(false);

                    await Click(DRIGHT, 0_300, token).ConfigureAwait(false);
                    await PressAndHold(DDOWN, 1_000, 1_000, token).ConfigureAwait(false);
                    await Click(DUP, 0_200, token).ConfigureAwait(false);
                    await Click(DUP, 0_200, token).ConfigureAwait(false);
                    await Click(DUP, 0_200, token).ConfigureAwait(false);
                    await Click(A, 1_000, token).ConfigureAwait(false);

                    if (!await ConnectToOnline(token).ConfigureAwait(false))
                    {
                        Log_Box.Text += ("无法连接到网络！！\n");
                        return;
                    }
                    if (await SwitchConnection.IsProgramRunning(Offsets.LibAppletWeID, token).ConfigureAwait(false))
                    {
                        Log_Box.Text += ("检测到的新闻，将在加载后关闭!\n");
                        await Task.Delay(5_000, token).ConfigureAwait(false);
                        await Click(B, 2_000, token).ConfigureAwait(false);
                    }
                    await Task.Delay(4_000, token).ConfigureAwait(false);
                    await Click(DDOWN, 0_300, token).ConfigureAwait(false);
                    await Click(DDOWN, 0_300, token).ConfigureAwait(false);
                    await Click(A, 4_000, token).ConfigureAwait(false);

                    await BeginTradeViaCode(Convert.ToInt32(Code_Text.Text), token);

                    await Click(A, 1_000, token).ConfigureAwait(false);
                    await Click(A, 1_000, token).ConfigureAwait(false);
                }

                Log_Box.Text += ("正在搜寻交换对象...\n");
                int ctr = 65_000;
                await Task.Delay(2_000, token).ConfigureAwait(false);
                int end = 0;
                while (ctr > 0)
                {
                    await Task.Delay(1_000, token).ConfigureAwait(false);
                    ctr -= 1_000;
                    end += 1_000;
                    var newNID = await GetTradePartnerNID(token).ConfigureAwait(false);
                    if (newNID != 0)
                    {
                        var tradePartner = await FetchIDFromTradeOffset(token).ConfigureAwait(false);
                        Log_Box.Text += $"找到连接对象: {tradePartner.TrainerName}（{tradePartner.TID:000000}-{tradePartner.SID:0000}）\n" +
                            $"可以开始进行宝可梦交易...\n";
                        TradeInfo_Box.Text = $"交易对象信息：\n" +
                            $"昵称：{tradePartner.TrainerName}\n" +
                            $"表里ID：{tradePartner.TID:000000}-{tradePartner.SID:0000}\n" +
                            $"性别：{(tradePartner.Gender == 0 ? "男" : "女")}\n" +
                            $"语言：{(tradePartner.Language >= 0 && tradePartner.Language < languages.Length ? languages[tradePartner.Language] : $"未知{tradePartner.Language}")}\n" +
                            $"版本：{(tradePartner.Game == 50 ? "朱" : tradePartner.Game == 51 ? "紫" : "未知")}\n" +
                            $"NID：{newNID:X16}";
                        trading = true;
                        ctr = 0;
                    }
                    if (end == 36_000)
                    {
                        Log_Box.Text += ($"未搜索到用户,请重新创建交易！！\n");
                        tradelink = true;
                        return;
                    }
                }
                if (trading)
                    WaitingStop();
            }
            else if (GamesModel == "剑盾")
            {
                (var Boxvalid, var Overworldoffs) = await ValidatePointerAll(Offsets.OverworldPointer_SWSH, token).ConfigureAwait(false);
                if (!await IsConnectedOnline(Overworldoffs, token).ConfigureAwait(false))
                {
                    Log_Box.Text += $"正在返回主世界...\n";
                    while (!await IsConnectedOnline(Overworldoffs, token).ConfigureAwait(false))
                    {
                        for (int i = 0; i < 3; i++)
                            await Click(B, 0_600, token).ConfigureAwait(false);
                        await Click(A, 1_000, token).ConfigureAwait (false);
                    }
                }
                await Click(Y, 2_000, token).ConfigureAwait(false);
                await Click(A, 1_500, token).ConfigureAwait(false);
                await Click(DDOWN, 500, token).ConfigureAwait(false);

                for (int i = 0; i < 2; i++)
                    await Click(A, 1_500, token).ConfigureAwait(false);

                // All other languages require an extra A press at this menu.
                if (GetGameLang() != LanguageID.English && GetGameLang() != LanguageID.Spanish)
                    await Click(A, 1_500, token).ConfigureAwait(false);

                await EnterLinkCode(Convert.ToInt32(Code_Text.Text),0_100, token);
                await Click(PLUS, 1_000, token).ConfigureAwait(false);
                while (!await IsConnectedOnline(Overworldoffs, token).ConfigureAwait(false))
                {
                    for (int i = 0; i < 5; i++)
                        await Click(A, 0_800, token).ConfigureAwait(false);
                }
                Log_Box.Text += $"正在搜寻交换对象(两分钟)...\n";
                var partnerFound = await WaitForTradePartnerOffer(token).ConfigureAwait(false);
                if (!partnerFound)
                {
                    await ResetTradePosition(token).ConfigureAwait(false);
                    Log_Box.Text += $"未找到交换对象...\n";
                    return;
                }
                var data = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNIDOffset_SWSH, 8, CancellationToken.None).ConfigureAwait(false);
                ulong NID = BitConverter.ToUInt64(data, 0);
                var tradePartner = await GetTradePartnerMyStatus_SWSH(CancellationToken.None).ConfigureAwait(false);

                Log_Box.Text += $"找到连接对象: {tradePartner.TrainerName}（{Convert.ToUInt32(tradePartner.TID7):000000}-{Convert.ToUInt32(tradePartner.SID7):0000}）\n" +
                            $"可以开始进行宝可梦交易...\n";
                TradeInfo_Box.Text = $"交易对象信息：\n" +
                    $"昵称：{tradePartner.TrainerName}\n" +
                    $"表里ID：{Convert.ToUInt32(tradePartner.TID7):000000}-{Convert.ToUInt32(tradePartner.SID7):0000}\n" +
                    $"性别：{(tradePartner.Gender == 0 ? "男" : "女")}\n" +
                    $"语言：{(tradePartner.Language >= 0 && tradePartner.Language < languages.Length ? languages[tradePartner.Language] : $"未知{tradePartner.Language}")}\n" +
                    $"版本：{(tradePartner.Game == 44 ? "剑" : tradePartner.Game == 45 ? "盾" : "未知")}\n" +
                    $"NID：{NID:X16}";
                WaitingStop();
            }
            else
            {
                Log_Box.Text += "检测到未启动可支持的游戏！！\n";
            }
        }

        private void EndTrade_BTN_Click(object sender, EventArgs e)
        {
            EndTrade();
            Log_Box.Text += ("交易已结束！！\n");
        }
        private async void EndTrade()
        {
            (var Boxvalid, var Boxoffs) = await ValidatePointerAll(Offsets.PortalBoxStatusPointer_SV, token).ConfigureAwait(false);
            if (!SwitchConnection.Connected || !await IsInBox(Boxoffs, token).ConfigureAwait(false))
            {
                Log_Box.Text += ("当前没有进行交易！！\n");
                trading = false;
                return;
            }
            while (await IsInBox(Boxoffs, token).ConfigureAwait(false))
            {
                for (int i = 0; i < 3; i++)
                    await Click(B, 1_000, token).ConfigureAwait(false);
                await Click(A, 1_000, token).ConfigureAwait(false);
            }
            trading = false;
        }
        private async Task ResetTradePosition(CancellationToken token)
        {
            // Shouldn't ever be used while not on overworld.
            (var Boxvalid, var Overworldoffs) = await ValidatePointerAll(Offsets.OverworldPointer_SWSH, token).ConfigureAwait(false);
            while (!await IsConnectedOnline(Overworldoffs, token).ConfigureAwait(false))
            {
                for (int i = 0; i < 3; i++)
                    await Click(B, 0_600, token).ConfigureAwait(false);
                await Click(A, 1_000, token).ConfigureAwait(false);
            }

            await Click(Y, 2_000, token).ConfigureAwait(false);
            for (int i = 0; i < 5; i++)
                await Click(A, 1_500, token).ConfigureAwait(false);
            // Extra A press for Japanese.
            if (GetGameLang() == LanguageID.Japanese)
                await Click(A, 1_500, token).ConfigureAwait(false);
            await Click(B, 1_500, token).ConfigureAwait(false);
            await Click(B, 1_500, token).ConfigureAwait(false);
        }
        private async Task<bool> ConnectToOnline(CancellationToken token)
        {
            (var valid, var offs) = await ValidatePointerAll(Offsets.IsConnectedPointer_SV, token).ConfigureAwait(false);
            if (!valid)
                return false;
            if (await IsConnectedOnline(offs, token).ConfigureAwait(false))
                return true;

            await Click(L, 5_000, token).ConfigureAwait(false);

            var wait = 0;
            while (!await IsConnectedOnline(offs, token).ConfigureAwait(false))
            {
                await Task.Delay(0_500, token).ConfigureAwait(false);
                if (++wait > 30) // More than 15 seconds without a connection.
                    return false;
            }

            // There are several seconds after connection is established before we can dismiss the menu.
            await Task.Delay(3_000, token).ConfigureAwait(false);
            await Click(A, 1_000, token).ConfigureAwait(false);
            return true;
        }
        private void Code_Text_TextChanged(object sender, EventArgs e)
        {
            tradelink = false;
            if (Code_Text.Text.Length > 8)
            {
                Code_Text.Text = Code_Text.Text.Substring(0, 8);
                Code_Text.SelectionStart = Code_Text.Text.Length;
            }
            Settings.Default.teadecode = Code_Text.Text;
            Settings.Default.Save();
        }
        private void PKM_CheckBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
                return;
            OpenQuick(files[0]);
            e.Effect = DragDropEffects.Copy;
        }

        private void PKM_CheckBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e is null)
                return;
            if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link)) // external file
                e.Effect = DragDropEffects.Copy;
            else if (e.Data != null) // within
                e.Effect = DragDropEffects.Copy;
        }

        private void Clear_BTN_Click(object sender, EventArgs e)
        {
            j = 0;
            BD.Clear();
            PKM_CheckBox.Items.Clear();
        }

        private void ReadList_BTN_Click(object sender, EventArgs e)
        {
            BD = PKM_CheckBox.CheckedItems.OfType<PKM>().ToList();
            BD.RemoveAll(s => s.Species == 0);
            n = BD.Count;
            Log_Box.Text += $"{BD.Count}个宝可梦已加载\n";
        }

        private void StartTrade_BTN_Click(object sender, EventArgs e)
        {
            if (ContinuousTrade_Check.Checked)
                ContinuousTrade();
            else
                SoloTrade();
        }
        private async void SoloTrade()
        {
            if (j < n)
            {
                var tradePartnerNID = await GetTradePartnerNID(token).ConfigureAwait(false);
                var tradePartner = await FetchIDFromTradeOffset(token).ConfigureAwait(false);
                tradePartner.NSAID = tradePartnerNID;
                PK9 offered = (PK9)BD[0];
                if (BD.Count != 0)
                {
                    await SwitchConnection.PointerPoke(BD[j].EncryptedBoxData, Offsets.BoxStartPokemonPointer_SV, token).ConfigureAwait(false);

                    if (ID_CheckBox.Checked)
                    {
                        await SetBoxPkmWithSwappedIDDetailsSV(BD[j], tradePartner, token);
                    }
                    await Task.Delay(1_500).ConfigureAwait(false);
                    Log_Box.Text += $"正在交换第{j + 1}只宝可梦，{GameInfo.GetStrings("zh").Species[BD[j].Species]}\n";

                    for (int i = 0; i < 5; i++)
                        await Click(A, 1_000, token).ConfigureAwait(false);
                    offered = await ReadUntilPresentPointer(Offsets.LinkTradePartnerPokemonPointer_SV, 600_000, 1_000, 0x158, token).ConfigureAwait(false);
                    if (offered == null || offered.Species < 1 || !offered.ChecksumValid)
                    {
                        Log_Box.Text += $"对方没有提供有效的宝可梦\n";
                    }
                    else
                    {
                        Log_Box.Text += ("正在确认交换...\n");
                        if (await ConfirmAndStartTrading(token).ConfigureAwait(false))
                        {
                            Log_Box.Text += $"{GameInfo.GetStrings("zh").Species[BD[j].Species]}交换完成！\n";
                            j++;
                        }
                        else
                        {
                            Log_Box.Text += ("交易失败：可能因为网络或其他原因\n");
                            Log_Box.Text += ("正在结束交易...\n");
                            (var valid, var offs) = await ValidatePointerAll(Offsets.OverworldPointer_SV, token).ConfigureAwait(false);
                            int ns = 0;
                            while (!await IsOnOverworld(offs, token).ConfigureAwait(false))
                            {
                                ns++;
                                await Click(B, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                await Click(B, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                await Click(B, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                await Click(A, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                if (ns > 10)
                                    break;
                            }
                            Log_Box.Text += ("请重新创建交易继续交换！！\n");
                        }
                    }
                }
            }
            else
            {
                Log_Box.Text += "注意，队列空了！！";
            }
            WaitingStop();
        }

        private async void ContinuousTrade()
        {
            var tradePartnerNID = await GetTradePartnerNID(token).ConfigureAwait(false);
            var tradePartner = await FetchIDFromTradeOffset(token).ConfigureAwait(false);
            tradePartner.NSAID = tradePartnerNID;

            int counting = 0;
            if (BD.Count != 0)
            {
                PK9 offered;
                foreach (var send in BD)
                {
                    counting++;
                    Log_Box.Text += $"正在交换第{counting}只宝可梦，{GameInfo.GetStrings("zh").Species[send.Species]}\n";
                    await SwitchConnection.PointerPoke(send.EncryptedBoxData, Offsets.BoxStartPokemonPointer_SV, token).ConfigureAwait(false);
                    if (ID_CheckBox.Checked)
                    {
                        await SetBoxPkmWithSwappedIDDetailsSV(send, tradePartner, token);
                    }
                    await Task.Delay(2_000, token).ConfigureAwait(false);
                    offered = await ReadUntilPresentPointer(Offsets.LinkTradePartnerPokemonPointer_SV, 600_000, 1_000, 0x158, token).ConfigureAwait(false);
                    if (offered == null || offered.Species < 1 || !offered.ChecksumValid)
                    {
                        Log_Box.Text += $"对方没有提供有效的宝可梦\n";
                    }
                    else
                    {
                        Log_Box.Text += "正在确认交换...\n";
                        if (await ConfirmAndStartTrading(token).ConfigureAwait(false))
                        {
                            Log_Box.Text += $"{GameInfo.GetStrings("zh").Species[send.Species]}交换完成！\n";
                        }
                        else
                        {
                            Log_Box.Text += "交易失败：可能因为网络或其他原因\n";
                            Log_Box.Text += "正在结束交易...\n";
                            (var valid, var offs) = await ValidatePointerAll(Offsets.OverworldPointer_SV, token).ConfigureAwait(false);
                            int ns = 0;
                            while (!await IsOnOverworld(offs, token).ConfigureAwait(false))
                            {
                                ns++;
                                await Click(B, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                await Click(B, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                await Click(B, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                await Click(A, 1_500, token).ConfigureAwait(false);
                                if (await IsOnOverworld(offs, token).ConfigureAwait(false))
                                    break;
                                if (ns > 10)
                                    break;
                            }
                            Log_Box.Text += ("请重新创建交易继续交换！！\n");
                        }
                    }
                }
                Log_Box.Text += ("宝可梦交易完成，可继续添加宝可梦交换！！\n");
            }
            else
            {
                Log_Box.Text += "注意，交换队列是空的！！\n";
            }
            WaitingStop();
        }
        private async void WaitingStop()
        {
            int times = 600_000;
            while (true)
            {
                await Task.Delay(1_000, token).ConfigureAwait(false);
                times -= 1_000;
                if (times <= 0)
                {
                    EndTrade();
                    Log_Box.Text += "由于长时间未交易，已经断开与交易对象的连接！！\n";
                    break;
                }
            }
        }

        private async Task<PKM> SetBoxPkmWithSwappedIDDetailsSV(PKM toSend, TradePartnerSV tradePartner, CancellationToken token)
        {
            var cln = (PK9)toSend.Clone();
            cln.OriginalTrainerGender = tradePartner.Gender;
            cln.DisplayTID = (uint)Math.Abs(tradePartner.TID7);
            cln.DisplaySID = (uint)Math.Abs(tradePartner.SID7);
            cln.Language = tradePartner.Language;
            cln.OriginalTrainerName = tradePartner.TrainerName;
            if (cln.IsEgg == false)
            {
                if (cln.Species == (short)Species.Koraidon)
                {
                    cln.Version = GameVersion.SL;
                    // Log($"故勒顿，强制修改版本为朱");

                }
                else if (cln.Species == (short)Species.Miraidon)
                {
                    cln.Version = GameVersion.VL;
                    //  Log($"密勒顿，强制修改版本为紫");
                }
                //   else
                // {
                //    cln.Version = tradePartner.Game;
                //  }
                cln.ClearNickname();
            }
            else
            {
                cln.IsNicknamed = true;
                cln.Nickname = tradePartner.Language switch
                {
                    1 => "タマゴ",
                    3 => "Œuf",
                    4 => "Uovo",
                    5 => "Ei",
                    7 => "Huevo",
                    8 => "알",
                    9 or 10 => "蛋",
                    _ => "Egg",
                };
                Log_Box.Text += $"是蛋,修改昵称\n";
            }

            if (toSend.MetLocation == Locations.TeraCavern9 && toSend.IsShiny)
            {
                cln.PID = (((uint)(cln.TID16 ^ cln.SID16) ^ (cln.PID & 0xFFFF) ^ 1u) << 16) | (cln.PID & 0xFFFF);
            }
            else if (toSend.IsShiny)
                cln.SetShiny();

            cln.RefreshChecksum();
            await SwitchConnection.PointerPoke(cln.EncryptedBoxData, Offsets.BoxStartPokemonPointer_SV, token).ConfigureAwait(false);
            return cln;
        }
        #region //按键底层
        protected virtual async Task<bool> WaitForTradePartnerOffer(CancellationToken token)
        {
            return await WaitForPokemonChanged(Offsets.LinkTradePartnerPokemonOffset_SWSH, 120_000, 0_200, token).ConfigureAwait(false);
        }
        private async Task<bool> WaitForPokemonChanged(uint offset, int waitms, int waitInterval, CancellationToken token)
        {
            // check EC and checksum; some pkm may have same EC if shown sequentially
            var oldEC = await SwitchConnection.ReadBytesAsync(offset, 8, token).ConfigureAwait(false);
            return await ReadUntilChanged(offset, oldEC, waitms, waitInterval, false, token).ConfigureAwait(false);
        }
        public async Task<bool> ReadUntilChanged(ulong offset, byte[] comparison, int waitms, int waitInterval, bool match, CancellationToken token)
        {
            Log_Box.Text += $"正在等待连接...\n";
            var sw = new Stopwatch();
            sw.Start();
            do
            {
                var task = false
                    ? SwitchConnection.ReadBytesAbsoluteAsync(offset, comparison.Length, token)
                    : SwitchConnection.ReadBytesAsync((uint)offset, comparison.Length, token);
                var result = await task.ConfigureAwait(false);
                if (match == result.SequenceEqual(comparison))
                    return true;

                await Task.Delay(waitInterval, token).ConfigureAwait(false);
            } while (sw.ElapsedMilliseconds < waitms);
            return false;
        }
        public async Task<bool> IsInBox(ulong offset, CancellationToken token)
        {
            if (GamesModel == "剑盾")
            {
                var data = await SwitchConnection.ReadBytesAsync(Offsets.CurrentScreenOffset, 4, token).ConfigureAwait(false);
                var dataint = BitConverter.ToUInt32(data, 0);
                return dataint is Offsets.CurrentScreen_Box1 or Offsets.CurrentScreen_Box2;
            }
            else
            {
                var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 1, token).ConfigureAwait(false);
                return data[0] == 0x14;
            }
        }
        public async Task<bool> IsOnOverworld(ulong offset, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 1, token).ConfigureAwait(false);
            return data[0] == 0x11;
        }
        public async Task<bool> IsConnectedOnline(ulong offset, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 1, token).ConfigureAwait(false);
            return data[0] == 1;
        }
        public async Task Click(SwitchButton b, int delay, CancellationToken token)
        {
            await SwitchConnection.SendAsync(SwitchCommand.Click(b), token).ConfigureAwait(false);
            await Task.Delay(delay, token).ConfigureAwait(false);
        }
        public async Task PressAndHold(SwitchButton b, int hold, int delay, CancellationToken token)
        {
            await SwitchConnection.SendAsync(SwitchCommand.Hold(b), token).ConfigureAwait(false);
            await Task.Delay(hold, token).ConfigureAwait(false);
            await SwitchConnection.SendAsync(SwitchCommand.Release(b), token).ConfigureAwait(false);
            await Task.Delay(delay, token).ConfigureAwait(false);
        }
        protected async Task<(bool, ulong)> ValidatePointerAll(IEnumerable<long> jumps, CancellationToken token)
        {
            var solved = await SwitchConnection.PointerAll(jumps, token).ConfigureAwait(false);
            return (solved != 0, solved);
        }
        private async Task<bool> BeginTradeViaCode(int tradeCode, CancellationToken token)
        {

            Log_Box.Text += ($"输入交换密码: {tradeCode:0000 0000}...\n");

            await Click(X, 1_000, token).ConfigureAwait(false);
            await Click(PLUS, 1_000, token).ConfigureAwait(false);

            await Task.Delay(1000, token).ConfigureAwait(false);

            var keys = TradeUtil.GetPresses(tradeCode);
            foreach (var key in keys)
            {
                await Click(key, 0_100, token).ConfigureAwait(false);
            }

            await Click(PLUS, 1_000, token).ConfigureAwait(false);
            return true;
        }
        protected virtual async Task EnterLinkCode(int code, int delay, CancellationToken token)
        {
            // Default implementation to just press directional arrows. Can do via Hid keys, but users are slower than bots at even the default code entry.
            var keys = TradeUtil.GetPresses(code);
            foreach (var key in keys)
            {
                await Click(key, delay, token).ConfigureAwait(false);
            }
            // Confirm Code outside of this method (allow synchronization)
        }
        #endregion
        #region//存文件
        private void OpenQuick(string path)
        {
            if (!CanFocus)
            {
                SystemSounds.Asterisk.Play();
                return;
            }
            var fi = new FileInfo(path);
            if (!fi.Exists)
                return;
            byte[] input;
            input = File.ReadAllBytes(path);
            int num = input.Length;
            var pkms = ArrayUtil.EnumerateSplit(input, num);
            if (LoadFile(pkms, path))
                return;
        }
        private bool LoadFile(object? input, string path)
        {
            if (input == null)
            {
                return false;
            }
            switch (input)
            {
                case PKM pk: return OpenPKM(pk);
                case IEnumerable<byte[]> pkms: return OpenPCBoxBin(pkms);
            }
            return false;
        }
        private bool OpenPKM(PKM pk)
        {
            var destType = SAV.SAV.PKMType;
            var tmp = EntityConverter.ConvertToType(pk, destType, out var c);
            Debug.WriteLine(c.GetDisplayString(pk, destType));
            if (tmp == null)
                return false;
            SAV.SAV.AdaptPKM(tmp);
            PKM_CheckBox.Items.Add(pk, CheckState.Checked);
            return true;
        }
        protected PKM GetPKM(byte[] data) => new PK9(data);
        private bool OpenPCBoxBin(IEnumerable<byte[]> pkms)
        {
            var data = pkms.SelectMany(z => z).ToArray();
            var entryLength = 0x158;
            var pkdata = ArrayUtil.EnumerateSplit(data, entryLength, 0);
            if (pkdata != null)
            {
                BD = pkdata.Select(GetPKM).ToList();
            }

            if (BD.Count != 0)
            {
                for (int i = 0; i < BD.Count; i++)
                    PKM_CheckBox.Items.Add(BD[i], CheckState.Checked);
            }
            return true;
        }
        #endregion
        #region//读指针 
        public async Task<ulong> GetTradePartnerNID(CancellationToken token) => BitConverter.ToUInt64(await SwitchConnection.PointerPeek(sizeof(ulong), Offsets.LinkTradePartnerNIDPointer_SV, token).ConfigureAwait(false), 0);
        public async Task<TradePartnerSV> FetchIDFromTradeOffset(CancellationToken token)
        {
            // find which one is populated
            ulong offs = await SwitchConnection.PointerAll(Offsets.Trader1MyStatusPointer_SV, token).ConfigureAwait(false);
            var idCheck = BitConverter.ToUInt32(await SwitchConnection.ReadBytesAbsoluteAsync(offs, 4, token).ConfigureAwait(false), 0);

            if (idCheck == 0 || idCheck == OurTrainer.IDHash)
                offs = await SwitchConnection.PointerAll(Offsets.Trader2MyStatusPointer_SV, token).ConfigureAwait(false);

            var id = await SwitchConnection.ReadBytesAbsoluteAsync(offs, 4, token).ConfigureAwait(false);
            var name = await SwitchConnection.ReadBytesAbsoluteAsync(offs + 0x8, 0x18, token).ConfigureAwait(false);
            var idbytes = await SwitchConnection.ReadBytesAbsoluteAsync(offs + 0x04, 4, token).ConfigureAwait(false);
            byte[] idbytesNew = new byte[] { idbytes[0], idbytes[1], idbytes[3], idbytes[2] };
            return new TradePartnerSV(id, idbytesNew, name);
        }
        private async Task<TradePartnerSWSH> GetTradePartnerMyStatus_SWSH(CancellationToken token)
        {
            var id = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH - 0x8, 8, token).ConfigureAwait(false);
            var name = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH, TradePartnerSWSH.MaxByteLengthStringObject, token).ConfigureAwait(false);
            var idbytes = await SwitchConnection.ReadBytesAsync(Offsets.LinkTradePartnerNameOffset_SWSH - 0x8, 8, token).ConfigureAwait(false);

            return new TradePartnerSWSH(id, name, idbytes);
        }
        public async Task<PK9> ReadUntilPresentPointer(IReadOnlyList<long> jumps, int waitms, int waitInterval, int size, CancellationToken token)
        {
            int msWaited = 0;
            while (msWaited < waitms)
            {
                var pk = await ReadPokemonPointer(jumps, size, token).ConfigureAwait(false);
                if (pk.Species != 0 && pk.ChecksumValid)
                    return pk;
                await Task.Delay(waitInterval, token).ConfigureAwait(false);
                msWaited += waitInterval;
            }
            return null;
        }
        public async Task<PK9> ReadPokemonPointer(IEnumerable<long> jumps, int size, CancellationToken token)
        {
            var (valid, offset) = await ValidatePointerAll(jumps, token).ConfigureAwait(false);
            if (!valid)
                return new PK9();
            return await ReadPokemon(offset, 0x158, token).ConfigureAwait(false);
        }
        public async Task<PK9> ReadPokemon(ulong offset, int size, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, size, token).ConfigureAwait(false);
            return new PK9(data);
        }
        private async Task<bool> ConfirmAndStartTrading(CancellationToken token)
        {
            var BoxStartOffset = await SwitchConnection.PointerAll(Offsets.BoxStartPokemonPointer_SV, token).ConfigureAwait(false);
            // We'll keep watching B1S1 for a change to indicate a trade started -> should try quitting at that point.
            var oldEC = await SwitchConnection.ReadBytesAbsoluteAsync(BoxStartOffset, 8, token).ConfigureAwait(false);
            await Click(A, 3_000, token).ConfigureAwait(false);
            for (int i = 0; i < 60; i++)
            {
                await Click(A, 1_000, token).ConfigureAwait(false);

                // EC is detectable at the start of the animation.
                var newEC = await SwitchConnection.ReadBytesAbsoluteAsync(BoxStartOffset, 8, token).ConfigureAwait(false);
                if (!newEC.SequenceEqual(oldEC))
                {
                    await Task.Delay(25_000, token).ConfigureAwait(false);
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
