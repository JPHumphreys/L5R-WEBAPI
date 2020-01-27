using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class Rating
    {
        public string id { get; set; } = "";
        public string clan { get; set; } = "";

        public float overallrating { get; set; } = 0.0f;
        public float ratingcrab { get; set; } = 0.0f;
        public float ratingcrane { get; set; } = 0.0f;
        public float ratingdragon { get; set; } = 0.0f;
        public float ratinglion { get; set; } = 0.0f;
        public float ratingphoenix { get; set; } = 0.0f;
        public float ratingscorpion { get; set; } = 0.0f;
        public float ratingunicorn { get; set; } = 0.0f;

        public int totalvotescrab { get; set; } = 0;
        public int totalvotescrane { get; set; } = 0;
        public int totalvotesdragon { get; set; } = 0;
        public int totalvoteslion { get; set; } = 0;
        public int totalvotesphoenix { get; set; } = 0;
        public int totalvotesscorpion { get; set; } = 0;
        public int totalvotesunicorn { get; set; } = 0;
    }

    public class CreateRating : Rating
    {

    }

    public class ReadRating : Rating
    {
        public ReadRating(DataRow row)
        {
            id = row["id"].ToString();
            clan = row["clan"].ToString();

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
}