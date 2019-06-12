using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp68
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            StringBuilder name = new StringBuilder();
            string pattern = @"^(?<name>[A-Za-z\d!?@#$]+)=(?<length>[\d]+)<<(?<code>(.)+)$";
            while ((text = Console.ReadLine()) != "Last note")
            {
                Match match = Regex.Match(text, pattern);
                if (match.Success)
                {
                    string names = match.Groups["name"].Value;
                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;
                    if (code.Length == length)
                    {


                        for (int i = 0; i < names.Length; i++)
                        {
                            if (Char.IsLetterOrDigit(names[i]))
                            {
                              
                                name.Append(names[i]);
                            }
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {code}");
                    }
                    else
                    {
                        Console.WriteLine($"Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine($"Nothing found!");
                }
            }

        }
    }
}



