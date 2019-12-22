using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {

        //デリゲート
        private delegate string d_get_workDir();
        private string w_get_workDir()
        {
            return workDir;
        }

        private delegate string d_get_projectID();
        private string w_get_projectID()
        {
            return projectIDListBox.SelectedValue.ToString();
        }
        
        //PID+URLのTSVファイル出力
        private void do_create_pid_url_list()
        {
            Task.Run(() =>
            {

                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_workDir _d_get_workDir = new d_get_workDir(w_get_workDir);
                d_get_projectID _d_get_projectID = new d_get_projectID(w_get_projectID);

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

                ldr.browse_repo();
                DateUtil.app_sleep(shortWait);

                string site_name = ldr.get_site_name();
                string save_dir = (string)this.Invoke(_d_get_workDir);

                string save_filename = save_dir + projectID + "_" + site_name + " URL.txt";
                List<List<string>> data = ldr.get_page_list_data();

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

                ldr.browse_repo();
                DateUtil.app_sleep(shortWait);

                string site_name = ldr.get_site_name();
                string save_dir = (string)this.Invoke(_d_get_workDir);

                string save_filename = save_dir + projectID + "_" + site_name + " URL.xlsx";
                List<List<string>> data = ldr.get_page_list_data();

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

                ldr.browse_repo();
                DateUtil.app_sleep(shortWait);

                string site_name = ldr.get_site_name();
                string save_dir = (string)this.Invoke(_d_get_workDir);

                string save_filename = save_dir + projectID + "_" + site_name + " PID.txt";
                List<List<string>> data = ldr.get_page_list_data();
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
