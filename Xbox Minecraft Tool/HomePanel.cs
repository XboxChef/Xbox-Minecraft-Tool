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
        public static IXboxConsole console;
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
        public void TabPageNumber(int X)
        {
            switch (X)
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
            TabPageNumber(4);
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            TabPageNumber(1);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            TabPageNumber(2);

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            TabPageNumber(3);

        }
        #endregion
        #region TopMenuItems
        private void skinDropDownButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThemeChosen(Properties.Settings.Default.themesaver);
        }
        #endregion
        #region Welcome Page


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (console.Connect(out console))
                {
                    XNotify.Show("Connected! Welcome To Xbox Minecraft Tool " + labelControl29.Text+" Made By TeddyHammer");
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
            if(ConnectStatus.Text == "Connected!")
            {
                LaunchXEX(@"\Device\Package_232EEB4B8C0E92B5D507BDF43CA6CE35\default.xex", @"\Device\Package_232EEB4B8C0E92B5D507BDF43CA6CE35");
            }
        }
        public void LaunchTitle(string Path,string Directory)
        {
            string[] lines = Path.Split("\\".ToCharArray());
            for (int i = 0; i < lines.Length - 1; i++)
                Directory += lines[i] + "\\";
            console.SendTextCommand(0,"magicboot title=\"" + Path + "\" directory=\"" + Directory + "\"", out _);
        }
        public void LaunchXEX(string xexPath, string xexDirectory)
        {
            try
            {

                console.SendTextCommand(0, NewMethod(xexPath, xexDirectory), out _);
            }
            catch
            {
                MessageBox.Show("Unable to launch xex.", "oops :(");
            }
        }

        private static string NewMethod(string xexPath, string xexDirectory)
        {
            return string.Format("magicboot title=\"{0}\" directory=\"{1}\"", xexPath, xexDirectory);
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
            Process.Start("https://discord.gg/CSv8ZQF");//
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
                    GameCheat(0.5f, Cheats.SuperSpeed);
                }
                else
                {
                    GameCheat(0.91f, Cheats.SuperSpeed);
                }
            }
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch2.IsOn)
                {
                    GameCheat(-4f, Cheats.PlayerSize);
                }
                else
                {
                    GameCheat(-1f, Cheats.PlayerSize);
                }
            }
        }

        private void toggleSwitch4_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch4.IsOn)
                {
                    GameCheat(20f, Cheats.BirdsView);
                }
                else
                {
                    GameCheat(1.62f, Cheats.BirdsView);
                }
            }
        }

        private void toggleSwitch3_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch3.IsOn)
                {
                    GameCheat(100f, Cheats.FallDamage);
                }
                else
                {
                    GameCheat(3f, Cheats.FallDamage);
                }
            }
        }

        private void toggleSwitch8_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch8.IsOn)
                {
                    GameCheat(0f, Cheats.DayChanger);
                }
                else
                {
                    GameCheat(0.25f, Cheats.DayChanger);
                }
            }
        }

        private void toggleSwitch7_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch7.IsOn)
                {
                    GameCheat(100f, Cheats.Selected_Block);
                }
                else
                {
                    GameCheat(10f, Cheats.Selected_Block);
                }
            }
        }

        private void toggleSwitch6_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch6.IsOn)
                {
                    GameCheat(99f, Cheats.Commit_Suicide);
                }
                else
                {
                    GameCheat(0.8f, Cheats.Commit_Suicide);
                }
            }
        }

        private void toggleSwitch5_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch5.IsOn)
                {
                    GameCheat(20f, Cheats.Wall_Hack);
                }
                else
                {
                    GameCheat(0.05f, Cheats.Wall_Hack);
                }
            }
        }

        private void toggleSwitch9_Toggled(object sender, EventArgs e)
        {
            if (JRPC.activeConnection)
            {
                if (toggleSwitch9.IsOn)
                {
                    GameCheat(0.9f, Cheats.NightVision);
                }
                else
                {
                    GameCheat(0.9f, Cheats.NightVision);
                }
            }
        }

        private void NightVisionEdit(float value)
        {
            JRPC.WriteFloat(console, 0x820190F8, value);
        }
        #endregion
        #region Settings Page
        private void toggleSwitch10_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch10.IsOn == false)
            {
                Properties.Settings.Default.themesaver = DefaultTheme;
                Properties.Settings.Default.switchtheme = false;
                Properties.Settings.Default.Save();
            }
        }
        private void toggleSwitch14_Toggled(object sender, EventArgs e)
        {

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            ConnectStatus.ForeColor = randomColor;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Type"></param>
        public static void GameCheat(float value, Cheats Type)//more efficient way pass commands also saves alot of space
        {
            switch ((int)Type)  //checks the Type Of Mod You wanna Do
            {

                case (int)Cheats.Wall_Hack:
                    JRPC.WriteFloat(console, 0x82003168, value);
                    break;

                case (int)Cheats.Commit_Suicide:
                    JRPC.WriteFloat(console, 0x8201644C, value);
                    break;

                case (int)Cheats.DayChanger:
                    JRPC.WriteFloat(console, 0x820074A8, value);//check
                    break;

                case (int)Cheats.Selected_Block:
                    JRPC.WriteFloat(console, 0x820071C0, value);
                    break;

                case (int)Cheats.SuperSpeed:
                    JRPC.WriteFloat(console, 0x8201594C, value);
                    break;
                case (int)Cheats.PlayerSize:
                    JRPC.WriteFloat(console, 0x820042F4, value);
                    break;
                case (int)Cheats.BirdsView:
                    JRPC.WriteFloat(console, 0x82045B7C, value);
                    break;
                case (int)Cheats.FallDamage:
                    JRPC.WriteFloat(console, 0x82006348, value);//chedk
                    break;
            }
        }
        public enum Cheats
        {
            Commit_Suicide,
            Wall_Hack,
            FallDamage,
            NightVision,
            DayChanger,
            Selected_Block,
            SuperSpeed,
            PlayerSize,
            BirdsView,
        }

        public class XNotify
        {
            public static bool XNotifyActive { get; set; }
            public static void Show(string a)
            {
                if (XNotifyActive == true)
                {
                    object[] arguments = new object[] { 0x18, 0xff, 2, (a).ToWCHAR(), 1 };
                    console.CallVoid(JRPC.ThreadType.Title, "xam.xex", 0x290, arguments);
                }
                else
                {

                }
            }
        }


    }

}
