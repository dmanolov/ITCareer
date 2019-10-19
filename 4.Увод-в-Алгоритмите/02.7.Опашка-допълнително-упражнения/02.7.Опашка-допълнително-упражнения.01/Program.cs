using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._7.Опашка_допълнително_упражнения._01
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();
            queue.Enqueue("Viki");
            queue.Enqueue("Krisi");
            queue.Enqueue("Maria");
            Console.WriteLine(queue.Count);     // 3
            Console.WriteLine(String.Join(", ", queue.ToArray()));
            Console.WriteLine(queue.Dequeue()); // Viki
            Console.WriteLine(queue.Dequeue()); // Krisi
            Console.WriteLine(queue.Dequeue()); // Maria
            Console.WriteLine(queue.Count);     // 0
        }
    }
}
