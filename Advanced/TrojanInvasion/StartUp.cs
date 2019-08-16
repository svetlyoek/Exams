using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int wavesNumber = int.Parse(Console.ReadLine());

            int[] spartansPlates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> plates = new Queue<int>(spartansPlates);
            Stack<int> warriors = new Stack<int>();

            for (int i = 1; i <= wavesNumber; i++)
            {
                warriors = new Stack<int>(Console.ReadLine()
                         .Split()
                         .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }


                while (warriors.Count > 0 && plates.Count > 0)
                {
                    var wariorValue = warriors.Pop();
                    var plateValue = plates.Dequeue();

                    if (wariorValue > plateValue)
                    {
                        wariorValue -= plateValue;
                        warriors.Push(wariorValue);

                    }
                    else if (plateValue > wariorValue)
                    {
                        plateValue -= wariorValue;
                        plates = ReversePlates(plateValue, plates);

                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (warriors.Count > 0)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
            }

            if (warriors.Count > 0)
            {
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");

            }
        }

        private static Queue<int> ReversePlates(int plateValue, Queue<int> plates)
        {
            plates = new Queue<int>(plates.Reverse());
            plates.Enqueue(plateValue);
            plates = new Queue<int>(plates.Reverse());
            return plates;
        }
    }
}
