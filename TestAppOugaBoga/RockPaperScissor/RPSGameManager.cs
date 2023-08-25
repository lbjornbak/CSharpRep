using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.RockPaperScissor
{
    public class RPSGameManager
    {
        private readonly ScoreManager scoreManager;

        public RPSGameManager(ScoreManager scoreManager)
        {
            this.scoreManager = scoreManager;
        }

        public void PlayRound()
        {

            Console.WriteLine("Ready?\nRock!\nPaper!\nScissors!\nShoot!\n");
            string userPlayStr = Console.ReadLine();
            Computer.ComputerPlay(out string compPlayNum);

            if (!IsValidInput(userPlayStr))
            {
                Console.WriteLine("Invalid input for start number.");
                return;
            }

            if (userPlayStr == compPlayNum)
            {
                Console.WriteLine("It's a tie. Boring");
            }
            else
            {
                int userPlay = int.Parse(userPlayStr);
                int compPlay = int.Parse(compPlayNum);
                string resultMessage = DetermineWinner(userPlay, compPlay);

                Console.WriteLine(resultMessage);

                if (resultMessage.Contains("Congrats"))
                {
                    scoreManager.IncrementStreak();
                }
                else
                {
                    scoreManager.ResetStreak();
                }

                Console.WriteLine($"Your streak is now {scoreManager.GetStreak()}\n");
            }
        }

        private bool IsValidInput(string userInput)
        {
            return userInput == "1" || userInput == "2" || userInput == "3";
        }

        private string GetChoiceName(int choiceNumber)
        {
            switch (choiceNumber)
            {
                case 1:
                    return "Rock";
                case 2:
                    return "Paper";
                case 3:
                    return "Scissors";
                default:
                    return "Unknown";
            }
        }

        private string DetermineWinner(int userPlay, int compPlay)
        {
            string userChoice = GetChoiceName(userPlay);
            string compChoice = GetChoiceName(compPlay);

            if ((userPlay == 1 && compPlay == 3) || (userPlay == 2 && compPlay == 1) || (userPlay == 3 && compPlay == 2))
            {
                return $"Congrats, your {userChoice} beats computer's {compChoice}";
            }
            else
            {
                return "You suck, loser";
            }
        }

    }

}
