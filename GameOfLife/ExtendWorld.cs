using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class ExtendWorld
    {
        private List<List<Cell>> CurrentWorld;
        
        public ExtendWorld(List<List<Cell>> CurrentWorld)
        {
            this.CurrentWorld = CurrentWorld;
        }

        public List<List<Cell>> ExtendingWorld()
        {

            if (TopEdgeHas3InRow())
                AddTopRow();
            if (BottomEdgeHas3InRow())
                AddBottomEdge();
            if (RightEdgeHas3InRow())
                AddRightEdge();
            if (LeftEdgeHase3InRow())
                AddLeftEdge();

            return CurrentWorld;
        }

        private void AddTopRow()
        {
            var newWorld = new List<List<Cell>>() { CreateDeadRow() };
            CurrentWorld = newWorld.Concat(CurrentWorld).ToList();
        }

        private void AddBottomEdge() =>
            CurrentWorld.Add(CreateDeadRow());

        private List<Cell> CreateDeadRow()
        {
            var width = CurrentWorld[0].Count;
            return Enumerable.Range(1, width).Select(c => new Cell(State.Dead)).ToList();
        }

        private void AddRightEdge() =>
            CurrentWorld.ForEach(row => row.Add(new Cell(State.Dead)));

        private void AddLeftEdge()
        {
            var newWorld = new List<List<Cell>>();

            foreach (var row in CurrentWorld)
            {
                var newRow = new List<Cell>() { new Cell(State.Dead) };
                newWorld.Add(newRow.Concat(row).ToList());
            }
            CurrentWorld = newWorld;
        }

        private bool TopEdgeHas3InRow() =>
            CheckLineFor3Consecutive(CurrentWorld[0]);

        private bool BottomEdgeHas3InRow() =>
            CheckLineFor3Consecutive(CurrentWorld.Last());

        private bool RightEdgeHas3InRow()
        {
            var index = CurrentWorld[0].Count - 1;
            return CheckLineFor3Consecutive(ColumnToRow(index));
        }

        private bool LeftEdgeHase3InRow() =>
            CheckLineFor3Consecutive(ColumnToRow(0));

        private List<Cell> ColumnToRow(int index) =>
            CurrentWorld.Select(c => c[index]).ToList();

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
