using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.NumberGuesser
{
    public class RWCheckAns
    {
        public static void RWAnsCheck(int ans, int minRange, int maxRange, ref int streak)
        {
            RandInt randIntGenerator = new RandInt();
            int randInt = randIntGenerator.RandomNum(minRange, maxRange);

            Console.WriteLine("Checking answer");
            Console.WriteLine($"our pick was {randInt}");
            if (ans == randInt)
            {
                streak++;
                Console.WriteLine($"Congratulations, You won! Your current streak is {streak}");
            }
            else
            {
                Console.WriteLine("You lose lmao, we will now be deleting you windows OS (;");
                Console.WriteLine("Deleting Windows and wipeing SSD");

                for (int i = 0; i <= 100; i++)
                {
                    Console.WriteLine($"Deletion percentage {i}%");
                    if (i == 23 || i == 33 || i == 48 || i == 63 || i == 89)
                    {
                        Console.WriteLine($"Deletion percentage {i}%");
                  
                    }
                }
                streak = 0;
                Environment.Exit(0);
            }
        }


    }
}
