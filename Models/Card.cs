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
        /// <summary>
        /// Card ID in a form of "cardfirstname-cardothernames-n-n-n"
        /// Eg. "shrewd-yasuki", "yorimoto", "hiru-mori-toride-unicorn"
        /// </summary>
        public string id { get; set; } = "";
        /// <summary>
        /// This is the card clan affiliation
        /// </summary>
        public string clan { get; set; } = "";
        /// <summary>
        /// This is the deck side in which the card is legally played
        /// </summary>
        public string side { get; set; } = "";
        /// <summary>
        /// This is the legal card type
        /// Eg. "event","attachment"
        /// </summary>
        public string type { get; set; } = "";
    }
}