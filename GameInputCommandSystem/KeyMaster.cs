using AutoIt;
using GameInputCommandSystem.Models;

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
    class KeyMaster
    {
        public bool SendCommand(Command command)
        {
            int rv = AutoItX.WinActivate(GICValues.Instance.Application);
            if (rv == 0)
            {
                return false;
            } else {
                //if any modifiers, send them first
                foreach (string modifier in command.Modifier)
                {
                    AutoItX.Send("{" + modifier + " down}"); 
                }
                //now send the key itself
                AutoItX.Send("{" + command.Key + " down}"); 
                //keep everything pressed for 10ms
                AutoItX.Sleep(10); //
                AutoItX.Send("{" + command.Key + " up}"); //release the LEFT key
                //if any modifiers, unset them last
                foreach (string modifier in command.Modifier)
                {
                    AutoItX.Send("{" + modifier + " up}");
                }
            }
            return true;
        }
    }
}
