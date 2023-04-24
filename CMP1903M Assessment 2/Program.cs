namespace CMP1903M_Assessment_2
{
    internal class Program
    {
        static void DealMenu(ref Pack pack)
        {
            bool exit = false;
            while (!exit)
            {
                //present sum
                //take input
                //check if correct
                //deal again or break
            }
        }
        static void MainMenu()
        {
            Console.WriteLine("Welcome to the LinCode Maths Tutor demo!");


            Console.WriteLine("Goodbye!");
            Console.WriteLine("Please press ENTER to exit.");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Pack p = new Pack();
            foreach (Card c in p)
            {
                Console.WriteLine(c.ToString());
            }
            //Entry point hands straight off to console menu
            MainMenu();
        }
    }
}