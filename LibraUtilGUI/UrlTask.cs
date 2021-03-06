﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {

        //PID+URLのTSVファイル出力
        private void do_create_pid_url_list()
        {
            Task.Run(() =>
            {

                //共通デリゲートインスタンス
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;

                //専用デリゲートインスタンス（条件系）
                d_get_UrlTask_source_flag _get_UrlTask_source_flag = w_get_UrlTask_source_flag;
                d_is_pageID_selected _is_pageID_selected = w_is_pageID_selected;

                //専用デリゲートインスタンス（取得系）
                d_get_workDir _get_workDir = w_get_workDir;
                d_get_projectID _get_projectID = w_get_projectID;
                d_pageID_data get_page_rows = w_pageID_data;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_get_projectID);
                ldr.projectID = projectID;

                string flag = (string)this.Invoke(_get_UrlTask_source_flag);
                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                if (flag == "report")
                {
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    site_name = ldr.get_site_name();
                    data = ldr.get_page_list_data();
                }
                else if(flag == "combo")
                {
                    if (!(Boolean)this.Invoke(_is_pageID_selected))
                    {
                        this.Invoke(message, "ページIDが選択されていません。処理を停止します。");
                        ldr.logout();
                        this.Invoke(message, "処理を停止しました。（" + DateUtil.get_logtime() + "）");
                        return;
                    }
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    site_name = ldr.get_site_name();
                    data = (List<List<string>>)this.Invoke(get_page_rows);
                }
                else if(flag == "svpage")
                {
                    this.Invoke(message, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    data = ldr.get_page_list_data_from_svpage();

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    site_name = ldr.get_site_name();

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;
                }

                string save_dir = (string)this.Invoke(_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " URL.txt";

                FileUtil fu = new FileUtil();
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

                //共通デリゲートインスタンス
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;

                //専用デリゲートインスタンス（条件系）
                d_get_UrlTask_source_flag _get_UrlTask_source_flag = w_get_UrlTask_source_flag;
                d_is_pageID_selected _is_pageID_selected = w_is_pageID_selected;

                //専用デリゲートインスタンス（取得系）
                d_get_workDir _get_workDir = w_get_workDir;
                d_get_projectID _get_projectID = w_get_projectID;
                d_pageID_data get_page_rows = w_pageID_data;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_get_projectID);
                ldr.projectID = projectID;

                string flag = (string)this.Invoke(_get_UrlTask_source_flag);
                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                if (flag == "report")
                {
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    site_name = ldr.get_site_name();
                    data = ldr.get_page_list_data();
                }
                else if (flag == "combo")
                {
                    if (!(Boolean)this.Invoke(_is_pageID_selected))
                    {
                        this.Invoke(message, "ページIDが選択されていません。処理を停止します。");
                        ldr.logout();
                        this.Invoke(message, "処理を停止しました。（" + DateUtil.get_logtime() + "）");
                        return;
                    }
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    site_name = ldr.get_site_name();
                    data = (List<List<string>>)this.Invoke(get_page_rows);
                }
                else if (flag == "svpage")
                {
                    this.Invoke(message, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    data = ldr.get_page_list_data_from_svpage();

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    site_name = ldr.get_site_name();

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;
                }

                //ヘッダー行の処理
                List<string> head_row = new List<string>() { "PID", "URL" };
                data.Insert(0, head_row);

                string save_dir = (string)this.Invoke(_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " URL.xlsx";

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                ExcelUtil eu = new ExcelUtil();
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

                //共通デリゲートインスタンス
                d_status_messenger message = w_status_messenger;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;

                //専用デリゲートインスタンス（条件系）
                d_get_UrlTask_source_flag _get_UrlTask_source_flag = w_get_UrlTask_source_flag;
                d_is_pageID_selected _is_pageID_selected = w_is_pageID_selected;

                //専用デリゲートインスタンス（取得系）
                d_get_workDir _get_workDir = w_get_workDir;
                d_get_projectID _get_projectID = w_get_projectID;
                d_pageID_data get_page_rows = w_pageID_data;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                string projectID = (string)this.Invoke(_get_projectID);
                ldr.projectID = projectID;

                string flag = (string)this.Invoke(_get_UrlTask_source_flag);
                List<List<string>> data = new List<List<string>>();
                string site_name = "";

                if (flag == "report")
                {
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    site_name = ldr.get_site_name();
                    data = ldr.get_page_list_data();
                }
                else if (flag == "combo")
                {
                    if (!(Boolean)this.Invoke(_is_pageID_selected))
                    {
                        this.Invoke(message, "ページIDが選択されていません。処理を停止します。");
                        ldr.logout();
                        this.Invoke(message, "処理を停止しました。（" + DateUtil.get_logtime() + "）");
                        return;
                    }
                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    site_name = ldr.get_site_name();
                    data = (List<List<string>>)this.Invoke(get_page_rows);
                }
                else if (flag == "svpage")
                {
                    this.Invoke(message, "検査メイン画面に移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_sv_mainpage();
                    DateUtil.app_sleep(longWait);
                    data = ldr.get_page_list_data_from_svpage();

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                    ldr.browse_repo();
                    DateUtil.app_sleep(shortWait);
                    site_name = ldr.get_site_name();

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;
                }

                string save_dir = (string)this.Invoke(_get_workDir);
                string save_filename = save_dir + projectID + "_" + site_name + " PID.txt";

                List<string> fetch_data = new List<string>();
                for(int i=0; i<data.Count; i++)
                {
                    List<string> cols = (List<string>)data[i];
                    string col = (string)cols[0];
                    fetch_data.Add(col);
                }

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                FileUtil fu = new FileUtil();
                fu.write_text_data(fetch_data, save_filename);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }
    }
}
