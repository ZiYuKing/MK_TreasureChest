using MK_Plugins.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MK_Plugins.Subforms
{
    public partial class SettingEditor : Form
    {
        List<int> seenValues = new List<int>() {76, 75, 73, 74, 85, 69, 79, 81, 77, 90, 70, 72, 87, 83, 65, 68, 66, 86 };
        public SettingEditor()
        {
            InitializeComponent();
            KeyPreview = true; // 启用窗体的键盘事件预览
            Key_A.Text = ConvertKeyCode(Settings.Default.Key_A);
            Key_B.Text = ConvertKeyCode(Settings.Default.Key_B);
            Key_X.Text = ConvertKeyCode(Settings.Default.Key_X);
            Key_Y.Text = ConvertKeyCode(Settings.Default.Key_Y);
            Key_R.Text = ConvertKeyCode(Settings.Default.Key_R);
            Key_L.Text = ConvertKeyCode(Settings.Default.Key_L);
            Key_ZR.Text = ConvertKeyCode(Settings.Default.Key_ZR);
            Key_ZL.Text = ConvertKeyCode(Settings.Default.Key_ZL);
            Key_RSTICK.Text = ConvertKeyCode(Settings.Default.Key_RSTICK);
            Key_LSTICK.Text = ConvertKeyCode(Settings.Default.Key_LSTICK);
            Key_PLUS.Text = ConvertKeyCode(Settings.Default.Key_PLUS);
            Key_MINUS.Text = ConvertKeyCode(Settings.Default.Key_MINUS);
            Key_DUP.Text = ConvertKeyCode(Settings.Default.Key_DUP);
            Key_DDOWN.Text = ConvertKeyCode(Settings.Default.Key_DDOWN);
            Key_DLEFT.Text = ConvertKeyCode(Settings.Default.Key_DLEFT);
            Key_DRIGHT.Text = ConvertKeyCode(Settings.Default.Key_DRIGHT);
            Key_HOME.Text = ConvertKeyCode(Settings.Default.Key_HOME);
            Key_CAPTURE.Text = ConvertKeyCode(Settings.Default.Key_CAPTURE);

        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            SavePath_TextBox.Text = Settings.Default.ImagePath;
        }

        private void BrowsePath_BTN_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                SavePath_TextBox.Text = folderDialog.SelectedPath;
                Settings.Default.ImagePath = folderDialog.SelectedPath;
                MessageBox.Show("修改完成！！");
            }
        }
        private string ConvertKeyCode(int keyValue)
        {
            if (Enum.IsDefined(typeof(Keys), keyValue) && keyValue != 0)
            {
                Keys keyCode = (Keys)keyValue;
                return keyCode.ToString();
            }
            else
            {
                return "";
            }
        }
        private void KeyCodes(object sender, KeyEventArgs e)
        {
            if (seenValues.Contains(e.KeyValue))
            {
                MessageBox.Show($"按键{ConvertKeyCode(e.KeyValue)}已被使用！！");
                return;
            }
            TextBox textBox = (TextBox)sender;
            var currentKeyCode = e.KeyCode;
            textBox.Text = currentKeyCode.ToString();
            e.Handled = true;
            e.SuppressKeyPress = true;
            switch (textBox.Name)
            {
                case "Key_A":
                    Settings.Default.Key_A = e.KeyValue;
                    break;
                case "Key_B":
                    Settings.Default.Key_B = e.KeyValue;
                    break;
                case "Key_X":
                    Settings.Default.Key_X = e.KeyValue;
                    break;
                case "Key_Y":
                    Settings.Default.Key_Y = e.KeyValue;
                    break;
                case "Key_R":
                    Settings.Default.Key_R = e.KeyValue;
                    break;
                case "Key_L":
                    Settings.Default.Key_L = e.KeyValue;
                    break;
                case "Key_ZR":
                    Settings.Default.Key_ZR = e.KeyValue;
                    break;
                case "Key_ZL":
                    Settings.Default.Key_ZL = e.KeyValue;
                    break;
                case "Key_RSTICK":
                    Settings.Default.Key_RSTICK = e.KeyValue;
                    break;
                case "Key_LSTICK":
                    Settings.Default.Key_LSTICK = e.KeyValue;
                    break;
                case "Key_PLUS":
                    Settings.Default.Key_PLUS = e.KeyValue;
                    break;
                case "Key_MINUS":
                    Settings.Default.Key_MINUS = e.KeyValue;
                    break;
                case "Key_DUP":
                    Settings.Default.Key_DUP = e.KeyValue;
                    break;
                case "Key_DDOWN":
                    Settings.Default.Key_DDOWN = e.KeyValue;
                    break;
                case "Key_DLEFT":
                    Settings.Default.Key_DLEFT = e.KeyValue;
                    break;
                case "Key_DRIGHT":
                    Settings.Default.Key_DRIGHT = e.KeyValue;
                    break;
                case "Key_HOME":
                    Settings.Default.Key_HOME = e.KeyValue;
                    break;
                case "Key_CAPTURE":
                    Settings.Default.Key_CAPTURE = e.KeyValue;
                    break;
                default:
                    break;
            }
        }
        private void Key_A_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_B_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_X_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_Y_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_R_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_L_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_ZR_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_ZL_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_RSTICK_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_LSTICK_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_PLUS_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_MINUS_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_DUP_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_DDOWN_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_DLEFT_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_DRIGHT_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_HOME_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void Key_CAPTURE_KeyDown(object sender, KeyEventArgs e) => KeyCodes(sender, e);

        private void SaveKey_BTN_Click(object sender, EventArgs e)
        {

            Settings.Default.Save();
            seenValues.Clear();
            seenValues.Add(Settings.Default.Key_A);
            seenValues.Add(Settings.Default.Key_B);
            seenValues.Add(Settings.Default.Key_X);
            seenValues.Add(Settings.Default.Key_Y);
            seenValues.Add(Settings.Default.Key_R);
            seenValues.Add(Settings.Default.Key_L);
            seenValues.Add(Settings.Default.Key_ZR);
            seenValues.Add(Settings.Default.Key_ZL);
            seenValues.Add(Settings.Default.Key_RSTICK);
            seenValues.Add(Settings.Default.Key_LSTICK);
            seenValues.Add(Settings.Default.Key_PLUS);
            seenValues.Add(Settings.Default.Key_MINUS);
            seenValues.Add(Settings.Default.Key_DUP);
            seenValues.Add(Settings.Default.Key_DDOWN);
            seenValues.Add(Settings.Default.Key_DLEFT);
            seenValues.Add(Settings.Default.Key_DRIGHT);
            seenValues.Add(Settings.Default.Key_HOME);
            seenValues.Add(Settings.Default.Key_CAPTURE);
            MessageBox.Show("热键已保存！！");
        }

        private void EnableKeys_BTN_Click(object sender, EventArgs e)
        {
            if (EnableKeys_BTN.Text == "启用热键")
            {
                Settings.Default.KeyBool = true;
                EnableKeys_BTN.Text = "关闭热键";
            }
            else if (EnableKeys_BTN.Text == "关闭热键")
            {
                Settings.Default.KeyBool = false;
                EnableKeys_BTN.Text = "启用热键";
            }
            Settings.Default.Save();
        }

        private void ResetKeys_BTN_Click(object sender, EventArgs e)
        {
            Settings.Default.Key_A = 76;
            Settings.Default.Key_B = 75;
            Settings.Default.Key_X = 73;
            Settings.Default.Key_Y = 74;
            Settings.Default.Key_R = 85;
            Settings.Default.Key_L = 69;
            Settings.Default.Key_ZR = 79;
            Settings.Default.Key_ZL = 81;
            Settings.Default.Key_RSTICK = 77;
            Settings.Default.Key_LSTICK = 90;
            Settings.Default.Key_PLUS = 70;
            Settings.Default.Key_MINUS = 72;
            Settings.Default.Key_DUP = 87;
            Settings.Default.Key_DDOWN = 83;
            Settings.Default.Key_DLEFT = 65;
            Settings.Default.Key_DRIGHT = 68;
            Settings.Default.Key_HOME = 66;
            Settings.Default.Key_CAPTURE = 86;
            Settings.Default.Save();
            Key_A.Text = ConvertKeyCode(Settings.Default.Key_A);
            Key_B.Text = ConvertKeyCode(Settings.Default.Key_B);
            Key_X.Text = ConvertKeyCode(Settings.Default.Key_X);
            Key_Y.Text = ConvertKeyCode(Settings.Default.Key_Y);
            Key_R.Text = ConvertKeyCode(Settings.Default.Key_R);
            Key_L.Text = ConvertKeyCode(Settings.Default.Key_L);
            Key_ZR.Text = ConvertKeyCode(Settings.Default.Key_ZR);
            Key_ZL.Text = ConvertKeyCode(Settings.Default.Key_ZL);
            Key_RSTICK.Text = ConvertKeyCode(Settings.Default.Key_RSTICK);
            Key_LSTICK.Text = ConvertKeyCode(Settings.Default.Key_LSTICK);
            Key_PLUS.Text = ConvertKeyCode(Settings.Default.Key_PLUS);
            Key_MINUS.Text = ConvertKeyCode(Settings.Default.Key_MINUS);
            Key_DUP.Text = ConvertKeyCode(Settings.Default.Key_DUP);
            Key_DDOWN.Text = ConvertKeyCode(Settings.Default.Key_DDOWN);
            Key_DLEFT.Text = ConvertKeyCode(Settings.Default.Key_DLEFT);
            Key_DRIGHT.Text = ConvertKeyCode(Settings.Default.Key_DRIGHT);
            Key_HOME.Text = ConvertKeyCode(Settings.Default.Key_HOME);
            Key_CAPTURE.Text = ConvertKeyCode(Settings.Default.Key_CAPTURE);
        }
    }
}
