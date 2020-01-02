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
        //コンストラクタ
        public DataGridForm()
        {
            InitializeComponent();
            reportGridTable.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
    }
}
