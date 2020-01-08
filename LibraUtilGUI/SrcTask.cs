﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {
        //レポートを表示
        private void display_srccode_report()
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
                d_data_grid_as_SrcTask _data_grid_as_SrcTask = w_data_grid_as_SrcTask;
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

                //techデータ初期化
                List<string> tech_rows = new List<string>();

                //レポートデータ初期化
                List<List<string>> rep_data = new List<List<string>>();

                this.Invoke(message, "検査メインページに順次アクセスしていきます。（" + DateUtil.get_logtime() + "）");

                //タスクのキャンセル判定
                if ((Boolean)this.Invoke(canceler)) return;

                //処理タイプ条件分岐
                string opt_type = "";
                if ((Boolean)this.Invoke(is_tech_selected)) opt_type = "qry";
                else opt_type = "seq";

                switch (opt_type)
                {
                    //絞り込み
                    case "qry":

                        //techコンボから値取得
                        tech_rows = (List<string>)this.Invoke(get_tech_rows);

                        //guidelineのループ
                        for (int i = 0; i < guideline_rows.Count; i++)
                        {
                            if (i > 0) break; //複数達成基準には対応しない

                            string guideline = guideline_rows[i];
                            string guideline_disp = guideline;

                            //タスクのキャンセル判定
                            if ((Boolean)this.Invoke(canceler)) return;

                            //pageのループ
                            for (int j = 0; j < page_rows.Count; j++)
                            {
                                List<string> page_row = page_rows[j];
                                string pageID = page_row[0];
                                string pageURL = page_row[1];

                                //techのループ
                                for (int k = 0; k < tech_rows.Count; k++)
                                {
                                    string tech = tech_rows[k];
                                    this.Invoke(message, pageID + ", " + guideline_disp + ", " + tech + " を処理しています。 （" + DateUtil.get_logtime() + "）");
                                    string path = ldr.get_sv_mainpage_url(pageID);
                                    ldr.wd.Navigate().GoToUrl(path);
                                    DateUtil.app_sleep(midWait);

                                    ldr.select_guideline(guideline);
                                    DateUtil.app_sleep(midWait);

                                    ldr.select_techlist(tech);
                                    DateUtil.app_sleep(midWait);

                                    //ldr.browse_all_sv_page();
                                    List<string> srccode_rows = ldr.get_srccode_list();
                                    foreach (string srccode in srccode_rows)
                                    {
                                        List<string> row_data = new List<string>();
                                        row_data.Add(pageID);
                                        row_data.Add(pageURL);
                                        row_data.Add(guideline);
                                        row_data.Add(tech);
                                        row_data.Add(srccode);
                                        rep_data.Add(row_data);
                                    }

                                    //余分な行がついてくるので削除
                                    rep_data.RemoveAt(rep_data.Count - 1);

                                }
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

                            //タスクのキャンセル判定
                            if ((Boolean)this.Invoke(canceler)) return;

                            //pageのループ
                            for (int j = 0; j < page_rows.Count; j++)
                            {
                                List<string> page_row = page_rows[j];
                                string pageID = page_row[0];
                                string pageURL = page_row[1];

                                //検査メイン画面アクセス
                                string path = ldr.get_sv_mainpage_url(pageID);
                                ldr.wd.Navigate().GoToUrl(path);
                                DateUtil.app_sleep(midWait);

                                ldr.select_guideline(guideline);
                                DateUtil.app_sleep(midWait);

                                //LibraDriverクラスからtechデータ取得
                                tech_rows = ldr.get_tech_list();

                                //techのループ
                                for (int k = 0; k < tech_rows.Count; k++)
                                {
                                    string tech = tech_rows[k];
                                    this.Invoke(message, pageID + ", " + guideline_disp + ", " + tech + " を処理しています。 （" + DateUtil.get_logtime() + "）");

                                    ldr.select_techlist(tech);
                                    DateUtil.app_sleep(midWait);

                                    //ldr.browse_all_sv_page();
                                    List<string> srccode_rows = ldr.get_srccode_list();
                                    foreach (string srccode in srccode_rows)
                                    {
                                        List<string> row_data = new List<string>();
                                        row_data.Add(pageID);
                                        row_data.Add(pageURL);
                                        row_data.Add(guideline);
                                        row_data.Add(tech);
                                        row_data.Add(srccode);
                                        rep_data.Add(row_data);
                                    }

                                    //余分な行がついてくるので削除
                                    rep_data.RemoveAt(rep_data.Count - 1);

                                }
                            }
                        }
                        break;
                }

                //DataGridレポート処理
                this.Invoke(message, "データグリッドビューへの書き出しを開始します。（" + DateUtil.get_logtime() + "）");
                List<string> head_row = TextUtil.get_header_SrcTask();
                rep_data.Insert(0, head_row);


                this.Invoke(_data_grid_as_SrcTask, rep_data);

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");
            });
        }
    }
}