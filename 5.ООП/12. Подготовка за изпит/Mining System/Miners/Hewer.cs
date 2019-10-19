using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining_System
{
    public class Hewer : Miner
    {
        private int enduranceFactor;

        public int EnduranceFactor { get => enduranceFactor; set => enduranceFactor = value; }

        public Hewer(string id, double coalOutput, double energyRequirement, int enduranceFactor): 
            base(id, coalOutput, energyRequirement/enduranceFactor)
        {
            EnduranceFactor = enduranceFactor;
        }
    }
}
