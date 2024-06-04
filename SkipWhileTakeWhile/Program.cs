using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace SkipWhileTakeWhile
{//Эти методы работают похожим образом, но с их помощью можно делать выборки по определенным условиям.
    class Program
    {
        static void Main(string[] args)
        {
            // Подготовка данных
            var cars = new List<Car>()
            {
               new Car("Suzuki", "JP"),
                new Car("Toyota", "JP"),
                new Car("Opel", "DE"),
                new Car("Kamaz", "RUS"),
                new Car("Lada", "RUS"),
                new Car("Lada", "RUS"),
                new Car("Honda", "JP"),
            };

            Console.WriteLine("Пропустим японские машины в начале списка");
            var notJapanCars = cars.SkipWhile(car => car.CountryCode == "JP");

            foreach (var notJapanCar in notJapanCars)
                Console.WriteLine(notJapanCar.Manufacturer);

            Console.WriteLine();

            Console.WriteLine("Теперь выберем только японские машины из начала списка");
            var japanCars = cars.TakeWhile(car => car.CountryCode == "JP");

            foreach (var japanCar in japanCars)
                Console.WriteLine(japanCar.Manufacturer);
        }

        static void Main2(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            
            // Читаем введенный с консоли символ
            var input = Console.ReadKey().KeyChar;

            // проверяем, число ли это
            var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

            // если не соответствует критериям - показываем ошибку
            if (!parsed || pageNumber < 1 || pageNumber > 3)
            {
                Console.WriteLine();
                Console.WriteLine("Страницы не существует");
            }

            // если соответствует - запускаем вывод
            else
            {
                // пропускаем нужное количество элементов и берем 2 для показа на странице
                var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                Console.WriteLine();

                // выводим результат
                foreach (var entry in pageContent)
                    Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                Console.WriteLine();
            }
        }
    }

    public class Car
    {
        public string Manufacturer { get; set; }
        public string CountryCode { get; set; }

        public Car(string manufacturer, string countryCode)
        {
            Manufacturer = manufacturer;
            CountryCode = countryCode;
        }
    }

    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}

