using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    /// <summary>
    /// This is a many to many relationship table
    /// It checks whether a rating from a user has already been done.
    /// It it where the cardRating table gets totalvotes from.
    /// </summary>
    public class UserRating
    {
        /// <summary>
        /// This is a foreign key to the Users table
        /// </summary>
        public string username { get; set; } = "";
        /// <summary>
        /// This is a foreign key to the Cards table
        /// </summary>
        public string id { get; set; } = "";
        /// <summary>
        /// This is the clan the vote is in respect to
        /// </summary>
        public string clan { get; set; } = "";
        /// <summary>
        /// This is the rating that the user selected.
        /// </summary>
        public float rating { get; set; } = 0.0f;
    }

    public class CreateUserRating : UserRating
    {

    }

    public class ReadUserRating : UserRating
    {
        public ReadUserRating(DataRow row)
        {
            username = row["username"].ToString();
            id = row["id"].ToString();
            clan = row["clan"].ToString();
            rating = Convert.ToSingle(row["rating"]);
        }
    }
}