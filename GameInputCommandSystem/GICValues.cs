using System;
using System.Diagnostics;

/**
 Copyright [2019] [Terence Doerksen]

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */
namespace GameInputCommandSystem
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

        public Process ActiveProcess { get; set; }

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
