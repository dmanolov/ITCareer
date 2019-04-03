using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Клас__Box___правоъгълен_паралелепипед_
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = Double.Parse(Console.ReadLine());
            var w = Double.Parse(Console.ReadLine());
            var h = Double.Parse(Console.ReadLine());
            var box = new Box(l, w, h);

            Console.WriteLine("Surface Area – {0:0.00}", box.SurfaceArea);
            Console.WriteLine("Lateral Surface Area  – {0:0.00}", box.LateralSurfaceArea);
            Console.WriteLine("Volume – {0:0.00}", box.Volume);
        }
    }
}
