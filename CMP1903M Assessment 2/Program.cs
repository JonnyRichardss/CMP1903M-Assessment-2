namespace CMP1903M_Assessment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] testExpressions = { "1 + 2 + 3", "2 * 4 - 3" };
            Testing.Test(testExpressions);
            //Entry point hands straight off to console menu
            Tutorial.MainMenu();
        }
    }
}