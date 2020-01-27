using L5R_API.Models;//allows the use of card class model
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
    /// <summary>
    /// This Controller is for the L5R cards.
    /// </summary>
    public class CardController : ApiController
    {
        //declare sql connection
        private SqlConnection _con;
        private SqlDataAdapter _adapter;

        //[Route("api/Card/all/{id}")]//{id}/{type}//string is assumed type
        //[HttpGet]//come between for multiple
        //public List<string> GetCardIds()
        //{
        //    List<string> idList = new List<string>();

        //    foreach(var c in cards)
        //    {
        //        idList.Add(c.id);
        //    }

        //    return idList;
        //}


        // GET: api/Card
        /// <summary>
        /// This is a query to return all the cards in the DB
        /// </summary>
        /// <returns></returns>
        public List<Card> Get()
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM Cards";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<Card> cards = new List<Models.Card>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow cardRecord in _dt.Rows)
                {
                    cards.Add(new ReadCard(cardRecord));
                }
            }

            return cards;
        }

        // GET: api/Card/clan/side/type
        /// <summary>
        ///     This is used for the cards.html page of the website
        /// </summary>
        /// <param name="clan">This is the clan of the card</param>
        /// <param name="side">This is the deck of the card</param>
        /// <param name="type">This is the type of the card</param>
        /// <returns>List of cards that match the clan,side and type of the api query</returns>
        [Route("api/Card/{clan}/{side}/{type}")]
        public List<Card> Get(string clan, string side, string type)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();

            var _clan = "";
            var _side = "";
            var _type = "";
            int counter = 0;

            if(clan != "ns")
            {
                _clan = "clan= '" + clan + "'";
                counter++;
            }
            if(side != "ns")
            {
                if(counter > 0)
                {
                    _side = "AND side= '" + side + "'";
                }
                else
                {
                    _side = "side = '" + side + "'";
                }
                counter++;
            }
            if(type != "ns")
            {
                if (counter > 0)
                {
                    _type = " AND typeof= '" + type + "'";
                }
                else
                {
                    _type = "typeof = '" + type + "'";
                }
            }

            var query = "SELECT * FROM Cards WHERE " + _clan + _side + _type;

            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<Card> cards = new List<Models.Card>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow cardRecord in _dt.Rows)
                {
                    cards.Add(new ReadCard(cardRecord));
                }
            }

            return cards;
        }

    }
}
