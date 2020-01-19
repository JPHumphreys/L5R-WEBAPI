using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class Card
    {
        public string id { get; set; } = "";
        public string clan { get; set; } = "";
        public string side { get; set; } = "";
        public string type { get; set; } = "";
    }
}