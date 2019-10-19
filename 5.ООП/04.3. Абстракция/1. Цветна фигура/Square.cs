using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Цветна_фигура
{
    class Square : ColoredFigure
    {
        public Square(string color, int size) : base(color, size){}

        public override double GetArea()
        {
            return Size * Size;
        }

        public override string GetName()
        {
            return "Square";
        }
    }
}
