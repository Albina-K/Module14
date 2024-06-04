using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Select
{//Проекция позволяет преобразовать данные текущей выборки в какой-либо другой тип.
    class Program
    {
        static void Main(string[] args)
        {   
            //Допустим, имея всё тот же список студентов, мы хотим получить только их имена:          
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var names = from s in student select s.Name;

            // Выведем результат
            foreach (var name in names)
                Console.WriteLine(name);
        }

        //Допустим, из данных по студентам мы хотим выгрузить для них анкеты,
        //но описывать модель класса анкеты не хотим, ведь больше нигде она нам не понадобится.
        static void Main2(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var studentApplication = from s in students
                                         // создадим анонимный тип для представления анкеты
                                     select new
                                     {
                                         FirstName = s.Name,
                                         YearOfBirth = DateTime.Now.Year - s.Age //DateTime.Now.Year - s.Age этой функцией мы получаем год рожднения. из текущего года вычитаем количесвто лет и получаем год рождения
                                     };
            //Либо, если модель Анкеты у нас есть, так: 
            var studentApplications = from s in students
                                          // спроецируем в новую сущеность анкеты
                                      select new Application()
                                      {
                                          FirstName = s.Name,
                                          YearOfBirth = DateTime.Now.Year - s.Age
                                      };
            //Вывод будет одинаковым как для анонимного класса, так и для обычного: 
            foreach (var application in studentApplications)
                Console.WriteLine($"{application.FirstName}, {application.YearOfBirth}");

            //С методами расширения то же самое, ещё проще:
            // выборка имен в строки
            var names = students.Select(u => u.Name);
            // проекция в анонимный тип
            var applications = students.Select(u => new
            {
                FirstName = u.Name,
                YearOfBirth = DateTime.Now.Year - u.Age
            });
            // проекция в другой тип
            var applications1 = students.Select(u => new Application()
            {
                FirstName = u.Name,
                YearOfBirth = DateTime.Now.Year - u.Age
            });

            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

            var word = words.Select(w => new
            {// Выборка в анонимный тип
                Name = w,
                Lenght = w.Length,// Длину слова сохраняем сразу в свойство нового анонимного типа
            })
                .OrderBy(wor => wor.Lenght);//  сортируем коллекцию по длине
            // выводим
            foreach (var wor in word)
                Console.WriteLine($"{wor.Name} - {wor.Lenght} букв");
        }
    }
}
