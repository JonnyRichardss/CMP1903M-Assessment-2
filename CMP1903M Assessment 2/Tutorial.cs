using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    internal static class Tutorial
    {
        static Pack pack = new Pack();
        static void ResetPack()
        {
            pack = new Pack(true);
        }
        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the LinCode Maths Tutor demo!");
            ResetPack();
            bool quit = false;
            string header = "Main menu:";
            string[] options = 
            { 
                "Show Instructions",
                "Deal 3 Cards",
                "Deal 5 Cards",
                "Show Statistics",
                "Quit" 
            };
            string instructions = "This demo is designed to show off an early version of the card-based maths tutor program.\n"
                +"To use it choose to deal either 3 or 5 cards from the pack.\n" +
                "These dealt cards are interpreted as a maths equation.\n"
                +"You then answer the equation and the program will check if you are right.\n" +
                "The program will also store basic statistics about the number of questions answered correctly";
            while (!quit)
            {
                int input = Helpers.intMenu(header, options);
                switch (input)
                {
                    case 1:
                        Console.WriteLine(instructions);
                        break;
                    case 2:
                        DealMenu(3);
                        break;
                    case 3:
                        DealMenu(5);
                        break;
                    case 4:
                        Console.WriteLine("Total 3-Card questions:{0} \nTotal 5-Card questions:{1} \nCorrect 3-Card questions:{2} \nCorrect 5-Card questions:{3}",Statistics.total3Card,Statistics.total5Card,Statistics.correct3Card,Statistics.correct5Card);
                        break;
                    default:
                        quit = true;
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
            Console.WriteLine("Please press ENTER to exit.");
            Console.ReadLine();
        }
        public static void DealMenu(int numCards)
        {
            Expression currentE;
            bool exit = false;
            while (!exit)
            {
                try
                {
                    currentE = new Expression(pack.Deal(numCards));
                }
                catch (PackEmptyException)
                {
                    Console.WriteLine("Pack was empty! Reset pack!");
                    ResetPack();
                    currentE = new Expression(pack.Deal(numCards));
                }
                Console.WriteLine(currentE);
                float input = Helpers.floatInput();
                bool correct = input == currentE.Evaluate();
                if (correct)
                {
                    Console.WriteLine("You got it right!");
                }
                else
                {
                    Console.WriteLine("Incorrect. The answer was {0}!",currentE.Evaluate());
                }
                Statistics.AddResult(correct, numCards);
                exit = !Helpers.BoolInput("Do you want to deal again?"); 
            }
        }
    }
}
