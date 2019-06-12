using System;

namespace Trekking_equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int carabiners = int.Parse(Console.ReadLine());
            int ropes = int.Parse(Console.ReadLine());
            int iceAxes = int.Parse(Console.ReadLine());
            double carabinerPrice = carabiners * 36.00;
            double ropesPrice = ropes * 3.60;
            double iceAxesPrice = iceAxes * 19.80;
            double allPrice = (ropesPrice + iceAxesPrice + carabinerPrice) * people;
            double finalPrice = allPrice + (allPrice * 0.20);
            Console.WriteLine("{0:f2}", finalPrice);
        }
    }
}
