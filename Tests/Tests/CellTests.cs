using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void WhenAliveAndLessThan2LivingNeighbours_NextGenerationIsDead()
        {
            var cell = new Cell(State.Alive, LivingNeighbours.C1);

            var nextState = cell.NextState();

            Assert.AreEqual(State.Dead, nextState);
        }

        [TestMethod]
        public void WhenAliveAnd2LivingNeighbours_NextGenerationIsAlive()
        {
            var cell = new Cell(State.Alive, LivingNeighbours.C2);

            var nextState = cell.NextState();

            Assert.AreEqual(State.Alive, nextState);
        }

        [TestMethod]
        public void WhenAliveAndMoreThan3LivingNeighbours_NextGenerationIsDead()
        {
            var cell = new Cell(State.Alive, LivingNeighbours.C4);

            var nextState = cell.NextState();

            Assert.AreEqual(State.Dead, nextState);
        }

        [TestMethod]
        public void WhenDeadAnd3LivingNeighbours_NextGenerationIsAlive()
        {
            var cell = new Cell(State.Dead, LivingNeighbours.C3);

            var nextState = cell.NextState();

            Assert.AreEqual(State.Alive, nextState);
        }

        [TestMethod]
        public void TwoCellsWithSameConstructorValue_AreEqual()
        {
            var cell1 = new Cell(State.Alive, LivingNeighbours.C0);
            var cell2 = new Cell(State.Alive, LivingNeighbours.C0);

            Assert.AreEqual(cell1, cell2);
        }
    }
}
