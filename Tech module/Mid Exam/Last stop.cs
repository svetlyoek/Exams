using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                List<string> tokens = command.Split().ToList();
                if (tokens[0] == "Change")
                {
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);
                    if (numbers.Contains(firstNumber))
                    {

                        int index = numbers.IndexOf(firstNumber);
                        numbers[index] = secondNumber;



                    }
                }
                else if (tokens[0] == "Hide")
                {
                    int number = int.Parse(tokens[1]);
                    if (numbers.Contains(number))
                    {
                        numbers.Remove(number);
                    }
                }
                else if (tokens[0] == "Switch")
                {
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);
                    if (numbers.Contains(firstNumber) && numbers.Contains(secondNumber))
                    {
                        int firstIndex = numbers.IndexOf(firstNumber);
                        int secondIndex = numbers.IndexOf(secondNumber);
                        int temp = numbers[firstIndex];
                        numbers[firstIndex] = numbers[secondIndex];
                        numbers[secondIndex] = temp;
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    int number = int.Parse(tokens[2]);
                    if (index >= 0 && index <= numbers.Count - 1)
                    {

                        numbers.Insert(index + 1, number);
                    }
                }
                else if (tokens[0] == "Reverse")
                {
                    numbers.Reverse();
                }
            }

            Console.Write(string.Join(" ", numbers));
        }
        }
    }


