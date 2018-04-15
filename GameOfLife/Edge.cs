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

        public bool IsAtEdge(int x, int y)
        {
            return
                x == 0 ||
                y == 0 ||
                x == _width ||
                y == _height;
        }

        public bool TopHas3LivingInARow() =>
            CheckLineFor3ConsecutiveLiving(_currentWorld[0]);

        public bool BottomHas3LivingInARow() =>
            CheckLineFor3ConsecutiveLiving(_currentWorld.Last());

        public bool RightHas3LivingInARow()
        {
            var index = _currentWorld[0].Count - 1;
            return CheckLineFor3ConsecutiveLiving(ColumnToRow(index));
        }

        public bool LeftHas3LivingInARow() =>
            CheckLineFor3ConsecutiveLiving(ColumnToRow(0));

        private List<Cell> ColumnToRow(int index) =>
            _currentWorld.Select(c => c[index]).ToList();

        private bool CheckLineFor3ConsecutiveLiving(List<Cell> line)
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