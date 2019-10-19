using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class AggressiveDriver : Driver
    {
        public override double Speed { set => base.Speed = value * 1.3; }

        public AggressiveDriver(Car car, string name) 
            : base(car, name, 2.7)
        {
        }

    }
}
