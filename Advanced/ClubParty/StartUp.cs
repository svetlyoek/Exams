using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());

            string[] people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> reservations = new Stack<string>(people);
            List<int> guests = new List<int>();
            Queue<string> halls = new Queue<string>();
            int currentCapacity = 0;

            while (reservations.Any())
            {
                bool isNumber = int.TryParse(reservations.Peek(), out int result);
                var currentElement = reservations.Pop();

                if (isNumber)
                {

                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (currentCapacity + result > hallCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", guests)}");
                        guests.Clear();
                        currentCapacity = 0;

                    }

                    if (halls.Count > 0)
                    {
                        currentCapacity += result;
                        guests.Add(result);
                    }

                }
                else
                {
                    halls.Enqueue(currentElement);
                }

            }

        }
    }
}
