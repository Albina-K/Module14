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
        //Рассмотрим пример, где надо выбрать четные числа больше 10:
        static void Main4(string[] args)
        {
            int[] numbers =
            {
                1,
                2,
                3,
                4,
                10,
                34,
                55,
                66,
                77,
                88
            };

            var evenNums = from i in numbers
                           where i % 2 == 0 && i > 10
                           select i;

            foreach (int i in evenNums)
                Console.WriteLine(i);
        }

        static void Main5(string[] args)
        {
            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var bigCities = from russianCity in russianCities
                            where russianCity.Population < 1000000
                            orderby russianCity.Population descending
                            select russianCity;

            foreach (var bigCity in bigCities)
                Console.WriteLine(bigCity.Name + " - " + bigCity.Population);

            //То же самое с помощью методов расширения выглядит ещё проще: 
            var bigCities2 = russianCities.Where(c => c.Population > 1000000)
                .OrderByDescending(c => c.Population);

            var bigCities3 = russianCities.Where(c => c.Name.Length <= 10)
                .OrderBy (c => c.Name.Length);
        }

        // Создадим модель класс для города
        public class City    
        {
            public City(string name, long population) 
            {
                Name = name;
                Population = population;
            }

            public string Name { get; set; }
            public long Population { get; set; }
        }

        static void Main6(string[] args)
        {
            // Словарь для хранения стран с городами
            var Countries = new Dictionary<string, List<City>>();

            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));
            Countries.Add("Россия", russianCities);

            // Добавим Беларусь
            var belarusCities = new List<City>();
            belarusCities.Add(new City("Минск", 1200000));
            belarusCities.Add(new City("Витебск", 362466));
            belarusCities.Add(new City("Гродно", 368710));
            Countries.Add("Беларусь", belarusCities);

            // Добавим США
            var americanCities = new List<City>();
            americanCities.Add(new City("Нью-Йорк", 8399000));
            americanCities.Add(new City("Вашингтон", 705749));
            americanCities.Add(new City("Альбукерке", 560218));
            Countries.Add("США", americanCities);

            // сделать выборку городов - миллионников по всем странам.
            var cities = from country in Countries // пройдемся по странам
                         from city in country.Value // пройдемся по городам
                         where city.Population > 1000000 // выберем города-миллионники
                         orderby city.Population descending // отсортируем по населению
                         select city;

            foreach (var city in cities)
                Console.WriteLine(city.Name + " - " + city.Population);
        }
        //Соедините все слова в одну последовательность(каждое слово — отдельный элемент последовательности).
        static void main7(string[] args)
        {
            string[] text =
            {
                "Раз два три",
                "четыре пять шесть",
                "семь восемь девять"
            };

            var words = from str in text // пробегаемся по элементам массива
                        from word in str.Split(' ') // дробим каждый элемент по пробелам, сохраняя в новую последовательность
                        select word; // собираем все куски в результирующую выборку

            // выводим результат
            foreach (var word in words)
                Console.WriteLine(word);
        }
    }
}


