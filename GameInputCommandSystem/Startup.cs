using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Thinktecture.IdentityModel.Owin;

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
    class Startup
    {
        // Configures the Web API. This class is a parameter in the WerbApp.Start method in the main class.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseBasicAuthentication(new BasicAuthenticationOptions("SecureApi",
                async (username, password) => await Authenticate(username, password)));

            appBuilder.UseWebApi(config);
        }
        private async Task<IEnumerable<Claim>> Authenticate(string username, string password)
        {
            // authenticate user
            if (username == "gic" && password == Properties.Settings.Default.password)
            {
                return new List<Claim> {
            new Claim("name", username)
        };
            }

            return null;
        }
    }
}
