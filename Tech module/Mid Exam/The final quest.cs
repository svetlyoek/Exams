using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split().ToList();
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                List<string> tokens = command.Split().ToList();
                if (tokens[0] == "Delete")
                {
                    int index = int.Parse(tokens[1]) + 1;

                    if (index <= text.Count - 1 && index >= 0)
                    {
                        text.RemoveAt(index);
                    }
                }
                else if (tokens[0] == "Swap")
                {
                    string firstWord = tokens[1];
                    string secondWord = tokens[2];
                    if (text.Contains(firstWord) && text.Contains(secondWord))
                    {
                        int firstIndex = text.IndexOf(firstWord);
                        int secondIndex = text.IndexOf(secondWord);
                        string temp = text[firstIndex];
                        text[firstIndex] = text[secondIndex];
                        text[secondIndex] = temp;

                    }
                }
                else if (tokens[0] == "Put")
                {
                    string word = tokens[1];
                    int index = int.Parse(tokens[2]) - 1;
                    if (index >= 0 && index <= text.Count)
                    {
                        text.Insert(index, word);
                    }

                }
                else if (tokens[0] == "Sort")
                {
                    text.Sort();
                    text.Reverse();

                }
                else if (tokens[0] == "Replace")
                {
                    string firstWord = tokens[1];
                    string secondWord = tokens[2];
                    if (text.Contains(secondWord))
                    {
                        int index = text.IndexOf(firstWord);
                        int secondIndex = text.IndexOf(secondWord);
                        text.RemoveAt(secondIndex);
                        text.Insert(secondIndex, firstWord);



                    }
                }
            }
            Console.WriteLine(string.Join(" ", text));



        }

    }
    }

