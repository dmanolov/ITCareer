using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class Tyre
    {
        private string name;
        private double hardness;
        protected double degradation;

        public string Name { get => name; set => name = value; }
        public double Hardness { get => hardness; set => hardness = value; }
        public virtual double Degradation
        {
            get => degradation;
            set
            {
                degradation = value;
                if (degradation < 0)
                {
                    throw new ArgumentOutOfRangeException("Blown Tyre");
                }
            }
        }

        public Tyre(string name, double hardness)
        {
            this.name = name;
            this.hardness = hardness;
            this.degradation = 100;
        }

        public virtual void LapFinished()
        {
            Degradation = Degradation - Hardness;
        }
    }
}