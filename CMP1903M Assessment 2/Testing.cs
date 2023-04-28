using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    internal class Testing
    {
        static Expression StringToExpression(string s)
        {
            string[] cardStrings = s.Split(" ");
            List<Card > Cards = new List<Card>();
            foreach(string cardString in cardStrings)
            {
                SuitEnum currentOperation;
                switch (cardString)
                {
                    case "+":
                        currentOperation = SuitEnum.add;
                        break;
                    case "-":
                        currentOperation = SuitEnum.subtract;
                        break;
                    case "*":
                        currentOperation = SuitEnum.multiply;
                        break;
                    case "/":
                        currentOperation = SuitEnum.divide;
                        break;
                    default:
                        Cards.Add(new Card(int.Parse(cardString)));
                        continue;
                }
                Cards.Add(new Card(currentOperation));
            }
            return new Expression(Cards);
        }
        public static void Test(string[] testExpressions)
        {


            foreach (string testString in testExpressions)
            {
                Console.WriteLine(testString);
                Expression e = StringToExpression(testString);
                Console.WriteLine(e.Evaluate());
            }
        }
    }
}
