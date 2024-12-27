using MK_Plugins.Properties;
using PKHeX.Core;
using static MK_Plugins.PulginsGUI.MK_TradePartnerViewerForm;

namespace MK_Plugins.PulginsGUI
{
    public partial class MK_GenerateMoveIndexForm : Form
    {
        public BOX BoxIndex = BOX.ONE;
        private ISaveFileProvider? SAV { get; }
        private IPKMView? Editor { get; }

        private string avatarPath = "";

        public string GetAvatarPath()
        {
            return avatarPath;
        }

        public void SetAvatarPath(string value)
        {
            avatarPath = value;
        }

        private bool _isOtherMode = false;
        public MK_GenerateMoveIndexForm(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            Text = "PS网页字典生成器";
            InitializeComponent();
        }

        private void Generate_Button_Click(object sender, EventArgs e)
        {
            if (_isOtherMode)
            {
                if (OtherMode_comboBox.SelectedIndex == 0)
                    GenerateItem();
                else if (OtherMode_comboBox.SelectedIndex == 1)
                    GenerateAbility();
                else if (OtherMode_comboBox.SelectedIndex == 2)
                    GenerateMove();
            }
            else
                GeneratePKM();
        }
        private void GenerateItem()
        {
            string item = "var pk_items = [\n";
            var filtered = GameInfo.FilteredSources.Items;
            var itemList_en = GameInfo.GetStrings("en").itemlist;
            var itemList_zh = GameInfo.GetStrings("zh").itemlist;
            List<int> numbers = new List<int> { };
            foreach (var filter in filtered)
            {
                numbers.Add(filter.Value);
            }
            numbers.Sort();
            for (int i = 0; i < numbers.Count; i++)
            {
                var itemValue = numbers[i];
                if (i == numbers.Count - 1)
                {
                    item += $"[\"{itemList_zh[itemValue]}\", \"{itemList_en[itemValue]}\"]";
                    break;
                }
                item += $"[\"{itemList_zh[itemValue]}\", \"{itemList_en[itemValue]}\"],\n";
            }
            item += "];";
            MoveIndex_Box.Text = $"{item}\n";
        }
        private void GenerateAbility()
        {
            string ability = "var pk_ablilities = [\n";
            var abilityList_en = GameInfo.GetStrings("en").abilitylist;
            var abilityList_zh = GameInfo.GetStrings("zh").abilitylist;
            for (int i = 0; i < abilityList_en.Length; i++)
            {
                if (i == abilityList_en.Length - 1)
                {
                    ability += $"[\"{abilityList_zh[i]}\", \"{abilityList_en[i]}\"]";
                    break;
                }
                ability += $"[\"{abilityList_zh[i]}\", \"{abilityList_en[i]}\"],\n";
            }
            ability += "];";
            MoveIndex_Box.Text = $"{ability}\n";
        }
        private void GenerateMove()
        {
            string move = "var pk_moves = [\n";
            var moveList_en = GameInfo.GetStrings("en").movelist;
            var moveList_zh = GameInfo.GetStrings("zh").movelist;
            for (int i = 0; i < moveList_en.Length; i++)
            {
                if (i == moveList_en.Length - 1)
                {
                    move += $"[\"{moveList_zh[i]}\", \"{moveList_en[i]}\"]";
                    break;
                }
                move += $"[\"{moveList_zh[i]}\", \"{moveList_en[i]}\"],\n";
            }
            move += "];";
            MoveIndex_Box.Text = $"{move}\n";
        }
        private void GeneratePKM()
        {
            string pkmString = "var pk_species = {\n";
            int n = SAV.CurrentBox;
            PKM[] PKL = SAV.SAV.GetBoxData(n);
            for (int i = 0; i < PKL.Count(); i++)
            {
                var pk = PKL[i];
                if (pk.Species == 0)
                    continue;
                var tableHeader = GetTableHeader(pk, pk.Form, out int formLength, out string formName);
                if (formLength > 1)
                {
                    for (int j = 0; j < formLength; j++)
                    {
                        pk.Form = (byte)j;
                        tableHeader = GetTableHeader(pk, j, out formLength, out formName);

                        var moveIndexs = GetMovesIndex(pk);
                        var genderIndex = GetGenderIndex(pk);
                        var abilityIndex = GetAbilityIndex(pk);
                        pkmString += $"{tableHeader}:" +
                            $"[\"{GameInfo.GetStrings("zh").Species[pk.Species]}-{formName}\"," +
                            $"{genderIndex}," +
                            $"{abilityIndex}," +
                            $"{moveIndexs}" +
                            $"],\n";
                    }
                }
                else
                {
                    var moveIndexs = GetMovesIndex(pk);
                    var genderIndex = GetGenderIndex(pk);
                    var abilityIndex = GetAbilityIndex(pk);
                    pkmString += $"{tableHeader}:" +
                        $"[\"{GameInfo.GetStrings("zh").Species[pk.Species]}\"," +
                        $"{genderIndex}," +
                        $"{abilityIndex}," +
                        $"{moveIndexs}" +
                        $"],\n";
                }

                PKL[i] = pk;
            }
            pkmString = pkmString.TrimEnd('\n', ',') + "\n};";
            MoveIndex_Box.Text = pkmString;
            if (PKL.Count() != 0)
            {
                SAV.SAV.SetBoxData(PKL, n);
            }
            SAV.ReloadSlots();
        }
        private string GetImageName()
        {
            if (GetAvatarPath() == "")
                return "";
            string result = "";
            string[] fileNames = Directory.GetFiles(GetAvatarPath());
            foreach (string fileName in fileNames)
            {

            }
            return result;
        }
        private string GetTableHeader(PKM pk, int formIndex, out int formLength, out string formName)
        {
            string result = "\"";
            formName = "";
            var str = GameInfo.Strings;
            var speciesName = GameInfo.GetStrings("en").Species[pk.Species];
            var forms_en = FormConverter.GetFormList(pk.Species, str.types, GameInfo.GetStrings("en").forms, GameInfo.GenderSymbolUnicode, pk.Context);
            var forms_zh = FormConverter.GetFormList(pk.Species, str.types, GameInfo.GetStrings("zh").forms, GameInfo.GenderSymbolUnicode, pk.Context);
            formLength = forms_en.Length;
            if (formLength > 1)
            {
                formName = forms_zh[formIndex];
                result += speciesName + "-" + forms_en[formIndex];
            }
            else
                result += speciesName;
            result += "\"";
            return result;
        }
        private string GetGenderIndex(PKM pk)
        {
            string result = "";
            var isDual = SAV.SAV.Personal[pk.Species].IsDualGender;
            if (isDual)
            {
                result = "127";
            }
            else
            {
                switch (pk.Gender)
                {
                    case 0:
                        result = "0";
                        break;
                    case 1:
                        result = "254";
                        break;
                    case 2:
                        result = "255";
                        break;
                }
            }
            return result;
        }
        private string GetAbilityIndex(PKM pk)
        {
            string result = "[";
            var abilityList = GameInfo.FilteredSources.GetAbilityList(pk);
            for (int i = 0; i < abilityList.Count; i++)
            {
                var ability = abilityList[i];
                result += ability.Value + ",";
            }
            result = result.TrimEnd(',');
            result += "]";
            return result;
        }
        private string GetMovesIndex(PKM pk)
        {
            string result = "[";
            if (pk is ITechRecord Record)
            {
                Record.ClearRecordFlags();
                Record.SetRecordFlagsAll(true, Record.Permit.RecordCountUsed);
                pk.SetMove(1, 0);
                pk.SetMove(2, 0);
                pk.SetMove(3, 0);
                for (ushort j = 1; j < 921; j++)
                {
                    pk.SetMove(0, j);
                    var la = new LegalityAnalysis(pk);
                    var check = la.Info.Moves;
                    if (check[0].Valid)
                    {
                        result += j + ",";
                    }
                }
            }
            result = result.TrimEnd(',');
            result += "]";
            return result;
        }

        private void Copy_Button_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MoveIndex_Box.Text);
            MessageBox.Show("已复制到剪贴板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BrowsePath_Button_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                avatarPath_TextBox.Text = folderDialog.SelectedPath;
                SetAvatarPath(folderDialog.SelectedPath);
            }
        }

        private void pkInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherMode_comboBox.Visible = false;
            avatarPath_TextBox.Visible = true;
            BrowsePath_Button.Visible = true;
            pkInfoToolStripMenuItem.Visible = false;
            OtherMode_TSMI.Visible = true;
            _Label.Text = "头像文件夹:";
            _isOtherMode = false;
        }

        private void OtherMode_TSMI_Click(object sender, EventArgs e)
        {
            OtherMode_comboBox.Visible = true;
            avatarPath_TextBox.Visible = false;
            BrowsePath_Button.Visible = false;
            pkInfoToolStripMenuItem.Visible = true;
            OtherMode_TSMI.Visible = false;
            _Label.Text = " 选择模式:";
            _isOtherMode = true;
            OtherMode_comboBox.SelectedIndex = 0;
        }
    }
}
