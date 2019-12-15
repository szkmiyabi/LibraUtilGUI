using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using System.Threading;


namespace LibraUtilGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

            toolStripStatusLabel1.Text = "はじめに事前処理を実行してください。";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] appWait = { systemWait, longWait, midWait, shortWait };
            LibraDriver ldr = new LibraDriver(uid, pswd, "600", appWait, driver, headless, basic_auth, workDir);
            ldr.login();
            DateUtil.app_sleep(5);
            // ldr.screenshot(DateUtil.fetch_filename_from_datetime("png"));
            //string save_path = workDir + @"test-191\";
            //if (!Directory.Exists(save_path)) Directory.CreateDirectory(save_path);
            //save_path += DateUtil.fetch_filename_from_datetime("png");

            //ldr.fullpage_screenshot_as(save_path);
            ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));
            ldr.logout();
            ldr.shutdown();

        }

        private void FileMenuSettings_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }
    }

}
