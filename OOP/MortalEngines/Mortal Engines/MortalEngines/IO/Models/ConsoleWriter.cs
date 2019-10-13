namespace MortalEngines.IO.Models
{
    using MortalEngines.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }

    }
}
