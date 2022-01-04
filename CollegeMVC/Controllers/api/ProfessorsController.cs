using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeMVC.Controllers.api
{
    public class ProfessorsController : ApiController
    {
        // GET: api/Professors
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Professors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Professors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Professors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Professors/5
        public void Delete(int id)
        {
        }
    }
}
