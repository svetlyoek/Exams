using System;

namespace Project_price
{
    class Program
    {
        static void Main(string[] args)
        {
            double projectParts = double.Parse(Console.ReadLine());
            double priceForOneScore = double.Parse(Console.ReadLine());
            double finalPrice = 0;
            double scoresSum = 0;

            for (int i = 1; i <= projectParts; i++)
            {
                double scores = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {

                    scoresSum += scores * 2;

                }
                else if (i % 2 != 0)
                {
                    scoresSum += scores * 1;
                }
            }
            finalPrice = scoresSum * priceForOneScore;
            Console.WriteLine("The project prize was {0:f2} lv.", finalPrice);

        }
    }
}
