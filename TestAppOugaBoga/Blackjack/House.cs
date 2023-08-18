using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.Blackjack
{
    class House : Participants
    {
        public bool firstCardFlipped;

        public House()
        {
            Name = "House";
            firstCardFlipped = false;
        }

        // Returns the house name plus their hand and total score.
        public override void SetHandAsString()
        {
            HandAsString = Name + ": ";

            if (firstCardFlipped == false)
            {
                if (HandTotal == 21)
                {
                    foreach (Card card in Hand)
                    {
                        HandAsString += card.Name + card.Suit + " ";
                    }

                    HandAsString += " Total: " + HandTotal.ToString();
                }
                else if (HandTotal > 21)
                {
                    foreach (Card card in Hand)
                    {
                        HandAsString += card.Name + card.Suit + " ";
                    }

                    HandAsString += " Total: " + HandTotal.ToString() + "  House Bust!";
                }
                else
                {
                    HandAsString += "XX ";

                    for (int i = 1; i < Hand.Count; i++)
                    {
                        HandAsString += Hand[i].Name + Hand[i].Suit + " ";
                    }
                }
            }
            else
            {
                if (HandTotal == 21)
                {
                    foreach (Card card in Hand)
                    {
                        HandAsString += card.Name + card.Suit + " ";
                    }

                    HandAsString += " Total: " + HandTotal.ToString();
                }
                else if (HandTotal > 21)
                {
                    foreach (Card card in Hand)
                    {
                        HandAsString += card.Name + card.Suit + " ";
                    }

                    HandAsString += " Total: " + HandTotal.ToString() + "  House Bust!";
                    Bust = true;
                }
                else
                {
                    for (int i = 0; i < Hand.Count; i++)
                    {
                        HandAsString += Hand[i].Name + Hand[i].Suit + " ";
                    }

                    HandAsString += " Total: " + HandTotal.ToString();
                }
            }
        }

        // Count the cards in the dealers hand.
        public override int CountCards()
        {
            HandTotal = 0;

            foreach (Card card in Hand)
            {
                HandTotal = HandTotal + card.Rank;
                if (card.Name == "A" && HandTotal > 21)
                {
                    card.Rank = 1;
                    HandTotal -= 10;
                }
            }

            if (HandTotal > 21)
            {
                Bust = true;
            }

            return HandTotal;
        }
    }
}
