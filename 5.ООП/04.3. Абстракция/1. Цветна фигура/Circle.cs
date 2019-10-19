using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Цветна_фигура
{
    class Circle : ColoredFigure
    {
            public Circle(string color, int size) : base(color, size) { }

            public override double GetArea()
            {
                return Size * Size * Math.PI;
            }

            public override string GetName()
            {
                return "Circle";
            }
    }
}
