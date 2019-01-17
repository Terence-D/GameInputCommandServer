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
                AutoItX.Send("{" + command.Key + " down}"); //hold down the LEFT key
                AutoItX.Sleep(10); //keep it pressed for 10 milliseconds
                AutoItX.Send("{" + command.Key + " up}"); //release the LEFT key
            }
            return true;
        }
    }
}
