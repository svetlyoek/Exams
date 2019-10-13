using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double oneDayWaterForOne = double.Parse(Console.ReadLine());
            double oneDayFoodForOne = double.Parse(Console.ReadLine());
            double totalWater = days * people * oneDayWaterForOne;
            double totalFood = days * people * oneDayFoodForOne;
            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }

                if (i % 2 == 0)
                {
                    groupEnergy += (groupEnergy * 0.05);
                    totalWater -= (totalWater * 0.30);
                }
                if (i % 3 == 0)
                {
                    totalFood -= totalFood / people;
                    groupEnergy += (groupEnergy * 0.1);
                }

            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");





        }

    }
    }

