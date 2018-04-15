using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Neighbour
    {
        private readonly List<List<Cell>> _currentWorld;
        private int _height;
        private int _width;

        public Neighbour(List<List<Cell>> currentWorld)
        {
            _currentWorld = currentWorld;
            _height = _currentWorld.Count - 1;
            _width = _currentWorld[0].Count - 1;
        }
        public List<List<Cell>> UpdateWorldWithLivingNeighbours(bool fixedSize = false)
        {
            var x = 0;
            var y = 0;
            var nextGeneration = _currentWorld;
            foreach (var rows in nextGeneration)
            {
                foreach (var currentCell in rows)
                {
                    currentCell.LivingNeighbours = NrOfSuroundingLivingNeighbours(x, y);
                    if (fixedSize)
                    {
                        currentCell.LivingNeighbours += NrAtOpposite(x, y);
                    }
                    x++;
                }
                x = 0;
                y++;
            }

            return nextGeneration;
        }

        public LivingNeighbours NrOfSuroundingLivingNeighbours(int xOrigin, int yOrigin)
        {
            var nr = 0;

            var yMin = yOrigin == 0 ? 0 : yOrigin - 1;
            var xMin = xOrigin == 0 ? 0 : xOrigin - 1;
            var yMax = yOrigin == _currentWorld.Count - 1 ? yOrigin : yOrigin + 1;
            var xMax = xOrigin == _currentWorld[0].Count - 1 ? xOrigin : xOrigin + 1;

            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    var currentCell = _currentWorld[y][x];
                    if (currentCell.State == State.Alive)
                        nr++;
                }
            }

            if (_currentWorld[yOrigin][xOrigin].State == State.Alive)
                nr--;

            return (LivingNeighbours)nr;
        }

        public int NrAtOpposite(int x, int y)
        {
            var edge = new Edge(_currentWorld);
            if (!edge.IsAtEdge(x, y))
                return 0;

            var nr = 0;
            if (x == 0)
                nr += GetNeighboursOfMax3Column(_width, y);
            if (x == _width)
                nr += GetNeighboursOfMax3Column(0, y);
            if (y == 0)
                nr += GetNeighboursOfMax3Row(x, _height);
            if (y == _height)
                nr += GetNeighboursOfMax3Row(x, 0);
            nr += GetNeighboursAtOppositeCorner(x, y);
            return nr;
        }

        private int GetNeighboursAtOppositeCorner(int x, int y)
        {
            if (x == 0 && y == 0 && CellIsAlive(_width, _height))
                return 1;
            if (x == 0 && y == _height && CellIsAlive(_width, 0))
                return 1;
            if (x == _width && y == 0 && CellIsAlive(0, _height))
                return 1;
            if (x == _width && y == _height && CellIsAlive(0, 0))
                return 1;
            return 0;
        }

        private int GetNeighboursOfMax3Column(int column, int centerHeight)
        {
            var fromY = centerHeight == 0 ? 0 : centerHeight - 1;
            var toY = centerHeight == _currentWorld.Count - 1 ? centerHeight : centerHeight + 1;

            var neighbours = 0;
            for (int y = fromY; y <= toY; y++)
            {
                if (CellIsAlive(column, y))
                    neighbours++;
            }

            return neighbours;
        }

        private int GetNeighboursOfMax3Row(int centerWidth, int row)
        {
            var fromX = centerWidth == 0 ? centerWidth : centerWidth - 1;
            var toX = centerWidth == _currentWorld[0].Count - 1 ? centerWidth : centerWidth + 1;

            var neighbours = 0;
            for (int x = fromX; x <= toX; x++)
            {
                if (CellIsAlive(x, row))
                    neighbours++;
            }

            return neighbours;
        }

        private bool CellIsAlive(int x, int y)
        {
            return _currentWorld[y][x].State == State.Alive;
        }
    }
}
