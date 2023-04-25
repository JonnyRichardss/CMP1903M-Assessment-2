using System;
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


        public Expression(List<Card> cards)
        { 
            if (cards.Count%2 ==0) 
            {
                //fix this
                throw new Exception();
            }
            Cards = cards;
            Value = float.PositiveInfinity;
        }
        public Expression(int NumCards)
        {
            if (NumCards % 2 == 0)
            { 
                //fix this too
                throw new Exception();
            }
            Cards = new List<Card>();
            for(int i = 0; i < NumCards; i++)
            {
                Cards.Add(new Card());
            }
        }
        public float Evaluate()
        {
            if (Value != float.PositiveInfinity)
            {
                //If already Evaluated find the stored value
                return Value;
            }
            else
            {
                //evaluate, store and return
                Value = Calculator.Calc(this);
                return Value;
            }
        }
    }
}
