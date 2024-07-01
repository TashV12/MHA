using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MHA
{
    public class Day1
    {

        private const string FilePath = "C:\\Users\\JHBDemoRoom\\source\\repos\\MHA\\MHA\\TextFiles\\day1.txt";

        public static void dayOnePartOne()
        {
            try
            {
                string[] lines = ReadLinesFromFile(FilePath);
                int totalSum = 0;

                foreach (var line in lines)
                {
                    char firstDigit = line.FirstOrDefault(char.IsDigit);
                    char lastDigit = line.LastOrDefault(char.IsDigit);

                
                    if (firstDigit != default && lastDigit != default)
                    {
                        int calibrationValue = int.Parse($"{firstDigit}{lastDigit}");
                        totalSum += calibrationValue;
                    }
                }

                // Print Total
                Console.WriteLine($"The sum of all values for day 1 with numbers only: {totalSum}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file was not found.");
            }
        }

        public static void dayOnePartTwo()
        {
            try
            {
                List<string> inputLines = new List<string>(ReadLinesFromFile(FilePath));

                Dictionary<string, char> spelledDigits = new Dictionary<string, char>
                {
                    { "zero", '0' },
                    { "one", '1' },
                    { "two", '2' },
                    { "three", '3' },
                    { "four", '4' },
                    { "five", '5' },
                    { "six", '6' },
                    { "seven", '7' },
                    { "eight", '8' },
                    { "nine", '9' }
                };

                int totalSum = 0;
                Regex regex = new Regex(string.Join("|", spelledDigits.Keys), RegexOptions.IgnoreCase);

                foreach (string line in inputLines)
                {
                    string replacedLine = regex.Replace(line, match => spelledDigits[match.Value.ToLower()].ToString());

                    char firstDigit = ' ';
                    char lastDigit = ' ';
                    bool foundFirst = false;

                    foreach (char c in replacedLine)
                    {
                        if (char.IsDigit(c))
                        {
                            if (!foundFirst)
                            {
                                firstDigit = c;
                                foundFirst = true;
                            }
                            lastDigit = c;
                        }
                    }

                    if (foundFirst)
                    {
                        int first = int.Parse(firstDigit.ToString());
                        int last = int.Parse(lastDigit.ToString());
                        int calibrationValue = first * 10 + last;
                        totalSum += calibrationValue;
                    }
                }

                Console.WriteLine($"The sum of Day1 with text and numbers {totalSum}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file was not found.");
            }
        }

        private static string[] ReadLinesFromFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        /*
        static void dayTwo()
        {
           
        }
        */


    }
}