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
            get { return Value; }
            private set
            {
                if (value >0 && value < 14)
                {
                    Value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        } 
        public SuitEnum Suit
        {
            get;
            private set;
        }
        private float FloatValue;
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
            Value = val;
            Suit = suit;
        }
        public Card(int val, int suit) : this(val,(SuitEnum)suit)
        {

        }

        //decided to have operators return float since divide can give decimal values
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

        public override string ToString()
        {
            //return card name (mainly for debugging)
            return (String.Format("{0},{1}.", Value, Suit));
        }
    }
}
