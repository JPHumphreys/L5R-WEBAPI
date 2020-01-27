using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    /// <summary>
    /// Represents one card within the database
    /// </summary>
    public class Card
    {
        public string id { get; set; } = "";

        public string clan { get; set; } = "";

        public int cost { get; set; } = 0;

        public string element { get; set; } = "";

        public int fate { get; set; } = 0;

        public int glory { get; set; } = 0;

        public int honor { get; set; } = 0;

        public string imglocation { get; set; } = "";

        public int influencecost { get; set; } = 0;

        public int influencepool { get; set; } = 0;

        public string isrestricted { get; set; } = "";

        // This is a TRUE/FALSE indicator to tell whether the card is banned or not (not yet implemented)
        //public string isbanned { get; set; } = "";

        public int military { get; set; } = 0;

        public string militarybonus { get; set; } = "";

        public string rolerestriction { get; set; } = "";

        public string side { get; set; } = "";

        public int strength { get; set; } = 0;

        public string strengthbonus { get; set; } = "";

        public string text { get; set; } = "";

        public string type { get; set; } = "";

        public string unicity { get; set; } = "";

    }
}