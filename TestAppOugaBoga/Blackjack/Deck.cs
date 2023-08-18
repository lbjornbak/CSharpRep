using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.Blackjack
{
    class Deck
    {
        private List<Card> cardDeck = new List<Card>();

    public List<Card> CardDeck { get => cardDeck; set => cardDeck = value; }

    // Creates the playing deck.
    public List<Card> BuildCardDeck()
    {
        Deck deck = new Deck();

        foreach (Enums.Suit suit in Enum.GetValues(typeof(Enums.Suit)))
        {
            foreach (Enums.Rank rank in Enum.GetValues(typeof(Enums.Rank)))
            {
                Card card = new Card();
                card.Suit = suit.ToString();

                // Set card name.
                if ((int)rank <= 10)
                {
                    int temp = (int)rank;
                    card.Name = temp.ToString();
                }
                else
                {
                    card.Name = rank.ToString();
                }

                // Set card value.
                if ((int)rank > 11)
                {
                    card.Rank = 10;
                }
                else
                {
                    card.Rank = (int)rank;
                }

                deck.CardDeck.Add(card);
            }
        }

        return deck.CardDeck;
    }

    // Shuffles the playing deck.
    public List<Card> ShuffleDeck(List<Card> cardDeck)
    {
        var shuffledDeck = cardDeck.OrderBy(x => Guid.NewGuid()).ToList();

        return shuffledDeck;
    }
}
}
