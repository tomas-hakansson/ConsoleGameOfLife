using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameOfLife
{
    class Samples
    {
        private static string NL = Environment.NewLine;

        private static string glider =
               "..X" + NL +
               "X.X" + NL +
               ".XX";

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

        public static string Get(string name)
        {
            var result = string.Empty;
            switch (name.ToLower())
            {
                case "glider":
                    result = glider;
                    break;
                case "pulsar":
                    result = pulsar;
                    break;
            }
            return result;
        }
    }
}
