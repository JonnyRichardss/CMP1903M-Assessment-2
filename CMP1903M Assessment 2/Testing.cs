using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    internal static class Testing
    {
        static Expression StringToExpression(string input)
        {
            List<string> cardStrings = new List<string>();
            cardStrings.AddRange(input.Split(" "));
            foreach (string s in cardStrings)
            {
                if (s == string.Empty)
                {
                    cardStrings.Remove(s);
                }
            }
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
        public static string[] TemplateToExpressions(string[] input)
        {
            Random rng =new Random();
            string[] output = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                string str = input[i];
                char[] Carray = str.ToCharArray();
                for (int j = 0; j < str.Length; j++)
                {
                    char c = str[j];
                    if (Char.IsLetterOrDigit(c))
                    {
                        Carray[j] = rng.Next(1, 14).ToString()[0];
                    }
                }
                output[i] = new string(Carray);
            }
            return output;
        }
        public static string[] Test(string[] testExpressions)
        {
            string[] output = new string[testExpressions.Length];
            for (int i = 0; i < testExpressions.Length; i++)
            {
                string testString = testExpressions[i];
                Expression e = StringToExpression(testString);
                output[i] = String.Format(testString+" = " + e.Evaluate());
            }
            return output;
        }

    }
}
