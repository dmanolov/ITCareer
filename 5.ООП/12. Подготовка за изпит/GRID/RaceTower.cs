using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class RaceTower
    {
        private int totalLapsNumber;
        private int currentLapsNumber = 0;
        private int trackLength;
        private Dictionary<string, Driver> registeredDrivers = new Dictionary<string, Driver>();
        private List<Driver> failedDrivers = new List<Driver>();

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.totalLapsNumber = lapsNumber;
            this.trackLength = trackLength;
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            try
            {
                // вземаме информацията от входните данни
                string driverType = commandArgs[0];
                string driverName = commandArgs[1];
                int carHP = int.Parse(commandArgs[2]);
                double carFuelAmount = double.Parse(commandArgs[3]);
                string tyreType = commandArgs[4];
                double tyreHardness = double.Parse(commandArgs[5]);

                // създаваме подходящите обекти
                Tyre newTyre = null;
                if (tyreType == "Ultrasoft")
                {
                    double tyreGrip = double.Parse(commandArgs[6]);
                    newTyre = new UltrasoftTyre(tyreHardness, tyreGrip);
                }
                else if (tyreType == "Hard")
                {
                    newTyre = new HardTyre(tyreHardness);
                }
                Car newCar = new Car(carHP, carFuelAmount, newTyre);
                Driver newDriver = null;
                if (driverType == "Aggressive")
                {
                    newDriver = new AggressiveDriver(newCar, driverName);
                }
                else if (driverType == "Endurance")
                {
                    newDriver = new EnduranceDriver(newCar, driverName);
                }

                // добавяме го в списъка
                registeredDrivers.Add(driverName, newDriver);
            }
            catch (Exception)
            {
                ;
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            // вземаме информацията от входните данни
            string reasonToBox = commandArgs[0];
            string driverName = commandArgs[1];
            Driver driverInBox = registeredDrivers[driverName];
            if (driverInBox == null) return;
            driverInBox.TotalTime += 20;

            if (reasonToBox == "ChangeTyres")
            {
                string tyreType = commandArgs[2];
                double tyreHardness = double.Parse(commandArgs[3]);
                Tyre newTyre = null;
                if (tyreType == "Ultrasoft")
                {
                    double tyreGrip = double.Parse(commandArgs[4]);
                    newTyre = new UltrasoftTyre(tyreHardness, tyreGrip);
                }
                else if (tyreType == "Hard")
                {
                    newTyre = new HardTyre(tyreHardness);
                }
                // извършваме указаните промени
                driverInBox.Car.Tyre = newTyre;
            }
            else if (reasonToBox == "Refuel")
            {
                double fuelAmount = double.Parse(commandArgs[2]);
                // извършваме указаните промени
                driverInBox.Car.FuelAmount += fuelAmount;
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            int numberOfLaps = int.Parse(commandArgs[0]);
            // увеличаваме броят 
            if ((numberOfLaps + currentLapsNumber) > totalLapsNumber)
            {
                new ArgumentOutOfRangeException($"There is no time! On lap {currentLapsNumber}.");
            }
            currentLapsNumber += numberOfLaps;

            for (int i = 0; i < numberOfLaps; i++)
            {
                Driver[] drivers = registeredDrivers.Values.ToArray();
                if (drivers.Length == 0) break;
                for (int j = 0; j < drivers.Length; j++)
                {
                    Driver driver = drivers[j];
                    try
                    {
                        driver.CalculateSpeed();
                        driver.TotalTime += 60 / (trackLength / driver.Speed);
                        driver.Car.FuelAmount -= trackLength * driver.FuelConsumptionPerKm;
                        driver.Car.Tyre.LapFinished();
                    }
                    catch (Exception e)
                    {
                        registeredDrivers.Remove(driver.Name);
                        driver.ReasonToFail = e.Message;
                        failedDrivers.Add(driver);
                    }
                }
            }

            if(currentLapsNumber == totalLapsNumber)
            {
                Driver firstDriver = registeredDrivers.Values.OrderBy(x => x.TotalTime).First();
                return String.Format($"{firstDriver.Name} wins the race for {firstDriver.TotalTime:F3} seconds.");
            }
                
            else return "";
        }

        public string GetLeaderboard()
        {
            string result = string.Format($"Lap {currentLapsNumber}/{totalLapsNumber}");
            result += Environment.NewLine;

            int position = 1;
            foreach (var driver in registeredDrivers.Values.OrderBy(x => x.TotalTime))
            {
                result += string.Format($"{position++} {driver.Name} {driver.TotalTime:F3}");
                result += Environment.NewLine;
            }

            foreach (var driver in failedDrivers)
            {
                result += string.Format($"{position++} {driver.Name} {driver.ReasonToFail}");
                result += Environment.NewLine;
            }

            return result;
        }
    }
}
