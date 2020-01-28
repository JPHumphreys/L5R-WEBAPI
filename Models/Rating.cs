using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class CardRating
    {
        /// <summary>
        /// This is the id that is shared with card id's - this is a foreign key
        /// </summary>
        public string id { get; set; } = "";

        /// <summary>
        /// this a calculation:
        /// (rating + votes) + n + n / total of all votes
        /// </summary>
        public float overallrating { get; set; } = 0.0f;

        /// <summary>
        /// The rating for the crab matchup
        /// </summary>
        public float ratingcrab { get; set; } = 0.0f;
        /// <summary>
        /// The rating for the crane matchup
        /// </summary>
        public float ratingcrane { get; set; } = 0.0f;
        /// <summary>
        /// The rating for the dragon matchup
        /// </summary>
        public float ratingdragon { get; set; } = 0.0f;
        /// <summary>
        /// The rating for the lion matchup
        /// </summary>
        public float ratinglion { get; set; } = 0.0f;
        /// <summary>
        /// The rating for the phoenix matchup
        /// </summary>
        public float ratingphoenix { get; set; } = 0.0f;
        /// <summary>
        /// The rating for the scorpion matchup
        /// </summary>
        public float ratingscorpion { get; set; } = 0.0f;
        /// <summary>
        /// The rating for the unicorn matchup
        /// </summary>
        public float ratingunicorn { get; set; } = 0.0f;

        /// <summary>
        /// The total votes for all crab votes
        /// </summary>
        public int totalvotescrab { get; set; } = 0;
        /// <summary>
        /// The total votes for all crane votes
        /// </summary>
        public int totalvotescrane { get; set; } = 0;
        /// <summary>
        /// the total votes for all dragon votes
        /// </summary>
        public int totalvotesdragon { get; set; } = 0;
        /// <summary>
        /// the total votes for all lion votes
        /// </summary>
        public int totalvoteslion { get; set; } = 0;
        /// <summary>
        /// the total votes for all phoenix votes
        /// </summary>
        public int totalvotesphoenix { get; set; } = 0;
        /// <summary>
        /// the total votes for all scorpion votes
        /// </summary>
        public int totalvotesscorpion { get; set; } = 0;
        /// <summary>
        /// the total votes for all unicron votes
        /// </summary>
        public int totalvotesunicorn { get; set; } = 0;
    }

    public class CreateRating : CardRating
    {

    }

    /*
     * 
     * 
     SELECT clan, imglocation, side, typeof, overallrating
     FROM Cards
     INNER JOIN Ratings ON Cards.id=Ratings.id; 
     * 
     */

    public class ReadRating : CardRating
    {
        public ReadRating(DataRow row)
        {
            id = row["id"].ToString();

            overallrating = Convert.ToSingle(row["overallrating"]);
            ratingcrab = Convert.ToSingle(row["ratingcrab"]);
            ratingcrane = Convert.ToSingle(row["ratingcrane"]);
            ratingdragon = Convert.ToSingle(row["ratingdragon"]);
            ratinglion = Convert.ToSingle(row["ratinglion"]);
            ratingphoenix = Convert.ToSingle(row["ratingphoenix"]);
            ratingscorpion = Convert.ToSingle(row["ratingscorpion"]);
            ratingunicorn = Convert.ToSingle(row["ratingunicorn"]);

            totalvotescrab = Convert.ToInt32(row["totalvotescrab"]);
            totalvotescrane = Convert.ToInt32(row["totalvotescrane"]);
            totalvotesdragon = Convert.ToInt32(row["totalvotesdragon"]);
            totalvoteslion = Convert.ToInt32(row["totalvoteslion"]);
            totalvotesphoenix = Convert.ToInt32(row["totalvotesphoenix"]);
            totalvotesscorpion = Convert.ToInt32(row["totalvotesscorpion"]);
            totalvotesunicorn = Convert.ToInt32(row["totalvotesunicorn"]);
        }
    }

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
}