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
namespace GameInputCommandSystem.Controllers
{
    /**
     * Used to validate the version of the server is what the client expects
     * */
    public class VersionController : ApiController
    {
        private const string API_VERSION = "1.3.0.0";
        /**
         * Returns current API version of this server
         * */
        public HttpResponseMessage Get()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            //FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = API_VERSION;// fileVersionInfo.ProductVersion;

            return Request.CreateResponse(HttpStatusCode.OK, version, Configuration.Formatters.JsonFormatter);
        }
    }
}
