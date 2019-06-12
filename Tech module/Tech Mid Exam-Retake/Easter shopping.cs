using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split().ToList();
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                if (command[0] == "Include")
                {
                    string shop = command[1];
                    shops.Add(shop);
                }
                else if (command[0] == "Visit")
                {
                    string itemToRemove = command[1];
                    int shopsNumber = int.Parse(command[2]);
                    if (shops.Count > shopsNumber)
                    {
                        if (itemToRemove == "first")
                        {

                            shops.RemoveRange(0, shopsNumber);
                        }
                        else if (itemToRemove == "last")
                        {
                            int index = shops.Count - shopsNumber;


                            shops.RemoveRange(index, shopsNumber);


                        }
                    }
                }
                else if (command[0] == "Prefer")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    if (firstIndex >= 0 && firstIndex <= shops.Count - 1)
                    {
                        if (secondIndex >= 0 && secondIndex <= shops.Count - 1)
                        {

                            string temp = shops[firstIndex];
                            shops[firstIndex] = shops[secondIndex];
                            shops[secondIndex] = temp;


                        }
                    }
                }
                else if (command[0] == "Place")
                {
                    string shop = command[1];
                    int index = int.Parse(command[2]) + 1;

                    if (index >= 0 && index <= shops.Count - 1)
                    {
                        shops.Insert(index, shop);
                    }
                }
                }
            
            Console.WriteLine($"Shops left:");
            Console.Write(string.Join(" ", shops));

        







    }
    }
}
