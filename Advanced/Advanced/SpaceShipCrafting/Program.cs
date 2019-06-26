using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsElements = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] itemsElements = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsElements);

            Stack<int> items = new Stack<int>(itemsElements);

            Dictionary<string, int> advancedItems = new Dictionary<string, int>();
            advancedItems.Add("Glass", 0);
            advancedItems.Add("Aluminium", 0);
            advancedItems.Add("Lithium", 0);
            advancedItems.Add("Carbon fiber", 0);

            int glass = 25;
            int aluminium = 50;
            int lithium = 75;
            int carbon = 100;

            while (items.Count > 0 && liquids.Count > 0)
            {

                int sum = 0;
                var currentLiquid = liquids.Peek();
                var currentItem = items.Peek();

                sum = currentItem + currentLiquid;

                if (sum == glass)
                {

                    advancedItems["Glass"]++;

                    liquids.Dequeue();
                    items.Pop();
                }


                else if (sum == aluminium)
                {

                    advancedItems["Aluminium"]++;

                    liquids.Dequeue();
                    items.Pop();
                }


                else if (sum == lithium)
                {

                    advancedItems["Lithium"]++;
                    liquids.Dequeue();
                    items.Pop();
                }

                else if (sum == carbon)
                {

                    advancedItems["Carbon fiber"]++;
                    liquids.Dequeue();
                    items.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    items.Pop();
                    items.Push(currentItem + 3);

                }
                if (items.Count == 0 || liquids.Count == 0)
                {
                    break;
                }
            }

            if (advancedItems["Glass"] > 0 && advancedItems["Aluminium"] > 0 && advancedItems["Lithium"] > 0 && advancedItems["Carbon fiber"] > 0)
            {
                Console.WriteLine($"Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }

            if (items.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine($"Physical items left: none");
            }

            foreach (var item in advancedItems.OrderBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");

            }
        }
    }
}