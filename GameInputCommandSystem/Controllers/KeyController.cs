using GameInputCommandSystem.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    [Authorize]
    public class KeyController : ApiController
    {
        //// GET api/key/5 
        //public HttpResponseMessage Get(char id)
        //{
        //    Command test = new Command();
        //    test.Key = id.ToString();
        //    sendCommand(test);
        //    List<Command> responses = new List<Command>();
        //    responses.Add(new Command());
        //    return Request.CreateResponse(HttpStatusCode.OK, responses, Configuration.Formatters.JsonFormatter);
        //}

        // POST api/key 
        public void Post([FromBody]Command value)
        {
            sendCommand(value);
        }

        private void sendCommand(Command value)
        {
            KeyMaster.SendCommand(value);
        }
    }
}
