using System;

namespace Puppy_care
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodKg = double.Parse(Console.ReadLine());
            string command = "";
            double allEatFood = 0;
            double realFoodGrams = 0;
            double realFood = 0;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "Adopted")
                {
                    break;
                }

                double eatFood = double.Parse(command);
                allEatFood += eatFood;
                realFoodGrams = foodKg * 1000;

            }



            if (realFoodGrams >= allEatFood && command == "Adopted")
            {
                realFood = realFoodGrams - allEatFood;
                Console.WriteLine("Food is enough! Leftovers: {0} grams.", realFood);
            }
            else if (realFoodGrams < allEatFood && command == "Adopted")
            {
                realFood = allEatFood - realFoodGrams;
                Console.WriteLine("Food is not enough. You need {0} grams more.", realFood);
            }
        }
    }
}
