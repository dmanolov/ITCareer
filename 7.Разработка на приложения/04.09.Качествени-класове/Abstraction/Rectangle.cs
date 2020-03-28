using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public virtual double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Width have to be positive number");
                width = value;
            }
        }
        public virtual double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Height have to be positive number");
                height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
