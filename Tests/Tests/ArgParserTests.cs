using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleGameOfLife;
using System;

namespace Tests
{
    [TestClass]
    public class ArgParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToFew_Exception()
        {
            var args = new string[] { "-s" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToMany_Exception()
        {
            //gol -s pulsar -w 10 -h 10 -f oneTooMany

            var args = new string[] { "-s", "pulsar", "-w", "10", "-h", "10", "-f", "oneTooMany" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotStartWithAFlag_Exception()
        {
            var args = new string[] { "flagless", "value" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SuperfluousValue_Exception()
        {
            //gol -s glider pulsar
            var args = new string[] { "-s", "glider", "pulsar" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WNotFollewedByNunber_Exception()
        {
            var args = new string[] { "-s", "glider", "-w", "not a nat" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WNotFollewedByPositiveNunber_Exception()
        {
            var args = new string[] { "-s", "glider", "-w", "-40" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfRandom_BothWidthAndHeightMustBeGiven()
        {
            var args = new string[] { "-w", "40" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfRandom_WidthMustBeGreaterThanZero()
        {
            var args = new string[] { "-w", "0", "-h", "40" };
            new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfRandom_HeightMustBeGreaterThanZero()
        {
            var args = new string[] { "-w", "40", "-h", "0" };
            new ArgsParser(args);
        }

        [TestMethod]
        public void GivingW40_SetsWidthAs40()
        {
            var args = new string[] { "-s", "glider", "-w", "40" };
            var parser = new ArgsParser(args);
            Assert.AreEqual(40, parser.Width);
        }

        [TestMethod]
        public void OmittingW_WidthIs0()
        {
            var args = new string[] { "-s", "glider" };
            var parser = new ArgsParser(args);
            Assert.AreEqual(0, parser.Width);
        }

        [TestMethod]
        public void OmittingF_FixedIsFalse()
        {
            var args = new string[] { "-s", "glider" };
            var parser = new ArgsParser(args);
            Assert.IsFalse(parser.Fixed);
        }

        [TestMethod]
        public void GivingF_FixedIsTrue()
        {
            var args = new string[] { "-s", "glider", "-f" };
            var parser = new ArgsParser(args);
            Assert.IsTrue(parser.Fixed);
        }

        [TestMethod]
        public void OmittingS_SourceTypeIsRandom()
        {
            var args = new string[] { "-w", "40", "-h", "40" };
            var parser = new ArgsParser(args);
            Assert.AreEqual(InitialWorld.Random, parser.SourceType);
        }

        [TestMethod]
        public void SGivenPulsar_SourceTypeIsSample()
        {
            var args = new string[] { "-s", "pulsar" };
            var parser = new ArgsParser(args);
            Assert.AreEqual(InitialWorld.Sample, parser.SourceType);
        }

        [TestMethod]
        public void SStartingWithHash_SourceTypeIsRaw()
        {
            var args = new string[] { "-s", "#X.|.X" };
            var parser = new ArgsParser(args);
            Assert.AreEqual(InitialWorld.Raw, parser.SourceType);
        }

        [TestMethod]
        public void SGivenPulsar_SourceValIsPulsar()
        {
            var args = new string[] { "-s", "pulsar" };
            var parser = new ArgsParser(args);
            Assert.AreEqual("pulsar", parser.Source);
        }

        [TestMethod]
        public void SGivenRaw_RawHasCorrectFormat()
        {
            var args = new string[] { "-s", "#X.|.X|XX" };
            var parser = new ArgsParser(args);
            var actualFormat = "X." + Environment.NewLine + ".X" + Environment.NewLine + "XX";
            Assert.AreEqual(actualFormat, parser.Source);
        }
    }
}