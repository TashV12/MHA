using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MHA
{
    public class Day2
    {
        private const string filePath = "C:\\Users\\JHBDemoRoom\\source\\repos\\MHA\\MHA\\TextFiles\\day2.txt";
        public static void Day2PartOne()
        {


            string input = File.ReadAllText(filePath);

            // Set target cube counts
            int targetRed = 12;
            int targetGreen = 13;
            int targetBlue = 14;

            // Parse the input and process each game
            var games = ParseGames(input);
            List<int> possibleGames = new List<int>();

            foreach (var game in games)
            {
                if (isPossible(game, targetRed, targetGreen, targetBlue))
                {
                    possibleGames.Add(game.ID);
                }
            }

            // Calculate the sum of IDs 
            int sumOfIDs = possibleGames.Sum();
            Console.WriteLine($"Sum of ID's {sumOfIDs}");
        }


        public class GameInfo
        {
            public int ID { get; set; }
            public List<Dictionary<string, int>> Sets { get; set; }
        }

        // Parse the input
        static List<GameInfo> ParseGames(string input)
        {
            List<GameInfo> games = new List<GameInfo>();
            string[] lines = input.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                int gameID = int.Parse(parts[0].Trim().Split()[1]);
                string[] sets = parts[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                GameInfo game = new GameInfo
                {
                    ID = gameID,
                    Sets = new List<Dictionary<string, int>>()
                };

                foreach (string set in sets)
                {
                    string[] cubes = set.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, int> subset = new Dictionary<string, int>();

                    foreach (string cube in cubes)
                    {
                        string[] tokens = cube.Trim().Split();
                        int count = int.Parse(tokens[0]);
                        string color = tokens[1];
                        subset[color] = count;
                    }

                    game.Sets.Add(subset);
                }

                games.Add(game);
            }

            return games;
        }

        // Check if possible
        static bool isPossible(GameInfo game, int targetRed, int targetGreen, int targetBlue)
        {
            foreach (var set in game.Sets)
            {
                foreach (var kvp in set)
                {
                    string color = kvp.Key;
                    int count = kvp.Value;

                    switch (color)
                    {
                        case "red":
                            if (count > targetRed)
                                return false;
                            break;
                        case "green":
                            if (count > targetGreen)
                                return false;
                            break;
                        case "blue":
                            if (count > targetBlue)
                                return false;
                            break;
                    }
                }
            }

            return true;
        }
        public static void Day2PartTwo()
        {
            string input = File.ReadAllText(filePath);

            var games = ParseGamesTwo(input);

            // Calculate the minimum cube counts required and sum of powers
            long sumOfPowers = 0;
            foreach (var game in games)
            {
                int minRed = 0;
                int minGreen = 0;
                int minBlue = 0;

                foreach (var set in game.Sets)
                {
                    if (set.TryGetValue("red", out int redCount))
                        minRed = Math.Max(minRed, redCount);

                    if (set.TryGetValue("green", out int greenCount))
                        minGreen = Math.Max(minGreen, greenCount);

                    if (set.TryGetValue("blue", out int blueCount))
                        minBlue = Math.Max(minBlue, blueCount);
                }

                long power = (long)minRed * minGreen * minBlue;
                sumOfPowers += power;
            }

            Console.WriteLine($"The sum of the power of minimum sets of cubes is: {sumOfPowers}");
        }

        public class GameInfoTwo
        {
            public int ID { get; set; }
            public List<Dictionary<string, int>> Sets { get; set; }
        }

        private static List<GameInfoTwo> ParseGamesTwo(string input)
        {
            List<GameInfoTwo> games = new List<GameInfoTwo>();
            string[] lines = input.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                int gameID = int.Parse(parts[0].Trim().Split()[1]);
                string[] sets = parts[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                GameInfoTwo game = new GameInfoTwo
                {
                    ID = gameID,
                    Sets = new List<Dictionary<string, int>>()
                };

                foreach (string set in sets)
                {
                    string[] cubes = set.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, int> subset = new Dictionary<string, int>();

                    foreach (string cube in cubes)
                    {
                        string[] tokens = cube.Trim().Split();
                        int count = int.Parse(tokens[0]);
                        string color = tokens[1];
                        subset[color] = count;
                    }

                    game.Sets.Add(subset);
                }

                games.Add(game);
            }

            return games;
        }

    }
}

