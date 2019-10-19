using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining_System
{
    public class SunProvider : Provider
    {
        public SunProvider(string id , double energyOutput): base(id , 1.25*energyOutput)
        {
            
        }
    }
}
