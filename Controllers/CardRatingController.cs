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
        public string updateCard(string id, float rating, string clan, int newVote)
        {
            //get the current values
            CardRating cr = new CardRating();
            cr = Get(id);
            float ratingTotal = 0.0f;

            switch (clan)
            {
                //1/times the votes by the rating --(IF NOT 0)
                //2/add the rating (plus / minus)
                //3/add the voting (plus / minus)
                //4/divide back down and PUT that as the new rating --(IF NOT 0)
                case "crab":
                    if(cr.totalvotescrab != 0)
                    {
                        ratingTotal = cr.ratingcrab * cr.totalvotescrab;
                    }
                    ratingTotal += rating;
                    cr.totalvotescrab += newVote;
                    if(cr.totalvotescrab != 0)
                    {
                        cr.ratingcrab = ratingTotal / cr.totalvotescrab;
                    }
                    else
                    {
                        cr.ratingcrab = 0;
                    }
                    break;
                case "crane":
                    if(cr.totalvotescrane != 0)
                    {
                        ratingTotal = cr.ratingcrane * cr.totalvotescrane;
                    }
                    ratingTotal += rating;
                    cr.totalvotescrane += newVote;
                    if(cr.totalvotescrane != 0)
                    {
                        cr.ratingcrane = ratingTotal / cr.totalvotescrane;
                    }
                    else
                    {
                        cr.ratingcrane = 0;
                    }
                    break;
                case "dragon":
                    if(cr.totalvotesdragon != 0)
                    {
                        ratingTotal = cr.ratingdragon * cr.totalvotesdragon;
                    }
                    ratingTotal += rating;
                    cr.totalvotesdragon += newVote;
                    if(cr.totalvotesdragon != 0)
                    {
                        cr.ratingdragon = ratingTotal / cr.totalvotesdragon;
                    }
                    else
                    {
                        cr.ratingdragon = 0;
                    }
                    break;
                case "lion":
                    if(cr.totalvoteslion != 0)
                    {
                        ratingTotal = cr.ratinglion * cr.totalvoteslion;
                    }
                    ratingTotal += rating;
                    cr.totalvoteslion += newVote;
                    if(cr.totalvoteslion != 0)
                    {
                        cr.ratinglion = ratingTotal / cr.totalvoteslion;
                    }
                    else
                    {
                        cr.ratinglion = 0;
                    }
                    break;
                case "phoenix":
                    if(cr.totalvotesphoenix != 0)
                    {
                        ratingTotal = cr.ratingphoenix * cr.totalvotesphoenix;
                    }
                    ratingTotal += rating;
                    cr.totalvotesphoenix += newVote;
                    if(cr.totalvotesphoenix != 0)
                    {
                        cr.ratingphoenix = ratingTotal / cr.totalvotesphoenix;
                    }
                    else
                    {
                        cr.ratingphoenix = 0;
                    }
                    break;
                case "scorpion":
                    if(cr.totalvotesscorpion != 0)
                    {
                        ratingTotal = cr.ratingscorpion * cr.totalvotesscorpion;
                    }
                    ratingTotal += rating;
                    cr.totalvotesscorpion += newVote;
                    if(cr.totalvotesscorpion != 0)
                    {
                        cr.ratingscorpion = ratingTotal / cr.totalvotesscorpion;
                    }
                    else
                    {
                        cr.ratingscorpion = 0;
                    }
                    break;
                case "unicorn":
                    if (cr.totalvotesunicorn != 0)
                    {
                        ratingTotal = cr.ratingunicorn * cr.totalvotesunicorn;
                    }
                    ratingTotal += rating;
                    cr.totalvotesunicorn += newVote;
                    if(cr.totalvotesunicorn != 0)
                    {
                        cr.ratingunicorn = ratingTotal / cr.totalvotesunicorn;
                    }
                    else
                    {
                        cr.ratingunicorn = 0;
                    }
                    break;
                default:
                    //this should not happen
                    return "false";
            }

            //put the new rating as the clans current rating
            //update overall rating

            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            var query = "UPDATE CardRatings SET overallrating=@overallrating," +

                "ratingcrab=@ratingcrab," +
                "ratingcrane=@ratingcrane," +
                "ratingdragon=@ratingdragon," +
                "ratinglion=@ratinglion," +
                "ratingphoenix=@ratingphoenix," +
                "ratingscorpion=@ratingscorpion," +
                "ratingunicorn=@ratingunicorn," +

                "totalvotescrab=@totalvotescrab," +
                "totalvotescrane=@totalvotescrane," +
                "totalvotesdragon=@totalvotesdragon," +
                "totalvoteslion=@totalvoteslion," +
                "totalvotesphoenix=@totalvotesphoenix," +
                "totalvotesscorpion=@totalvotesscorpion," +
                "totalvotesunicorn=@totalvotesunicorn" +

                " WHERE id= '" + id + "'";
            SqlCommand insertCommand = new SqlCommand(query, _con);

            insertCommand.Parameters.AddWithValue("@overallrating", calculateOverallRating(cr));

            insertCommand.Parameters.AddWithValue("@ratingcrab", cr.ratingcrab);
            insertCommand.Parameters.AddWithValue("@ratingcrane", cr.ratingcrane);
            insertCommand.Parameters.AddWithValue("@ratingdragon", cr.ratingdragon);
            insertCommand.Parameters.AddWithValue("@ratinglion", cr.ratinglion);
            insertCommand.Parameters.AddWithValue("@ratingphoenix", cr.ratingphoenix);
            insertCommand.Parameters.AddWithValue("@ratingscorpion", cr.ratingscorpion);
            insertCommand.Parameters.AddWithValue("@ratingunicorn", cr.ratingunicorn);

            insertCommand.Parameters.AddWithValue("@totalvotescrab", cr.totalvotescrab);
            insertCommand.Parameters.AddWithValue("@totalvotescrane", cr.totalvotescrane);
            insertCommand.Parameters.AddWithValue("@totalvotesdragon", cr.totalvotesdragon);
            insertCommand.Parameters.AddWithValue("@totalvoteslion", cr.totalvoteslion);
            insertCommand.Parameters.AddWithValue("@totalvotesphoenix", cr.totalvotesphoenix);
            insertCommand.Parameters.AddWithValue("@totalvotesscorpion", cr.totalvotesscorpion);
            insertCommand.Parameters.AddWithValue("@totalvotesunicorn", cr.totalvotesunicorn);

            _con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                _con.Close();
                return "true";
            }
            else
            {
                return "false";
            }

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
            float totalScore = getTotalScore(card);
            int totalVotes = getTotalVotes(card);
            if(totalScore == 0 || totalVotes == 0)
            {
                return 0;
            }
            else
            {
                return totalScore / totalVotes;
            }
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
