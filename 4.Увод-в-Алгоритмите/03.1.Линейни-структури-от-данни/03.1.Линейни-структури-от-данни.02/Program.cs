using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._1.Линейни_структури_от_данни._02
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var originalQueue = new Queue<int>();
            var outputQueue = new Queue<int>();
            var newNumber = int.Parse(Console.ReadLine());
            int number = 0;
            // записваме първо по-малките числа
            bool inMiddle = false;
            while(inputQueue.Count > 0)
            {
                // четем число
                number = inputQueue.Dequeue();
                // запазваме го за оригиналния масив
                originalQueue.Enqueue(number);
                // записваме всички по-малки в изходящия масив
                if (number <= newNumber)
                {
                    outputQueue.Enqueue(number);
                }
                // отбелязваме си, че едно по-голямо число остана извън опашката
                else
                {
                    inMiddle = true;
                    break;
                }
            }
            // записваме нашето число
            outputQueue.Enqueue(newNumber);
            // вмъкваме по-голямото число, което е извън опашката
            if (inMiddle)
                outputQueue.Enqueue(number);
            // записваме следващите след него
            while (inputQueue.Count > 0)
            {
                // четем число
                number = inputQueue.Dequeue();               
                // запазваме го за оригиналния масив
                originalQueue.Enqueue(number);
                // запазваме го в изходящия масив
                outputQueue.Enqueue(number);
            }
            // извеждаме новия масив
            Console.WriteLine(String.Join(", ", outputQueue.ToArray()));
            // извеждаме и оригиналния масив
            Console.WriteLine(String.Join(", ", originalQueue.ToArray()));
        }
    }
}
