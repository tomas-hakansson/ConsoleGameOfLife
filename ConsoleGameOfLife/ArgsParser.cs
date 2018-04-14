using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGameOfLife
{
    public class ArgsParser
    {
        public InitialWorld SourceType;
        public string Source;
        public int Width;
        public int Height;
        public bool FixedSize;

        public ArgsParser(string[] args)
        {
            SourceType = InitialWorld.Random;
            Width = 1;
            Height = 1;
            FixedSize = false;
            Parse(args);
        }

        private void Parse(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(args), args, $"The size of {nameof(args)} is too small");
            if (args.Length > 5)
                throw new ArgumentOutOfRangeException(nameof(args), args, $"The size of {nameof(args)} is too large");
            if (!IsFlag(args[0]))
                throw new ArgumentException($"{nameof(args)} must start with a flag", nameof(args));

            var flagDict = PopulateFlagDictionary(args);
            PopulateArgParser(flagDict);
        }

        private static bool IsFlag(string arg) => arg[0] == '-';

        private static Dictionary<string, string> PopulateFlagDictionary(string[] args)
        {
            var flagDict = new Dictionary<string, string>();
            var argsStack = new Stack<string>(args.Reverse().ToArray());
            while (argsStack.Count != 0)
            {
                string arg = argsStack.Pop();
                switch (arg)
                {
                    case "-s":
                    case "-w":
                    case "-h":
                        flagDict.Add(arg, argsStack.Pop());
                        break;
                    case "-f":
                        flagDict.Add(arg, string.Empty);
                        break;
                    default:
                        throw new ArgumentException("Flags can only take one value each");
                }
            }
            return flagDict;
        }

        private void PopulateArgParser(Dictionary<string, string> flagDict)
        {
            var widthSet = false;
            var heightSet = false;

            foreach (var pair in flagDict)
            {
                switch (pair.Key)
                {
                    case "-s":
                        if (pair.Value[0] == '#')
                        {
                            SourceType = InitialWorld.Raw;
                            Source = pair.Value.Replace("#", string.Empty);
                        }
                        else
                        {
                            SourceType = InitialWorld.Sample;
                            Source = pair.Value;
                        }
                        break;
                    case "-w":
                        widthSet = true;
                        populateSize(pair, ref Width);
                        break;
                    case "-h":
                        heightSet = true;
                        populateSize(pair, ref Height);
                        break;
                    case "-f":
                        FixedSize = true;
                        break;
                    default:
                        break;
                }
            }
            if (this.SourceType == InitialWorld.Random && (!widthSet || !heightSet))
                throw new ArgumentException("Both width and height must be set if a random world is chosen");
            if (this.SourceType != InitialWorld.Random && (widthSet || heightSet))
                throw new ArgumentException("The width and height can only be set for a random world");

            //local functions:

            void populateSize(KeyValuePair<string, string> pair, ref int size)
            {
                if (int.TryParse(pair.Value, out int val) && val > 0)
                {
                    size = val;
                }
                else
                    throw new ArgumentException($"{nameof(pair.Key)} must be an integer, greater or equal to zero");
            }
        }
    }
}