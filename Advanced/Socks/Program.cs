using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leftSocks = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Stack<int> lefts = new Stack<int>(leftSocks);

            int[] rightSocks = Console.ReadLine()
           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();

            Queue<int> rights = new Queue<int>(rightSocks);

            Queue<int> pairSocks = new Queue<int>();

            CreatePairs(rights, lefts, pairSocks);

            Console.WriteLine(GetBiggestSet(pairSocks));

            Console.WriteLine(string.Join(" ", pairSocks));


        }

        private static int GetBiggestSet(Queue<int> pairSocks)
        {
            int biggest = int.MinValue;

            foreach (var item in pairSocks)
            {
                if (item > biggest)
                {
                    biggest = item;
                }

            }

            return biggest;
        }

        private static void CreatePairs(Queue<int> rights, Stack<int> lefts, Queue<int> pairSocks)
        {
            int pair = 0;
            int current = 0;

            while (rights.Any() || lefts.Any())
            {
                if (rights.Count == 0 || lefts.Count == 0)
                {
                    return;
                }

                if (rights.Peek() > lefts.Peek())
                {

                    lefts.Pop();

                }


                else if (rights.Peek() == lefts.Peek())
                {

                    rights.Dequeue();
                    current = lefts.Peek();
                    lefts.Pop();
                    lefts.Push(current + 1);

                }


                else if (lefts.Peek() > rights.Peek())
                {

                    pair = lefts.Peek() + rights.Peek();

                    pairSocks.Enqueue(pair);

                    lefts.Pop();

                    rights.Dequeue();

                }

            }

        }
    }
}

