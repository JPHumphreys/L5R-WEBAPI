using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class Deck
    {
        public string userId { get; set; } = "";
        public string cardId { get; set; } = "";
        public string name { get; set; } = "";
        public string quantity { get; set; } = "";
    }
}