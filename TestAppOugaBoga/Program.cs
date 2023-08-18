// See https://aka.ms/new-console-template for more information);
using System;
using TestAppOugaBoga.functions;

namespace TestAppOugaBoga
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            Console.WriteLine("Hello and welcome to the test game to get used to C# again");
            Console.WriteLine("Would you like to get started?");
            Console.WriteLine("Press 'y' to continue or 'n' to stop");

            YNAnswerfunc.YNAns();

            Console.WriteLine("Program continues...");

            SelectGame.GameSelect();

        }
    }
}