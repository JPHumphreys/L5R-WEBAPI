using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class Rating
    {
        public string id { get; set; } = "";
        public float oValue { get; set; } = 0.0f;
        public float crabRating { get; set; } = 0.0f;
        public int crabVotes { get; set; } = 0;
    }
}