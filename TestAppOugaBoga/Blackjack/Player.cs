using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAppOugaBoga.Blackjack
{
    class Player : Participants
    {
        // Returns the players name plus their hand and total score.
        public override void SetHandAsString()
        {
            HandAsString = Name + ": ";

            foreach (Card card in Hand)
            {
                HandAsString += card.Name + card.Suit + " ";
            }

            HandAsString += " Total: " + HandTotal.ToString();

            if (HandTotal > 21)
            {
                HandAsString += "  Bust!";
            }
        }

        // Count the cards in a players hand.
        public override int CountCards()
        {
            HandTotal = 0;

            foreach (Card card in Hand)
            {
                HandTotal = HandTotal + card.Rank;
            }

            if (HandTotal > 21)
            {
                Bust = true;
            }

            return HandTotal;
        }
    }
}
