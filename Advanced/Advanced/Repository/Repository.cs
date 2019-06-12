
namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Repository
    {
        private const int DefaultId = 0;

        private int id;
        private Dictionary<int, Person> data;

        public Repository()
        {
            this.Id = DefaultId;
            this.Data = new Dictionary<int, Person>();
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        public Dictionary<int, Person> Data
        {
            get => this.data;
            set => this.data = value;
        }

        public int Count => this.Data.Count;

        public void Add(Person person)
        {
            if (!this.Data.ContainsKey(this.Id))
            {
                this.Data.Add(this.Id++, person);
            }
        }

        public Person Get(int id)
        {
            Person person = new Person();

            if (this.Data.ContainsKey(id))
            {
                person = this.Data[id];
            }

            return person;
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.Data.ContainsKey(id))
            {
                return false;
            }

            this.Data[id] = newPerson;

            return true;
        }

        public bool Delete(int id)
        {
            if (!this.Data.ContainsKey(id))
            {
                return false;
            }

            this.Data.Remove(id);

            return true;
        }
    }
}