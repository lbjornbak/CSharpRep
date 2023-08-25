using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestAppOugaBoga.functions;

namespace TestAppOugaBoga.RockPaperScissor
{
    class RPSBaseGame
    {
        private static ScoreManager sM = new ScoreManager();

        public static void RPSBGame()
        {

            bool continuePlay = true;

            Console.WriteLine("Welcome to Rock Paper Scissors");
            Console.WriteLine("In this game, type 1 for Rock, 2 for Paper, and 3 for Scissors");
            Console.WriteLine($"Your streak is {sM.GetStreak()}\n");

            while (continuePlay)
            {
                RPSGameManager gM = new(sM);

                gM.PlayRound();
                if (!PlayAgain())
                {
                    continuePlay = false;
                    SelectGame.GameSelect();
                }
                Console.Clear();

            }
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            return Console.ReadLine().ToLower() == "y";
        }
    }

}
