using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    internal static class IO
    {
        private static string FilePath = "Statistics.txt";
        public static void LoadStats()
        {
            try
            {
                string FileText = File.ReadAllText(FilePath);
                Statistics.AllValues = FileText;
            }
            catch (Exception e ) when (e is FormatException || e is FileNotFoundException)
            {
                Statistics.AllValues = "0,0,0,0";
                SaveStats();
            }
        }
        public static void SaveStats()
        {
            string stats = Statistics.AllValues;
            File.WriteAllText(stats, FilePath);
        }
    }
}
