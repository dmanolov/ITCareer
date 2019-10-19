using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Цветна_фигура
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string figure = tokens[0];
                string color = tokens[1];
                int size = int.Parse(tokens[2]);
                switch (figure)
                {
                    case "Triangle":
                        Triangle triangle = new Triangle(color, size);
                        triangle.Show();
                        break;
                    case "Square":
                        Square square = new Square(color, size);
                        square.Show();
                        break;
                    case "Circle":
                        Circle circle = new Circle(color, size);
                        circle.Show();
                        break;
                }
            }

        }
}
}
