using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{

    //プロジェクトIDコンボのデータ構造クラス
    public class projectIDComboItem
    {
        private string _id_str;
        private string _display_str;

        //コンストラクタ
        public projectIDComboItem() { }
        public projectIDComboItem(string id, string display)
        {
            _id_str = id;
            _display_str = display;
        }

        //ゲッターとセッター
        public string id_str
        {
            get { return _id_str; }
            set { _id_str = value; }
        }
        public string display_str
        {
            get { return _display_str; }
            set { _display_str = value; }
        }
    }


    //ページIDコンボのデータ構造クラス
    public class pageIDComboItem
    {
        private string _id_str;
        private string _display_str;

        //コンストラクタ
        public pageIDComboItem() { }
        public pageIDComboItem(string id, string display)
        {
            _id_str = id;
            _display_str = display;
        }

        //ゲッターとセッター
        public string id_str
        {
            get { return _id_str; }
            set { _id_str = value; }
        }
        public string display_str
        {
            get { return _display_str; }
            set { _display_str = value; }
        }
    }


    //ガイドラインIDコンボのデータ構造および静的メソッドクラス
    public class guidelineComboItem
    {
        private string _id_str;
        private string _display_str;

        //コンストラクタ
        public guidelineComboItem() {}
        public guidelineComboItem(string id, string display)
        {
            _id_str = id;
            _display_str = display;
        }

        //ゲッターとセッター
        public string id_str
        {
            get { return _id_str; }
            set { _id_str = value; }
        }
        public string display_str
        {
            get { return _display_str; }
            set { _display_str = value; }
        }

        //達成基準のリストを生成
        public static List<string> get_guideline_list(string type)
        {
            if (type == "" || type == null) type = "AA";
            List<string> ret = new List<string>();
            if(type == "A")
            {
                List<string> data = get_A();
                ret = data;
            }
            else if(type == "AA")
            {
                List<string> data1 = get_A();
                List<string> data2 = get_AA();
                data1.AddRange(data2);
                ret = data1;
            }
            else if(type == "AAA")
            {
                List<string> data1 = get_A();
                List<string> data2 = get_AA();
                List<string> data3 = get_AAA();
                data1.AddRange(data2);
                data1.AddRange(data3);
                ret = data1;
            }
            return ret;
        }
        private static List<string> get_A()
        {
            List<string> data = new List<string>()
            {
                "1.1.1","1.2.1","1.2.2","1.2.3","1.3.1","1.3.2","1.3.3","1.4.1","1.4.2","2.1.1","2.1.2","2.2.1","2.2.2","2.3.1","2.4.1","2.4.2","2.4.3","2.4.4","3.1.1","3.2.1","3.2.2","3.3.1","3.3.2","4.1.1","4.1.2"
            };
            return data;
        }
        private static List<string> get_AA()
        {
            List<string> data = new List<string>()
            {
                "1.2.4","1.2.5","1.4.3","1.4.4","1.4.5","2.4.5","2.4.6","2.4.7","3.1.2","3.2.3","3.2.4","3.3.3","3.3.4"
            };
            return data;
        }
        private static List<string> get_AAA()
        {
            List<string> data = new List<string>()
            {
                "1.2.6","1.2.7","1.2.8","1.2.9","1.4.6","1.4.7","1.4.8","1.4.9","2.1.3","2.2.3","2.2.4","2.2.5","2.3.2","2.4.8","2.4.9","2.4.10","3.1.3","3.1.4","3.1.5","3.1.6","3.2.5","3.3.5","3.3.6"
            };
            return data;
        }

    }
}
