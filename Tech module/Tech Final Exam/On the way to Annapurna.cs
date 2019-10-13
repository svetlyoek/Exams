using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp71
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Dictionary<string, List<string>> storesAndItems = new Dictionary<string, List<string>>();
            while ((text = Console.ReadLine()) != "END")
            {
                string[] tokens = text.Split("->").ToArray();
                string command = tokens[0];
                if (command == "Add")
                {
                    string store = tokens[1];
                    if (!tokens[2].Contains(","))
                    {
                        string item = tokens[2];
                        if (!storesAndItems.ContainsKey(store))
                        {
                            storesAndItems.Add(store, new List<string>());
                            storesAndItems[store].Add(item);
                        }
                        else
                        {
                            storesAndItems[store].Add(item);
                        }
                    }
                    else if (tokens[2].Contains(','))
                    {
                        List<string> items = tokens[2].Split(",").ToList();
                        if (!storesAndItems.ContainsKey(store))
                        {

                            storesAndItems.Add(store, new List<string>());
                            foreach (var item in items)
                            {

                                storesAndItems[store].Add(item);
                            }

                        }


                        else
                        {
                            foreach (var item in items)
                            {
                                storesAndItems[store].Add(item);
                            }

                        }

                    }

                }

                else if (command == "Remove")
                {
                    string store = tokens[1];
                    if (storesAndItems.ContainsKey(store))
                    {
                        storesAndItems.Remove(store);
                    }


                }
            }
            Console.WriteLine($"Stores list:");
            foreach (var kvp in storesAndItems.OrderByDescending(x => x.Value.Count).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value)
                {

                    Console.WriteLine($"<<{item}>>");
                }
            }

        }
    }
}
        
    

