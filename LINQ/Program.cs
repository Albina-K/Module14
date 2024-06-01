using System.Linq;
using System;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };
            //LINQ выражение
            var selectedPeople = from p in people // промежуточная переменная p 
                                 where p.StartsWith("A") // фильтрация по условию
                                 orderby p // сортировка по возрастанию (дефолтная)
                                 select p; // выбираем объект и сохраняем в выборку

            foreach (string s in selectedPeople)
            {
                Console.WriteLine(s);
            }

            /*

            from variable in collection // каждую переменную в коллекции
            where condition // для которой выполняется условие
            select variable; // добавить в выборку

            */
        }
        //метод расширения
        static void Main1(string[] args)
        {
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            var selectedPeople = people.Where(p => p.StartsWith("А")).OrderBy(p => p);

            foreach (string s in selectedPeople)
                Console.WriteLine(s);
        }

        static void Main2(string[] args)
        {
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            var selectedPeople = (from p in people
                                  where p.StartsWith("A")
                                  orderby p
                                  select p).Count();
            Console.WriteLine($"В выборке {selectedPeople} чел");
        }

        static void Main3(string[] args)
        {
            var objects = new List<object>()
            {
                1,
               "Сергей ",
               "Андрей ",
               300,
            };

            var names = from a in objects
                        where a is string // проверка на совместимость с типом
                        orderby a // сортировка по имени
                        select a; // выборка

            foreach (var name in names)
                Console.WriteLine(name);

            foreach (var namess in objects.Where(a => a is string).OrderBy(a=>a))
                Console.WriteLine(namess);
        }
    }
}


