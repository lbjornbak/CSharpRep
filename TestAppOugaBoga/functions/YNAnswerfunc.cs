using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.functions
{
    class YNAnswerfunc
    {
        public static void YNAns()
        {
            ConsoleKeyInfo cki;
            do 
            { 
                cki = Console.ReadKey();

                if (cki.KeyChar.ToString().ToLower() == "y")
                {
                    Console.WriteLine("\nThe 'Y' key!");
                    break;
                }
                else if (cki.KeyChar.ToString().ToLower() == "n")
                {
                    Console.WriteLine("\nYou pressed 'n' and are exiting");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nPlease use the key 'y' or 'n'");
                }
            } while (true);

            Console.Clear();
        }
    }
}

