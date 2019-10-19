using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GRID
{
    public class Car
    {
        private int hp;
        private double fuelAmount;
        private Tyre tyre;

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            this.Hp = hp;
            this.FuelAmount = fuelAmount;
            this.tyre = tyre;
        }

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public double FuelAmount
        {
            get => fuelAmount;
            set
            {
                fuelAmount = value;
                if (fuelAmount > 160)
                {
                    fuelAmount = 160;
                }
                if (fuelAmount < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of fuel!");
                }
            }
        }

        public Tyre Tyre { get => tyre; set => tyre = value; }
    }
}
    