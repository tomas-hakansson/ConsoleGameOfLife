using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    {
        public List<List<Cell>> CurrentWorld;

        public World(List<List<Cell>> CurrentWorld)
        {
            this.CurrentWorld = CurrentWorld;
        }

        public World(string initialWorld)
        {
            this.CurrentWorld = HelperMethods.StringToMatrix(initialWorld);
        }

        public World NextGeneration()
        {
            var extendWorld = new ExtendWorld(CurrentWorld);

            CurrentWorld = extendWorld.ExtendingWorld();

            var extendedWorld = HelperMethods.GetLivingNeighbours(CurrentWorld);

            //wraparoundWorld...

            var nextGeneration = GetNewState(extendedWorld);

            nextGeneration = HelperMethods.GetLivingNeighbours(nextGeneration);

            return new World(nextGeneration);
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
