using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace OrderByOrderByDescending
{
    class Program
    {
        static void Main(string[] args)
        {
            // Список студентов
            var students = new List<Student>
            {
                new Student {Name="Алёна", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Яков", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };
            // Сортировка по возрасту
            var sortedStuds = from s in students orderby s.Age select s;

            // Сортировка по убыванию возраста
            var sortedStuds2 = from s in students orderby s.Age descending select s;

            //То же самое через методы расширения: 
            var sortedStudentsAsc = students.OrderBy(s => s.Age);

            var sortedStudentsDesc = students.OrderByDescending(s => s.Age);

            //Множественная сортировка
            // Сортировка сначала по имени, а затем - по возрасту
            var sortedStuds3 = from s in students orderby s.Name, s.Age select s;


            // Через методы расширения по возрастанию:
            // Сортировка по имени и возрасту (возрастание)
            var sortedStuds4 = students
                 .OrderBy(s => s.Name)
                 .ThenBy(s => s.Age);
            // Сортировка по имени и возрасту (убывание)
            var sortedStuds5 = students
                .OrderByDescending(s => s.Name)
                .ThenByDescending(s => s.Age);

            foreach (var stud in sortedStuds)
                Console.WriteLine(stud.Name + ", " + stud.Age);
        }
    }
}
