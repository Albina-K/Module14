using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Let
{//объявление промежуточных переменных по ключевому слову let.
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var fullNameStudents = from s in students
                                       // временная переменная для генерации полного имени
                                   let fullName = s.Name + "Ivanov"
                                   // проекция в новую сущность с использованием новой переменной
                                   select new
                                   {
                                       Name = fullName,
                                       Age = s.Age
                                   };
            foreach ( var stud in fullNameStudents )
                Console.WriteLine(stud.Name + ", " + stud.Age);
        }

        static void Main2(string[] args)
        {
            // Наш список студентов
            List<Student> students = new List<Student>
            {
                new Student { Name = "Андрей", Age = 23, Languages = new List<string> { "английский", "немецкий" } },
                new Student { Name = "Сергей", Age = 27, Languages = new List<string> { "английский", "французский" } },
                new Student { Name = "Дмитрий", Age = 29, Languages = new List<string> { "английский", "испанский" } },
                new Student { Name = "Василий", Age = 24, Languages = new List<string> { "испанский", "немецкий" } }
            };
            var stud = from s in students
                       where s.Age < 27// берем тех, кто младше 27
                       let year = DateTime.Now.Year - s.Age// Вычисляем год рождения
                       select new Applicacation()// создаем анкеты
                       {
                           Name = s.Name,
                           YearOfBirth = year,
                       };
            foreach (var studApplication in stud)
                Console.WriteLine(studApplication.Name + ", " + studApplication.YearOfBirth);
        }


        static void Main3(string[] args)
        {
            // Список студентов
            var student = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
            };
            // Список курсов
            var coarses = new List<Coarse>
            {
                new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
                new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };
            // добавим студентов в курсы
            var studentsWithCoarses = from stud in student
                                      from coarse in coarses
                                      select new { Name = stud.Name, CoarseName = stud.Name };//анонимная сущность
            // выведем результат
            foreach (var stud in  studentsWithCoarses)
                Console.WriteLine($"Студент {stud.Name} добавлен курс {stud.CoarseName}");

            var studprog = from stud in student
                           where stud.Age < 29// берем всех студентов младше 29
                           where stud.Languages.Contains ("английский")// ищем тех, у кого в списке языков есть английский
                           let year = DateTime.Now.Year - stud.Age// Вычисляем год рождения
                           from coarse in coarses
                           where coarse.Name.Contains ("C#")// теперь выбираем только курс по C#
                           select new// выборка в новую сущность
                           {
                               Name = stud.Name,
                               YearOfBirth = year,
                               CoarseName = coarse.Name
                           };
        }
    }

    public class  Applicacation
    {
        public string Name { get; set; }
        public string YearOfBirth { get; set; }
    }
}
