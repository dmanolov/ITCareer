using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class UltrasoftTyre : Tyre
    {
        private double grip;

        public override double Degradation
        {
            set
            {
                degradation = value;
                if (Degradation < 30)
                {
                    throw new ArgumentOutOfRangeException("Blown Tyre");
                }
            }
        }

        public UltrasoftTyre(double hardness, double grip) 
            : base("Ultrasoft", hardness)
        {
            this.grip = grip;
        }

        public override void LapFinished()
        {
            Degradation = Degradation - Hardness - grip;
        }
    }
}
