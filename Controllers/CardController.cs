using L5R_API.Models;//allows the use of card class model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    /// <summary>
    /// This Controller is for the L5R cards.
    /// </summary>
    public class CardController : ApiController
    {
        List<Card> cards = new List<Card>();

        public CardController()
        {
            cards.Add(new Card
            {
                id = "shrewd-yasuki",
                clan = "crab",
                side = "dynasty",
                type = "character"
            });
            cards.Add(new Card
            {
                id = "hida-kisada",
                clan = "crab",
                side = "dynasty",
                type = "character"
            });
            cards.Add(new Card
            {
                id = "kaiu-envoy",
                clan = "crab",
                side = "dynasty",
                type = "character"
            });

        }

        /// <summary>
        /// Gets a list of the ids from the cardslist
        /// </summary>
        /// <returns>A list of ids</returns>

        [Route("api/Card/all/{id}")]//{id}/{type}//string is assumed type
        [HttpGet]//come between for multiple
        public List<string> GetCardIds()
        {
            List<string> idList = new List<string>();

            foreach(var c in cards)
            {
                idList.Add(c.id);
            }

            return idList;
        }

        // GET: api/Card
        public List<Card> Get()
        {
            return cards;
        }

        // GET: api/Card/id(string)
        public Card Get(string id)
        {
            return cards.Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Card
        public void Post(Card newCard)
        {
            //test to see if its a valid card
            cards.Add(newCard);

        }

        // PUT: api/Card/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE: api/Card/id(string)
        public void Delete(string id)
        {
            //cards.Remove
        }
    }
}
