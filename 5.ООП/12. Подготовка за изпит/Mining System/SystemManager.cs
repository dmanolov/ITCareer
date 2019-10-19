using System;
using System.Collections.Generic;
using System.Linq;

namespace Mining_System
{
    public class SystemManager
    {
        List<Miner> miners;
        List<Provider> providers;
        double totalMinedCoal;
        double totalStoredEnergy;

        public SystemManager()
        {
            miners = new List<Miner>();
            providers = new List<Provider>();
        }

        public string RegisterMiner(List<string> arguments)
        {
            try
            {
                switch (arguments[0])
                {
                    case "Driller":
                        Driller driller = new Driller(arguments[1],
                            double.Parse(arguments[2]), double.Parse(arguments[3]));

                        miners.Add(driller);
                        return $"Successfully registered Driller Miner - {arguments[1]}";
                    case "Hewer":
                        Hewer hewer = new Hewer(arguments[1],
                            double.Parse(arguments[2]), double.Parse(arguments[3]),
                            int.Parse(arguments[4]));

                        miners.Add(hewer);
                        return $"Successfully registered Hewer Miner - {arguments[1]}";
                    default:
                        return "";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string RegisterProvider(List<string> arguments)
        {
            try
            {
                if (arguments[0] == "Sun")
                {
                    Provider sunProvider = new SunProvider(arguments[1], double.Parse(arguments[2]));
                    providers.Add(sunProvider);
                }
                else if(arguments[0] == "Electricity")
                {
                    Provider electricityProvider = new ElectricityProvider(arguments[1], double.Parse(arguments[2]));
                    providers.Add(electricityProvider);
                }
                string result = $"Successfully registered {arguments[0]} Provider – {arguments[1]}";
                return result;
            }
            catch (Exception s)
            {
                return s.Message;
            }
        }

        public string Day()
        {
            double totalEnergyToday = providers.Sum(p => p.EnergyOutput);
            totalStoredEnergy += totalEnergyToday;
            double neededEnergy = miners.Sum(m => m.EnergyRequirement);
            double totalMinedCoalForToday = 0;

            if (totalStoredEnergy >= neededEnergy)
            {
                totalMinedCoalForToday = miners.Sum(m => m.CoalOutput);
                totalStoredEnergy -= neededEnergy;
                totalMinedCoal += totalMinedCoalForToday;
            }

            string result = "A day has passed." + Environment.NewLine;
            result += $"Energy Provided: {totalEnergyToday}" + Environment.NewLine;
            result += $"Mined Coal: {totalMinedCoalForToday}";
            return result;
        }

        public string Check(List<string> arguments)
        {
            Miner miner = miners.FirstOrDefault(m => m.Id == arguments[0]);
            if (miner == null)
            {
                Provider provider = providers.FirstOrDefault(p => p.Id == arguments[0]);

                if (provider == null)
                {
                    return $"No element found with id - {arguments[0]}";
                    
                }
                return provider.ToString();
            }
            return miner.ToString();
        }

        public string ShutDown()
        {
            string result = "System Shutdown" + Environment.NewLine;
            result += $"Total Energy Stored: {totalStoredEnergy}" + Environment.NewLine;
            result += $"Total Mined Coal: {totalMinedCoal}";
            return result;
        }
    }
}