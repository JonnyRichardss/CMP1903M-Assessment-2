using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    //Helpers.cs initially copied from my algorithms assessment
    internal static class Helpers
    {
        //class of functions that perform miscellaneous (console related) tasks in my code
        public static int intMenu(string heading, string[] options)
        {
            //function that constructs a text menu with any number of options from options array
            //returns an int that is guaranteed to be in the range of the options given
            bool invalidSelection;
            int output = 0;
            string input = "";
            //loop while there is no valid input
            do
            {
                //display heading and iterate to show options
                Console.WriteLine(heading);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine("{0}: {1}",i+1,options[i]);
                }
                Console.Write(">");
                //take user input
                input = Console.ReadLine() ??string.Empty; //the question mark thing is weird here but it makes the compiler happy
                if (int.TryParse(input, out output)&& output>0 && output <=options.Length)  //if input is an int and in range of the menu
                {
                    invalidSelection = false;//continue
                }
                else
                {
                    //else loop
                    invalidSelection = true;
                    Console.WriteLine("Not a valid option!");
                }
            } while (invalidSelection);

            return output;//once valid and in range, return the int
        }
        public static float floatInput()
        {
            //function that takes and validates a simple float input
            //returns the float the user inputted
            bool validInput = false;
            string userInput;
            float output = float.PositiveInfinity;
            while (!validInput)
            {
                //take input
                Console.Write(">");
                userInput = Console.ReadLine() ?? string.Empty; //again the weird question mark thing to shut the compiler up
                if (float.TryParse(userInput, out output))
                {
                    validInput = true;//if the input is valid continue
                }
                else
                {
                    Console.WriteLine("Input was not an float!"); //else loop
                }
            }
            return output;//finally return the float
        }

    }
}
