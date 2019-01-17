using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICServer
{
    class GICValues
    {
        private static readonly Lazy<GICValues> instance = new Lazy<GICValues>(() => new GICValues());
        public static GICValues Instance { get { return instance.Value; } }

        private string address = "localhost";
        private int port = 8093;
        private string password = "123456";
        private string application = "notepad.exe";


        private GICValues()
        {
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                if (value > 1023 && value < 655535)
                    port = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 6 && value.Length < 100)
                    password = value;
            }
        }
        public string Application
        {
            get
            {
                return application;
            }
            set
            {
                if (value.Length > 0)
                    application = value;
            }
        }

    }
}
