using System;

namespace Safe_password_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());
            PrintPassword(a, b, maxPasswords);
        }

        private static void PrintPassword(int a, int b, int maxPasswords)
        {
            char A = (char)35;
            char B = (char)64;
            int counter = 0;
            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    if (counter == maxPasswords)
                    {
                        return;
                    }
                    if (A > 55)
                    {
                        A = (char)35;
                    }
                    if (B > 96)
                    {
                        B = (char)64;
                    }
                    Console.Write($"{A}{B}{x}{y}{B}{A}|");
                    A++;
                    B++;
                    counter++;
                }

            }
            Console.WriteLine();
        }
    }
}
