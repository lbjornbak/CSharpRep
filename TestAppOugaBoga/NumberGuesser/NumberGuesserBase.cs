using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppOugaBoga.functions;

namespace TestAppOugaBoga.NumberGuesser
{
    public class NumberGuesserBase
    {
        public static void NumberGuesserBaseStart()
        {
            int streak = 0;
            bool continuePlaying = true;

            while (continuePlaying)
            {

                Console.WriteLine("Welcome to the number guessing game. This version is played at no risk. If you are more daring, try the RemoWin version");
                Console.WriteLine("We will now pick a number. Please pick the range for which we will be guessing");
                Console.WriteLine("Pick the first number, then press enter");

                string startStr = Console.ReadLine();
                if (!int.TryParse(startStr, out int start))
                {
                    Console.WriteLine("Invalid input for start number.");
                    return;
                }

                Console.WriteLine("Please choose the next number");
                string endStr = Console.ReadLine();
                if (!int.TryParse(endStr, out int end))
                {
                    Console.WriteLine("Invalid input for end number.");
                    return;
                }

                Console.WriteLine("Please enter your guess.");
                string guessStr = Console.ReadLine();
                if (!int.TryParse(guessStr, out int guess))
                {
                    Console.WriteLine("Invalid input for start number.");
                    return;
                }

                CheckAns.AnsCheck(guess, start, end, ref streak);

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
