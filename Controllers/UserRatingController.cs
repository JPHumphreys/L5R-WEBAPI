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
    public class UserRatingController : ApiController
    {

        //declare sql connection
        private SqlConnection _con;
        private SqlDataAdapter _adapter;

        // GET: api/UserRating
        public List<UserRating> Get()
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM UserRatings";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<UserRating> ratings = new List<Models.UserRating>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow ratingRecord in _dt.Rows)
                {
                    ratings.Add(new ReadUserRating(ratingRecord));
                }
            }

            return ratings;
        }

        // GET: api/UserRating/username
        public string Get(string username)
        {
            return "value";
        }

        // POST: api/UserRating
        /// <summary>
        /// This creates a new user rating.
        /// It containts the username which is used to check if they have voted on the card before
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true/false</returns>
        public string Post([FromBody]CreateUserRating value)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            CardRatingController cr = new CardRatingController();
            //check if a rating from that user already exists
            int noOfRatings = checkExisting(value.username, value.id, value.clan);

            if(noOfRatings > 0)
            {
                //get the values of the old vote
                float oldRating = getOldRating(value.username, value.id, value.clan);
                //remove them from the cardrating table
                noOfRatings = -1;
                if (cr.updateCard(value.id, -oldRating, value.clan, noOfRatings) == "false")
                {
                    return "false";
                }
                //remove it from userrating table
                removeOldRating(value.username, value.id, value.clan);
                noOfRatings = 1;
                /*
                 * this means that we dont need to add a new totalvote to the
                 * existing id in the card rating table.
                */
            }
            else
            {
                noOfRatings = 1;
                /*
                 * Because there is no exisiting vote from that user
                 * we need to add a value to the total number of votes
                 * for that id in the cardratings table
                 */
            }

            //insert new/'new' query
            var query = "INSERT INTO UserRatings (username, id, clan, rating) VALUES(@username, @id, @clan, @rating)";
            SqlCommand insertCommand = new SqlCommand(query, _con);

            insertCommand.Parameters.AddWithValue("@username", value.username);
            insertCommand.Parameters.AddWithValue("@id", value.id);
            insertCommand.Parameters.AddWithValue("@clan", value.clan);
            insertCommand.Parameters.AddWithValue("@rating", value.rating);

            _con.Open();
            int result = insertCommand.ExecuteNonQuery();
            _con.Close();
            if (result > 0)
            {
                if (cr.updateCard(value.id, value.rating, value.clan, noOfRatings) == "true")
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }
        }

        // PUT: api/UserRating/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserRating/username
        public void Delete(string username)
        {
        }

        private void addRating(string id, string clan, float rating)
        {

        }

        private float getOldRating(string username, string id, string clan)
        {
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM UserRatings WHERE username= '" + username + "'"
                + " AND id='" + id + "' AND clan='" + clan + "'";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);

            List<UserRating> ratings = new List<Models.UserRating>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow ratingRecord in _dt.Rows)
                {
                    ratings.Add(new ReadUserRating(ratingRecord));
                }
            }
            return ratings[0].rating;
        }

        private int checkExisting(string username, string id, string clan)
        {
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM UserRatings WHERE username= '" + username + "'"
                + " AND id='" + id + "' AND clan='" + clan + "'";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);

            return _dt.Rows.Count;
        }

        private void removeOldRating(string username, string id, string clan)
        {
            //delete oldest rating that matches the three variables sent in
            //this will be the old rating the user has made
            //delete old query
            var query = "DELETE FROM UserRatings WHERE username= '" + username + "'"
                + " AND id='" + id + "' AND clan='" + clan + "'";
            SqlCommand insertCommand = new SqlCommand(query, _con);
            _con.Open();
            int result = insertCommand.ExecuteNonQuery();//not sure if i need this
            if(result > 0)
            {
                //works
                _con.Close();
            }
        }

        

    }
}
