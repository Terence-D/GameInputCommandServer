using GameInputCommandSystem.Models;
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
    /**
     * Used for commands related to a standard key up/down event
     * */
    [Authorize]
    public class KeyController : ApiController
    {
        /**
         * Client will send in a specific key command along with modifiers and the event type - key down or key up
         * */
        public void Post([FromBody]Command value)
        {
            KeyMaster.SendCommand(value, false);
        }
    }
}
