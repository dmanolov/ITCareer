using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // за да се отдели входа от изхода - начало 1
            Console.WriteLine("INPUT:");
            var standartOutput = Console.Out;
            var standartError = Console.Error;
            var bufferOutput = new StringWriter();
            Console.SetOut(bufferOutput);
            Console.SetError(bufferOutput);
            Console.WriteLine();
            Console.WriteLine("OUTPUT:");
            // за да се отдели входа от изхода - край 1

            int capacity = int.Parse(Console.ReadLine());

            Dictionary<String, CapacityList> players = new Dictionary<string, CapacityList>();

            string command = "";
            do
            {
                command = Console.ReadLine();
                string[] commands = command.Split(' ').ToArray();
                switch (commands[0])
                {
                    case "Dice":
                        string player = commands[1];
                        int value1 = int.Parse(commands[2]);
                        int value2 = int.Parse(commands[3]);
                        if (players.ContainsKey(player))
                        {
                            players[player].Add(new Pair(value1, value2));
                        }
                        else
                        {
                            players.Add(player, new CapacityList(capacity));
                            players[player].Add(new Pair(value1, value2));
                        }
                        break;
                    case "CurrentPairSum":
                        string playerName = commands[1];
                        if (players.ContainsKey(playerName))
                        {
                            Console.WriteLine(players[playerName].Sum());
                        }
                        break;
                    case "CurrentStanding":
                        players = players.OrderBy(element => element.Value.Sum().Difference())
                            .ToDictionary(element => element.Key, element => element.Value);
                        foreach (var item in players)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value.Sum());
                        }
                        break;
                    case "CurrentState":
                        string playerNameState = commands[1];
                        if (players.ContainsKey(playerNameState))
                        {
                            players[playerNameState].PrintCurrentState();
                        }

                        break;
                    case "Winner":
                        players = players.OrderBy(element => element.Value.Sum().Difference())
                            .ThenBy(element => element.Key)
                            .ToDictionary(element => element.Key, element => element.Value);
                        Console.WriteLine("{0} wins the game!", players.First().Key);
                        break;

                }
            } while (command != "End");

            // за да се отдели входа от изхода - начало 2
            Console.SetOut(standartOutput);
            Console.SetError(standartError);
            Console.Write(bufferOutput.ToString());
            // за да се отдели входа от изхода - край 2
        }

    }
}