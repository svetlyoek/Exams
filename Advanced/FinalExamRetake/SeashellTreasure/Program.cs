using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    public class Program
    {
        static int stolenSeashell;
        static List<string> seashells;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            seashells = new List<string>();

            var beach = new string[matrixSize][];

            for (int row = 0; row < beach.Length; row++)
            {
                string[] lines = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                beach[row] = new string[lines.Length];

                for (int col = 0; col < beach[row].Length; col++)
                {
                    beach[row][col] = lines[col];

                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split()
                    .ToArray();

                string commandName = commands[0];

                if (commandName == "Sunset")
                {
                    break;
                }

                if (commandName == "Collect")
                {
                    int playerRow = int.Parse(commands[1]);
                    int playerCol = int.Parse(commands[2]);

                    if (playerRow >= 0 && playerRow <= beach.Length - 1 && playerCol >= 0 && playerCol <= beach[playerRow].Length - 1)
                    {
                        if (beach[playerRow][playerCol] == "C" || beach[playerRow][playerCol] == "N" || beach[playerRow][playerCol] == "M")
                        {
                            seashells.Add(beach[playerRow][playerCol]);

                            beach[playerRow][playerCol] = "-";
                        }
                    }
                }

                else if (commandName == "Steal")
                {
                    int evilRow = int.Parse(commands[1]);
                    int evilCol = int.Parse(commands[2]);
                    string direction = commands[3];

                    if (evilRow >= 0 && evilRow <= beach.Length - 1 && evilCol >= 0 && evilCol <= beach[evilRow].Length - 1)
                    {
                        if (beach[evilRow][evilCol] == "C" || beach[evilRow][evilCol] == "N" || beach[evilRow][evilCol] == "M")
                        {
                            stolenSeashell++;
                            beach[evilRow][evilCol] = "-";
                        }
                    }

                    else
                    {
                        continue;
                    }

                    if (direction == "up")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            evilRow--;

                            if (evilRow >= 0)
                            {
                                if (beach[evilRow][evilCol] == "C" || beach[evilRow][evilCol] == "N" || beach[evilRow][evilCol] == "M")
                                {
                                    stolenSeashell++;
                                    beach[evilRow][evilCol] = "-";
                                }

                            }
                        }
                    }

                    else if (direction == "down")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            evilRow++;


                            if (evilRow <= beach.Length - 1)
                            {
                                if (beach[evilRow][evilCol] == "C" || beach[evilRow][evilCol] == "N" || beach[evilRow][evilCol] == "M")
                                {
                                    stolenSeashell++;
                                    beach[evilRow][evilCol] = "-";
                                }


                            }
                        }
                    }

                    else if (direction == "left")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            evilCol--;

                            if (evilCol >= 0)
                            {
                                if (beach[evilRow][evilCol] == "C" || beach[evilRow][evilCol] == "N" || beach[evilRow][evilCol] == "M")
                                {
                                    stolenSeashell++;
                                    beach[evilRow][evilCol] = "-";
                                }

                            }

                        }
                    }

                    else if (direction == "right")
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            evilCol++;

                            if (evilCol <= beach[evilRow].Length - 1)
                            {
                                if (beach[evilRow][evilCol] == "C" || beach[evilRow][evilCol] == "N" || beach[evilRow][evilCol] == "M")
                                {
                                    stolenSeashell++;
                                    beach[evilRow][evilCol] = "-";
                                }

                            }
                        }
                    }

                }
            }

            for (int row = 0; row < beach.Length; row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    if (col == beach[row].Length)
                    {
                        Console.Write(beach[row][col]);
                    }

                    else
                    {
                        Console.Write(beach[row][col] + " ");
                    }

                }

                Console.WriteLine();
            }

            if (seashells.Count > 0)
            {
                Console.WriteLine($"Collected seashells: {seashells.Count} -> {string.Join(", ", seashells)}");
            }

            else
            {
                Console.WriteLine($"Collected seashells: 0");
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashell}");
        }
    }
}
