using L5R_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    public class DeckController : ApiController
    {

        //declare sql connection
        private SqlConnection _con;
        private SqlDataAdapter _adapter;

        // GET: api/Deck
        //public List<Deck> Get()
        //{

        //}

        // GET: api/Deck/username
        /// <summary>
        /// Gets ALL decks by a username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>List of deck objects that are sorted in the front end</returns>
        public List<Deck> Get(string username)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM Decks WHERE username= '" + username + "'" +
                " ORDER BY name";
            //order by name so that the cards in the decks are with eachother
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<Deck> decks = new List<Models.Deck>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow deckRecords in _dt.Rows)
                {
                    decks.Add(new ReadDeck(deckRecords));
                }
            }

            return decks;
        }

        // POST: api/Deck
        public void Post([FromBody]string value)
        {
        }

        // DELETE: api/Deck/5
        public void Delete(int id)
        {
        }
    }
}
