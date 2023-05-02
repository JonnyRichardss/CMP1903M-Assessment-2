namespace CMP1903M_Assessment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ExpressionsTemplate = { 
                "a + b","a - b","a * b","a / b",
                "a + b + c","a + b - c","a + b * c","a + b / c",
                "a - b + c","a - b - c","a - b * c","a - b / c",
                "a * b + c","a * b - c","a * b * c","a * b / c",
                "a / b + c","a / b - c","a / b * c","a / b / c"
            };
            string[] testExpressions1 = Testing.TemplateToExpressions(ExpressionsTemplate);
            string[] testExpressions2 = Testing.TemplateToExpressions(ExpressionsTemplate);
            
            foreach( string s in Testing.Test(testExpressions1))
            {
                //Console.WriteLine(s);
            }
            foreach (string s in Testing.Test(testExpressions2))
            {
               // Console.WriteLine(s);
            }
            //Entry point hands straight off to console menu
            Tutorial.MainMenu();
        }
    }
}