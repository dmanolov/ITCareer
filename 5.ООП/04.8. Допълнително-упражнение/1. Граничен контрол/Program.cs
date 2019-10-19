using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Граничен_контрол
{
    interface IId
    {
        string Id { get; }
    }
    public class Citizen : IId
    {
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
    public class Robot : IId
    {
        public string Id { get; }
        public string Model { get; }

        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int d = 5;
            int b = 2;
            Console.WriteLine(d.CompareTo(b));
            return;

            List<IId> borderControl = new List<IId>();
            string[] input;
            do
            {
                input = Console.ReadLine().Split();  
                switch(input.Length)
                {
                    case 2: // Robot
                        Robot robotAtBorder = new Robot(input[1], input[0]);
                        borderControl.Add(robotAtBorder);
                        break;
                    case 3: // Citizen
                        Citizen humanAtBorder = new Citizen(input[2], input[0], int.Parse(input[1]));
                        borderControl.Add(humanAtBorder);
                        break;
                }
            } while (!((input.Length == 1)&&(input[0] == "End")));

            string falseIdEnd = Console.ReadLine();

            foreach (var item in borderControl)
            {
                if(item.Id.EndsWith(falseIdEnd))
                    Console.WriteLine(item.Id);
            }
        }
    }
}
