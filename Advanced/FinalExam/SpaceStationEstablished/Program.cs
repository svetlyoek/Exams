using System;

namespace SpaceStationEstablished
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int playerRow = 0;
            int playerCol = 0;
            int firstHoleRow = 0;
            int firstHoleCol = 0;
            int secondHoleRow = 0;
            int secondHoleCol = 0;
            int stars = 0;
            int holeCount = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row, col] == 'O' && holeCount == 0)
                    {
                        firstHoleRow = row;
                        firstHoleCol = col;
                        holeCount++;
                    }
                    else if (matrix[row, col] == 'O' && holeCount > 0)
                    {
                        secondHoleRow = row;
                        secondHoleCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow--;

                }

                else if (command == "down")
                {

                    matrix[playerRow, playerCol] = '-';
                    playerRow++;
                }


                else if (command == "left")
                {

                    matrix[playerRow, playerCol] = '-';
                    playerCol--;

                }

                else if (command == "right")
                {

                    matrix[playerRow, playerCol] = '-';
                    playerCol++;

                }

                if (playerRow < 0 || playerRow >= matrix.GetLength(0) || playerCol < 0 || playerCol >= matrix.GetLength(1))
                {
                    Console.WriteLine($"Bad news, the spaceship went to the void.");
                    Console.WriteLine($"Star power collected: {stars}");
                    break;
                }

                if (Char.IsDigit(matrix[playerRow, playerCol]))
                {
                    stars += int.Parse(matrix[playerRow, playerCol].ToString());
                    matrix[playerRow, playerCol] = 'S';
                }

                else if (playerRow == firstHoleRow && playerCol == firstHoleCol)
                {
                    playerRow = secondHoleRow;
                    playerCol = secondHoleCol;
                    matrix[firstHoleRow, firstHoleCol] = '-';
                    matrix[secondHoleRow, secondHoleCol] = 'S';
                }

                else if (playerRow == secondHoleRow && playerCol == secondHoleCol)
                {
                    playerRow = firstHoleRow;
                    playerCol = firstHoleCol;
                    matrix[secondHoleRow, secondHoleCol] = '-';
                    matrix[firstHoleRow, firstHoleCol] = 'S';
                }

                if (stars >= 50)
                {
                    Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
                    Console.WriteLine($"Star power collected: {stars}");
                    break;
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

