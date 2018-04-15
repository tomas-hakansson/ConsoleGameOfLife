using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NeighbourTests
    {
        [TestMethod]
        public void GetNeigbourStatesForCenterCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(1, 1);

            Assert.AreEqual(LivingNeighbours.C2, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForTopEdgeCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(1, 0);

            Assert.AreEqual(LivingNeighbours.C3, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForLeftEdgeCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(0, 1);

            Assert.AreEqual(LivingNeighbours.C1, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForBottomEdgeCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(1, 2);

            Assert.AreEqual(LivingNeighbours.C3, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForRightEdgeCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(2, 1);

            Assert.AreEqual(LivingNeighbours.C1, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForTopLeftEdgeCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(0, 0);

            Assert.AreEqual(LivingNeighbours.C2, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForBottomRightEdgeCell()
        {
            var strState =
                "OOO|" +
                "XXX|" +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState, false);

            var neighbour = new Neighbour(state);
            LivingNeighbours neighbourStates = neighbour.NrOfSuroundingLivingNeighbours(2, 2);

            Assert.AreEqual(LivingNeighbours.C2, neighbourStates);
        }

        [TestMethod]
        public void NeighboursAtOpposite_RightEdge_returns2()
        {
            var strInitial =
                "......|" +
                ".....X|" +
                ".....X|" +
                "......";

            var world = new World(strInitial);
            var neighbour = new Neighbour(world.CurrentWorld);
            Assert.AreEqual(2, neighbour.NrAtOpposite(0, 1));
        }

        [TestMethod]
        public void NeighboursAtOpposite_LeftEdge_returns2()
        {
            var strInitial =
                "......|" +
                "X.....|" +
                "X.....|" +
                "......";

            var world = new World(strInitial);
            var neighbour = new Neighbour(world.CurrentWorld);
            Assert.AreEqual(2, neighbour.NrAtOpposite(5, 1));
        }

        [TestMethod]
        public void NeighboursAtOpposite_TopEdge_returns2()
        {
            var strInitial =
                "......|" +
                "......|" +
                "......|" +
                "..XX..";

            var world = new World(strInitial);
            var neighbour = new Neighbour(world.CurrentWorld);
            Assert.AreEqual(2, neighbour.NrAtOpposite(2, 0));
        }

        [TestMethod]
        public void NeighboursAtOpposite_BottomEdge_returns2()
        {
            var strInitial =
                "..XX..|" +
                "......|" +
                "......|" +
                "......";

            var world = new World(strInitial);
            var neighbour = new Neighbour(world.CurrentWorld);
            Assert.AreEqual(2, neighbour.NrAtOpposite(2, 3));
        }

        [TestMethod]
        public void NeighboursAtOpposite_BottomRightCorner_returns3()
        {
            var strInitial =
                ".....X|" +
                "......|" +
                "......|" +
                "X....X";

            var world = new World(strInitial);
            var neighbour = new Neighbour(world.CurrentWorld);
            Assert.AreEqual(3, neighbour.NrAtOpposite(0, 0));
        }
    }
}
