using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraUtilGUI
{
    public partial class DataGridForm : Form
    {
        private Form1 main_form;

        //コンストラクタ
        public DataGridForm()
        {
            InitializeComponent();
            reportGridTable.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            reportGridTable.AllowUserToAddRows = false;
            main_form = Form1.main_form;
        }

        //データグリッドセットアップ
        public void init(DataTable tbl)
        {
            reportGridTable.DataSource = tbl;
        }

        //列固定
        public void col_fix_as(int n)
        {
            reportGridTable.Columns[n].Frozen = true;
        }

        //Excel出力
        private void save_as_excel()
        {
            List<List<string>> data = new List<List<string>>();
            Func<DataGridView, List<string>> _head_row = delegate (DataGridView gr)
            {
                List<string> arr = new List<string>();
                for (int i = 0; i < gr.Columns.Count; i++)
                {
                    string col_name = gr.Columns[i].HeaderText;
                    arr.Add(col_name);
                }
                return arr;
            };
            List<string> head_row = _head_row(reportGridTable);
            for(int i=0; i<reportGridTable.RowCount; i++)
            {
                DataGridViewRow cols = reportGridTable.Rows[i];
                List<string> row_data = new List<string>();
                for(int j=0; j<cols.Cells.Count; j++)
                {
                    string col_val = "";
                    if(cols.Cells[j].Value != null) col_val = (string)cols.Cells[j].Value;
                    row_data.Add(col_val);
                }
                data.Add(row_data);
            }

            string save_path = main_form.w_get_workDir();
            string projectID = main_form.w_get_projectID();
            string save_filename = save_path + projectID + "_data_grid_repo_" + DateUtil.fetch_filename_from_datetime("xlsx");
            data.Insert(0, head_row);
            ExcelUtil eu = new ExcelUtil();
            eu.save_xlsx_as(data, save_filename);
        }

        //Excel出力クリック
        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            save_as_excel();
        }
    }
}
