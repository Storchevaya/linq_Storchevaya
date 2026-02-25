using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_1_Storchevaya_Melekhova
{
    internal class Person
    {
        public string LastName { get; set; } //Фамилия
        public string FirstName { get; set; } //Имя
        public string MiddleName { get; set; } //Отчество
        public int Age { get; set; } //Возраст
        public int Weight { get; set; } //Вес
        public Person(string lastName, string firstName, string middleName, int age, int weight)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Age = age;
            Weight = weight;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{LastName} {FirstName} {MiddleName}, возраст: {Age}, вес: {Weight} кг");
        }
    }
}

