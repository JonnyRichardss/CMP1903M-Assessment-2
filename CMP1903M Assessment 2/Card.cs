using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    public enum SuitEnum
    {
        add = 1,
        subtract = 2,
        multiply = 3,
        divide = 4
    }
    public class Card
    {
        public int Value
        {
            get;
            private set;
        } 
        public SuitEnum Suit
        {
            get;
            private set;
        }
        private float FloatValue;
        //this error checking wants looking at i think
        public Card()
        {
            Random rng = new Random();
            Value = rng.Next(1, 14);
            Suit = (SuitEnum)rng.Next(1, 5);
        }
        public Card(float floatValue):this()
        { 
           FloatValue = floatValue;
            Value = (int)floatValue;
        }
        public Card(int val, SuitEnum suit)
        {
            if (0 < val && val < 14) Value = val;
            Suit = suit;
        }
        public Card(int val, int suit) : this(val,(SuitEnum)suit)
        {

        }

        public override string ToString()
        {
            //return card name (human readable)
            return (String.Format("The {0} of {1}.", Value, Suit));
        }

        //decided to have operators return float since 
        public static float operator +(Card card1, Card card2)
        {
            return card1.FloatValue + card2.FloatValue;
        }
        public static float operator -(Card card1, Card card2)
        {
            return card1.FloatValue - card2.FloatValue;
        }
        public static float operator *(Card card1, Card card2)
        {
            return card1.FloatValue * card2.FloatValue;
        }
        public static float operator /(Card card1, Card card2)
        {
            return card1.FloatValue / card2.FloatValue;
        }
    }
}
