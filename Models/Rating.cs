using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class Rating
    {
        private string id { get; set; } = "";
        private float oValue { get; set; } = 0.0f;
        private float crabRating { get; set; } = 0.0f;
        private int crabVotes { get; set; } = 0;
    }
}