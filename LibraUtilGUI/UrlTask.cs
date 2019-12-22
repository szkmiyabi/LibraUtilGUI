using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {


        //デリゲート（UrlTaskの参照タイプ参照）
        private delegate string d_get_UrlTask_source_flag();
        private string w_get_UrlTask_source_flag()
        {
            string flag = "";
            if (UrlTaskSrcSurvey.Checked) flag = "svpage";
            else flag = "report";
            return flag;
        }

        //PID+URLのTSVファイル出力
        private void do_create_pid_url_list()
        {
            Task.Run(() =>
            {

                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_workDir _d_get_workDir = new d_get_workDir(w_get_workDir);
                d_get_projectID _d_get_projectID = new d_get_projectID(w_get_projectID);
                d_get_UrlTask_source_flag _d_get_UrlTask_source_flag = new d_get_UrlTask_source_flag(w_get_UrlTask_source_flag);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_d_get_projectID);
                ldr.projectID = projectID;

                string flag = (string)this.Invoke(_d_get_UrlTask_source_flag);
                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                if(flag == "report")
                {
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    site_name = ldr.get_site_name();
                    data = ldr.get_page_list_data();
                }
                else if(flag == "svpage")
                {
                    this.Invoke(message, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    data = ldr.get_page_list_data_from_svpage();

                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    site_name = ldr.get_site_name();
                }

                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " URL.txt";

                FileUtil fu = new FileUtil(this);
                fu.write_tsv_data(data, save_filename);
                
                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //PID+URLのExcelファイル出力
        private void do_create_pid_url_list_xlsx()
        {
            Task.Run(() =>
            {

                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_workDir _d_get_workDir = new d_get_workDir(w_get_workDir);
                d_get_projectID _d_get_projectID = new d_get_projectID(w_get_projectID);
                d_get_UrlTask_source_flag _d_get_UrlTask_source_flag = new d_get_UrlTask_source_flag(w_get_UrlTask_source_flag);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_d_get_projectID);
                ldr.projectID = projectID;

                string flag = (string)this.Invoke(_d_get_UrlTask_source_flag);
                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                if (flag == "report")
                {
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    site_name = ldr.get_site_name();
                    data = ldr.get_page_list_data();
                }
                else if (flag == "svpage")
                {
                    this.Invoke(message, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    data = ldr.get_page_list_data_from_svpage();

                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    site_name = ldr.get_site_name();
                }

                //ヘッダー行の処理
                List<string> head_row = new List<string>() { "PID", "URL" };
                data.Insert(0, head_row);

                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " URL.xlsx";

                ExcelUtil eu = new ExcelUtil(this);
                eu.save_xlsx_as(data, save_filename);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //PIDのテキストファイル出力
        private void do_create_pid_list()
        {
            Task.Run(() =>
            {

                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_workDir _d_get_workDir = new d_get_workDir(w_get_workDir);
                d_get_projectID _d_get_projectID = new d_get_projectID(w_get_projectID);
                d_get_UrlTask_source_flag _d_get_UrlTask_source_flag = new d_get_UrlTask_source_flag(w_get_UrlTask_source_flag);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_d_get_projectID);
                ldr.projectID = projectID;

                string flag = (string)this.Invoke(_d_get_UrlTask_source_flag);
                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                if (flag == "report")
                {
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    site_name = ldr.get_site_name();
                    data = ldr.get_page_list_data();
                }
                else if (flag == "svpage")
                {
                    this.Invoke(message, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    data = ldr.get_page_list_data_from_svpage();

                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    site_name = ldr.get_site_name();
                }

                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " PID.txt";

                List<string> fetch_data = new List<string>();
                for(int i=0; i<data.Count; i++)
                {
                    List<string> cols = (List<string>)data[i];
                    string col = (string)cols[0];
                    fetch_data.Add(col);
                }

                FileUtil fu = new FileUtil(this);
                fu.write_text_data(fetch_data, save_filename);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }
    }
}
