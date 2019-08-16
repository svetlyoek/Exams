using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsValue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] freshnessValue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int mimossa = 150;
            int daiquiri = 250;
            int sunshine = 300;
            int mojito = 400;

            int sum = 0;
            int totalFreshness = 0;

            Dictionary<string, int> productsToCreate = new Dictionary<string, int>();

            productsToCreate.Add("Mimosa", 0);
            productsToCreate.Add("Daiquiri", 0);
            productsToCreate.Add("Sunshine", 0);
            productsToCreate.Add("Mojito", 0);

            Queue<int> ingredients = new Queue<int>(ingredientsValue);

            Stack<int> freshness = new Stack<int>(freshnessValue);

            while (true)
            {
                if (ingredients.Count == 0 || freshness.Count == 0)
                {
                    break;
                }

                var currentIngredient = ingredients.Peek();
                var currentFreshness = freshness.Peek();

                totalFreshness = currentIngredient * currentFreshness;

                if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                if (totalFreshness == mimossa)
                {
                    productsToCreate["Mimosa"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (totalFreshness == daiquiri)
                {
                    productsToCreate["Daiquiri"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (totalFreshness == sunshine)
                {
                    productsToCreate["Sunshine"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else if (totalFreshness == mojito)
                {
                    productsToCreate["Mojito"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }

                else
                {
                    freshness.Pop();
                    int newIngredient = currentIngredient + 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(newIngredient);
                }

                totalFreshness = 0;
            }

            if (productsToCreate["Mimosa"] > 0 && productsToCreate["Daiquiri"] > 0 && productsToCreate["Sunshine"] > 0 && productsToCreate["Mojito"] > 0)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Any())
            {
                foreach (var ingredient in ingredients)
                {
                    sum += ingredient;
                }

                Console.WriteLine($"Ingredients left: {sum}");
            }

            foreach (var cocktail in productsToCreate.OrderBy(x => x.Key))
            {
                if (cocktail.Value > 0)
                {
                    Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
                }
            }

        }
    }
}
