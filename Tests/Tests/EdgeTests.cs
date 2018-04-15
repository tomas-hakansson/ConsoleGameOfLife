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
    }
}
