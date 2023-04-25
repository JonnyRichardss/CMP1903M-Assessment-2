using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    public static class Calculator
    {
        private static float BodmasCalc(Expression e)
        {
            SuitEnum[] Bodmasorder = new SuitEnum[] { SuitEnum.divide, SuitEnum.multiply, SuitEnum.add, SuitEnum.subtract };
            Dictionary<SuitEnum, int> operations = new Dictionary<SuitEnum, int>();
            for (int i = 0; i < e.Count; i++)
            {
                if (i %2 != 0)
                {
                    operations.Add(e[i].Suit,i);
                }
            }
            int OperationIndex=0;
            foreach (SuitEnum SearchSuit in Bodmasorder) 
            {
                foreach (SuitEnum CurrentSuit in operations.Keys)
                {
                    if (CurrentSuit == SearchSuit)
                    {
                        OperationIndex = operations[CurrentSuit];
                    }

                }
            }
            List<Card> nextExpression = new List<Card>();
            List<Card> currentCalculation = new List<Card>();
            for (int i = 0; i < e.Count; i++)
            {
                if (Math.Abs(i - OperationIndex) > 1)
                {
                    nextExpression.Add(e[i]);
                }
                else
                {
                    //this might be cleaner if I can add to expression, might look into it
                    currentCalculation.Add(e[i]);
                    if (currentCalculation.Count == 3)
                    {
                        Expression currentCalculationExpression = new Expression(currentCalculation);
                        int newValue = (int)Calc(currentCalculationExpression);
                        Card newCard = new Card(newValue);
                        nextExpression.Add(newCard);
                    }
                }
            }
            return BodmasCalc(new Expression(nextExpression));
        }
        public static float Calc(Expression e)
        {
            if (e.Count != 3)
            {
                return BodmasCalc(e);
            }
            else
            {
                Card operation = e[1];
                switch (operation.Suit)
                {
                    case SuitEnum.add:
                        return e[0] + e[2];
                    case SuitEnum.subtract:
                        return e[0] - e[2];
                    case SuitEnum.multiply:
                        return e[0] * e[2];
                    case SuitEnum.divide:
                        return e[0] / e[2];
                    default:
                        //fix this
                        throw new Exception();
                }
            }
        }
    }
}
