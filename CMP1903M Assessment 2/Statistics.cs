using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    public static class Statistics
    {
        //this entire thing is a little odd considering how the rest of the program could theoretically do an arbitrary number of  cards but oh well
        public static int total3Card;
        public static int total5Card;

        public static int correct3Card;
        public static int correct5Card;

        public static string AllValues
        {
            get => String.Format("{0},{1},{2},{3}", total3Card, total5Card, correct3Card, correct5Card);
            set
            {
                if (!CheckFormat(value))
                {
                    throw new FormatException("Statistics values not in correct format!");
                }
                string[] values = value.Split(",");
                total3Card = int.Parse(values[0]);
                total5Card = int.Parse(values[1]);
                correct3Card = int.Parse(values[2]);
                correct5Card = int.Parse(values[3]);
            }
        }
        static Statistics()
        {
            IO.LoadStats();
        }

        private static bool CheckFormat(string storedValues)
        {
            string[] values = storedValues.Split(",");
            if (values.Length != 4)
            {
                return false;
            }
            foreach (string s in values)
            {
                if (!int.TryParse(s,out _))
                {
                    return false;
                }
            }
            return true;
        }
        public static void AddResult(bool correct,int numCards)
        {
           
            if (numCards == 3)
            {
                total3Card++;
                if (correct)
                {
                    correct3Card++;
                } 
            }
            else
            {
                total5Card++;
                if (correct)
                {
                    correct5Card++;
                }
            }
        }
    }
}
