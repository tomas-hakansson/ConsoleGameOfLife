using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class HelperMethods
    {
        public static List<List<Cell>> StringToMatrix(string source, bool fixedSize)
        {
            var world = new List<List<Cell>>();
            source = source.Replace("|", Environment.NewLine);
            var strRows = source.Split(new char[] { }).Where(s => s != "");
            foreach (var strRow in strRows)
            {
                var row = new List<Cell>();

                var strCells = strRow.Select(i => new string(i, 1)).ToList();
                foreach (var strCell in strCells)
                {
                    if (strCell == "X")
                        row.Add(new Cell(State.Alive));
                    else
                        row.Add(new Cell(State.Dead));
                }
                world.Add(row);
            }
            var neighbour = new Neighbour(world);
            return neighbour.UpdateWorldWithLivingNeighbours(fixedSize);
        }

        public static string MatrixToString(List<List<Cell>> matrix)
        {
            var result = string.Empty;

            foreach (var rows in matrix)
            {
                foreach (var cell in rows)
                {
                    if (cell.State == State.Alive)
                        result += "X";
                    else
                        result += ".";
                }
                result += Environment.NewLine;
            }
            return result;
        }

        public static string GenerateRandomWorld(int width, int height)
        {
            Random random = new Random();
            var world = string.Empty;
            foreach (var row in Enumerable.Range(0, width))
            {
                foreach (var cell in Enumerable.Range(0, height))
                {
                    var binary = random.Next(0, 2);
                    if (binary == 1)
                        world += "X";
                    else
                        world += ".";
                }
                world += Environment.NewLine;
            }

            return world;
        }
    }
}
