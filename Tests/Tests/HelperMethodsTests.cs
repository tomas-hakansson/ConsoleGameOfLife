﻿using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HelperMethodsTests
    {
        string NL = Environment.NewLine;

        [TestMethod]
        public void GetNeigbourStatesForCenterCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 1, 1);

            Assert.AreEqual(LivingNeighbours.C2, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForTopEdgeCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 1, 0);

            Assert.AreEqual(LivingNeighbours.C3, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForLeftEdgeCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 0, 1);

            Assert.AreEqual(LivingNeighbours.C1, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForBottomEdgeCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 1, 2);

            Assert.AreEqual(LivingNeighbours.C3, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForRightEdgeCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 2, 1);

            Assert.AreEqual(LivingNeighbours.C1, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForTopLeftEdgeCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 0, 0);

            Assert.AreEqual(LivingNeighbours.C2, neighbourStates);
        }

        [TestMethod]
        public void GetNeigbourStatesForBottomRightEdgeCell()
        {
            var strState =
                "OOO" + NL +
                "XXX" + NL +
                "OOO";

            var state = HelperMethods.StringToMatrix(strState);

            LivingNeighbours neighbourStates = HelperMethods.NrOfLivingNeghbours(state, 2, 2);

            Assert.AreEqual(LivingNeighbours.C2, neighbourStates);
        }

        [TestMethod]
        public void StringBlinker_toListOfLists()
        {
            var strGlider =
                "OOX" + NL +
                "XOX" + NL +
                "OXX";

            var actual = HelperMethods.StringToMatrix(strGlider);

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

            var expected =
                "..X" + NL +
                "X.X" + NL +
                ".XX" + NL;

            Assert.AreEqual(expected, actual);
        }
    }
}