using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining_System
{
    public class Provider
    {
        private string id;
        private double energyOutput;

        public string Id { get => id; }

        public Provider (string id , double energyOutput)
        {
            this.id = id;
            this.EnergyOutput = energyOutput;
        }

        public double EnergyOutput
        {
            get => energyOutput;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("EnergyOutput must be possitive!");
                }
                else if (value > 10000)
                {
                    throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
                }
                energyOutput = value;
            }
        }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} Provider - {id}" + Environment.NewLine;
            result += $"Energy Output: {energyOutput}";
            return result;
        }
    }
}
