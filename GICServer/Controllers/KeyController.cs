using GICServer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GICServer.Controllers
{
    class KeyController : ApiController
    {
        private KeyMaster km = new KeyMaster();

        // GET api/values 
        public IEnumerable<string> Get()
        {
            Command test = new Command();
            test.Key = 'd';
            SendCommand(test);
            return new string[] { "value1", "value2" };
        }

        //// GET api/values/5 
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values 
        public void Post([FromBody]Command value)
        {
            SendCommand(value);
        }

        //// PUT api/values/5 
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5 
        //public void Delete(int id)
        //{
        //}

        private void SendCommand(Command value)
        {
            km.SendCommand(value);
        }
    }
}
