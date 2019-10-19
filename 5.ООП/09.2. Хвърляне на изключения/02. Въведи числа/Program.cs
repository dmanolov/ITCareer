using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.Въведи_числа
{
    class Program
    {
        public static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                throw new InvalidDataException($"Number is out of range [{start} ... {end}]");
            }
            return number;
        }


        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine($"Insert number {i+1}: ");
                    int number = ReadNumber(start, end);
                    Console.WriteLine("You entered: " + number);
                }
                catch (InvalidDataException ex)
                {
                    Console.WriteLine(ex.Message + "\nEnter new number");
                    i--;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message + "\nWrite number!");
                    i--;
                }
            }
        }
    }
}
