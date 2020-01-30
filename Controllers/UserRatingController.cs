﻿using L5R_API.Models;
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

        // GET: api/UserRating/5
        public string Get(int id)
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

            //delete old query
            var query = "DELETE FROM UserRatings WHERE username= '" + value.username + "'"
                + " AND id='" + value.id + "' AND clan='" + value.clan + "'";
            SqlCommand insertCommand = new SqlCommand(query, _con);

            _con.Open();
            int result = insertCommand.ExecuteNonQuery();

            _con.Close();
            //insert new query
            query = "INSERT INTO UserRatings (username, id, clan, rating) VALUES(@username, @id, @clan, @rating)";
            insertCommand = new SqlCommand(query, _con);

            insertCommand.Parameters.AddWithValue("@username", value.username);
            insertCommand.Parameters.AddWithValue("@id", value.id);
            insertCommand.Parameters.AddWithValue("@clan", value.clan);
            insertCommand.Parameters.AddWithValue("@rating", value.rating);

            _con.Open();
            result = insertCommand.ExecuteNonQuery();

            if (result > 0)
            {
                return "true";
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

        private void removeOldRating(string username, string id, string clan, float rating)
        {
            //delete oldest rating that matches the three variables sent in
            //this will be the old rating the user has made

            //THEN
            //update the cardratings table with the new values

        }

        private string usernameCheck(string username, string id, string clan)
        {
            //checks to see how many ratings with this clan there is
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM UserRatings WHERE username=" + username +
                " AND id=" + id + " AND clan=" + clan;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<UserRating> ratings = new List<Models.UserRating>(_dt.Rows.Count);

            if (_dt.Rows.Count > 1)//there is more than 1
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }
    }
}
