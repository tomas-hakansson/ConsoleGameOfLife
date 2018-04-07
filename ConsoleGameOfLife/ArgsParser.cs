using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGameOfLife
{
    public class ArgsParser
    {
        public int Width;
        public int Height;
        public bool Fixed;

        public ArgsParser(string[] args)
        {
            Width = 0;
            Height = 0;
            Fixed = false;
            Parse(args);
        }

        private void Parse(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(args), args, $"The size of {nameof(args)} is too small");
            if (args.Length > 7)
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
            foreach (var pair in flagDict)
            {
                switch (pair.Key)
                {
                    case "-s":
                        break;
                    case "-w":
                        PopulatePadding(pair, ref Width);
                        break;
                    case "-h":
                        PopulatePadding(pair, ref Height);
                        break;
                    case "-f":
                    default:
                        break;
                }
            }

            //local functions:

            void PopulatePadding(KeyValuePair<string, string> pair, ref int padding)
            {
                if (int.TryParse(pair.Value, out int val) && val >= 0)
                {
                    padding = val;
                }
                else
                    throw new ArgumentException($"{nameof(pair.Key)} must be an integer, greater or equal to zero");
            }
        }
    }
}