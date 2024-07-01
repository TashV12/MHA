using System;
using System.Collections.Generic;
using System.IO;

namespace MHA
{
    public class Day3
    {
        private const string filePath = "C:\\Users\\JHBDemoRoom\\source\\repos\\MHA\\MHA\\TextFiles\\day3.txt";

        public static void Day3Part1()
        {
            string[] input = ReadEngineSchematicFromFile(filePath);
            int sum = CalculateSumOfPartNumbers(input);
            Console.WriteLine($"Sum of part numbers based on adjacency: {sum}");
        }

        static string[] ReadEngineSchematicFromFile(string filePath)
        {

            string[] input = File.ReadAllLines(filePath);
            return input;
        }

        static int CalculateSumOfPartNumbers(string[] input)
        {
            int sum = 0;
            int rows = input.Length;
            int cols = input[0].Length;

           
            char[] adjacencySymbols = { '*', '+', '#', '$' };

            // Iterate through each cell in the grid
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Check if the current cell is a digit
                    if (Char.IsDigit(input[r][c]) && input[r][c] != '.')
                    {
                        bool adjacentToSymbol = false;

                        // Check all 8 possible directions
                        for (int dr = -1; dr <= 1; dr++)
                        {
                            for (int dc = -1; dc <= 1; dc++)
                            {
                                // Skip the current cell itself
                                if (dr == 0 && dc == 0)
                                    continue;

                                int nr = r + dr;
                                int nc = c + dc;

                                // Check if the adjacent cell is within bounds and is a symbol
                                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                                    Array.IndexOf(adjacencySymbols, input[nr][nc]) != -1)
                                {
                                    adjacentToSymbol = true;
                                    break; // No need to check further directions for this cell
                                }
                            }

                            if (adjacentToSymbol)
                                break; // No need to check further directions for this cell
                        }

                        if (adjacentToSymbol)
                        {
                            sum += int.Parse(input[r][c].ToString());
                        }
                    }
                }
            }

            return sum;
        }
    }
}
