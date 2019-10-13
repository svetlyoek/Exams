using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No Money")
            {
                if (command.Contains("OutOfStock"))
                {
                    string[] tokens = command.Split().ToArray();
                    string gift = tokens[1];
                    for (int i = 0; i < text.Count; i++)
                    {
                        if (text[i] == gift)
                        {
                            text[i] = "None";
                        }
                    }
                }
                else if (command.Contains("Required"))
                {
                    string[] tokens = command.Split().ToArray();
                    string gift = tokens[1];
                    int index = int.Parse(tokens[2]);
                    if (index >= 0 && index <= text.Count - 1)
                    {
                        text[index] = gift;
                    }
                }
                else if (command.Contains("JustInCase"))
                {

                    string[] tokens = command.Split().ToArray();
                    string gift = tokens[1];


                    text[text.Count - 1] = gift;

                }
            }

            for (int j = 0; j < text.Count; j++)
            {
                if (text[j] != "None")
                {
                    Console.Write($"{text[j]} ");

                }
            }
        }
    }
}
