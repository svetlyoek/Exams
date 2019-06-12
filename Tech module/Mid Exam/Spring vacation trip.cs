using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            double fuelPerKmPrice = double.Parse(Console.ReadLine());
            double foodExpensesPerOneForDay = double.Parse(Console.ReadLine());
            double oneRoomPricePerPerson = double.Parse(Console.ReadLine());

            double distancePrice = 0;
            double currentExpenses = 0;
            double foodExpenses = 0;
            double hotelExpenses = 0;
            foodExpenses = peopleCount * foodExpensesPerOneForDay * days;
            hotelExpenses = oneRoomPricePerPerson * peopleCount * days;
            if (peopleCount > 10)
            {

                hotelExpenses -= (hotelExpenses * 0.25);
            }
            currentExpenses = hotelExpenses + foodExpenses;

            for (int i = 1; i <= days; i++)
            {
                int distancePerDay = int.Parse(Console.ReadLine());

                distancePrice = distancePerDay * fuelPerKmPrice;

                currentExpenses += distancePrice;



                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpenses += currentExpenses * 0.40;

                }
                if (i % 7 == 0)
                {


                    currentExpenses -= currentExpenses / peopleCount;
                }
                if (currentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpenses - budget):f2}$ more.");
                    return;
                }
            }



            Console.WriteLine($"You have reached the destination. You have {(budget - currentExpenses):f2}$ budget left.");
        }
    }
}
