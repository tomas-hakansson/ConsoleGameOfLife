using System;
using GameOfLife;
using System.Threading;

namespace ConsoleGameOfLife
{
    class Program
    {
        private static string NL = Environment.NewLine;

        private static string gliderNW =
                "XX." + NL +
                "X.X" + NL +
                "X..";

        private static string gliderNE =
               ".XX" + NL +
               "X.X" + NL +
               "..X";

        private static string gliderSE =
               "..X" + NL +
               "X.X" + NL +
               ".XX";

        private static string gliderSW =
               "X.." + NL +
               "X.X" + NL +
               "XX.";

        private static string pulsar =
                "..............." + NL +
                "...XXX...XXX..." + NL +
                "..............." + NL +
                ".X....X.X....X." + NL +
                ".X....X.X....X." + NL +
                ".X....X.X....X." + NL +
                "...XXX...XXX..." + NL +
                "..............." + NL +
                "...XXX...XXX..." + NL +
                ".X....X.X....X." + NL +
                ".X....X.X....X." + NL +
                ".X....X.X....X." + NL +
                "..............." + NL +
                "...XXX...XXX..." + NL +
                "...............";

        private static string randomWorld = HelperMethods.GenerateRandomWorld(40, 40);

        static void Main(string[] args)
        {
            try
            {
                var pa = new ArgsParser(args);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch(ArgumentException ex)
            {

            }
            //if (args[0] == "test")
            {
                var world = new World(randomWorld);

                Console.WriteLine("Press 'q' to exit!");
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        //if (Console.ReadKey(true).Key == ConsoleKey.Q)
                        //    break;
                        Console.Clear();
                        var toPrint = HelperMethods.MatrixToString(world.CurrentWorld);
                        Console.WriteLine(toPrint);
                        world = world.NextGeneration();
                        Thread.Sleep(150);
                    }
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Q);
            }
        }
    }
}
