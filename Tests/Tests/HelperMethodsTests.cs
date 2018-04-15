using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HelperMethodsTests
    {
        [TestMethod]
        public void StringBlinker_toListOfLists()
        {
            var strGlider =
                "OOX|" +
                "XOX|" +
                "OXX";

            var actual = HelperMethods.StringToMatrix(strGlider, false);

            var expected = new List<List<Cell>>
            {
                new List<Cell> { new Cell(State.Dead, LivingNeighbours.C1), new Cell(State.Dead, LivingNeighbours.C3), new Cell(State.Alive, LivingNeighbours.C1)},
                new List<Cell> { new Cell(State.Alive, LivingNeighbours.C1), new Cell(State.Dead, LivingNeighbours.C5), new Cell(State.Alive, LivingNeighbours.C3)},
                new List<Cell> { new Cell(State.Dead, LivingNeighbours.C2), new Cell(State.Alive, LivingNeighbours.C3), new Cell(State.Alive, LivingNeighbours.C2)}
            };

            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    CollectionAssert.AreEqual(expected[i], actual[i]);
                }
            }
            else
                Assert.Fail("the two collections have different counts");
        }

        [TestMethod]
        public void ListOfLists_toStringBlinker()
        {
            var lstGlider = new List<List<Cell>>
            {
                new List<Cell> { new Cell(State.Dead, LivingNeighbours.C1), new Cell(State.Dead, LivingNeighbours.C3), new Cell(State.Alive, LivingNeighbours.C1)},
                new List<Cell> { new Cell(State.Alive, LivingNeighbours.C1), new Cell(State.Dead, LivingNeighbours.C5), new Cell(State.Alive, LivingNeighbours.C3)},
                new List<Cell> { new Cell(State.Dead, LivingNeighbours.C2), new Cell(State.Alive, LivingNeighbours.C3), new Cell(State.Alive, LivingNeighbours.C2)}
            };

            var actual = HelperMethods.MatrixToString(lstGlider);

            var NL = Environment.NewLine;
            var expected =
                "..X" + NL +
                "X.X" + NL +
                ".XX" + NL;

            Assert.AreEqual(expected, actual);
        }
    }
}