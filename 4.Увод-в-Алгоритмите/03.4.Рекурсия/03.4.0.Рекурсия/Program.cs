using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._4._0.Рекурсия
{
    class Program
    {
        static void Main(string[] args)
        {
            // примери за рекурсия
            Console.WriteLine("сума на числата от 1 до n: " + Sum(6));
            Console.WriteLine("факториел от n: "+Fact(5));
            Console.WriteLine("извеждане на числата от 1 до n:");
            Print1n(1, 6);
            Console.WriteLine("извеждане на числата от n do 1:");
            Printn1(1, 6);
            Console.WriteLine("извеждане на числата от 1 до n и пак до 1:");
            Print1n1(1, 4, 1);
            Console.WriteLine("извеждане на числата от n do 1 и пак до n:");
            Printn1n(4, 1, 4);
        }

        private static void Printn1n(int i, int n, int start)
        {
            if (i == n)
            {
                Console.Write(i + ", ");
                return;
            }
            Console.Write(i+", ");
            Printn1n(i - 1, n, start);
            if(i==start)
                Console.WriteLine(i);
            else 
                Console.Write(i + ", ");

        }

        private static void Print1n1(int i, int n, int start)
        {
            if (i == n)
            {
                Console.Write(i + ", ");
                return;
            }
            Console.Write(i + ", ");
            Print1n1(i + 1, n, start);
            if(i==start)
                Console.WriteLine(i);
            else Console.Write(i + ", ");
            
        }

        private static void Printn1(int i, int n)
        {
            if (i == n)
            {
                Console.WriteLine(n);
                return;
            }
            Console.Write(n + ", ");
            Printn1(i, n - 1);
        }

        private static void Print1n(int i, int n)
        {
            if (i == n)
            {
                Console.WriteLine(i);
                return;
            }
            Console.Write(i + ", ");
            Print1n(i + 1, n);
        }

        private static int Fact(int n)
        {
            if (n == 0) return 1;
            return n * Fact(n - 1);
        }

        private static int Sum(int n)
        {
            if (n == 0) return 0;
            return n + Sum(n - 1);
        }
    }
}
