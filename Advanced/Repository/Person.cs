
namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;
        private DateTime birthdate;

        public Person()
        {

        }

        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public DateTime Birthdate
        {
            get => this.birthdate;
            set => this.birthdate = value;
        }
    }
}