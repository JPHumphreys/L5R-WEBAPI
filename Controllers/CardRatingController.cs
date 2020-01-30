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
        /// <summary>
        /// check id for single card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(string id)
        {
            return "need to do";
        }

        // PUT: api/CardRating/id
        public void Put(string id, [FromBody]CreateCardRating value)
        {

        }

        /// <summary>
        /// This is used in conjunction with posting a new userrating
        /// This starts the process of adding the new value into the cardrating database
        /// This also calls the update of the card effected.
        /// </summary>
        /// <param name="id">the ID of the card</param>
        /// <param name="rating">the new rating being added to the card</param>
        /// <param name="newVote">this will either be 0 or 1 and this adds a new vote to the card</param>
        /// <param name="clan">The clan that the rating corresponds to</param>
        public void updateCard(string id, float rating, string clan, int newVote)
        {
            if(newVote > 0)
            {
                //add the new vote with a put
            }

            //organise the database
            organiseTheData(id, clan, rating);
        }

        private void organiseTheData(string id, string clan, float rating)
        {
            //

        }

    }
}
