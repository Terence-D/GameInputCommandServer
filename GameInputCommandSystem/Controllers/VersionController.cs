using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace GameInputCommandSystem.Controllers
{
    public class VersionController : ApiController
    {
        // Get api/version
        public HttpResponseMessage Get()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;

            return Request.CreateResponse(HttpStatusCode.OK, version, Configuration.Formatters.JsonFormatter);
        }
    }
}
