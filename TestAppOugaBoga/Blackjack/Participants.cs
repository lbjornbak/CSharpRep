using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.Blackjack
{
    public abstract class Participants
    {
        private List<Card> hand = new List<Card>();
        private string name;
        private int handTotal;
        private string handAsString;
        private bool bust = false;

        public string Name { get => name; set => name = value; }
        public int HandTotal { get => handTotal; set => handTotal = value; }
        public string HandAsString { get => handAsString; set => handAsString = value; }
        internal List<Card> Hand { get => hand; set => hand = value; }
        public bool Bust { get => bust; set => bust = value; }

        public void ResetHand()
        {
            handTotal = 0;
            hand.Clear();
            bust = false;
        }

        public virtual int CountCards()
        {
            return handTotal;
        }

        public virtual void SetHandAsString()
        {
        }
    }
}
