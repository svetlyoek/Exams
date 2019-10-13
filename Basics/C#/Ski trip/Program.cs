using System;

namespace Ski_trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string grade = Console.ReadLine();
            double price = 0;
            double finalPrice = 0;
            if (type == "room for one preson")
            {
                if (days < 10)
                {
                    price += 18.00;
                }
                else if (type == "apartment")
                {
                    price += 25.00 - (25.00 * 0.3);
                }
                else if (type == "president apartment")
                {
                    price += 35.00 - (35.00 * 0.1);
                }
            }
            else if (days >= 10 && days <= 15)
            {
                if (type == "room for one person")
                {
                    price += 18.00;
                }
                else if (type == "apartment")
                {
                    price += 25.00 - (25.00 * 0.35);
                }
                else if (type == "president apartment")
                {
                    price += 35.00 - (35.00 * 0.15);
                }
            }
            else if (days > 15)
            {
                if (type == "room for one person")
                {
                    price += 18.00;
                }
                else if (type == "apartment")
                {
                    price += 25.00 - (25.00 * 0.5);
                }
                else if (type == "president apartment")
                {
                    price += 35.00 - (35.00 * 0.2);
                }
            }
            double nights = days - 1;
            double allPrice = nights * price;
            if (grade == "positive")
            {
                finalPrice = allPrice + (allPrice * 0.25);
            }
            else if (grade == "negative")
            {
                finalPrice = allPrice - (allPrice * 0.1);
            }


            Console.WriteLine("{0:f2}", finalPrice);
        }
    }
}
