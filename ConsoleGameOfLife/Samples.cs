using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameOfLife
{
    class Samples
    {
        private static string glider =
               ".......|" +
               "....X..|" +
               "..X.X..|" +
               "...XX..|" +
               "......."; 

        private static string pulsar =
                ".................|" +
                ".................|" +
                "....XXX...XXX....|" +
                ".................|" +
                "..X....X.X....X..|" +
                "..X....X.X....X..|" +
                "..X....X.X....X..|" +
                "....XXX...XXX....|" +
                ".................|" +
                "....XXX...XXX....|" +
                "..X....X.X....X..|" +
                "..X....X.X....X..|" +
                "..X....X.X....X..|" +
                ".................|" +
                "....XXX...XXX....|" +
                ".................|" +
                ".................";

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
                default:
                    throw new ArgumentException($"the given sample name {name} isn't available!");
            }
            return result;
        }
    }
}
