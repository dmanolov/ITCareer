using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Car
    {
        private string carNumber;
        private Car next;

        public Car(string carNumber)
        {
            this.carNumber = carNumber;
            this.next = null;
        }

        public string CarNumber
        {
            get => carNumber;
            set => carNumber = value;
        }

        public Car Next
        {
            get => next;
            set => next = value;
        }

        public override string ToString()
        {
            return $"Car: {carNumber}";
        }
    }
}
