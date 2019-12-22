﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraUtilGUI
{

    partial class Form1
    {

        //デリゲート（基本認証ON/OFFチェック）
        public delegate Boolean d_get_basic_auth_cond();
        public Boolean w_get_basic_auth_cond()
        {
            Boolean flg = true;
            if (basic_auth == "yes" && headless == "yes")
            {
                flg = false;
                operationStatusReport.AppendText("【エラー】基本認証⇒「はい」を選択した場合、ヘッドレス起動⇒「いいえ」に設定しないと動作しません。基本設定を確認してください。\r\n");
            }
            return flg;
        }

        //デリゲート（処理状況テキストの更新）
        public delegate void d_status_messenger(string msg);
        public void w_status_messenger(string msg)
        {
            operationStatusReport.AppendText(msg + "\r\n");
        }

        //デリゲート（保存先フォルダ参照）
        private delegate string d_get_workDir();
        private string w_get_workDir()
        {
            return workDir;
        }

        //デリゲート（プロジェクトID参照）
        private delegate string d_get_projectID();
        private string w_get_projectID()
        {
            return projectIDListBox.SelectedValue.ToString();
        }

        //デリゲート（参照タイプ参照）
        private delegate string d_get_source_flag();
        private string w_get_source_flag()
        {
            string flag = "";
            if (BaseTaskSrcSurvey.Checked) flag = "svpage";
            else flag = "report";
            return flag;
        }


        //プロジェクトIDコンボをセット
        private void set_projectID_combo()
        {

            Task.Run(() =>
            {
                d_set_projectID_combo worker = new d_set_projectID_combo(w_set_projectID_combo);
                d_status_messenger message = new d_status_messenger(w_status_messenger);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                List<List<string>> data = ldr.get_site_list();
                this.Invoke(message, "サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                this.Invoke(worker, data);
                this.Invoke(message, "サイト名コンボが設定完了しました。（" + DateUtil.get_logtime() + "）");
                ldr.logout();
            });


        }
        private delegate void d_set_projectID_combo(List<List<string>> data);
        private void w_set_projectID_combo(List<List<string>> data)
        {
            List<projectIDComboItem> ListBoxItem = new List<projectIDComboItem>();
            projectIDComboItem itm;
            for(int i=0; i<data.Count; i++)
            {
                List<string> col = (List<string>) data[i];
                string text = col[0] + "  " + col[1];
                itm = new projectIDComboItem(col[0], text);
                ListBoxItem.Add(itm);
            }
            projectIDListBox.DisplayMember = "display_str";
            projectIDListBox.ValueMember = "id_str";
            projectIDListBox.DataSource = ListBoxItem;

            pageIDLoadButton.Enabled = true;
            BaseTaskSrcReport.Enabled = true;
            BaseTaskSrcSurvey.Enabled = true;
        }


        //ページIDコンボをセット
        private void set_pageID_combo()
        {

            Task.Run(() =>
            {
                d_set_pageID_combo worker = new d_set_pageID_combo(w_set_pageID_combo);
                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_projectID _d_get_projectID = new d_get_projectID(w_get_projectID);
                d_get_basic_auth_cond _d_get_basic_auth_cond = new d_get_basic_auth_cond(w_get_basic_auth_cond);
                d_get_source_flag _d_get_source_flag = new d_get_source_flag(w_get_source_flag);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string cr = (string) this.Invoke(_d_get_projectID);
                ldr.projectID = cr;

                string flg = (string)this.Invoke(_d_get_source_flag);
                if(flg == "report")
                {
                    this.Invoke(message, "レポートインデックスページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    List<List<string>> data = ldr.get_page_list_data();
                    this.Invoke(worker, data);
                }
                else if(flg == "svpage")
                {

                    Boolean auth_param_check = (Boolean)this.Invoke(_d_get_basic_auth_cond);
                    if (auth_param_check == false) return;

                    this.Invoke(message, "検査メイン画面ページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    List<List<string>> data = ldr.get_page_list_data_from_svpage();
                    this.Invoke(worker, data);
                }

                this.Invoke(message, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
            });
        }
        private delegate void d_set_pageID_combo(List<List<string>> data);
        private void w_set_pageID_combo(List<List<string>> data)
        {
            List<pageIDComboItem> ListBoxItem = new List<pageIDComboItem>();
            pageIDComboItem itm;
            for(int i=0; i<data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string text = col[0] + "   " + col[1];
                itm = new pageIDComboItem(col[1], text);
                ListBoxItem.Add(itm);
            }
            pageIDListBox.DisplayMember = "display_str";
            pageIDListBox.ValueMember = "id_str";
            pageIDListBox.DataSource = ListBoxItem;

            pageIDListBoxSelectAllButton.Enabled = true;
            pageIDListBoxSelectClearButton.Enabled = true;

        }

    }

}