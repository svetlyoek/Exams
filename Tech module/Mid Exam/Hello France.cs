using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split("|").ToList();
            double budget = double.Parse(Console.ReadLine());
            List<double> newprices = new List<double>();
            double profit = 0.0;
            for (int i = 0; i < text.Count; i++)
            {
                List<string> newtext = text[i].Split("->").ToList();
                string type = newtext[0];
                double price = double.Parse(newtext[1]);
                if (type == "Clothes" && price <= 50.00)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        double aditionalPrice = price * 0.40;
                        price += aditionalPrice;
                        profit += aditionalPrice;

                        newprices.Add(price);


                    }
                }
                else if (type == "Shoes" && price <= 35.00)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        double aditionalPrice = price * 0.40;
                        price += aditionalPrice;
                        profit += aditionalPrice;


                        newprices.Add(price);


                    }
                }
                else if (type == "Accessories" && price <= 20.50)
                {
                    if (budget >= price)
                    {
                        budget -= price;
                        double aditionalPrice = price * 0.40;
                        price += aditionalPrice;
                        profit += aditionalPrice;


                        newprices.Add(price);


                    }
                }
            }
            foreach (var item in newprices)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");
            if (budget + newprices.Sum() >= 150)
            {
                Console.WriteLine($"Hello, France!");
            }
            else
            {
                Console.WriteLine($"Time to go.");
            }
        }
    }
}
