using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleGameOfLife;
using System;

namespace Tests
{
    [TestClass]
    public class ArgParserTests
    {
        //[TestMethod]
        //[Ignore]
        //public void MyTestMethod()
        //{
        //    //gol -w 50 -h 50
        //    var args = new string[] { "-w" ,"50", "-h", "50" };
        //    var parser = new ArgsParser(args);
        //    Assert.AreEqual(parser.World, InitialWorld.Random);
        //    Assert.IsTrue(parser.Size);
        //    Assert.AreEqual(parser.Width, 50);
        //    Assert.AreEqual(parser.Height, 50);
        //    Assert.IsFalse(parser.Fixed);
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToFew_Exception()
        {
            var args = new string[] { "-s" };
            var parser = new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToMany_Exception()
        {
            //gol -s pulsar -w 10 -h 10 -f oneTooMany

            var args = new string[] { "-s", "pulsar", "-w", "10", "-h", "10", "-f", "oneTooMany" };
            var parser = new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotStartWithAFlag_Exception()
        {
            var args = new string[] { "flagless", "value" };
            var parser = new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SuperfluousValue_Exception()
        {
            //gol -s glider pulsar
            var args = new string[] { "-s", "glider", "pulsar" };
            var parser = new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WNotFollewedByNunber_Exception()
        {
            var args = new string[] { "-s", "glider", "-w", "not a nat" };
            var parser = new ArgsParser(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WNotFollewedByPositiveNunber_Exception()
        {
            var args = new string[] { "-s", "glider", "-w", "-40" };
            var parser = new ArgsParser(args);
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

        //test: if -w is given, -h must be given also, and vice versa? if -s is random?
        //test: -f mustn't be followed by a non-flag
    }
}