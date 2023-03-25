﻿using System;
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

        //this error checking wants looking at i think
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
            //THIS NEEDS CHANGING ITS PRETTY WEIRD maybe can just change wording for error idk
            if (Suit == SuitEnum.ERROR)
            {
                return ("Nothing, end of pack reached!");
            }
            //return card name (human readable)
            return (String.Format("The {0} of {1}.", Value, Suit));
        }
    }
}
