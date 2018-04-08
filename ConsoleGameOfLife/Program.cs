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
                        world = new World(ranWorld);
                        break;
                    case InitialWorld.Sample:
                        var sample = Samples.Get(pa.Source);
                        world = new World(sample);
                        break;
                    case InitialWorld.Raw:
                        world = new World(pa.Source);
                        break;
                    default:
                        break;
                }

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
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
