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

        public List<List<Cell>> Extending()
        {
            var edge = new Edge(CurrentWorld);
            if (edge.TopHas3LivingInARow())
                AddTopRow();
            if (edge.BottomHas3LivingInARow())
                AddBottomEdge();
            if (edge.RightHas3LivingInARow())
                AddRightEdge();
            if (edge.LeftHas3LivingInARow())
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
    }
}
