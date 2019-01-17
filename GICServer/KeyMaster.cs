using GICServer.Models;
using Keyboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICServer
{
    class KeyMaster
    {
        public void SendCommand(Command command)
        {
            var p = new Process { StartInfo = { FileName = GICValues.Instance.Application } };

            p.Start();

            try
            {
                //List<Key> keys = "hello world".Select(c => new Key(c)).ToList();
                //var procId = p.Id;
                ////Console.WriteLine("ID: " + procId);
                ////Console.WriteLine("Sending background keypresses to write \"hello world\"");
                //p.WaitForInputIdle();
                //foreach (var key in keys)
                //{
                //    key.PressForeground(p.MainWindowHandle);
                //}
                Key key = new Key(command.Key);
                key.PressBackground(p.MainWindowHandle);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
