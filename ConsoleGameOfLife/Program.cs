using System;
using GameOfLife;
using System.Threading;

namespace ConsoleGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                World world = null;
                var pa = new ArgsParser(args);

                switch (pa.SourceType)
                {
                    case InitialWorld.Random:
                        var ranWorld = HelperMethods.GenerateRandomWorld(pa.Width, pa.Height);
                        world = new World(ranWorld, pa.FixedSize);
                        break;
                    case InitialWorld.Sample:
                        var sample = Samples.Get(pa.Source);
                        world = new World(sample, pa.FixedSize);
                        break;
                    case InitialWorld.Raw:
                        world = new World(pa.Source, pa.FixedSize);
                        break;
                    default:
                        break;
                }
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        //if (Console.ReadKey(true).Key == ConsoleKey.Q)
                        //    break;
                        Console.Clear();
                        Console.WriteLine("Press 'q' to exit!");
                        Console.WriteLine();
                        var toPrint = HelperMethods.MatrixToString(world.CurrentWorld);
                        Console.WriteLine(toPrint);
                        world = world.NextGeneration();
                        Thread.Sleep(150);
                    }
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Q);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
