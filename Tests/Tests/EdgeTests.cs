using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Tests
{
    [TestClass]
    public class EdgeTests
    {
        [TestMethod]
        public void IsAtEdgeReturnsTrue_WhenAtBottomEdge()
        {
            var strInitial =
                "......|" +
                "......|" +
                "......|" +
                "....X.";

            var world = new World(strInitial);
            var edge = new Edge(world.CurrentWorld);

            Assert.IsTrue(edge.IsAtEdge(4, 3));
        }

        [TestMethod]
        public void IsAtEdgeReturnsTrue_WhenAtRightEdge()
        {
            var strInitial =
                "......|" +
                ".....X|" +
                "......|" +
                "......";

            var world = new World(strInitial);
            var edge = new Edge(world.CurrentWorld);

            Assert.IsTrue(edge.IsAtEdge(5, 1));
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
            var edge = new Edge(world.CurrentWorld);
            Assert.AreEqual(2, edge.NeighboursAtOpposite(0, 1));
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
            var edge = new Edge(world.CurrentWorld);
            Assert.AreEqual(2, edge.NeighboursAtOpposite(5, 1));
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
            var edge = new Edge(world.CurrentWorld);
            Assert.AreEqual(2, edge.NeighboursAtOpposite(2, 0));
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
            var edge = new Edge(world.CurrentWorld);
            Assert.AreEqual(2, edge.NeighboursAtOpposite(2, 3));
        }
    }
}
