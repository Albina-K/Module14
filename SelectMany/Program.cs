using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectMany
{//SelectMany — метод расширения, предоставляющий другой способ сделать сложную фильтрацию. 
    class Program
    {
        static void Main(string[] args)
        {
            // Подготовим данные
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };
            // Составим запрос ()
            var selectedStudents = students.SelectMany(
                // коллекция, которую нужно преобразовать
                s => s.Languages,
                // функция преобразования, применяющаяся к каждому элементу коллекции
                (s, l) => new { Student = s, Lang = l })
                // дополнительные условия            
                .Where(s => s.Lang == "английский" && s.Student.Age < 28)
                // указатель на объект выборки
                .Select(s => s.Student);

            // Выведем результат
            foreach(Student student in selectedStudents)
            {
                Console.WriteLine($"{student.Name} - {student.Age}");
            }
        }

        //Сделайте выборку тех, которые производят мобильную технику.
        static void Main2(string[] args)
        {
            var companies = new Dictionary<string, string[]>();

            companies.Add("Apple", new[] { "Mobile", "Desktop" });
            companies.Add("Samsung", new[] { "Mobile" });
            companies.Add("IBM", new[] { "Desktop" });

            var mobileCompanies = companies
                // смотрим те из выборки, значения в которых содержат искомое
                .Where(c => c.Value.Contains("Mobile"));

            foreach (var company in mobileCompanies)
                Console.WriteLine(company.Key);
        }
        //Сделайте выборку всех чисел в новую коллекцию, расположив их в ней по возрастанию.
        static void Main3(string[] args)
        {
            var numList = new List<int[]>()
            {
                new[] {2, 3, 7, 1},
                new[] {45, 17, 88, 0},
                new[] {23, 32, 44, -6},
            };

            var collection = numList
                .SelectMany(c => c) // выбираем элементы
                .OrderBy(c => c); // сортируем
            // выводим
            foreach (var ord in collection)
                Console.WriteLine(ord);
        }
    }
}
