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

        // GET: api/Card/id(string)
        //public Card Get(string id)
        //{
            
        //}

    }
}
