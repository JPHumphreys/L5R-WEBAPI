using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    public class UserRatingController : ApiController
    {
        // GET: api/UserRating
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserRating/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserRating
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserRating/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserRating/5
        public void Delete(int id)
        {
        }
    }
}
