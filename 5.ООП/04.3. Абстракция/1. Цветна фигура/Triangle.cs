using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Цветна_фигура
{
    public class Triangle : ColoredFigure
    {
        public Triangle(string color, int size) 
            : base(color, size) {}

        public override double GetArea()
        {
            double area = (Size * Size) * Math.Sqrt(3) / 4;
            return area;
        }

        public override string GetName()
        {
            return "Triangle";
        }
    }
}
