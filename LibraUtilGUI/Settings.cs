using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraUtilGUI
{
    public class Settings
    {
        private string _uid;
        private string _pswd;
        private int _systemWait;
        private int _longWait;
        private int _midWait;
        private int _shortWait;
        private string _driver;
        private string _headless;
        private string _guidelineLevel;
        private string _basic_auth;
        private string _workDir;

        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

        public string pswd
        {
            get { return _pswd; }
            set { _pswd = value; }
        }

        public int systemWait
        {
            get { return _systemWait; }
            set { _systemWait = value; }
        }

        public int longWait
        {
            get { return _longWait; }
            set { _longWait = value; }
        }

        public int midWait
        {
            get { return _midWait; }
            set { _midWait = value; }
        }

        public int shortWait
        {
            get { return _shortWait; }
            set { _shortWait = value; }
        }

        public string driver
        {
            get { return _driver; }
            set { _driver = value; }
        }

        public string headless
        {
            get { return _headless; }
            set { _headless = value; }
        }

        public string guidelineLevel
        {
            get { return _guidelineLevel; }
            set { _guidelineLevel = value; }
        }

        public string basic_auth
        {
            get { return _basic_auth; }
            set { _basic_auth = value; }
        }

        public string workDir
        {
            get { return _workDir; }
            set { _workDir = value; }
        }

        //コンストラクタ
        public Settings()
        {
            _uid = "";
            _pswd = "";
            _systemWait = 0;
            _longWait = 0;
            _midWait = 0;
            _shortWait = 0;
            _driver = "";
            _headless = "";
            _guidelineLevel = "";
            _basic_auth = "";
            _workDir = "";
        }

    }
}
