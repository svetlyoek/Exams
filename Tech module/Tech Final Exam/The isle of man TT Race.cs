using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
           while(true)
            {
                string text = Console.ReadLine();
                string pattern = @"^([#$%*&])(?<name>[A-Za-z]+)\1=(?<length>[0-9]+)!!(?<code>(.)+)$";
                Match match = Regex.Match(text, pattern);
                StringBuilder newCode = new StringBuilder();
                if(match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;
                    if(code.Length==length)
                    {
                        for(int i=0;i<code.Length;i++)
                        {
                            newCode.Append((char)(code[i] + length));
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {newCode}");
                        return;
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
