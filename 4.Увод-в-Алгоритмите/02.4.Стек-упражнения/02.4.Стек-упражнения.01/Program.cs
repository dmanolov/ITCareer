using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._4.Стек_упражнения._01
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> stack = new ArrayStack<int>(2);
            try
            {
                Console.WriteLine(stack.Pop());  // error
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);  
            }
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Count);  // 2
            stack.Push(4);
            Console.WriteLine(stack.Pop());  // 4
            Console.WriteLine(stack.Count);  // 2

            int[] array = stack.ToArray();
            foreach(var e in array)          // 2, 3
                Console.Write(e + ", ");
            Console.WriteLine();
        }
    }
}
