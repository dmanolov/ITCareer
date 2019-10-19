using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GRID
{
    class StartUp
    {
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
            try
            {
                int lapsNumber = int.Parse(Console.ReadLine());
                int trackLenght = int.Parse(Console.ReadLine());
                RaceTower raceTower = new RaceTower();
                raceTower.SetTrackInfo(lapsNumber, trackLenght);
                while (true)
                {
                    List<string> command = Console.ReadLine().Split(' ').ToList();
                    List<string> commandArgs = command.Skip(1).ToList();

                    //string result="";

                    try
                    {
                        switch (command.First())
                        {
                            case "RegisterDriver":
                                raceTower.RegisterDriver(commandArgs);
                                break;
                            case "Leaderboard":
                                Console.WriteLine(raceTower.GetLeaderboard());
                                break;
                            case "Box":
                                raceTower.DriverBoxes(commandArgs);
                                break;
                            case "CompleteLaps":
                                var result = raceTower.CompleteLaps(commandArgs);

                                if (!string.IsNullOrEmpty(result))
                                {
                                    Console.WriteLine(result);
                                    return;
                                }
                                break;
                            default: break;
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
            }
            finally
            {
                Console.SetOut(standartOutput);
                Console.SetError(standartError);
                Console.Write(bufferOutput.ToString());
            }
        }
    }
}
