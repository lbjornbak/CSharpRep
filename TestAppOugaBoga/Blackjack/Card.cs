using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.Blackjack
{
    class Card
    {
        private string name;
        private string suit;
        private int rank;

        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Rank
        {
            get { return rank; }
            set
            {
                if (value >= 12)
                {
                    rank = 10;
                }
                else
                {
                    rank = value;
                }
            }
        }
    }
}
