using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.Blackjack
{
    class BlackJackMain
    {
        public static void BlackJackStarter()
        {
            PlayerGroup playerGroup = new PlayerGroup();
            Dealer dealer = new Dealer();
            House house = new House();
            bool gameWon = false;
            bool keepPlaying = true;
            int numberOfPlayers;
            string userInput = "";

            Console.WriteLine("Welcome to Blackjack!" + "\r\n\r\n\r\n");

            // Get number of players.
            numberOfPlayers = playerGroup.SetNumberOfPlayers();

            // Set players names.
            playerGroup.SetPlayersNames(numberOfPlayers);

            while (keepPlaying == true)
            {
                while (gameWon == false)
                {
                    // Create and shuffle deck.
                    Deck deck = new Deck();
                    deck.CardDeck = deck.BuildCardDeck();
                    deck.CardDeck = deck.ShuffleDeck(deck.CardDeck);

                    Console.Write("\r\n\r\n" + "Press enter to deal hands...");
                    Console.ReadLine();

                    // Deal first round of cards.
                    dealer.DealFirstRound(deck, playerGroup, house);
                    house.HandTotal = house.CountCards();
                    house.SetHandAsString();

                    // Print the houses hand.
                    Console.WriteLine("\r\n\r\n" + house.HandAsString);

                    // Print each of the players hands.
                    foreach (Player player in playerGroup.PlayerList)
                    {
                        player.HandTotal = player.CountCards();
                        player.SetHandAsString();

                        Console.WriteLine("\r\n" + player.HandAsString);
                    }

                    Console.WriteLine();

                    // If any players have blackjack add them to the winning players list.
                    foreach (Player player in playerGroup.PlayerList)
                    {
                        if (player.HandTotal == 21)
                        {
                            playerGroup.WinningPlayers.Add(player);
                        }
                    }

                    // If anyone has blackjack.
                    if (playerGroup.WinningPlayers.Count > 0 || house.HandTotal == 21)
                    {
                        // Blackjack for player/s and house.
                        if (playerGroup.WinningPlayers.Count > 0 && house.HandTotal == 21)
                        {
                            foreach (Player player in playerGroup.WinningPlayers)
                            {
                                Console.WriteLine("\r\n" + player.Name + " Tie...");
                            }

                            Console.WriteLine("\r\n" + house.Name + " Tie...");
                            gameWon = true;
                        }

                        // Blackjack for house.
                        if (playerGroup.WinningPlayers.Count == 0 && house.HandTotal == 21)
                        {
                            Console.WriteLine("\r\n" + house.Name + " Wins - Blackjack");
                            gameWon = true;
                        }

                        // Blackjack for player/s.
                        if (playerGroup.WinningPlayers.Count > 0 && house.HandTotal != 21)
                        {
                            if (playerGroup.WinningPlayers.Count > 1)
                            {
                                foreach (Player player in playerGroup.WinningPlayers)
                                {
                                    Console.WriteLine("\r\n" + player.Name + " Tie...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\r\n" + playerGroup.WinningPlayers[0].Name + " Wins - Blackjack!");
                            }

                            gameWon = true;
                        }
                    }

                    // If someone hasnt got blackjack then continue - necessary as not exiting while loop
                    if (gameWon == false)
                    {
                        // Loop through the list of players.
                        foreach (Player player in playerGroup.PlayerList)
                        {
                            // Count current players hand.
                            player.HandTotal = player.CountCards();
                            player.SetHandAsString();

                            // If player hasnt bust.
                            if (player.Bust == false)
                            {
                                Console.WriteLine("\r\n" + player.HandAsString);

                                string playerHit = "Y";

                                // Loop while player hasnt won, bust or stayed.
                                while (playerHit != "N" && gameWon == false && player.Bust == false)
                                {
                                    Console.Write("Would you like another card (y/n)? ");
                                    playerHit = Console.ReadLine().ToUpper();

                                    // Validation for user input.
                                    while (playerHit != "Y" && playerHit != "N")
                                    {
                                        Console.WriteLine("Incorect input...");
                                        Console.Write("\r\n" + "Would you like another card(y/n)?: ");
                                        playerHit = Console.ReadLine().ToUpper();
                                    }

                                    // If player selects hit, deal them a card and remove it from the deck.
                                    if (playerHit == "Y")
                                    {
                                        dealer.DealPlayerCard(player, deck);
                                        player.HandTotal = player.CountCards();
                                        player.SetHandAsString();

                                        Console.WriteLine("\r\n" + player.HandAsString);
                                    }
                                }
                            }
                        }

                        // 'Flip' the houses first card. 
                        house.firstCardFlipped = true;
                        house.SetHandAsString();
                        Console.WriteLine("\r\n" + house.HandAsString);

                        // Determine the highest score
                        playerGroup.GetHighestHand(playerGroup);

                        if (house.HandTotal > playerGroup.HighestHand)
                        {
                            Console.WriteLine("\r\n" + house.Name + " Wins!");
                            gameWon = true;
                        }
                        else
                        {
                            // Loop and keep hiting house hand if it hasnt won, bust or gone over 17.
                            while (gameWon == false && house.HandTotal <= 16 && house.HandTotal < playerGroup.HighestHand)
                            {
                                Random rnd = new Random();
                                int randomCard;

                                Console.WriteLine("\r\n" + "Press enter to deal the House a card...");
                                Console.ReadLine();

                                randomCard = rnd.Next(deck.CardDeck.Count);
                                house.Hand.Add(deck.CardDeck[randomCard]);
                                deck.CardDeck.Remove(deck.CardDeck[randomCard]);

                                house.HandTotal = house.CountCards();
                                house.SetHandAsString();

                                Console.WriteLine("\r\n" + house.HandAsString);
                            }

                            // If house has bust all players who havent, win.
                            if (house.Bust == true)
                            {
                                foreach (Player player in playerGroup.PlayerList)
                                {
                                    if (player.Bust == false)
                                    {
                                        Console.WriteLine("\r\n" + player.Name + " Wins!");
                                    }
                                }

                                gameWon = true;
                            }
                            // Else house must have 17-21 so check and display win/draw
                            else
                            {
                                if (house.HandTotal > playerGroup.HighestHand)
                                {
                                    Console.WriteLine("\r\n" + house.Name + " Wins!");
                                    gameWon = true;
                                }
                                else if (house.HandTotal < playerGroup.HighestHand)
                                {
                                    foreach (Player player in playerGroup.PlayerList)
                                    {
                                        if (player.HandTotal > house.HandTotal && player.Bust == false)
                                        {
                                            Console.WriteLine("\r\n" + player.Name + " Wins!");
                                        }
                                    }

                                    gameWon = true;
                                }
                                else
                                {
                                    Console.WriteLine("\r\n" + house.Name + " Tie...");

                                    foreach (Player player in playerGroup.PlayerList)
                                    {
                                        if (player.HandTotal == house.HandTotal)
                                        {
                                            Console.WriteLine("\r\n" + player.Name + " Tie...");
                                        }
                                    }

                                    gameWon = true;
                                }
                            }
                        }
                    }

                    Console.Write("\r\n\r\n" + "Game over! Play again (y/n)? ");
                    userInput = Console.ReadLine().ToUpper();

                    // Validate user input.
                    while (userInput != "Y" && userInput != "N")
                    {
                        Console.Write("Incorect input...");
                        Console.Write("\r\n\r\n" + "Play again (y/n)? ");
                        userInput = Console.ReadLine().ToUpper();
                    }

                    if (userInput == "N")
                    {
                        keepPlaying = false;
                    }
                    else
                    {
                        Console.Clear();
                        house.ResetHand();

                        foreach (Player player in playerGroup.PlayerList)
                        {
                            player.ResetHand();
                        }

                        playerGroup.ResetPlayerGroup();

                        keepPlaying = true;
                        gameWon = false;
                        house.firstCardFlipped = false;
                    }
                }
            }
        }
    }
}
