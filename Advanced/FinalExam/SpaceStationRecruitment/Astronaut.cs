﻿namespace SpaceStationRecruitment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Astronaut
    {
        public Astronaut(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Astronaut: {this.Name}, {this.Age} ({this.Country})");
            return result.ToString().TrimEnd();
        }

    }
}
