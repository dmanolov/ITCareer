using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class Driver
    {
        private string name;
        private double totalTime;
        private Car car;
        private double fuelConsumptionPerKm;
        private double speed;
        private string reasonToFail;

        public Driver(Car car, string name, double fuelConsumptionPerKm)
        {
            Car = car;
            Name = name;
            TotalTime = 0;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            ReasonToFail = "";
        }

        public string Name { get => name; private set => name = value; }
        public double TotalTime { get => totalTime; set => totalTime = value; }
        public double FuelConsumptionPerKm { get => fuelConsumptionPerKm; private set => fuelConsumptionPerKm = value; }
        public virtual double Speed { get => speed; set => speed = value; }
        public Car Car
        {
            get => car;
            set
                {
                    car = value;
                    CalculateSpeed();
                }
        }

        public string ReasonToFail { get => reasonToFail; set => reasonToFail = value; }

        public virtual void CalculateSpeed()
        {
            if (Car == null)
                speed = 0;
            else
                speed = (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
        }
    }
}
