using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Edge
    {
        private List<List<Cell>> _currentWorld;
        private int _height;
        private int _width;

        public Edge(List<List<Cell>> currentWorld)
        {
            _currentWorld = currentWorld;
            _height = _currentWorld.Count - 1;
            _width = _currentWorld[0].Count - 1;
        }

        public bool TopHas3InRow() =>
            CheckLineFor3Consecutive(_currentWorld[0]);

        public bool BottomHas3InRow() =>
            CheckLineFor3Consecutive(_currentWorld.Last());

        public bool RightHas3InRow()
        {
            var index = _currentWorld[0].Count - 1;
            return CheckLineFor3Consecutive(ColumnToRow(index));
        }

        public bool LeftHas3InRow() =>
            CheckLineFor3Consecutive(ColumnToRow(0));

        public int NeighboursAtOpposite(int x, int y)
        {
            if (!IsAtEdge(x, y))
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

        private int GetNeighboursAtOppositeCorner(int x, int y)//todo: move all neigbour getting methods to other class.
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

        public bool IsAtEdge(int x, int y)
        {
            return
                x == 0 ||
                y == 0 ||
                x == _width ||
                y == _height;
        }

        private List<Cell> ColumnToRow(int index) =>
            _currentWorld.Select(c => c[index]).ToList();

        private bool CheckLineFor3Consecutive(List<Cell> line)
        {
            if (line.Count < 3)
                return false;
            var nr = 0;
            var previousState = State.Dead;
            foreach (Cell cell in line)
            {
                var thisState = cell.State;
                if (cellWasAndNowIs(State.Dead, State.Alive))
                {
                    nr = 1;
                    previousState = State.Alive;
                }
                else if (cellWasAndNowIs(State.Alive, State.Dead))
                {
                    nr = 0;
                    previousState = State.Dead;
                }
                else if (cellWasAndNowIs(State.Alive, State.Alive))
                    nr++;

                bool cellWasAndNowIs(State past, State current) =>
                    previousState == past && cell.State == current;

                if (nr >= 3)
                    return true;
            }
            return false;
        }
    }
}