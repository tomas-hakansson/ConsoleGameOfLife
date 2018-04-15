using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void ABlinker_blinks()
        {
            var strInitial =
                "OOO|" +
                "XXX|" +
                "OOO";

            var world = new World(strInitial);

            var nextGeneration = world.NextGeneration();

            var strNext =
                "OXO|" +
                "OXO|" +
                "OXO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, false);

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
                "OOO|" +
                "XXX|" +
                "OOO";

            var currentGeneration = HelperMethods.StringToMatrix(strInitial, false);
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
                "OOXO|" +
                "XOXO|" +
                "OXXO";

            var world = new World(strInitial);

            var nextGeneration = world.NextGeneration();

            var strNext =
                "OXOO|" +
                "OOXX|" +
                "OXXO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, false);

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
                "OOXO|" +
                "XOXO|" +
                "OXXO";

            var world = new World(strInitial);

            var nextGeneration = world.NextGeneration().NextGeneration();

            var strNext =
                "OOXO|" +
                "OOOX|" +
                "OXXX";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, false);

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
                "X|" +
                "X|" +
                "X";

            var world = new World(strInitial);

            var actualGeneration = world.NextGeneration();

            var strNext =
                "OOO|" +
                "XXX|" +
                "OOO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, false);



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
                "OXO|" +
                "OXO|" +
                "OXO";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, false);



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
        public void Wrap_glider_Test1()
        {
            var strInitial =
                "........|" +
                ".......X|" +
                ".....X.X|" +
                "......XX|" +
                "........";

            var world = new World(strInitial, true);

            var actualGeneration = world.NextGeneration();

            var strNext =
                "........|" +
                "......X.|" +
                "X......X|" +
                "......XX|" +
                "........";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, true);

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
        public void Wrap_glider_Test2()
        {
            var strInitial =
                "X.....XX|" +
                "........|" +
                "........|" +
                ".......X|" +
                "X.......";

            var world = new World(strInitial, true);

            var actualGeneration = world.NextGeneration();

            var strNext =
                "X......X|" +
                ".......X|" +
                "........|" +
                "........|" +
                "X.....X.";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, true);

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
        public void Wrap_glider_Test3()
        {
            var strInitial =
                "......XX|" +
                "........|" +
                "........|" +
                ".......X|" +
                ".....X.X";

            var world = new World(strInitial, true);

            var actualGeneration = world.NextGeneration();

            var strNext =
                "......XX|" +
                "........|" +
                "........|" +
                "......X.|" +
                "X......X";

            var expectedGeneration = HelperMethods.StringToMatrix(strNext, true);

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