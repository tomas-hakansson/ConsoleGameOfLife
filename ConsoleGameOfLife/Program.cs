using GameOfLife;
using System;
using System.Threading;

namespace ConsoleGameOfLife
{
    class Program
    {
        static bool Quit = false;
        static bool Pause = false;
        static bool Step = false;

        static void Main(string[] args)
        {
            try
            {
                World world = null;
                var parser = new ArgsParser(args);

                switch (parser.SourceType)
                {
                    case InitialWorld.Random:
                        var ranWorld = HelperMethods.GenerateRandomWorld(parser.Width, parser.Height);
                        world = new World(ranWorld, parser.FixedSize);
                        break;
                    case InitialWorld.Sample:
                        var sample = Samples.Get(parser.Source);
                        world = new World(sample, parser.FixedSize);
                        break;
                    case InitialWorld.Raw:
                        world = new World(parser.Source, parser.FixedSize);
                        break;
                }

                Thread ConsoleKeyListener = new Thread(new ThreadStart(KeyboardEvents));
                ConsoleKeyListener.Start();

                var wasGrowing = false;
                while (!Quit)
                {
                    if (Pause)
                    {
                        if (Step)
                        {
                            RunGameOfLife("Press 'q' to quit, 's' to step through each generation, and 'r' to resume!", ref world, parser, ref wasGrowing);
                            Step = false;
                        }
                    }
                    else
                    {
                        RunGameOfLife("Press 'q' to quit and 'p' to pause!", ref world, parser, ref wasGrowing);
                    }
                }

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }

        private static void RunGameOfLife(string text, ref World world, ArgsParser pa, ref bool wasGrowing)
        {
            var currentWorld = world.CurrentWorld;
            var width = currentWorld[0].Count;
            var height = currentWorld.Count;
            if (pa.SourceType != InitialWorld.Random && pa.FixedSize && (width < pa.Width || height < pa.Height))
            {
                world = new World(world.CurrentWorld, false);
                wasGrowing = true;
            }
            else if (wasGrowing)
                world = new World(world.CurrentWorld, pa.FixedSize);

            Console.Clear();
            Console.WriteLine(text);
            Console.WriteLine();
            var toPrint = HelperMethods.MatrixToString(world.CurrentWorld);
            Console.WriteLine(toPrint);
            world = world.NextGeneration();
            Thread.Sleep(150);
        }

        private static void KeyboardEvents()
        {
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Q:
                        Quit = true;
                        break;
                    case ConsoleKey.P:
                        Pause = true;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Press 'q' to quit, 's' to step through each generation, and 'r' to resume!");
                        break;
                    case ConsoleKey.S://step
                        Step = true;
                        break;
                    case ConsoleKey.R://Resume
                        Pause = false;
                        break;
                    default:
                        break;
                }
            }
            while (true);
        }
    }
}
