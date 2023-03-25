using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    public enum SuitEnum
    {
        ERROR = 0,
        hearts = 1,
        clubs = 2,
        diamonds = 3,
        spades = 4
    }
    internal class Card
    {

        private int _value;
        private SuitEnum _suit;

        public int Value
        {
            get { return _value; }
        }
        public SuitEnum Suit
        {
            get { return _suit; }
        }

        public Card(int val, SuitEnum suit)
        {
            if (0 < val && val < 14) _value = val;
            _suit = suit;
        }
        public Card(int val, int suit)
        {
            if (0 < val && val < 14) _value = val;
            _suit = (SuitEnum)suit;
        }

        public override string ToString()
        {
            //THIS NEEDS CHANGING ITS PRETTY WEIRD maybe can just change wording for error idk
            if (Suit == SuitEnum.ERROR)
            {
                return ("Nothing, end of pack reached!");
            }
            //return card name (human readable)
            return (String.Format("The {0} of {1}.", _value, Suit));
        }
    }
}
