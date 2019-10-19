using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._6.Списък_методи_допълнително_упражнения._01
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(0);
            list.AddFirst(1);
            Console.WriteLine(list.Count); // 2
            Console.WriteLine(list.RemoveFirst()); // 1
            Console.WriteLine(list.RemoveFirst()); // 0
            Console.WriteLine(list.Count); // 0

            list.AddLast(0);
            list.AddLast(1);
            Console.WriteLine(list.RemoveLast()); // 1
            Console.WriteLine(list.RemoveLast()); // 0
        }
    }
}
