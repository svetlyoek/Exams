using System;

namespace Math_puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool found = false;
            for (int a = 1; a <= 30; a++)

            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {


                        if (a < b && b < c && a + b + c == num)
                        {

                            found = true;
                            Console.WriteLine($"{a} + {b} + {c} = {num}");
                        }

                        if (a > b && b > c && a * b * c == num)
                        {
                            found = true;
                            Console.WriteLine($"{a} * {b} * {c} = {num}");
                        }


                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
