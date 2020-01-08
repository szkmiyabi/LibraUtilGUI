using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {

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

                //ファイル名サフィックスを先に取得しておく
                string guideline_sufix = (string)this.Invoke(get_guideline_sufix);
                string pageID_sufix = (string)this.Invoke(get_pageID_sufix);

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
                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + "_" + guideline_sufix + "_" + pageID_sufix + " " + " 検査結果 " + DateUtil.fetch_filename_logtime() + ".xlsx";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                ExcelUtil eu = new ExcelUtil();
                eu.repo_task_save_xlsx(rep_data, save_filename);
                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");


            });
        }

        //レポートを表示
        private void display_survey_report()
        {
            Task.Run(() =>
            {
                d_status_messenger message = w_status_messenger;
                d_get_projectID get_projectID = w_get_projectID;
                d_get_basic_auth_cond get_basic_auth_cond = w_get_basic_auth_cond;
                d_get_source_flag get_source_flag = w_get_source_flag;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;
                d_get_workDir get_workDir = w_get_workDir;
                d_is_pageID_selected is_pageID_selected = w_is_pageID_selected;
                d_is_guideline_selected is_guideline_selected = w_is_guideline_selected;
                d_is_tech_selected is_tech_selected = w_is_tech_selected;
                d_pageID_data get_page_rows = w_pageID_data;
                d_guideline_data get_guideline_rows = w_guideline_data;
                d_get_pageID_sufix get_pageID_sufix = w_get_pageID_sufix;
                d_get_guideline_sufix get_guideline_sufix = w_get_guideline_sufix;
                d_data_grid_as_RepoTask _data_grid_as_RepoTask = w_data_grid_as_RepoTask;
                d_tech_data get_tech_rows = w_tech_data;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(get_projectID);
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

                //処理タイプ条件分岐
                string opt_type = "";
                if ((Boolean)this.Invoke(is_tech_selected)) opt_type = "qry";
                else opt_type = "seq";

                switch (opt_type)
                {

                    //絞り込み
                    case "qry":

                        //techコンボから値取得
                        List<string> tech_rows = (List<string>)this.Invoke(get_tech_rows);

                        //一次格納用rep_data
                        List<List<string>> tmp_rep_data = new List<List<string>>();

                        //guidelineのループ
                        for (int i = 0; i < guideline_rows.Count; i++)
                        {
                            if (i > 0) break; //複数達成基準には対応しない
                            string guideline = guideline_rows[i];
                            string guideline_disp = guideline;
                            guideline = "7." + guideline;

                            //タスクのキャンセル判定
                            if ((Boolean)this.Invoke(canceler)) return;

                            //pageのループ
                            for (int j = 0; j < page_rows.Count; j++)
                            {
                                List<string> page_row = page_rows[j];
                                string pageID = page_row[0];
                                string pageURL = page_row[1];
                                this.Invoke(message, pageID + ", " + guideline_disp + " を処理しています。 （" + DateUtil.get_logtime() + "）");
                                string path = ldr.fetch_report_detail_path(pageID, guideline);
                                ldr.wd.Navigate().GoToUrl(path);
                                DateUtil.app_sleep(shortWait);
                                List<List<string>> tbl_data = ldr.get_detail_table_data(pageID, pageURL, guideline);
                                tmp_rep_data.AddRange(tbl_data);
                            }
                        }

                        //rep_dataを組み立て
                        foreach(List<string> row in tmp_rep_data)
                        {
                            string q_col = row[4];
                            Func<List<string>, string, Boolean> _contain_tech = delegate (List<string> arr, string key)
                            {
                                Boolean flg = false;
                                foreach(string vl in arr)
                                {
                                    if(vl == key)
                                    {
                                        flg = true;
                                        break;
                                    }
                                }
                                return flg;
                            };
                            if(_contain_tech(tech_rows, q_col))
                            {
                                rep_data.Add(row);
                            }
                        }
                        break;

                    //全件
                    case "seq":

                        //guidelineのループ
                        for (int i = 0; i < guideline_rows.Count; i++)
                        {
                            string guideline = guideline_rows[i];
                            string guideline_disp = guideline;
                            guideline = "7." + guideline;

                            //タスクのキャンセル判定
                            if ((Boolean)this.Invoke(canceler)) return;

                            //pageのループ
                            for (int j = 0; j < page_rows.Count; j++)
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
                        break;

                }

                //DataGridレポート処理
                this.Invoke(message, "データグリッドビューへの書き出しを開始します。（" + DateUtil.get_logtime() + "）");
                List<string> head_row = TextUtil.get_header();
                rep_data.Insert(0, head_row);
                this.Invoke(_data_grid_as_RepoTask, rep_data);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

    }
}
