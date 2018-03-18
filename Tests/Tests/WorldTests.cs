using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class WorldTests
    {
        string NL = Environment.NewLine;

        [TestMethod]
        public void ABlinker_blinks()
        {
            var strInitial =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var world = new World(strInitial);

            var nextGeneration = world.NextGeneration();

            var strNext =
                "OXO" + NL +
                "OXO" + NL +
                "OXO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext);

            if (nextGeneration.CurrentWorld.Count == expectedGeneration.Count)
            {
                for (int i = 0; i < expectedGeneration.Count; i++)
                {
                    CollectionAssert.AreEqual(expectedGeneration[i], nextGeneration.CurrentWorld[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }

        [TestMethod]
        public void ABlinker_blinksTwice()
        {
            var strInitial =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var currentGeneration = HelperMethods.StringToMatrix(strInitial);
            var world = new World(currentGeneration);

            var nextGeneration = world.NextGeneration().NextGeneration();
            
            if (nextGeneration.CurrentWorld.Count == currentGeneration.Count)
            {
                for (int i = 0; i < currentGeneration.Count; i++)
                {
                    CollectionAssert.AreEqual(currentGeneration[i], nextGeneration.CurrentWorld[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }

        [TestMethod]
        public void AGlider_Glides()
        {
            var strInitial =
                "OOXO" + NL +
                "XOXO" + NL +
                "OXXO";

            var world = new World(strInitial);

            var nextGeneration = world.NextGeneration();

            var strNext =
                "OXOO" + NL +
                "OOXX" + NL +
                "OXXO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext);

            if (nextGeneration.CurrentWorld.Count == expectedGeneration.Count)
            {
                for (int i = 0; i < expectedGeneration.Count; i++)
                {
                    CollectionAssert.AreEqual(expectedGeneration[i], nextGeneration.CurrentWorld[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }

        [TestMethod]
        public void AGlider_GlidesTwice()
        {
            
            var strInitial =
                "OOXO" + NL +
                "XOXO" + NL +
                "OXXO";

            var world = new World(strInitial);

            var nextGeneration = world.NextGeneration().NextGeneration();

            var strNext =
                "OOXO" + NL +
                "OOOX" + NL +
                "OXXX";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext);

            if (nextGeneration.CurrentWorld.Count == expectedGeneration.Count)
            {
                for (int i = 0; i < expectedGeneration.Count; i++)
                {
                    CollectionAssert.AreEqual(expectedGeneration[i], nextGeneration.CurrentWorld[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }

        [TestMethod]
        public void TheWorldCanGrow_LeftAndRight()
        {
            var strInitial =
                "X" + NL +
                "X" + NL +
                "X";

            var world = new World(strInitial);

            var actualGeneration = world.NextGeneration();

            var strNext =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext);



            if (actualGeneration.CurrentWorld.Count == expectedGeneration.Count)
            {
                for (int i = 0; i < expectedGeneration.Count; i++)
                {
                    CollectionAssert.AreEqual(expectedGeneration[i], actualGeneration.CurrentWorld[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }

        [TestMethod]
        public void TheWorldCanGrow_UpAndDown()
        {
            var strInitial = "XXX";

            var world = new World(strInitial);

            var actualGeneration = world.NextGeneration();

            var strNext =
                "OXO" + NL +
                "OXO" + NL +
                "OXO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext);



            if (actualGeneration.CurrentWorld.Count == expectedGeneration.Count)
            {
                for (int i = 0; i < expectedGeneration.Count; i++)
                {
                    CollectionAssert.AreEqual(expectedGeneration[i], actualGeneration.CurrentWorld[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }
    }
}