using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] twoSubstrings = Console.ReadLine().Split(" ").ToArray();
            string firstSubstring = twoSubstrings[0];
            string secondSubstring = twoSubstrings[1];

            StringBuilder newText = new StringBuilder();

            string pattern = @"^[d-z\{\}\,\|\#]+$";

            Match matches = Regex.Match(text, pattern);

            if (matches.Success)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    char symbol = (char)((int)(text[i] - 3));
                    newText.Append(symbol);
                }
                newText = newText.Replace(firstSubstring, secondSubstring);

                Console.WriteLine(string.Join(" ", newText));
            }
            else
            {
                Console.WriteLine($"This is not the book you are looking for.");
            }
        }
        }
    }

            
       
    

        

            


        
    


