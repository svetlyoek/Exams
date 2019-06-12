using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {
            double effort = 0.0;
            int totalFire = 0;
            string[] text = Console.ReadLine().Split("#").ToArray();
            int water = int.Parse(Console.ReadLine());
            List<int> putOuts = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                string[] fires = text[i].Split(" = ").ToArray();
                string fireLevel = fires[0];
                int neededWater = int.Parse(fires[1]);
                if (fireLevel == "High" && neededWater >= 81 && neededWater <= 125)
                {
                    if (water >= neededWater)
                    {
                        water -= neededWater;
                        effort += neededWater * 0.25;
                        totalFire += neededWater;
                        putOuts.Add(neededWater);
                    }

                }
                else if (fireLevel == "Medium" && neededWater >= 51 && neededWater <= 80)
                {
                    if (water >= neededWater)
                    {
                        water -= neededWater;
                        effort += neededWater * 0.25;
                        totalFire += neededWater;
                        putOuts.Add(neededWater);
                    }
                }
                else if (fireLevel == "Low" && neededWater >= 1 && neededWater <= 50)
                {
                    if (water >= neededWater)
                    {
                        water -= neededWater;
                        effort += neededWater * 0.25;
                        totalFire += neededWater;
                        putOuts.Add(neededWater);
                    }
                }
            }



            Console.WriteLine($"Cells:");
            foreach (var item in putOuts)
            {
                Console.WriteLine($" - {item}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");



        }

    }
    }

