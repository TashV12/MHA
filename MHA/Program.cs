//Day1 Solution
//using System;
//using System.IO;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            // Read all lines from the file day1.txt
//            string[] lines = File.ReadAllLines("C:\\Users\\JHBDemoRoom\\source\\repos\\MHA\\MHA\\day1.txt");

//            int totalSum = 0;

//            foreach (var line in lines)
//            {

//                char firstDigit = line.FirstOrDefault(char.IsDigit);

//                char lastDigit = line.LastOrDefault(char.IsDigit);

//                //  Add first and last digit
//                if (firstDigit != default && lastDigit != default)
//                {
//                    int calibrationValue = int.Parse($"{firstDigit}{lastDigit}");
//                    totalSum += calibrationValue;
//                }
//            }

//            // Print the total sum of calibration values
//            Console.WriteLine($"The sum of all calibration values is: {totalSum}");
//        }
//        catch (FileNotFoundException)
//        {
//            Console.WriteLine("The file day1.txt was not found.");
//        }

//    }
//}

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    // Dictionary to map spelled-out digits to their numerical values
    static Dictionary<string, char> digitMap = new Dictionary<string, char>
    {
        {"zero", '0'}, {"one", '1'}, {"two", '2'}, {"three", '3'},
        {"four", '4'}, {"five", '5'}, {"six", '6'}, {"seven", '7'},
        {"eight", '8'}, {"nine", '9'}
    };

    static void Main()
    {
        try
        {
            // Read all lines from the file day1.txt
            string[] lines = File.ReadAllLines("day1.txt");

            int totalSum = 0;

            foreach (var line in lines)
            {
                string firstDigit = FindFirstDigit(line);
                string lastDigit = FindLastDigit(line);

                // Convert spelled-out digits to numerical characters
                if (digitMap.ContainsKey(firstDigit)) firstDigit = digitMap[firstDigit].ToString();
                if (digitMap.ContainsKey(lastDigit)) lastDigit = digitMap[lastDigit].ToString();

                if (!string.IsNullOrEmpty(firstDigit) && !string.IsNullOrEmpty(lastDigit))
                {
                    int calibrationValue = int.Parse(firstDigit + lastDigit);
                    totalSum += calibrationValue;
                }
            }

            // Print the total sum of calibration values
            Console.WriteLine($"The sum of all calibration values is: {totalSum}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file day1.txt was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Method to find the first digit (numerical or spelled-out)
    static string FindFirstDigit(string line)
    {
        foreach (var kvp in digitMap)
        {
            if (line.Contains(kvp.Key))
                return kvp.Key;
        }

        foreach (char c in line)
        {
            if (char.IsDigit(c))
                return c.ToString();
        }

        return string.Empty;
    }

    // Method to find the last digit (numerical or spelled-out)
    static string FindLastDigit(string line)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            foreach (var kvp in digitMap)
            {
                if (line.Substring(0, i + 1).Contains(kvp.Key))
                    return kvp.Key;
            }

            if (char.IsDigit(line[i]))
                return line[i].ToString();
        }

        return string.Empty;
    }
}

