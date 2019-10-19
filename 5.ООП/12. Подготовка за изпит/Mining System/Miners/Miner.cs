using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining_System
{
    public class Miner
    {
        private string id;
        private double coalOutput;
        private double energyRequirement;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public double CoalOutput
        {
            get => coalOutput;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Coal output can not be negative!");
                }
                coalOutput = value;
            }
        }
        public double EnergyRequirement
        {
            get => energyRequirement;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Energy Requirement can not be negative!");
                }
                if(value > 20000)
                {
                    throw new ArgumentException("Miner is not registered, because of it's EnergyRequirement");
                }
                energyRequirement = value;
            }
        }

        public Miner(string id, double coalOutput, double energyRequirement)
        {
            this.Id = id;
            this.CoalOutput = coalOutput;
            this.EnergyRequirement = energyRequirement;
        }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} Miner - {id}" + Environment.NewLine;
            result += $"Coal Output: {coalOutput}" + Environment.NewLine;
            result += $"Energy Requirement: {energyRequirement}";
            return result;
        }

    }
}
