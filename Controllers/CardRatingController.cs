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
    public class CardRatingController : ApiController
    {

        //declare sql connection
        private SqlConnection _con;
        private SqlDataAdapter _adapter;

        // GET: api/CardRating
        public List<CardRating> Get()
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM CardRatings";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<CardRating> ratings = new List<Models.CardRating>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow ratingRecord in _dt.Rows)
                {
                    ratings.Add(new ReadCardRating(ratingRecord));
                }
            }

            return ratings;
        }

        // GET: api/CardRating/id
        public string Get(string id)
        {
            return "value";
        }

        // PUT: api/CardRating/id
        public void Put(string id, [FromBody]CreateCardRating value)
        {

        }

    }
}
