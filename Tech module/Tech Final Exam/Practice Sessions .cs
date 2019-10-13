using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp66
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Dictionary<string, List<string>> roadsAndRacers = new Dictionary<string, List<string>>();
            while((text=Console.ReadLine())!="END")
            {
                string[] tokens = text.Split("->").ToArray();
                string command = tokens[0];
                if(command=="Add")
                {
                    string road = tokens[1];
                    string racer = tokens[2];
                    if(!roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers.Add(road, new List<string>());
                        roadsAndRacers[road].Add(racer);
                    }
                    else
                    {
                        roadsAndRacers[road].Add(racer);
                    }
                }
                else if(command=="Move")
                {
                    string currentRoad = tokens[1];
                    string racer = tokens[2];
                    string nextRoad = tokens[3];
                    if(roadsAndRacers[currentRoad].Contains(racer))
                    {
                        roadsAndRacers[currentRoad].Remove(racer);
                        roadsAndRacers[nextRoad].Add(racer);
                    }
                }
                else if(command=="Close")
                {
                    string road = tokens[1];
                    if(roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers.Remove(road);
                    }
                }
            }
            Console.WriteLine($"Practice sessions:");
            foreach(var kvp in roadsAndRacers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach(var item in kvp.Value)
                {
                    Console.WriteLine($"++{item}");
                }
            }
           
            }

        }
    }

          



            

        
    




