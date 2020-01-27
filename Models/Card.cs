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
        /// This is primary key that is used in conjunction with the ratings table.
        /// This is the ID of the card that is in the context of name-name. EG: shrewd yasuki = shrewd-yasuki
        /// Any apostrophes are replaced with dashes. EG: Mountain's Anvil Castle = mountain-s-anvil-castle
        /// </summary>
        public string id { get; set; } = "";

        /// <summary>
        /// This is the clan that the card corresponds to: this includes the main clans and neutral type
        /// </summary>
        public string clan { get; set; } = "";

        /// <summary>
        /// This is the card cost in fate.
        /// </summary>
        public int cost { get; set; } = 0;

        /// <summary>
        /// This is used to categorize provinces into the different types
        /// </summary>
        public string element { get; set; } = "";

        /// <summary>
        /// This is how much fate a stronghold will yeild a turn.
        /// </summary>
        public int fate { get; set; } = 0;

        /// <summary>
        /// This is the glory value of a card (if it has one)
        /// </summary>
        public int glory { get; set; } = 0;

        /// <summary>
        /// This is how much honor you will start the game with.
        /// This is used for stronghold cards only.
        /// </summary>
        public int honor { get; set; } = 0;

        /// <summary>
        /// This is the image location from the official l5r website.
        /// </summary>
        public string imglocation { get; set; } = "";

        /// <summary>
        /// This is the influence cost that is related to the conflict card. (if it has one)
        /// </summary>
        public int influencecost { get; set; } = 0;

        /// <summary>
        /// This is the influence pool that your stronghold provides.
        /// </summary>
        public int influencepool { get; set; } = 0;

        /// <summary>
        /// This indicates whether the card is restricted
        /// The restricted list is derived from the official rules guide.
        /// </summary>
        public string isrestricted { get; set; } = "";

        // This is a TRUE/FALSE indicator to tell whether the card is banned or not (not yet implemented)
        //public string isbanned { get; set; } = "";

        /// <summary>
        /// This is the military value on the character card.
        /// if not applicable - put a 0.
        /// </summary>
        public int military { get; set; } = 0;

        /// <summary>
        /// This is the added bonus an attachment provides a character.
        /// if not applicable - put a NULL
        /// </summary>
        public string militarybonus { get; set; } = "";

        /// <summary>
        /// This indicates whether a card is restricted to 'KEEPER' or 'SEEKER' - null if not
        /// </summary>
        public string rolerestriction { get; set; } = "";

        /// <summary>
        /// This indicates which deck the card lies within.
        /// </summary>
        public string side { get; set; } = "";

        /// <summary>
        /// This indicates the strength of the province.
        /// IE how much above your opponent you need to be to break the province.
        /// </summary>
        public int strength { get; set; } = 0;

        /// <summary>
        /// This applies to stronghold provinces.
        /// It indicates the added strength bonus it provides on top of the province it is above.
        /// </summary>
        public string strengthbonus { get; set; } = "";

        /// <summary>
        /// This is the card text
        /// </summary>
        public string text { get; set; } = "";

        /// <summary>
        /// This is the card type.
        /// </summary>
        public string type { get; set; } = "";

        /// <summary>
        /// This indicates whether the card is unique or not.
        /// TRUE / FALSE
        /// </summary>
        public string unicity { get; set; } = "";

    }
}