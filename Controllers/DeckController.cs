using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    public class DeckController : ApiController
    {
        // GET: api/Deck
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Deck/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Deck
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Deck/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Deck/5
        public void Delete(int id)
        {
        }
    }
}
