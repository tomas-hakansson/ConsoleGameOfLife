using System;
using GameOfLife;
using System.Threading;

namespace ConsoleGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string NL = Environment.NewLine;

            var gliderNW =
                "XX." + NL +
                "X.X" + NL +
                "X..";

            var gliderNE =
               ".XX" + NL +
               "X.X" + NL +
               "..X";

            var gliderSE =
               "..X" + NL +
               "X.X" + NL +
               ".XX";

            var gliderSW =
               "X.." + NL +
               "X.X" + NL +
               "XX.";

            var pulsar =
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

            var randomWorld = HelperMethods.GenerateRandomWorld(40, 40);

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
