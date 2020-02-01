using System;
using System.Collections.Generic;
using System.Data;
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
        /// How many of the cards are legally allowed to be in the decks.
        /// </summary>
        public int decklimit { get; set; } = 0;
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
        /// This is the name of the card as written on the card
        /// </summary>
        public string name { get; set; } = "";


        /// <summary>
        /// This is the political value on the character
        /// </summary>
        public int political { get; set; } = 0;

        /// <summary>
        /// This is the political bonus an attachment provides a character.
        /// </summary>
        public string politicalbonus { get; set; } = "";

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

    public class ReadCard : Card
    {
        /// <summary>
        /// This reads the rows and places the values within the card object.
        /// </summary>
        /// <param name="row"></param>
        public ReadCard(DataRow row)
        {
            id = row["id"].ToString();//primary key
            clan = row["clan"].ToString();
            cost = Convert.ToInt32(row["cost"]);
            decklimit = Convert.ToInt32(row["decklimit"]);
            element = row["element"].ToString();
            fate = Convert.ToInt32(row["fate"]);
            glory = Convert.ToInt32(row["glory"]);
            honor = Convert.ToInt32(row["honor"]);
            imglocation = row["imglocation"].ToString();
            influencecost = Convert.ToInt32(row["influencecost"]);
            influencepool = Convert.ToInt32(row["influencepool"]);
            isrestricted = row["isrestricted"].ToString();
            military = Convert.ToInt32(row["military"]);
            militarybonus = row["militarybonus"].ToString();
            name = row["name"].ToString();
            political = Convert.ToInt32(row["political"]);
            politicalbonus = row["politicalbonus"].ToString();
            rolerestriction = row["rolerestriction"].ToString();
            side = row["side"].ToString();
            strength = Convert.ToInt32(row["strength"]);
            strengthbonus = row["strengthbonus"].ToString();
            text = row["text"].ToString();
            type = row["typeof"].ToString();
            unicity = row["unicity"].ToString();
        }

    }

    /// <summary>
    /// This is for a joined table that combines a card and its cardrating
    /// </summary>
    public class RatingAndCard//to get both the rating and the card attributes
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
        /// How many of the cards are legally allowed to be in the decks.
        /// </summary>
        public int decklimit { get; set; } = 0;
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
        /// This is the name of the card as written on the card
        /// </summary>
        public string name { get; set; } = "";


        /// <summary>
        /// This is the political value on the character
        /// </summary>
        public int political { get; set; } = 0;

        /// <summary>
        /// This is the political bonus an attachment provides a character.
        /// </summary>
        public string politicalbonus { get; set; } = "";

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

    /// <summary>
    /// Reads in the values from the joined table and stores them into an object
    /// </summary>
    public class ReadRatingAndCard : RatingAndCard
    {
        public ReadRatingAndCard(DataRow row)
        {
            id = row["id"].ToString();//primary key
            clan = row["clan"].ToString();
            cost = Convert.ToInt32(row["cost"]);
            decklimit = Convert.ToInt32(row["decklimit"]);
            element = row["element"].ToString();
            fate = Convert.ToInt32(row["fate"]);
            glory = Convert.ToInt32(row["glory"]);
            honor = Convert.ToInt32(row["honor"]);
            imglocation = row["imglocation"].ToString();
            influencecost = Convert.ToInt32(row["influencecost"]);
            influencepool = Convert.ToInt32(row["influencepool"]);
            isrestricted = row["isrestricted"].ToString();
            military = Convert.ToInt32(row["military"]);
            militarybonus = row["militarybonus"].ToString();
            name = row["name"].ToString();
            political = Convert.ToInt32(row["political"]);
            politicalbonus = row["politicalbonus"].ToString();
            rolerestriction = row["rolerestriction"].ToString();
            side = row["side"].ToString();
            strength = Convert.ToInt32(row["strength"]);
            strengthbonus = row["strengthbonus"].ToString();
            text = row["text"].ToString();
            type = row["typeof"].ToString();
            unicity = row["unicity"].ToString();

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