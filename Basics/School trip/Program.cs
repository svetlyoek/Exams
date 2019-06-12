using System;

namespace School_trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double foodKg = double.Parse(Console.ReadLine());
            double firstkg = double.Parse(Console.ReadLine());
            double secondKg = double.Parse(Console.ReadLine());
            double thirdKg = double.Parse(Console.ReadLine());
            double allFood = 0;
            double firstDog = days * firstkg;
            double secondDog = days * secondKg;
            double thirdDog = days * thirdKg;
            allFood = firstDog + secondDog + thirdDog;
            if (allFood <= foodKg)
            {
                double leftFood = Math.Floor(foodKg - allFood);
                Console.WriteLine("{0} kilos of food left.", leftFood);
            }
            else if (allFood > foodKg)
            {
                double neededFood = Math.Ceiling(allFood - foodKg);
                Console.WriteLine("{0} more kilos of food are needed.", neededFood);
            }
        }
    }
}
