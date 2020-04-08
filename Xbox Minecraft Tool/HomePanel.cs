using DevExpress.XtraBars;
using JRPC_Client;
using XDevkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xbox_Minecraft_Tool
{
    public partial class HomePanel : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        #region Form Handlers
        int caseSwitch = 1;
        public string DefaultTheme = "Visual Studio 2013 Dark";
        public string ReloadTheme = "";
        private bool updates;

        public HomePanel()
        {
            InitializeComponent();
            StartHandler();
        }
        private void StartHandler()
        {
            #region StartHandler

            if (Properties.Settings.Default.switchtheme == true)
            {
                ReloadTheme = Properties.Settings.Default.themesaver;
                Theme.LookAndFeel.SkinName = ReloadTheme;
                toggleSwitch10.IsOn = Properties.Settings.Default.switchtheme;
            }
            else
            {
                Theme.LookAndFeel.SkinName = DefaultTheme;
            }
            slidemenu.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            Tabs.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            #endregion
        }
        public void wasClicked()
        {
            switch (caseSwitch)
            {
                case 1:
                    wce.Show();
                    break;
                case 2:
                    at.Show();
                    break;
                case 3:
                    Settings.Show();
                    break;
                case 4:
                    mods.Show();
                    break;
            }
        }
        public void ThemeChosen(string theme)
        {
            theme = Theme.LookAndFeel.SkinName;

        }
        private void HomePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toggleSwitch10.IsOn == true)
            {
                Properties.Settings.Default.switchtheme = toggleSwitch10.IsOn;
                ReloadTheme = Theme.LookAndFeel.SkinName;
                Properties.Settings.Default.themesaver = ReloadTheme;
                Properties.Settings.Default.Save();
            }
            else
            {

            }
            Process.GetCurrentProcess().Kill();
        }
        #endregion
        #region SlideMenuItems
        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            caseSwitch = 4;
            wasClicked();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            caseSwitch = 1;
            wasClicked();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            caseSwitch = 2;
            wasClicked();

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            caseSwitch = 3;
            wasClicked();

        }
        #endregion
        #region TopMenuItems
        private void skinDropDownButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThemeChosen(Properties.Settings.Default.themesaver);
        }
        #endregion
        #region Welcome Page
        public static void X360Text(string a)
        {
            if (Xnotify == true)
            {
                object[] arguments = new object[] { 0x18, 0xff, 2, (a).ToWCHAR(), 1 };
                console.CallVoid(JRPC.ThreadType.Title, "xam.xex", 0x290, arguments);
            }
            else
            {

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (console.Connect(out console))
                {
                    X360Text("Connected! Welcome To Xbox Minecraft Tool " + labelControl29.Text+" Made By Serenity");
                    ConnectStatus.ForeColor = Color.Green;
                    ConnectStatus.Text = "Connected!";
                }
                else
                {
                    ConnectStatus.ForeColor = Color.Red;
                    ConnectStatus.Text = "Error 101";
                    MessageBox.Show("Error 101 (Xbox 360 Not Found)");

                }
            }
            catch
            {

            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            LaunchXEX(@"\Device\Package_232EEB4B8C0E92B5D507BDF43CA6CE35\default.xex", @"\Device\Package_232EEB4B8C0E92B5D507BDF43CA6CE35");
        }
        public void LaunchTitle(string Path,string Directory)
        {
            string[] lines = Path.Split("\\".ToCharArray());
            for (int i = 0; i < lines.Length - 1; i++)
                Directory += lines[i] + "\\";
            SendText("magicboot title=\"" + Path + "\" directory=\"" + Directory + "\"");
        }
        public void LaunchXEX(string xexPath, string xexDirectory)
        {
            try
            {
                SendText(string.Format("magicboot title=\"{0}\" directory=\"{1}\"", xexPath, xexDirectory));
            }
            catch
            {
                MessageBox.Show("Unable to launch xex.", "oops :(");
            }
        }
        private void SendText(string v)
        {
            console.SendTextCommand(JRPC.connectionId, v, out Responses);

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ConnectStatus.Text = "Checking For Updates!";
            if(updates)
            {
                ConnectStatus.Text = "Updates Found!";
                timer1.Stop();
            }
            else
            {
                ConnectStatus.Text = "No New Updates!";
            }
            timer1.Start();

        }

        private void RandomColors(Color Color)
        {

        }
        #endregion
        #region About Page
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/KtwsM8U");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start("https://xbonline.live/home/");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Process.Start("https://xbonlinekvs.live/kvs/");
        }
        #endregion
        #region Mods Page
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch1.IsOn)
                {
                    superSpeedEdit(0.5f);
                }
                else
                {
                    superSpeedEdit(0.91f);
                }
            }
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch2.IsOn)
                {
                    playerSizeEdit(-4f);
                }
                else
                {
                    playerSizeEdit(-1f);
                }
            }
        }

        private void toggleSwitch4_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch4.IsOn)
                {
                    setViewEdit(20f);
                }
                else
                {
                    setViewEdit(1.62f);
                }
            }
        }

        private void toggleSwitch3_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch3.IsOn)
                {
                    fallDamageEdit(100f);
                }
                else
                {
                    fallDamageEdit(3f);
                }
            }
        }

        private void toggleSwitch8_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch8.IsOn)
                {
                    dayChangerEdit(8f);
                }
                else
                {
                    dayChangerEdit(0.25f);
                }
            }
        }

        private void toggleSwitch7_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch7.IsOn)
                {
                    setBlockEdit(100f);
                }
                else
                {
                    setBlockEdit(10f);
                }
            }
        }

        private void toggleSwitch6_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch6.IsOn)
                {
                    commitSuicideEdit(99f);
                }
                else
                {
                    commitSuicideEdit(0.8f);
                }
            }
        }

        private void toggleSwitch5_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch5.IsOn)
                {
                    wallhackEdit(20f);
                }
                else
                {
                    wallhackEdit(0.05f);
                }
            }
        }

        private void toggleSwitch9_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch9.IsOn)
                {
                    NightVisionEdit(0.9f);
                }
                else
                {
                    NightVisionEdit(0.9f);
                }
            }
        }

        private void NightVisionEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820190F8, value);
        }
        #endregion

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            ConnectStatus.ForeColor = randomColor;
        }

        private void HomePanel_Load(object sender, EventArgs e)
        {

        }

        private void toggleSwitch10_Toggled(object sender, EventArgs e)
        {
            if(toggleSwitch10.IsOn == false)
            {
                Properties.Settings.Default.themesaver = DefaultTheme;
                Properties.Settings.Default.switchtheme = false;
                Properties.Settings.Default.Save();
            }
        }
        public static IXboxConsole console;
        private static bool Xnotify;
        private string Responses;

        public static void commitSuicideEdit(float value)
        {
            JRPC.WriteFloat(console, 0x8201644C, value);
        }

        public static void dayChangerEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820568E4, value);//check
        }

        public static void fallDamageEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820061C8, value);//chedk
        }

        public static void playerSizeEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820042F4, value);
        }

        public static void setBlockEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820071C0, value);
        }

        public static void setViewEdit(float value)
        {
            JRPC.WriteFloat(console, 0x82045B7C, value);
        }

        public static void stiffAnimationEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820dc2c8, value);
        }

        public static void superSpeedEdit(float value)
        {
            JRPC.WriteFloat(console, 0x8201594C, value);
        }

        public static void wallhackEdit(float value)
        {
            JRPC.WriteFloat(console, 0x82003168, value);
        }

        private void toggleSwitch11_Toggled(object sender, EventArgs e)
        {

        }
    }

}
