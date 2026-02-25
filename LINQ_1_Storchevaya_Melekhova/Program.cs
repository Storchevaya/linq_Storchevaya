using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_1_Storchevaya_Melekhova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "1.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                List<Person> people = new List<Person>();
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    string[] data = line.Split(' ');
                    Person person = new Person(
                        data[0], //Фамилия
                        data[1], //Имя
                        data[2], //Отчество
                        int.Parse(data[3]), //Возраст
                        int.Parse(data[4])  //Вес
                    );
                    people.Add(person);
                }
                var youngPeople = from p in people
                                  where p.Age < 40
                                  select p;

                Console.WriteLine("Люди младше 40 лет:");
                foreach (Person p in youngPeople)
                {
                    p.PrintInfo();
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не найден!");
                Console.WriteLine("Создайте файл 1.txt с данными:");
                Console.WriteLine("Иванов Сергей Николаевич 21 64");
                Console.WriteLine("Петров Игорь Юрьевич 45 88");
                Console.WriteLine("Семёнов Михаил Алексеевич 20 70");
                Console.WriteLine("Пиманов Александр Дмитриевич 53 101");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
