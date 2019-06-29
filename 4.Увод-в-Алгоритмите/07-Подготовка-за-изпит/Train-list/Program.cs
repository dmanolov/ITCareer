using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Program
    {
        private static Deque<Train> trains = new Deque<Train>();
        // този път ще пазим историята тук, така Deque е по-универсален клас
        private static Stack<Train> history = new Stack<Train>();

        private static void Add(int number, string name, string type, int cars)
        {
            if (type == "F")
            {
                trains.AddBack(new Train(number, name, type, cars));
            }
            else
            {
                trains.AddFront(new Train(number, name, type, cars));
            }
        }
        private static void Travel()
        {
            if (trains.Count > 0)
            {

                Train frontTrain = trains.GetFront();
                Train backTrain = trains.GetBack();
                if (backTrain != null && backTrain.Type == "F" && backTrain.Cars > 15)
                {
                    // когато замине влак, той отива в историята
                    history.Push(backTrain);
                    Console.WriteLine(trains.RemoveBack());
                }
                else if (frontTrain != null && frontTrain.Type == "P")
                {
                    history.Push(frontTrain);
                    Console.WriteLine(trains.RemoveFront());
                }
                else if (backTrain != null && backTrain.Type == "F")
                {
                    history.Push(backTrain);
                    Console.WriteLine(trains.RemoveBack());
                }
            }
        }
        private static void Next()
        {
            if (trains.Count > 0)
            {

                Train frontTrain = trains.GetFront();
                Train backTrain = trains.GetBack();
                if (backTrain != null && backTrain.Type == "F" && backTrain.Cars > 15)
                {
                    Console.WriteLine(backTrain);
                }
                else if (frontTrain != null && frontTrain.Type == "P")
                {
                    Console.WriteLine(frontTrain);
                }
                else if (backTrain != null && backTrain.Type == "F")
                {
                    Console.WriteLine(backTrain);
                }
            }
        }

        private static void History()
        {
            // ако ги вземем с Pop(), ще изчезнат от history
            Train[] trains = history.ToArray<Train>();
            foreach(var t in trains)
            {
                Console.WriteLine(t);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("INPUT:");
            var standartOutput = Console.Out;
            var standartError = Console.Error;
            var bufferOutput = new StringWriter();
            Console.SetOut(bufferOutput);
            Console.SetError(bufferOutput);
            Console.WriteLine();
            Console.WriteLine("OUTPUT:");

            string[] command;
            do
            {
                command = Console.ReadLine().Split(' ').ToArray();
                switch (command[0])
                {
                    case "Add": Add(int.Parse(command[1]), command[2], command[3], int.Parse(command[4])); break;
                    case "Travel": Travel(); break;
                    case "Next": Next(); break;
                    case "History": History(); break;
                }
            } while (command[0] != "End");

            Console.SetOut(standartOutput);
            Console.SetError(standartError);
            Console.Write(bufferOutput.ToString());
        }
    }
}
