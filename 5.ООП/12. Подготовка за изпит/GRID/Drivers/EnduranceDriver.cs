using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class EnduranceDriver : Driver
    {
        public EnduranceDriver(Car car, string name) 
            : base(car, name, 1.5)
        {
        }
    }
}
