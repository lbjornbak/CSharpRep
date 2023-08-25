using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestAppOugaBoga.NumberGuesser;

namespace TestAppOugaBoga.RockPaperScissor
{
    public class Computer
    {
        public static void ComputerPlay(out string compNum)
        {
            Random rand = new Random();

            int randInt = rand.Next(1, 3);
            
            compNum = randInt.ToString();
        }
    }
}
