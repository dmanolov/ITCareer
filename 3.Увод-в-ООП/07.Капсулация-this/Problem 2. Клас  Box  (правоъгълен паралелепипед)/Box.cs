using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Клас__Box___правоъгълен_паралелепипед_
{
    class Box
    {
        private double l, w, h;


        public double Volume { get => l * w * h; }
        public double LateralSurfaceArea { get => 2 * l * h + 2 * w * h; }
        public double SurfaceArea { get => 2 * l * w + LateralSurfaceArea; }

        public Box( double l, double w, double h)
        {
            this.l = l;
            this.w = w;
            this.h = h;
        }
    }
}
