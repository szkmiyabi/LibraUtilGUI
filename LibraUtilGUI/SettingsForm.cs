﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LibraUtilGUI
{
    public partial class SettingsForm : Form
    {

        private Settings appSettings;
        private string filename;

        public SettingsForm()
        {
            InitializeComponent();
            filename = Application.UserAppDataPath + @"\settings.config";
            appSettings = new Settings();
            loadSettings();
        }

        //環境設定を保存
        private void saveSettings()
        {
            try
            {
                appSettings.uid = uidText.Text;
                appSettings.pswd = pswdText.Text;
                appSettings.systemWait = (int)systemWaitCombo.Value;
                appSettings.longWait = (int)longWaitCombo.Value;
                appSettings.midWait = (int)midWaitCombo.Value;
                appSettings.shortWait = (int)shortWaitCombo.Value;
                appSettings.driver = (string)driverCombo.SelectedItem;
                appSettings.headless = (string)headlessCombo.SelectedItem;
                appSettings.guidelineLevel = (string)guidelineLevelCombo.SelectedItem;
                appSettings.basic_auth = (string)basicAuthCombo.SelectedItem;

                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamWriter sw = new StreamWriter(
                    filename,
                    false,
                    new System.Text.UTF8Encoding(false)
                );
                xsz.Serialize(sw, appSettings);
                sw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("設定が保存でませんでした。" + ex.Message);
            }
        }

        //環境設定をロード
        private void loadSettings()
        {
            try
            {
                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamReader sr = new StreamReader(
                    filename,
                    new System.Text.UTF8Encoding(false)
                );
                appSettings = (Settings)xsz.Deserialize(sr);
                sr.Close();

                uidText.Text = appSettings.uid;
                pswdText.Text = appSettings.pswd;
                systemWaitCombo.Value = (decimal)appSettings.systemWait;
                longWaitCombo.Value = (decimal)appSettings.longWait;
                midWaitCombo.Value = (decimal)appSettings.midWait;
                shortWaitCombo.Value = (decimal)appSettings.shortWait;
                driverCombo.Text = appSettings.driver;
                headlessCombo.Text = appSettings.headless;
                guidelineLevelCombo.Text = appSettings.guidelineLevel;
                basicAuthCombo.Text = appSettings.basic_auth;

            }
            catch(Exception ex)
            {

            }
        }

        //環境設定を削除
        private void deleteSettings()
        {
            try
            {
                appSettings.uid = "";
                appSettings.pswd = "";
                appSettings.systemWait = 60;
                appSettings.longWait = 10;
                appSettings.midWait = 8;
                appSettings.shortWait = 5;
                appSettings.driver = "";
                appSettings.headless = "";
                appSettings.guidelineLevel = "";
                appSettings.basic_auth = "";

                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamWriter sw = new StreamWriter(
                    filename,
                    false,
                    new System.Text.UTF8Encoding(false)
                );
                xsz.Serialize(sw, appSettings);
                sw.Close();

                uidText.Text = "";
                pswdText.Text = "";
                systemWaitCombo.Value = 60;
                longWaitCombo.Value = 10;
                midWaitCombo.Value = 8;
                shortWaitCombo.Value = 5;
                driverCombo.Text = "";
                headlessCombo.Text = "";
                guidelineLevelCombo.Text = "";
                basicAuthCombo.Text = "";
                MessageBox.Show("設定が削除できました。");

            }
            catch (Exception ex)
            {
                MessageBox.Show("設定が保存でませんでした。" + ex.Message);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            deleteSettings();
        }
    }
}