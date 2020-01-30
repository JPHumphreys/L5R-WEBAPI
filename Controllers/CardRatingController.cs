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
        public CardRating Get(string id)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM CardRatings WHERE id='" + id + "'";
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

            return ratings[0];
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
            addTheData(id, clan, rating);
        }

        private void addTheData(string id, string clan, float rating)
        {
            //get the current values
            CardRating cr = new CardRating();
            cr = Get(id);
            float newRating = 0.0f;
            
            switch (clan)
            {
                //times the votes by the rating
                //add the rating 
                //divide back down and PUT that as the new rating
                case "crab":
                    newRating = cr.ratingcrab * cr.totalvotescrab;
                    newRating += rating;
                    newRating /= cr.totalvotescrab;
                    break;
                case "crane":
                    newRating = cr.ratingcrane * cr.totalvotescrane;
                    newRating += rating;
                    newRating /= cr.totalvotescrane;
                    break;
                case "dragon":
                    newRating = cr.ratingdragon * cr.totalvotesdragon;
                    newRating += rating;
                    newRating /= cr.totalvotesdragon;
                    break;
                case "lion":
                    newRating = cr.ratinglion * cr.totalvoteslion;
                    newRating += rating;
                    newRating /= cr.totalvoteslion;
                    break;
                case "phoenix":
                    newRating = cr.ratingphoenix * cr.totalvotesphoenix;
                    newRating += rating;
                    newRating /= cr.totalvotesphoenix;
                    break;
                case "scorpion":
                    newRating = cr.ratingscorpion * cr.totalvotesscorpion;
                    newRating += rating;
                    newRating /= cr.totalvotesscorpion;
                    break;
                case "unicorn":
                    newRating = cr.ratingunicorn * cr.totalvotesunicorn;
                    newRating += rating;
                    newRating /= cr.totalvotesunicorn;
                    break;
                default:
                    //this should not happen
                    return;
            }

            //put the new rating as the clans current rating
            //update overall rating

            float test = calculateOverallRating(cr);

        }

        private List<CardRating> GetQuery(string query)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            
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

        private float calculateOverallRating(CardRating card)
        {
            return getTotalScore(card) / getTotalVotes(card);
        }

        private float getTotalScore(CardRating card)
        {
            float totalScore = 0.0f;

            if (card.totalvotescrab != 0)
            {
                totalScore += card.ratingcrab * card.totalvotescrab;
            }

            if(card.totalvotescrane != 0)
            {
                totalScore += card.ratingcrane * card.totalvotescrane;
            }

            if(card.totalvotesdragon != 0)
            {
                totalScore += card.ratingdragon * card.totalvotesdragon;
            }

            if(card.totalvoteslion != 0)
            {
                totalScore += card.ratinglion * card.totalvoteslion;
            }

            if(card.totalvotesphoenix != 0)
            {
                totalScore += card.ratingphoenix * card.totalvotesphoenix;
            }

            if(card.totalvotesscorpion != 0)
            {
                totalScore += card.ratingscorpion * card.totalvotesscorpion;
            }

            if(card.totalvotesunicorn != 0)
            {
                totalScore += card.ratingunicorn * card.totalvotesunicorn;
            }

            return totalScore;
        }

        private int getTotalVotes(CardRating card)
        {
            return card.totalvotescrab + card.totalvotescrane +
                card.totalvotesdragon + card.totalvoteslion +
                card.totalvotesphoenix + card.totalvotesscorpion +
                card.totalvotesunicorn;
        }

    }
}
