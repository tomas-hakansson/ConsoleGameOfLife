using System;

namespace ConsoleGameOfLife
{
    public class ArgsParser
    {
        public ArgsParser(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(args), args, $"The size of {nameof(args)} is too small");
            if (args.Length > 7)
                throw new ArgumentOutOfRangeException(nameof(args), args, $"The size of {nameof(args)} is too large");
            var firstOfFirst = args[0][0];
            if (firstOfFirst != '-')
                throw new ArgumentException($"{nameof(args)} must start with a flag", nameof(args));
        }
    }
}