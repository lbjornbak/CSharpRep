using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.RockPaperScissor
{
    public class ScoreManager
    {
        private int RPSStreak;

        public ScoreManager()
        {
            RPSStreak = 0;
        }

        public void IncrementStreak()
        {
            RPSStreak++;
        }

        public void ResetStreak()
        {
            RPSStreak = 0;
        }

        public int GetStreak()
        {
            return RPSStreak;
        }
    }

}
