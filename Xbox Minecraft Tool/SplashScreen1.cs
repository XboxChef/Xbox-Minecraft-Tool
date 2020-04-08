using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Xbox_Minecraft_Tool
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();
            this.labelControl1.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
            timer1.Start();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                Visible = false;
            }
            catch
            {

            }

            HomePanel HomePanel = new HomePanel();
            HomePanel.Show();
            HomePanel.Focus();


        }

        private void SplashScreen1_Load(object sender, EventArgs e)
        {

        }
    }
}