using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edin_magazin
{
    class Program
    {
        static void Main(string[] args)
        {
            /* За всичко това трябва да се създаде и програма, която приема команди 
             * и изпълнява съответните действия. Името на всяка команда е записано 
             * в скоби по-горе. Командата, която приключва въвеждането е „Close”. 
             * Когато се въведе тя програмата приключва. Всички реални числа се 
             * извеждат закръглене и с точно 2 знака след запетаята. */
            string[] input;
            do
            {
                input = Console.ReadLine().Split(' ');
                switch (input[0])
                {
                    case "Sell": Product_info.Sell(input[1], double.Parse(input[2])); break;
                    case "Add":
                        Product_info.Add(input[1], input[2], double.Parse(input[3]),
                                         double.Parse(input[4])); break;
                    case "Update": Product_info.Update(input[1], double.Parse(input[2])); break;
                    case "PrintA": Product_info.PrintA(); break;
                    case "PrintU": Product_info.PrintU(); break;
                    case "PrintD": Product_info.PrintD(); break;
                    case "Calculate": Console.WriteLine(Product_info.Calculate().ToString("0.00"));
                        break;
                }
            } while (input[0] != "Close");
        }
    }
}
