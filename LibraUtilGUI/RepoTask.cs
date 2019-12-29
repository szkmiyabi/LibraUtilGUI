using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {

        //デリゲート（ページIDコンボが選択されているか）
        private delegate Boolean d_is_pageID_selected();
        private Boolean w_is_pageID_selected()
        {
            if (pageIDListBox.SelectedItems.Count == 0) return false;
            else return true;
        }

        //デリゲート（ページIDコンボ選択値を取得）
        private delegate List<List<string>> d_pageID_data();
        private List<List<string>> w_pageID_data()
        {
            List<List<string>> data = new List<List<string>>();

            //データバインドしたListBoxの項目はそのデータ型でしか取り出せない
            foreach(pageIDComboItem cmb in pageIDListBox.SelectedItems)
            {
                List<string> row = new List<string>();
                string pid = cmb.id_str;
                string url = TextUtil.fetch_url(cmb.display_str);
                row.Add(pid);
                row.Add(url);
                data.Add(row);
            }
            return data;
        }

        //デリゲート（ページIDサフィックス）
        private delegate string d_get_pageID_sufix();
        private string w_get_pageID_sufix()
        {
            string ret = "";
            string opt = "";

            int nx = pageIDListBox.SelectedItems.Count;
            if (nx > 5) opt = "hyphen";
            else opt = "comma";

            if(opt == "comma")
            {
                int cnt = 0;
                foreach (pageIDComboItem cmb in pageIDListBox.SelectedItems)
                {
                    string pid = cmb.id_str;
                    if (cnt != (nx - 1)) ret += pid + ",";
                    else ret += pid;
                    cnt++;
                }
            }
            else
            {
                List<string> row = new List<string>();
                foreach (pageIDComboItem cmb in pageIDListBox.SelectedItems)
                {                  
                    string pid = cmb.id_str;
                    row.Add(pid);
                }
                int end = row.Count - 1;
                ret += row[0] + "_" + row[end];
            }
            return ret;
        }

        //デリゲート（ガイドラインIDコンボが選択されているか）
        private delegate Boolean d_is_guideline_selected();
        private Boolean w_is_guideline_selected()
        {
            if (guidelineListBox.SelectedItems.Count == 0) return false;
            else return true;
        }

        //デリゲート（ガイドラインIDコンボ選択値を取得）
        private delegate List<string> d_guideline_data();
        private List<string> w_guideline_data()
        {
            List<string> data = new List<string>();

            //データバインドしたListBoxの項目はそのデータ型でしか取り出せない
            foreach(guidelineComboItem cmb in guidelineListBox.SelectedItems)
            {
                data.Add(cmb.id_str);
            }
            return data;
        }

        //デリゲート（ガイドラインIDサフィックス）
        private delegate string d_get_guideline_sufix();
        private string w_get_guideline_sufix()
        {
            string ret = "";
            string opt = "";

            int nx = guidelineListBox.SelectedItems.Count;
            if (nx > 5) opt = "hyphen";
            else opt = "comma";

            if (opt == "comma")
            {
                int cnt = 0;
                foreach (guidelineComboItem cmb in guidelineListBox.SelectedItems)
                {
                    string guidelineID = cmb.id_str;
                    if (cnt != (nx - 1)) ret += guidelineID + ",";
                    else ret += guidelineID;
                    cnt++;
                }
            }
            else
            {
                List<string> row = new List<string>();
                foreach (guidelineComboItem cmb in guidelineListBox.SelectedItems)
                {
                    string guidelineID = cmb.id_str;
                    row.Add(guidelineID);
                }
                int end = row.Count - 1;
                ret += row[0] + "_" + row[end];
            }
            return ret;
        }

        //レポートを生成
        private void create_survey_report()
        {
            Task.Run(() =>
            {
                d_set_pageID_combo worker = new d_set_pageID_combo(w_set_pageID_combo);
                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_projectID _d_get_projectID = new d_get_projectID(w_get_projectID);
                d_get_basic_auth_cond _d_get_basic_auth_cond = new d_get_basic_auth_cond(w_get_basic_auth_cond);
                d_get_source_flag _d_get_source_flag = new d_get_source_flag(w_get_source_flag);

                d_ldr_activate ldr_activate = new d_ldr_activate(w_ldr_activate);
                d_task_cancel canceler = new d_task_cancel(w_task_cancel);

                d_get_workDir _d_get_workDir = new d_get_workDir(w_get_workDir);

                d_is_pageID_selected is_pageID_selected = new d_is_pageID_selected(w_is_pageID_selected);
                d_is_guideline_selected is_guideline_selected = new d_is_guideline_selected(w_is_guideline_selected);
                d_pageID_data get_page_rows = new d_pageID_data(w_pageID_data);
                d_guideline_data get_guideline_rows = new d_guideline_data(w_guideline_data);

                d_get_pageID_sufix get_pageID_sufix = new d_get_pageID_sufix(w_get_pageID_sufix);
                d_get_guideline_sufix get_guideline_sufix = new d_get_guideline_sufix(w_get_guideline_sufix);

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_d_get_projectID);
                ldr.projectID = projectID;

                //サイト名取得
                this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                ldr.browse_repo();
                DateUtil.app_sleep(shortWait);
                string site_name = ldr.get_site_name();

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                //pageIDコンボから選択値を取得
                List<string> guideline_rows = (List<string>)this.Invoke(get_guideline_rows);

                //guidelineコンボから選択値を取得
                List<List<string>> page_rows = (List<List<string>>)this.Invoke(get_page_rows);

                this.Invoke(message, "レポート詳細ページに順次アクセスしていきます。（" + DateUtil.get_logtime() + "）");

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                //レポートデータ初期化
                List<List<string>> rep_data = new List<List<string>>();

                //guidelineのループ
                for (int i=0; i<guideline_rows.Count; i++)
                {
                    string guideline = guideline_rows[i];
                    string guideline_disp = guideline;
                    guideline = "7." + guideline;

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    //pageのループ
                    for (int j=0; j<page_rows.Count; j++)
                    {
                        List<string> page_row = page_rows[j];
                        string pageID = page_row[0];
                        string pageURL = page_row[1];
                        this.Invoke(message, pageID + ", " + guideline_disp + " を処理しています。 （" + DateUtil.get_logtime() + "）");
                        string path = ldr.fetch_report_detail_path(pageID, guideline);
                        ldr.wd.Navigate().GoToUrl(path);
                        DateUtil.app_sleep(shortWait);
                        List<List<string>> tbl_data = ldr.get_detail_table_data(pageID, pageURL, guideline);
                        rep_data.AddRange(tbl_data);
                    }
                }

                //Excelレポート処理
                this.Invoke(message, "Excelファイルへの書き出しを開始します。（" + DateUtil.get_logtime() + "）");
                List<string> head_row = TextUtil.get_header();
                rep_data.Insert(0, head_row);
                string guideline_sufix = (string)this.Invoke(get_guideline_sufix);
                string pageID_sufix = (string)this.Invoke(get_pageID_sufix);
                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + "_" + guideline_sufix + "_" + pageID_sufix + "_" + " 検査結果.xlsx";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                ExcelUtil eu = new ExcelUtil();
                eu.save_xlsx_as(rep_data, save_filename);
                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");


            });
        }

    }
}
