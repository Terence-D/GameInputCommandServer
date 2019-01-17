using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace GICServer
{
    public class GateKeeper
    {
        private IDisposable app;

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

        public void Start()
        {
            string baseAddress = "http://" + Address + ":" + Port + "/";

            // Start our OWIN hosting
            //app = WebApp.Start<Startup>(url: baseAddress);
            //using (app)
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create the HttpCient 
                HttpClient client = new HttpClient();
            }
        }

        public void Stop()
        {
            app.Dispose();
        }
    }
}
