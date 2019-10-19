using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._1.Линейни_структури_от_данни._01
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var searchedNumber = int.Parse(Console.ReadLine()); 
            
            // най-лесния начин
            if(numbers.Contains(searchedNumber))
                Console.WriteLine($"{searchedNumber} Exists in the List");
            else Console.WriteLine($"{searchedNumber} Not exists in the List");
            
            // втори начин
            bool found = false;
            foreach(var value in numbers)
            {
                if(value == searchedNumber)
                {
                    found = true;
                    break;
                }
            }
            if (found)
                Console.WriteLine($"{searchedNumber} Exists in the List");
            else Console.WriteLine($"{searchedNumber} Not exists in the List");

            // трети начин, сложен
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            found = false;
            var count = queue.Count; // защото опашката остава с постоянен брой 
            for (int i = 0; i < count; i++)  // а не искаме цикъла да се повтаря до безкрай
            {
                var number = queue.Dequeue(); // прочитаме поредното число
                queue.Enqueue(number); // за да не го загубим от опашката
                if (number == searchedNumber)
                {
                    found = true;
                    break;
                }
            }
            if (found)
                Console.WriteLine($"{searchedNumber} Exists in the List");
            else Console.WriteLine($"{searchedNumber} Not exists in the List");

            // същото е със стек
        }
    }
}
