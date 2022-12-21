using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static List<Person> personList = GetList();
        static void Main(string[] args)
        {
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += Sort;

            PersonShow(personList);

            while (true)
            {
                try
                {
                    numberReader.Read();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static List<Person> GetList()
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person() { Surname = "Аистов" });
            persons.Add(new Person() { Surname = "Бобров" });
            persons.Add(new Person() { Surname = "Волков" });
            persons.Add(new Person() { Surname = "Гадюкин" });
            persons.Add(new Person() { Surname = "Долгоносиков" });

            return persons;
        }

        static void Sort(int number)
        {
            switch (number)
            {
                case 1:
                    PersonShow(Sort1(personList));
                    Console.WriteLine("Сортировка от А до Я завершена.");
                    break;
                case 2:
                    PersonShow(Sort2(personList));
                    Console.WriteLine("Сортировка от Я до А завершена.");
                    break;
            }
        }

        static void PersonShow(List<Person> persons)
        {
            Console.WriteLine("Список фамилий: ");

            foreach (var person in persons)
            {
                Console.WriteLine(person.Surname);
            }
        }

        static List<Person> Sort1(List<Person> persons)
        {
            persons.Sort(delegate (Person personFirst, Person personSecond)
            {
                return personFirst.Surname.CompareTo(personSecond.Surname);
            });

            return persons;
        }

        static List<Person> Sort2(List<Person> persons)
        {
            persons.Sort(delegate (Person personFirst, Person personSecond)
            {
                return personSecond.Surname.CompareTo(personFirst.Surname);
            });

            return persons;
        }

    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine("Введите значение 1 для сортировки от А до Я либо 2 для сортировки от Я до А");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
            {
                throw new FormatException();
            }

            NumberEntered(number);
        }

        public virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }

    class Person
    {
        public string Surname { get; set; }
    }
}
