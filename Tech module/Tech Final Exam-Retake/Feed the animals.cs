using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Dictionary<string, int> animalsAndFood = new Dictionary<string, int>();
            Dictionary<string, int> areaAndCount = new Dictionary<string, int>();
            while ((text = Console.ReadLine()) != "Last Info")
            {
                string[] tokens = text.Split(":").ToArray();
                string command = tokens[0];
                if (command == "Add")
                {
                   
                    string name = tokens[1];
                    int dailyFood = int.Parse(tokens[2]);
                    string area = tokens[3];
                    if (!animalsAndFood.ContainsKey(name))
                    {
                       
                        animalsAndFood.Add(name, dailyFood);
                        if(!areaAndCount.ContainsKey(area))
                        {


                            areaAndCount.Add(area, 1);
                        }
                        else
                        {
                            areaAndCount[area]++;
                        }
                    }
                    else
                    {
                        animalsAndFood[name] += dailyFood;
                      
                    }
                }
                else if(command=="Feed")
                {
                    string name = tokens[1];
                    int food = int.Parse(tokens[2]);
                    string area = tokens[3];
                    if(animalsAndFood.ContainsKey(name))
                    {
                        animalsAndFood[name] -= food;
                        if(animalsAndFood[name]<=0)
                        {
                            animalsAndFood.Remove(name);
                            if(areaAndCount.ContainsKey(area))
                            {
                                areaAndCount[area]--;
                            }
                           
                            Console.WriteLine($"{name} was successfully fed");
                        }
                    }
                }
            }

            Console.WriteLine($"Animals:");
            foreach(var kvp in animalsAndFood.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}g");
            }
            Console.WriteLine($"Areas with hungry animals:");
            foreach(var kvp in areaAndCount.OrderByDescending(x=>x.Value))
            {
                if(kvp.Value>0)
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                }
                   
                
            }
        }
    }
}
