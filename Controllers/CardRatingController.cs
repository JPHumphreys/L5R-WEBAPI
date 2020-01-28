using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    public class CardRatingController : ApiController
    {
        // GET: api/CardRating
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CardRating/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CardRating
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CardRating/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CardRating/5
        public void Delete(int id)
        {
        }
    }
}
