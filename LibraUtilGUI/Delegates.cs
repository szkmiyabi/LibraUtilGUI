﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraUtilGUI
{
    partial class Form1
    {
        //デリゲート（Libraドライバの起動とエラー処理）
        private delegate Boolean d_ldr_activate();
        private Boolean w_ldr_activate()
        {
            if (load_wd())
            {
                operationStatusReport.AppendText("ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）" + "\r\n");
                return true;
            }
            else
            {
                operationStatusReport.AppendText("【エラー】ブラウザドライバの起動に失敗しました。考えられる理由は、ブラウザのドライバが作業フォルダ内に未設置、あるいは、ブラウザのドライバのバージョンが現行のブラウザ用より古いか、新しすぎるかのどちらかです。サポートされているバージョンのブラウザのドライバに差し換えてください。\r\n");
                operationStatusReport.AppendText(error_buff + "\r\n");
                return false;
            }
        }

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
        public delegate string d_get_workDir();
        public string w_get_workDir()
        {
            return workDir;
        }

        //デリゲート（プロジェクトID参照）
        public delegate string d_get_projectID();
        public string w_get_projectID()
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

        //デリゲート（タスクのキャンセル判定とキャンセル実行処理）
        private delegate Boolean d_task_cancel();
        private Boolean w_task_cancel()
        {
            Boolean flag = false;
            if (token.IsCancellationRequested)
            {
                operationStatusReport.AppendText("処理をキャンセルします。（" + DateUtil.get_logtime() + "）" + "\r\n");
                token_src.Dispose();
                token_src = null;
                if (ldr != null) ldr.logout();
                operationStatusReport.AppendText("処理をキャンセルしLibraからログアウトしました。（" + DateUtil.get_logtime() + "）" + "\r\n");
                flag = true;
            }
            return flag;
        }

        //デリゲート（コントロールの有効無効制御）
        private delegate void d_ctrl_toggle(string ctrl_name);
        private void ctrl_toggle(string ctrl_name)
        {
            List<Control> controls = GetAllControls<Control>(this);
            foreach (var ctrl in controls)
            {
                if (ctrl.Name == ctrl_name)
                {
                    ctrl.Enabled = !ctrl.Enabled;
                    break;
                }
            }
        }

        //デリゲート（コントロールの有効制御）
        private delegate void d_ctrl_activate(string ctrl_name);
        private void ctrl_activate(string ctrl_name)
        {
            List<Control> controls = GetAllControls<Control>(this);
            foreach (var ctrl in controls)
            {
                if (ctrl.Name == ctrl_name)
                {
                    ctrl.Enabled = true;
                    break;
                }
            }
        }

        //デリゲート（コントロールの無効制御）
        private delegate void d_ctrl_deactivate(string ctrl_name);
        private void ctrl_deactivate(string ctrl_name)
        {
            List<Control> controls = GetAllControls<Control>(this);
            foreach (var ctrl in controls)
            {
                if (ctrl.Name == ctrl_name)
                {
                    ctrl.Enabled = false;
                    break;
                }
            }
        }

        //デリゲート（メイン画面のサイトIDコンボセットアップ）
        private delegate void d_set_projectID_combo(List<List<string>> data);
        private void w_set_projectID_combo(List<List<string>> data)
        {
            List<projectIDComboItem> ListBoxItem = new List<projectIDComboItem>();
            projectIDComboItem itm;
            for (int i = 0; i < data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string text = col[0] + "  " + col[1];
                itm = new projectIDComboItem(col[0], text);
                ListBoxItem.Add(itm);
            }
            projectIDListBox.DisplayMember = "display_str";
            projectIDListBox.ValueMember = "id_str";
            projectIDListBox.DataSource = ListBoxItem;
        }

        //デリゲート（メイン画面のページIDコンボセットアップ）
        private delegate void d_set_pageID_combo(List<List<string>> data);
        private void w_set_pageID_combo(List<List<string>> data)
        {
            List<pageIDComboItem> ListBoxItem = new List<pageIDComboItem>();
            pageIDComboItem itm;
            for (int i = 0; i < data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string text = "[" + col[0] + "]  " + col[1];
                itm = new pageIDComboItem(col[0], text);
                ListBoxItem.Add(itm);
            }
            pageIDListBox.DisplayMember = "display_str";
            pageIDListBox.ValueMember = "id_str";
            pageIDListBox.DataSource = ListBoxItem;

            SendMessage(pageIDListBox.Handle, LB_SETSEL, 0, -1);
            pageIDListBox.SetSelected(0, false);
        }

        //デリゲート（メイン画面の実装番号コンボセットアップ）
        private delegate void d_set_techID_combo(List<string> data);
        private void w_set_techID_combo(List<string> data)
        {
            List<techIDComboItem> ListBoxItem = new List<techIDComboItem>();
            techIDComboItem itm;
            for(int i=0; i<data.Count; i++)
            {
                string row = (string)data[i];
                itm = new techIDComboItem(row, row);
                ListBoxItem.Add(itm);
            }
            techListBox.DisplayMember = "display_str";
            techListBox.ValueMember = "id_str";
            techListBox.DataSource = ListBoxItem;

            SendMessage(techListBox.Handle, LB_SETSEL, 0, -1);
            techListBox.SetSelected(0, false);
        }


        //デリゲート（UrlTaskの参照タイプ参照）
        private delegate string d_get_UrlTask_source_flag();
        private string w_get_UrlTask_source_flag()
        {
            string flag = "";
            if (UrlTaskSrcSurvey.Checked) flag = "svpage";
            else if (UrlTaskSrcPageIDCombo.Checked) flag = "combo";
            else flag = "report";
            return flag;
        }

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
            foreach (pageIDComboItem cmb in pageIDListBox.SelectedItems)
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

            if (opt == "comma")
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
            foreach (guidelineComboItem cmb in guidelineListBox.SelectedItems)
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

        //デリゲート（実装番号コンボが選択されているか）
        private delegate Boolean d_is_tech_selected();
        private Boolean w_is_tech_selected()
        {
            if (techListBox.SelectedItems.Count == 0) return false;
            else return true;
        }

        //デリゲート（実装番号コンボ選択値を取得）
        private delegate List<string> d_tech_data();
        private List<string> w_tech_data()
        {
            List<string> data = new List<string>();

            //データバインドしたListBoxの項目はそのデータ型でしか取り出せない
            foreach (techIDComboItem cmb in techListBox.SelectedItems)
            {
                data.Add(cmb.id_str);
            }
            return data;
        }

        //デリゲート（PreSvTaskの解析内容配列を取得）
        private delegate List<string> d_get_presv_operation();
        private List<string> w_get_presv_operation()
        {
            List<string> data = new List<string>();
            if(PreSvTaskCC.Checked) data.Add("css-cut");
            if(PreSvTaskDL.Checked) data.Add("document-link");
            if(PreSvTaskTA.Checked) data.Add("target-attr");
            if(PreSvTaskIA.Checked) data.Add("image-alt");
            if(PreSvTaskLA.Checked) data.Add("lang-attr");
            if(PreSvTaskSC.Checked) data.Add("semantic-check");
            if(PreSvTaskTLTA.Checked) data.Add("tag-label-and-title-attr");
            return data;
        }

        //デリゲート（PreSvTaskの重ね掛け判定）
        private delegate Boolean d_get_layer_flag();
        private Boolean w_get_layer_flag()
        {
            if (PreSvTaskLayerYes.Checked) return true;
            else return false;
        }

        //デリゲート（BrowseTaskのモード判定）
        private delegate string d_get_browse_mode();
        private string w_get_browse_mode()
        {
            string ret = "normal";
            if (BrowseTaskNormal.Checked) ret = "normal";
            else if (BrowseTaskSurvey.Checked) ret = "survey";
            return ret;
        }

        //デリゲート（RepoTaskのデータグリッド出力）
        private delegate void d_data_grid_as_RepoTask(List<List<string>> data);
        private void w_data_grid_as_RepoTask(List<List<string>> data)
        {
            DataTable tbl = new DataTable("RepoTaskTable");

            //カラム設定
            List<string> head_row = (List<string>)data[0];
            foreach (string col in head_row)
            {
                tbl.Columns.Add(col);
            }

            //行のループ
            for (int i = 0; i < data.Count; i++)
            {
                if (i == 0) continue;
                List<string> row = (List<string>)data[i];
                DataRow newRow = tbl.NewRow();

                //列のループ
                for (int j = 0; j < row.Count; j++)
                {
                    string col = (string)row[j];
                    if (j == 2) col = TextUtil.jis2016_encode(col);
                    newRow[head_row[j]] = col;
                }
                tbl.Rows.Add(newRow);
            }

            data_grid_form.init(tbl);
            data_grid_form.col_auto_size(0, 2, 3, 4, 5);
            data_grid_form.Show();
        }

        //デリゲート（SrcTaskのデータグリッド出力）
        private delegate void d_data_grid_as_SrcTask(List<List<string>> data);
        private void w_data_grid_as_SrcTask(List<List<string>> data)
        {
            DataTable tbl = new DataTable("SrcTaskTable");

            //カラム設定
            List<string> head_row = (List<string>)data[0];
            foreach (string col in head_row)
            {
                tbl.Columns.Add(col);
            }

            //行のループ
            for (int i = 0; i < data.Count; i++)
            {
                if (i == 0) continue;
                List<string> row = (List<string>)data[i];
                DataRow newRow = tbl.NewRow();

                //列のループ
                for (int j = 0; j < row.Count; j++)
                {
                    string col = (string)row[j];
                    newRow[head_row[j]] = col;
                }
                tbl.Rows.Add(newRow);
            }

            data_grid_form.init(tbl);
            data_grid_form.col_auto_size(0, 2, 3);
            data_grid_form.Show();
        }

    }
}
