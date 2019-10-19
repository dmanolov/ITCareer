using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Фигури
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return "Drawing ";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.Draw());
            builder.AppendLine($"Area: {this.CalculateArea()}");
            builder.AppendLine($"Perimeter: {this.CalculatePerimeter()}");

            return builder.ToString().TrimEnd();
        }
    }

    public class Rectangle : Shape
    {
        private double sideA;
        private double sideB;

        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        public override double CalculatePerimeter()
        { return this.sideA * 2 + this.sideB * 2; }
        public override double CalculateArea()
        { return this.sideA * this.sideB; }
        public sealed override string Draw()
        { return base.Draw() + "Rectangle"; }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculatePerimeter()
        { return 2 * Math.PI * this.radius; }
        public override double CalculateArea()
        { return Math.PI * this.radius * this.radius; }
        public sealed override string Draw()
        { return base.Draw() + "Circle"; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(2);
            Shape rectangle = new Rectangle(2, 4);

            Console.WriteLine(circle);
            Console.WriteLine(rectangle);
        }
    }
}
