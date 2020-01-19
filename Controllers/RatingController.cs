using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    public class RatingController : ApiController
    {
        // GET: api/Rating
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rating/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rating
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rating/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rating/5
        public void Delete(int id)
        {
        }
    }
}
