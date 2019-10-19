using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._8.Стек_допълнително_упражнение._01
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<string> stack = new LinkedStack<string>();
            stack.Push("donkey");
            stack.Push("dog");
            stack.Push("cat");
            stack.Push("bird");
            stack.Push("bee");
            Console.WriteLine(stack.Count); // 5
            Console.WriteLine(stack.Pop()); // bee
            Console.WriteLine(stack.Count); // 4
            Console.WriteLine(String.Join(" < ", stack.ToArray()));
        }
    }
}
