using System;

namespace Energy_booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            double setCount = double.Parse(Console.ReadLine());
            double sum = 0;
            double price = 0;
            if (fruit == "Watermelon")
            {
                if (size == "small")
                {
                    sum += 56.00 * 2;
                }
                else if (size == "big")
                {
                    sum += 28.70 * 5;
                }
            }
            else if (fruit == "Mango")
            {
                if (size == "small")
                {
                    sum += 36.66 * 2;
                }
                else if (size == "big")
                {
                    sum += 19.60 * 5;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (size == "small")
                {
                    sum += 42.10 * 2;
                }
                else if (size == "big")
                {
                    sum += 24.80 * 5;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (size == "small")
                {
                    sum += 20.00 * 2;
                }
                else if (size == "big")
                {
                    sum += 15.20 * 5;
                }
            }
            price = sum * setCount;
            if (price >= 400 && price <= 1000)
            {
                price = price - (price * 0.15);
            }
            else if (price > 1000)
            {
                price = price - (price * 0.5);
            }

            Console.WriteLine("{0:f2} lv.", price);
        }
    }
}
