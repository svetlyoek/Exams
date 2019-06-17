using System;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int carrotsCounter = 0;
            int potatosCounter = 0;
            int lettuceCounter = 0;
            int harmedVegetables = 0;

            int gardenRows = int.Parse(Console.ReadLine());
            char[][] arr = new char[gardenRows][];

            for (int i = 0; i < arr.Length; i++)
            {
                char[] lines = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                arr[i] = lines;
            }

            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "End of Harvest")
            {
                string[] command = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Harvest")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);

                    if (row <= arr.Length - 1 && row >= 0 && col >= 0 && col <= arr[row].Length - 1)
                    {

                        if (arr[row][col] == 'L')
                        {
                            arr[row][col] = ' ';
                            lettuceCounter++;
                        }
                        else if (arr[row][col] == 'C')
                        {
                            arr[row][col] = ' ';
                            carrotsCounter++;
                        }

                        else if (arr[row][col] == 'P')
                        {
                            arr[row][col] = ' ';
                            potatosCounter++;
                        }
                    }
                }


                else if (command[0] == "Mole")
                {
                    int moleRow = int.Parse(command[1]);
                    int moleCol = int.Parse(command[2]);
                    string direction = command[3];
                    if (moleRow <= arr.Length - 1 && moleRow >= 0 && moleCol >= 0 && moleCol <= arr[moleRow].Length - 1)
                    {
                        if (direction == "up")
                        {

                            for (int row = moleRow; row >= 0; row -= 2)
                            {
                                if (row >= 0)
                                {
                                    if (arr[row][moleCol] != ' ')
                                    {
                                        arr[row][moleCol] = ' ';
                                        harmedVegetables++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }


                            }
                        }

                        else if (direction == "down")
                        {

                            for (int row = moleRow; row <= arr.Length - 1; row += 2)
                            {
                                if (moleRow <= arr.Length - 1)
                                {
                                    if (arr[row][moleCol] != ' ')
                                    {
                                        arr[row][moleCol] = ' ';
                                        harmedVegetables++;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                                else
                                {
                                    break;
                                }


                            }
                        }
                        else if (direction == "left")
                        {

                            for (int col = moleCol; col >= 0; col -= 2)
                            {

                                if (arr[moleRow][col] != ' ')
                                {
                                    arr[moleRow][col] = ' ';
                                    harmedVegetables++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        else if (direction == "right")
                        {


                            for (int col = moleCol; col <= arr[moleRow].Length - 1; col += 2)
                            {

                                if (arr[moleRow][col] != ' ')
                                {
                                    arr[moleRow][col] = ' ';
                                    harmedVegetables++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var row in arr)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Carrots: {carrotsCounter}");
            Console.WriteLine($"Potatoes: {potatosCounter}");
            Console.WriteLine($"Lettuce: {lettuceCounter}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

    }
}


