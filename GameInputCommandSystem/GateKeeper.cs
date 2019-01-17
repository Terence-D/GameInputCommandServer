using Microsoft.Owin.Hosting;
using System;
using System.Diagnostics;
using System.Net.Http;

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
    public class GateKeeper
    {
        private IDisposable app;
        private HttpClient client;

        public string Address
        {
            get
            {
                return GICValues.Instance.Address;
            }
            set
            {
                GICValues.Instance.Address = value;
            }
        }

        public int Port
        {
            get
            {
                return GICValues.Instance.Port;
            }
            set
            {
                GICValues.Instance.Port = value;
            }
        }

        public string Password
        {
            get
            {
                return GICValues.Instance.Password;
            }
            set
            {
                GICValues.Instance.Password = value;
            }
        }
        public string Application
        {
            get
            {
                return GICValues.Instance.Application;
            }
            set
            {
                GICValues.Instance .Application = value;
            }
        }

        public bool Start()
        {
            //GICValues.Instance.ActiveProcess = FindProcess();

            //if (GICValues.Instance.ActiveProcess != null)
            {
                string baseAddress = "http://" + "*" + ":" + Port + "/";

                // Start our OWIN hosting
                app = WebApp.Start<Startup>(url: baseAddress);
                client = new HttpClient();
                return true;
            }
            //return false;
        }

        private Process FindProcess()
        {
            Process[] procs = Process.GetProcesses();

            foreach (Process proc in procs)
            {
                if (proc.MainWindowTitle == GICValues.Instance.Application)
                    return proc;
            }

            return null;
        }

        public void Stop()
        {
            app.Dispose();
            client.Dispose();
        }
    }
}
