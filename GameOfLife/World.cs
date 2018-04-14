using System.Collections.Generic;

namespace GameOfLife
{
    public class World
    {
        public List<List<Cell>> CurrentWorld;
        private bool FixedSize;

        public World(List<List<Cell>> CurrentWorld, bool fixedSize = false)
        {
            this.CurrentWorld = HelperMethods.GetLivingNeighbours(CurrentWorld, fixedSize);
            this.FixedSize = fixedSize;
        }

        public World(string initialWorld, bool fixedSize = false)
        {
            this.CurrentWorld = HelperMethods.StringToMatrix(initialWorld, fixedSize);
            this.FixedSize = fixedSize;
        }

        public World NextGeneration()
        {
            if (!FixedSize)
            {
                var extendWorld = new ExtendWorld(CurrentWorld);
                CurrentWorld = extendWorld.Extending();
                //because the extended world has no neighbour information.
                CurrentWorld = HelperMethods.GetLivingNeighbours(CurrentWorld);
            }

            var nextGeneration = GetNewState(CurrentWorld);

            return new World(nextGeneration, FixedSize);
        }

        private List<List<Cell>> GetNewState(List<List<Cell>> oldState)
        {
            var nextGeneration = new List<List<Cell>>();

            foreach (var rows in oldState)
            {
                var newRow = new List<Cell>();
                foreach (var currentCell in rows)
                {
                    var nextState = currentCell.NextState();
                    newRow.Add(new Cell(nextState));
                }
                nextGeneration.Add(newRow);
            }

            return nextGeneration;
        }
    }
}
