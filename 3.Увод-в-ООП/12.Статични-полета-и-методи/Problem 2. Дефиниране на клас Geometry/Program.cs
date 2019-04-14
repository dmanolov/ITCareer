using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Дефиниране_на_клас_Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Liceto na kvadrat s duljina na stranata " + 
                                a + " e " + Geometry.SquareArea(a).ToString("#.00"));

            Console.WriteLine("Perimetura na kvadrat s duljina na stranata {0} e {1:F2} ",
                                a, Geometry.SquarePerimeter(a));

            Console.WriteLine("Obikolkata na kvadrat s duljina na stranata " +
                                a + " i stranata " + b +" e" + 
                                Math.Round(Geometry.RectanglePerimeter(a,b), 2));

            Console.WriteLine($"Liceto na kvadrat s duljina na stranata {a} e {Geometry.RectangleArea(a, b):F2}");
            Console.WriteLine("lice na kruga s radius {0} e {1:0.00}", a/2, Geometry.CircleArea(a/2));

        }
    }
}
