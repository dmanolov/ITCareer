using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Цветна_фигура
{
    public abstract class ColoredFigure
    {
        private string color;
        private int size;

        public int Size
        {
            get => size;
            private set => size = value;
        }

        public ColoredFigure(string color , int size)
        {
            this.color = color;
            this.size = size;
        }
        public void Show()
        {
            Console.WriteLine($"{GetName()}: ");
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Area: {GetArea():F2}");
        }
        public abstract string GetName();
        public abstract double GetArea();
    }

}
