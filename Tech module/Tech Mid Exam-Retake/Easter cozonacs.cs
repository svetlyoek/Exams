using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double kgFlourPrice = double.Parse(Console.ReadLine());
            double onePackEggsPrice = kgFlourPrice * 0.75;
            double literMilkPrice = kgFlourPrice + (kgFlourPrice * 0.25);
            double cupMilkPrice = literMilkPrice / 4;
            double oneCozonacPrice = cupMilkPrice + onePackEggsPrice + kgFlourPrice;
            int cozonacCount = 0;
            int eggsCount = 0;
            int looseEggs = 0;
            while (budget >= oneCozonacPrice)
            {
                budget -= oneCozonacPrice;
                cozonacCount++;
                eggsCount += 3;
                if (cozonacCount % 3 == 0)
                {

                    looseEggs = cozonacCount - 2;
                    eggsCount -= looseEggs;
                }
            }
            Console.WriteLine($"You made {cozonacCount} cozonacs! Now you have {eggsCount} eggs and {budget:f2}BGN left.");


        }
    }
    }

