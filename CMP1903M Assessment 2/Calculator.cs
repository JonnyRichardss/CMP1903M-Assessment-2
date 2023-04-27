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
            //find all operation cards in expression
            for (int i = 0; i < e.Count; i++)
            {
                if (i %2 != 0)
                {
                    operations.Add(e[i].Suit,i);
                }
            }
            //choose the next one to be used 
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
            //constructs next expression including the results of the current calculation
            Expression nextExpression = new Expression();
            Expression currentCalculation = new Expression();
            for (int i = 0; i < e.Count; i++)
            {
                if (Math.Abs(i - OperationIndex) > 1)
                {
                    nextExpression.Add(e[i]);
                }
                else
                {
                    currentCalculation.Add(e[i]);
                    if (currentCalculation.Count == 3)
                    {
                        int newValue = (int)Calculate(currentCalculation);
                        Card newCard = new Card(newValue);
                        nextExpression.Add(newCard);
                    }
                }
            }
            return Calculate(nextExpression);
        }

        public static float Calculate(Expression e)
        {
            if (e.Count != 3)//recursive case
            {
                return BodmasCalc(e);
            }
            else //base case
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
                        //not sure this is possible but the compiler sure thinks it is
                        throw new Exception();
                }
            }
        }
    }
}
