﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    public class Expression : CardCollection, IEvaluable
    {
        protected override List<Card> Cards { get; }
        public override int Count 
        { 
            get { return Cards.Count; } 
        }
        private float Value;

        public Expression()
        {
            Cards = new List<Card>();
            Value = float.PositiveInfinity;
        }
        public Expression(List<Card> cards)
        { 
            Cards = cards;
            Value = float.PositiveInfinity;
        }
        public Expression(int NumCards)
        {
            Cards = new List<Card>();
            for(int i = 0; i < NumCards; i++)
            {
                Cards.Add(new Card());
            }
        }
        public float Evaluate()
        {
            if (Cards.Count % 2 == 0)
            {
                throw new EvaluationImpossibleException();
            }
            if (Value != float.PositiveInfinity)
            {
                //If already Evaluated find the stored value
                return Value;
            }
            else
            {
                //evaluate, store and return
                Value = Calculator.Calculate(this);
                return Value;
            }
        }
    }
}
