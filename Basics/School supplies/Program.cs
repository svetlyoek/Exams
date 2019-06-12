using System;

namespace School_supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            double pensPacketCount = double.Parse(Console.ReadLine());
            double markersPacketCount = double.Parse(Console.ReadLine());
            double liters = double.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine());
            double pensPrice = pensPacketCount * 5.80;
            double markerPrice = markersPacketCount * 7.20;
            double washingPrice = liters * 1.20;
            double allPrice = pensPrice + markerPrice + washingPrice;
            double realPrice = allPrice - ((allPrice * procent) / 100);
            Console.WriteLine("{0:f3}", realPrice);
        }
    }
}
