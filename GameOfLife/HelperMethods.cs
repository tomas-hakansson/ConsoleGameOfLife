using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class HelperMethods
    {
        public static List<List<Cell>> GetLivingNeighbours(List<List<Cell>> nextGeneration)
        {
            var x = 0;
            var y = 0;
            foreach (var rows in nextGeneration)
            {
                foreach (var currentCell in rows)
                {
                    var currentCellsLivingNeighbours = NrOfLivingNeghbours(nextGeneration, x, y);
                    currentCell.LivingNeighbours = currentCellsLivingNeighbours;
                    x++;
                }
                x = 0;
                y++;
            }

            return nextGeneration;
        }

        public static LivingNeighbours NrOfLivingNeghbours(List<List<Cell>> state, int xOrigin, int yOrigin)
        {
            var nr = 0;

            var yMin = yOrigin == 0 ? 0 : yOrigin - 1;
            var xMin = xOrigin == 0 ? 0 : xOrigin - 1;
            var yMax = yOrigin == state.Count - 1 ? yOrigin : yOrigin + 1;
            var xMax = xOrigin == state[0].Count - 1 ? xOrigin : xOrigin + 1;

            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    var currentCell = state[y][x];
                    if (currentCell.State == State.Alive)
                        nr++;
                }
            }

            if (state[yOrigin][xOrigin].State == State.Alive)
                nr--;

            return (LivingNeighbours)nr;
        }

        public static List<List<Cell>> StringToMatrix(string source)
        {
            var world = new List<List<Cell>>();

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
            return GetLivingNeighbours(world);
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
