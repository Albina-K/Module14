using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace SkipTake
{//Для пропуска элементов существует метод Skip(), а для включения элементов в выборку — Take()..
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new[] { "Volvo", "Opel", "Suzuki", "Toyota", "Lada", "Kamaz" };
            // пропустим первые два элемента
            var skip2 = cars.Skip(2);

            foreach (var car in skip2)
                Console.WriteLine(car);

            // пропустим первые два элемента и выведем следующие два
            var skip2a = cars.Skip(2).Take(2);

            foreach (var car in skip2a)
                Console.WriteLine(car);

         
            
            //  К примеру, на первой странице вы показываете товары с 1 по 10,
          //  то есть в данном случае условный код будет выглядеть вот так:

            var page1 = products.Take(10);
            // Далее, на второй и третьей странице:
            var page2 = products.Skip(10).Take(10);
            var page3 = products.Skip(20).Take(10);
        }

        static void Main5(string[] args)
        {
            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 7999945005 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };

            // бесконечный цикл, ожидающий ввод с консоли
            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
                Console.Clear();  //  очистка консоли от введенного текста

                if (!Char.IsDigit(keyChar))
                {
                    Console.WriteLine("Ошибка ввода, введите число");
                }
                else
                {
                    //  переменная для хранения запроса в зависимости от введенного с консоли числа
                    IEnumerable<Contact> page = null;

                    //  выбираем нужное кол-во элементов для создания постраничного ввода в зависимости от запроса
                    switch (keyChar)
                    {
                        case ('1'):
                            page = contacts.Take(2);
                            break;
                        case ('2'):
                            page = contacts.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = contacts.Skip(4).Take(2);
                            break;
                    }
                    //   проверим, что ввели существующий номер страницы
                    if (page == null)
                    {
                        Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                        continue;
                    }
                    // вывод результата на консоль
                    foreach (var contact in page)
                        Console.WriteLine(contact.Name + " " + contact.Phone);
                }
            }
        }
    }
}

