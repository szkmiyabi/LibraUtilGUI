﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    class FileUtil
    {
        private Form1 form1;

        //コンストラクタ
        public FileUtil(Form1 form1)
        {
            this.form1 = form1;
        }

        //デリゲート
        public delegate void d_messenger(string msg);
        public void w_messenger(string msg)
        {
            form1.operationStatusReport.AppendText(msg + "\r\n");
        }


        //2次元配列をTSVファイルとして書き込み
        public void write_tsv_data(List<List<string>> data, string filename)
        {
            Encoding enc = new System.Text.UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(filename, false, enc);
            for(int i=0; i<data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string row_data = col[0] + "\t" + col[1] + "\r\n";
                sw.Write(row_data);
            }
            sw.Close();
            d_messenger message = new d_messenger(w_messenger);
            form1.Invoke(message, "保存に成功しました。（" + DateUtil.get_logtime() + "）");
        }
    }
}
