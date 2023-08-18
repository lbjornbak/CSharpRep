using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.NumberGuesser
{
    class RandInt
    {
        public int RandomNum(int min, int max)
        {
            Random rnd = new Random();
            int RandNum = rnd.Next(min, max + 1);

            return RandNum;
        }
    }

}
