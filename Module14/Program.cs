using System;
using System.Collections.Generic;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //выбрать имена на букву А и отсортировать в алфавитном порядке.
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            // список, куда будем сохранять выборку
            var orderedList = new List<string>();

            // пробежимся по массиву и добавим искомое в наш список
            foreach (string person in people)
            {
                if (person.ToUpper().StartsWith("А"))
                    orderedList.Add(person);
            }

            // отсортируем список
            orderedList.Sort();
            foreach (string s in orderedList)
                Console.WriteLine(s);
        }
    }
}