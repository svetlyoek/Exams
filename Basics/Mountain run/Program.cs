using System;

namespace Mountain_run
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double metersDistance = double.Parse(Console.ReadLine());
            double oneMeterInSeconds = double.Parse(Console.ReadLine());
            double seconds = oneMeterInSeconds * metersDistance;
            double realSeconds = Math.Floor(metersDistance / 50);
            realSeconds *= 30;
            double finalSeconds = realSeconds + seconds;
            if (finalSeconds < recordSeconds)
            {
                Console.WriteLine("Yes! The new record is {0:f2} seconds.", finalSeconds);
            }
            else if (finalSeconds >= recordSeconds)
            {
                double neededSeconds = finalSeconds - recordSeconds;
                Console.WriteLine("No! He was {0:f2} seconds slower.", neededSeconds);
            }
        }
    }
}
