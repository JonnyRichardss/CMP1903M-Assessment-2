﻿using System;
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
        private int _value;
        public int Value
        {
            get { return _value; }
            private set
            {
                if (value >0 && value < 14)
                {
                    _value = value;
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
            FloatValue = (float)Value;
        }
        public Card(float floatValue):this()
        { 
           FloatValue = floatValue;
            try
            {
                Value = (int)floatValue;
            }
            catch (ArgumentOutOfRangeException)
            {
                Value = 13;
            }
        }
        public Card(SuitEnum suit) :this()
        {
            Suit = suit;
        }
        public Card(int val, SuitEnum suit)
        {
            Value = val;
            Suit = suit;
            FloatValue = val;
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
        public static string OperatorToString(SuitEnum input)
        {
            switch (input)
            {
                case SuitEnum.add:
                    return "+";
                case SuitEnum.subtract:
                    return "-";
                case SuitEnum.multiply:
                    return "*";
                case SuitEnum.divide:
                    return "/";
                default:
                    return String.Empty;
            }
        }
    }
}
