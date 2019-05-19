using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._2.Списък._02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Създаваме свързан списък
            DynamicList list = new DynamicList();

            // Зареждаме съдържание
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            // Тестваме списъка
            Console.WriteLine(list.Count);           // 4
            Console.WriteLine(list[0]);              // 1
            Console.WriteLine(list.IndexOf(4));      // 3
            Console.WriteLine(list.Remove(1));       // 2
            Console.WriteLine(list.Remove(2));       // 4
            Console.WriteLine(list.Remove(0));       // 1
            Console.WriteLine(list.Remove(0));       // 3
        }
    }
}
