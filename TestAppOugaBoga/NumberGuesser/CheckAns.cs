﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.NumberGuesser
{
    public class CheckAns
    {
        public static void AnsCheck(int ans, int minRange, int maxRange, ref int streak)
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
                Console.WriteLine("You lose lmao. Rip streak");
                streak = 0;
            }
        }


    }
}
