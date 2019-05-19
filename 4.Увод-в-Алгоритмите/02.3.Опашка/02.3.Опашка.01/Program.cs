using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._3.Опашка._01
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new CircularQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Count);     // 3
            Console.WriteLine(queue.Dequeue()); // 1
            Console.WriteLine(queue.Dequeue()); // 2
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue.Count);     // 3

        }
    }
}
