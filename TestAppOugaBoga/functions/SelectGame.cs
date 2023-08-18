using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppOugaBoga.Blackjack;
using TestAppOugaBoga.NumberGuesser;

namespace TestAppOugaBoga.functions
{
    class SelectGame
    {
        public static void GameSelect()
        {
            do
            {

                Console.Write(" Please type in the number marking the game you want to play: \r\n");
                Console.Write(" 1 - BlackJack \r\n");
                Console.Write(" 2 - Number guesser \r\n");
                Console.Write(" 3 - \r\n");
                Console.Write(" 4 - \r\n");
                Console.Write(" 5 - RemoWin \r\n");
                Console.Write(" 6 - Exit \r\n");

                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        Console.WriteLine("Launching game: Blackjack");
                        BlackJackMain.BlackJackStarter();
                        break;

                    case "2":
                        Console.WriteLine("Launching game: Number guesser");
                        NumberGuesserBase.NumberGuesserBaseStart();
                        break;

                    case "3":
                        Console.WriteLine("Launching game: ");

                        break;

                    case "4":
                        Console.WriteLine("Launching game: ");

                        break;

                    case "5":
                        Console.WriteLine("Launching game: RemoWin");
                        RemoWinBase.RemoWinBaseStart();
                        break;

                    case "6":
                        Console.WriteLine("Exiting");
                        Environment.Exit(0);

                        break;

                    default:
                        Console.WriteLine("Please select a number from the below selection");
                        Console.Clear();
                        continue;
                } 
            } while (true);
        }
    } 
}
