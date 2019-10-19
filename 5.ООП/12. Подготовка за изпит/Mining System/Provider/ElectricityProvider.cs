using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining_System
{
    public class ElectricityProvider : Provider
    {
        public ElectricityProvider(string id , double energyOutput): base(id , 1.5*energyOutput)
        {

        }   
    }
}
