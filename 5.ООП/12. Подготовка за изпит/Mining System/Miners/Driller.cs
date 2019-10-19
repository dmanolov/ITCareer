using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining_System
{
    public class Driller : Miner
    {
        public Driller(string id, double coalOutput, double energyRequirement): 
            base(id, coalOutput*3, energyRequirement*2)
        {

        }
    }
}
