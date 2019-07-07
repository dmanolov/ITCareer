using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Parking
    {
        private Car head;
        private Car tail;
        private int count;

        public int Count
        {
            get => count;
            private set => count = value;
        }

        public Parking()
        {
            head = tail = null;
            count = 0;
        }

        public void AddCar(string carNumber)
        {
            Car newCar = new Car(carNumber);
            if (Count == 0)
            {
                head = tail = newCar;
            }
            else
            {
                tail.Next = newCar;
                tail = newCar;
            }
            count++;
        }

        public void AddFancyCar(string carNumber)
        {
            Car newCar = new Car(carNumber);
            if (Count == 0)
            {
                head = tail = newCar;
            }
            else
            {
                newCar.Next = head;
                head = newCar;
            }
            count++;
        }

        public Car CheckCarIsPresent(string carNumber)
        {
            Car current = head;
            while (current != null)
            {
                if (carNumber == current.CarNumber)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public bool ReleaseCar(string carNumber)
        {
            if (Count == 0)
                return false;
            // ако махаме първата кола
            if (head.CarNumber == carNumber)
            {
                Car removed = head;
                head = head.Next;
                removed.Next = null;
                count--;
                return true;
            }
            else
            {
                // намираме предишната на търсената
                Car current = head;
                while (current.Next != null && current.Next.CarNumber != carNumber)
                    current = current.Next;
                // ако сме стигнали до края, значи няма такава
                if (current.Next == null)
                    return false;
                // или следващата е тази, която ще премахваме
                Car removed = current.Next;
                // пропускаме премахваната и сочим към следващата след нея
                current.Next = removed.Next;
                // ако е бил последна, новата последна е и опашка
                if (removed.Next == null)
                    tail = current;
                removed.Next = null;
                count--;
                return true;
            }
        }

        public bool ReleaseCar(int index)
        {
            // проверяваме всички проблемни случаи
            if (index < 0 || index >= Count)
                return false;
            if (index == 0)
            {
                Car removed = head;
                head = head.Next;
                removed.Next = null;
                count--;
                return true;
            }
            else
            {
                // намираме предишната на премахваната
                Car current = head;
                for (int i = 0; i < (index - 1); i++)
                    current = current.Next;
                Car removed = current.Next;
                // пропускаме премахваната и сочим към следващата след нея
                current.Next = removed.Next;
                // ако е бил последна, новата последна е и опашка
                if (removed.Next == null)
                    tail = current;
                removed.Next = null;
                count--;
                return true;
            }
        }

        public StringBuilder ParkingInformation()
        {
            StringBuilder builder = new StringBuilder();
            if (Count == 0)
            {
                builder.AppendLine("< Parking is empty!>");
            }
            else
            {
                Car current = head;
                for (int i = 0; i < Count; i++)
                {
                    builder.AppendLine(current.ToString());
                    current = current.Next;
                }
            }
            return builder;
        }

    }
}
