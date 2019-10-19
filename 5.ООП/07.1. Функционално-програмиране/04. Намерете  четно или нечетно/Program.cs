using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Намерете__четно_или_нечетно
{
    class Program
    {
        static void Main(string[] args)
        {
            // решение на Ники
            List<int> borders = Console.ReadLine().Split().Select(int.Parse).ToList();
            string option = Console.ReadLine();

            int lower = borders[0];
            int upper = borders[1];

            List<int> numbers = new List<int>();

            for (int i = lower; i <= upper; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> odd = n => n % 2 == 1;
            Predicate<int> even = n => n % 2 == 0;

            List<int> result = new List<int>();

            if (option == "odd")
            {
                result = numbers.FindAll(odd);
            }
            else if (option == "even")
            {
                result = numbers.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", result));

            // друго решение, базирано на неговото
            List<int> borders2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            int lowerBorder = borders[0];
            int upperBorder = borders[1];

            string option2 = Console.ReadLine();
            Predicate<int> selectNumbers = n => false;
            if (option2 == "odd")
            {
                selectNumbers = n => n % 2 == 1;
            }
            else if (option2 == "even")
            {
                selectNumbers = n => n % 2 == 0;
            }

            for (int i = lower; i <= upper; i++)
            {
                if (selectNumbers(i))
                    Console.WriteLine(i + " ");
            }
        }
    }
}
