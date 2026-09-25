using System;
using System.Xml.Linq;

namespace Haking
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }

    class Univer
    {
        public List<Company> companies = new List<Company>();
        

        public void Start()
        {

        }

        public void SaveXML()
        {
            
            Console.Write("Введите имя файла: ");
            string name = $"E:\\{Console.ReadLine()}";


            if (File.Exists(name))
            {
                name += new Random().Next(20);
            }

            Console.WriteLine();
        }
        public void LoadXML()
        {

        }

        public void MovePerson()
        {

        }
        public void MoveDelete()
        {

        }
    }


    class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Person(string Name)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
        }
    }

    class Company
    {
        public string Name { get; private set; }
        public List<Person> people {  get; private set; }

        public Company(string Name)
        {
            this.Name = Name;
            this.people = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            if (!people.Contains(person))
            {
                people.Add(person);
            }
        }

        public Person FindPerson(string name)
        {
            Person person = people.FirstOrDefault(p => p.Name == name);
            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

        public Person FindPerson(Guid ID)
        {
            Person person = people.FirstOrDefault(p => p.Id == ID);
            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }
        public void AddDelete(Person person)
        {
            if (people.Contains(person))
            {
                people.Remove(person);
            }
        }
    }
}
