using System;
using System.Linq;

namespace TronRacers
{
    class Program
    {
        static char[][] field;
        static int firstPlayerRow;
        static int firstPlayerCol;
        static int secondPlayerRow;
        static int secondPlayerCol;
        static int matrixSize;
        static void Main(string[] args)
        {
            matrixSize = int.Parse(Console.ReadLine());

            field = new char[matrixSize][];

            for (int row = 0; row < field.Length; row++)
            {
                char[] lines = Console.ReadLine().ToCharArray();
                field[row] = lines;

                for (int col = 0; col < field[row].Length; col++)
                {

                    if (field[row][col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (field[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            while (true)
            {

                string[] commands = Console.ReadLine()
                    .Split()
                    .ToArray();

                string firstCommand = commands[0];
                string secondCommand = commands[1];

                FirstCommand(firstCommand);
                SecondCommand(secondCommand);
            }
        }

        private static void SecondCommand(string secondCommand)
        {
            if (secondCommand == "up")
            {
                secondPlayerRow--;

                if (secondPlayerRow < 0)
                {
                    secondPlayerRow = field.Length - 1;
                }
            }
            else if (secondCommand == "down")
            {
                secondPlayerRow++;

                if (secondPlayerRow > field.Length - 1)
                {
                    secondPlayerRow = 0;
                }
            }

            else if (secondCommand == "left")
            {
                secondPlayerCol--;

                if (secondPlayerCol < 0)
                {
                    secondPlayerCol = field[secondPlayerRow].Length - 1;
                }
            }

            else if (secondCommand == "right")
            {
                secondPlayerCol++;

                if (secondPlayerCol > field[secondPlayerRow].Length - 1)
                {
                    secondPlayerCol = 0;
                }
            }

            if (field[secondPlayerRow][secondPlayerCol] == 'f')
            {
                field[secondPlayerRow][secondPlayerCol] = 'x';
                End();
            }
            else
            {
                field[secondPlayerRow][secondPlayerCol] = 's';


            }
        }

        private static void FirstCommand(string firstCommand)
        {
            if (firstCommand == "up")
            {
                firstPlayerRow--;

                if (firstPlayerRow < 0)
                {
                    firstPlayerRow = field.Length - 1;
                }
            }
            else if (firstCommand == "down")
            {
                firstPlayerRow++;

                if (firstPlayerRow > field.Length - 1)
                {
                    firstPlayerRow = 0;
                }
            }

            else if (firstCommand == "left")
            {
                firstPlayerCol--;

                if (firstPlayerCol < 0)
                {
                    firstPlayerCol = field[firstPlayerRow].Length - 1;
                }
            }

            else if (firstCommand == "right")
            {
                firstPlayerCol++;

                if (firstPlayerCol > field[firstPlayerRow].Length - 1)
                {
                    firstPlayerCol = 0;
                }
            }

            if (field[firstPlayerRow][firstPlayerCol] == 's')
            {
                field[firstPlayerRow][firstPlayerCol] = 'x';
                End();
            }
            else
            {
                field[firstPlayerRow][firstPlayerCol] = 'f';


            }

        }

        private static void End()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }
    }
}