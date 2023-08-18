using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppOugaBoga.functions;

namespace TestAppOugaBoga.NumberGuesser
{
    public class RemoWinBase
    {
        public static void RemoWinBaseStart()
        {
            int streak = 0;
            int start = 0;
            int end = 100;
            bool continuePlaying = true;

            while (continuePlaying)
            {

                Console.WriteLine("Welcome to the RemoWin number guesser");
                Console.WriteLine("We will now pick a number. Please pick the range for which we will be guessing");

                Console.WriteLine("Please enter your guess.");
                string guessStr = Console.ReadLine();
                if (!int.TryParse(guessStr, out int guess))
                {
                    Console.WriteLine("Invalid input for start number.");
                    return;
                }

                RWCheckAns.RWAnsCheck(guess, start, end, ref streak);

                Console.WriteLine("Do you want to play again? (y/n)");
                string playAgain = Console.ReadLine();

                if (playAgain.ToLower() != "y")
                {
                    continuePlaying = false;
                    SelectGame.GameSelect();
                }

                Console.Clear();
            }
        }
    }
}
