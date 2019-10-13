using System;

namespace Repository
{
    public class StartUp
    {
        public static void Main()
        {
            Repository repository = new Repository();

            Person firstPerson = new Person("George", 10, new DateTime(2009, 05, 04));
            Person secondPerson = new Person("Peter", 5, new DateTime(2014, 05, 24));

            repository.Add(firstPerson);
            repository.Add(secondPerson);

            Person foundPerson = repository.Get(0);

            Console.WriteLine(
                $"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");

            Person person = new Person("Jon", 12, new DateTime(2007, 2, 3));

            repository.Update(2, person);
            repository.Update(0, person);

            //Console.WriteLine(repository.Update(2, person));
            //Console.WriteLine(repository.Update(0, person));

            foundPerson = repository.Get(0);

            Console.WriteLine(
                $"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");

            Console.WriteLine(repository.Count);

            repository.Delete(5);
            repository.Delete(0);

            Console.WriteLine(repository.Count);
        }
    }
}
        
    

