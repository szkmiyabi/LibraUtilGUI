using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraUtilGUI
{

    partial class Form1
    {

        //プロジェクトIDコンボをセット
        private void set_projectID_combo()
        {

            Task.Run(() =>
            {
                d_set_projectID_combo worker = new d_set_projectID_combo(w_set_projectID_combo);
                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_ldr_activate ldr_activate = new d_ldr_activate(w_ldr_activate);
                d_task_cancel canceler = new d_task_cancel(w_task_cancel);

                d_ctrl_activate w_ctrl_activate = new d_ctrl_activate(ctrl_activate);
                d_ctrl_deactivate w_ctrl_deactivate = new d_ctrl_deactivate(ctrl_deactivate);



                //2重実行防止
                this.Invoke(w_ctrl_deactivate, "projectIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "pageIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "doUrlTaskButton");
                this.Invoke(w_ctrl_deactivate, "cancelUrlTaskButton");

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }
                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                List<List<string>> data = ldr.get_site_list();

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                this.Invoke(message, "サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                this.Invoke(worker, data);
                this.Invoke(message, "サイト名コンボが設定完了しました。（" + DateUtil.get_logtime() + "）");
                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

                this.Invoke(w_ctrl_activate, "projectIDLoadButton");
                this.Invoke(w_ctrl_activate, "pageIDLoadButton");

                this.Invoke(w_ctrl_activate, "doUrlTaskButton");
                this.Invoke(w_ctrl_activate, "cancelUrlTaskButton");
                this.Invoke(w_ctrl_activate, "createSiteInfoBookButton");

            });

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

                d_ldr_activate ldr_activate = new d_ldr_activate(w_ldr_activate);
                d_task_cancel canceler = new d_task_cancel(w_task_cancel);

                d_ctrl_activate w_ctrl_activate = new d_ctrl_activate(ctrl_activate);
                d_ctrl_deactivate w_ctrl_deactivate = new d_ctrl_deactivate(ctrl_deactivate);

                //2重実行防止
                this.Invoke(w_ctrl_deactivate, "pageIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "projectIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "doRepoTaskButton");
                this.Invoke(w_ctrl_deactivate, "cancelRepoTaskButton");

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
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

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

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

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    this.Invoke(worker, data);
                }

                this.Invoke(message, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

                this.Invoke(w_ctrl_activate, "pageIDLoadButton");
                this.Invoke(w_ctrl_activate, "projectIDLoadButton");
                this.Invoke(w_ctrl_activate, "doRepoTaskButton");
                this.Invoke(w_ctrl_activate, "cancelRepoTaskButton");

                this.Invoke(w_ctrl_activate, "pageIDListBoxSelectAllButton");
                this.Invoke(w_ctrl_activate, "pageIDListBoxSelectClearButton");

                this.Invoke(w_ctrl_activate, "openAsFirefoxButton");
                this.Invoke(w_ctrl_activate, "openAsIEButton");
                this.Invoke(w_ctrl_activate, "openAsChromeButton");
                this.Invoke(w_ctrl_activate, "openAsAnotherBrowserButton");

                this.Invoke(w_ctrl_activate, "techIDLoadButton");

            });
        }



        //サイト一覧テーブルをExcelファイルで出力
        private void create_site_info_book()
        {
            Task.Run(() =>
            {
                d_status_messenger message = new d_status_messenger(w_status_messenger);
                d_get_workDir _d_get_workDir = new d_get_workDir(w_get_workDir);

                d_ldr_activate ldr_activate = new d_ldr_activate(w_ldr_activate);
                d_task_cancel canceler = new d_task_cancel(w_task_cancel);

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                List<List<string>> data = ldr.get_site_info_data();
                List<string> head_row = new List<string>() { "ID", "サイト名", "備考", "検査期間" };
                data.Insert(0, head_row);

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                string save_dir = (string)this.Invoke(_d_get_workDir);
                string save_filename = save_dir + "Libra検査サイト一覧_" + DateUtil.fetch_filename_logtime() + ".xlsx";
                ExcelUtil eu = new ExcelUtil();
                eu.save_xlsx_as(data, save_filename);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }

        //実装番号コンボをセット
        private void set_techID_combo()
        {
            Task.Run(() =>
            {
                //デリゲートのインスタンス取得
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;
                d_ctrl_activate w_ctrl_activate = ctrl_activate;
                d_ctrl_deactivate w_ctrl_deactivate = ctrl_deactivate;
                d_get_projectID _projectID = w_get_projectID;
                d_pageID_data _page_rows = w_pageID_data;
                d_guideline_data _guideline_rows = w_guideline_data;
                d_set_techID_combo _set_techID_combo = w_set_techID_combo;

                //2重実行防止
                this.Invoke(w_ctrl_deactivate, "techIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "projectIDLoadButton");
                this.Invoke(w_ctrl_deactivate, "pageIDLoadButton");

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }
                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                //projectIDコンボから選択値を取得しセットする
                string projectID = (string)this.Invoke(_projectID);
                ldr.projectID = projectID;

                //pageIDコンボの選択値を匿名関数で取得（複数選択の場合先頭のみ取得）
                List<List<string>> page_rows = (List<List<string>>)this.Invoke(_page_rows);
                Func<List<List<string>>, string> _pageID = delegate(List<List<string>> data)
                {
                    return data[0][0];
                };
                string pageID = _pageID(page_rows);

                //guidelineコンボの選択値を匿名関数で取得（複数選択の場合先頭のみ取得）
                List<string> guideline_rows = (List<string>)this.Invoke(_guideline_rows);
                Func<List<string>, string> _guideline = delegate (List<string> data)
                {
                    return data[0];
                };
                string guideline = _guideline(guideline_rows);
                guideline = "7." + guideline;

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                this.Invoke(message, "レポート詳細ページに移動します。（" + DateUtil.get_logtime() + "）");

                string path = ldr.fetch_report_detail_path(pageID, guideline);
                ldr.wd.Navigate().GoToUrl(path);
                DateUtil.app_sleep(shortWait);

                this.Invoke(message, "レポート詳細ページから実装番号を取得しています。（" + DateUtil.get_logtime() + "）");

                List<string> tech_rows = ldr.get_tech_list();
                this.Invoke(_set_techID_combo, tech_rows);

                this.Invoke(message, "実装番号コンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

                this.Invoke(w_ctrl_activate, "techIDLoadButton");
                this.Invoke(w_ctrl_activate, "projectIDLoadButton");
                this.Invoke(w_ctrl_activate, "pageIDLoadButton");

                this.Invoke(w_ctrl_activate, "techSelectAllButton");
                this.Invoke(w_ctrl_activate, "techSelectClearButton");

            });
        }

    }

}
