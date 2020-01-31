using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    /// <summary>
    /// This is the deck objects
    /// It is a many to many table that holds the
    /// username of the user that created the deck
    /// id of the card that is taken from the cards table
    /// name of the deck
    /// quantity of the card in that deck
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// This is the username that is associated with the deck
        /// </summary>
        public string username { get; set; } = "";
        /// <summary>
        /// This is the card id that is contained within the deck
        /// </summary>
        public string id { get; set; } = "";
        /// <summary>
        /// This is the deckname
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// This is the quantity of the card within the deck
        /// </summary>
        public int quantity { get; set; } = 0;
    }

    public class CreateDeck : Deck
    {

    }

    public class ReadDeck : Deck
    {
        public ReadDeck(DataRow row)
        {
            username = row["username"].ToString();
            id = row["id"].ToString();
            name = row["name"].ToString();
            quantity = Convert.ToInt32(row["quantity"]);
        }
    }
}