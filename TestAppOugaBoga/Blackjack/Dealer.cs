using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.Blackjack
{
    class Dealer
    {
        private string userInput = "";
        private Random random = new Random();
        private int randomCard;

        // Deal first round of cards.
        public void DealFirstRound(Deck deck, PlayerGroup playerGroup, House house)
        {
            // Give each player a card and remove card from deck.
            foreach (Player player in playerGroup.PlayerList)
            {
                randomCard = random.Next(deck.CardDeck.Count);
                player.Hand.Add(deck.CardDeck[randomCard]);
                deck.CardDeck.Remove(deck.CardDeck[randomCard]);
            }

            // Give player second card. 
            foreach (Player player in playerGroup.PlayerList)
            {
                randomCard = random.Next(deck.CardDeck.Count);

                // If player has been delt two Aces.
                if (player.Hand[0].Name == "A" && deck.CardDeck[randomCard].Name == "A")
                {
                    Console.Write("\r\n\r\n" + player.Name + ": You have been delt two Aces. Would you like the first to count as a 1 or 11? ");
                    userInput = Console.ReadLine();

                    while (userInput != "1" && userInput != "11")
                    {
                        Console.Write("\r\n" + "Incorect input. Enter 1 or 11: ");
                        userInput = Console.ReadLine();
                    }

                    player.Hand[0].Rank = int.Parse(userInput);

                    Console.Write("\r\n\r\n" + player.Name + ": Would you like the second Ace to count as a 1 or 11? ");
                    userInput = Console.ReadLine();

                    while (userInput != "1" && userInput != "11")
                    {
                        Console.Write("\r\n" + "Incorect input. Enter 1 or 11: ");
                        userInput = Console.ReadLine();
                    }

                    deck.CardDeck[randomCard].Rank = int.Parse(userInput);
                    player.Hand.Add(deck.CardDeck[randomCard]);
                    deck.CardDeck.Remove(deck.CardDeck[randomCard]);
                }
                // If the player has been delt an Ace for thier first card and they dont have blackjack.
                else if (player.Hand[0].Name == "A" && deck.CardDeck[randomCard].Name != "A" && deck.CardDeck[randomCard].Rank != 10)
                {
                    Console.Write("\r\n\r\n" + player.Name + ": You have been delt an ace and a " + deck.CardDeck[randomCard].Name +
                                  ". Would you like the ace to count as a 1 or 11? ");
                    userInput = Console.ReadLine();

                    while (userInput != "1" && userInput != "11")
                    {
                        Console.Write("\r\n" + "Incorect input. Enter 1 or 11: ");
                        userInput = Console.ReadLine();
                    }

                    player.Hand[0].Rank = int.Parse(userInput);
                    player.Hand.Add(deck.CardDeck[randomCard]);
                    deck.CardDeck.Remove(deck.CardDeck[randomCard]);
                }
                // If the player has been delt an Ace for thier second card and they dont have blackjack.
                else if (player.Hand[0].Name != "A" && player.Hand[0].Rank != 10 && deck.CardDeck[randomCard].Name == "A")
                {
                    Console.Write("\r\n\r\n" + player.Name + ": You have been delt a " + player.Hand[0].Name +
                                  " and an Ace. Would you like the ace to count as a 1 or 11? ");
                    userInput = Console.ReadLine();

                    while (userInput != "1" && userInput != "11")
                    {
                        Console.Write("\r\n" + "Incorect input. Enter 1 or 11: ");
                        userInput = Console.ReadLine();
                    }

                    deck.CardDeck[randomCard].Rank = int.Parse(userInput);
                    player.Hand.Add(deck.CardDeck[randomCard]);
                    deck.CardDeck.Remove(deck.CardDeck[randomCard]);
                }
                else
                {
                    player.Hand.Add(deck.CardDeck[randomCard]);
                    deck.CardDeck.Remove(deck.CardDeck[randomCard]);
                }
            }

            // Deal the house two cards.
            for (int i = 0; i < 2; i++)
            {
                randomCard = random.Next(deck.CardDeck.Count);
                house.Hand.Add(deck.CardDeck[randomCard]);
                deck.CardDeck.Remove(deck.CardDeck[randomCard]);
            }
        }

        // Deal the player a random card from the deck.
        public void DealPlayerCard(Player player, Deck deck)
        {
            randomCard = random.Next(deck.CardDeck.Count);

            if (deck.CardDeck[randomCard].Name == "A")
            {
                Console.Write("\r\n" + "You have been delt an Ace. Would you like it to count as a 1 or 11? ");
                userInput = Console.ReadLine();

                while (userInput != "1" && userInput != "11")
                {
                    Console.Write("\r\n" + "You have been delt an Ace. Would you like it to count as a 1 or 11? ");
                    userInput = Console.ReadLine();
                }

                deck.CardDeck[randomCard].Rank = int.Parse(userInput);
            }

            player.Hand.Add(deck.CardDeck[randomCard]);
            deck.CardDeck.Remove(deck.CardDeck[randomCard]);
        }
    }
}
