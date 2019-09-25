using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LR3_UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumMoreThanSideLength()
        {
            double x = 10, y = 20, z = 25;
            bool expected = true;
            
            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumLessThanSideLength()
        {
            double x = 2.5, y = 10, z = 7.5;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumEqualsSideLength()
        {
            double x = 100, y = 200, z = 300;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EquilateralTriangle()
        {
            double x = 15.6, y = 15.6, z = 15.6;
            bool expected = true;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsoscelesTriangle()
        {
            double x = 40, y = 60, z = 40;
            bool expected = true;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZeroLengthSide()
        {
            double x = 30, y = 0, z = 12;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeZeroLengthSides()
        {
            double x = 0, y = 0, z = 0;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneNegativeLengthSide()
        {
            double x = -2, y = 14, z = 7.5;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoNegativeLengthSides()
        {
            double x = -34, y = 28, z = -32;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeNegativeLengthSides()
        {
            double x = -2, y = -4, z = -6;
            bool expected = false;

            bool actual = Triangle.CheckExisting(x, y, z);

            Assert.AreEqual(expected, actual);
        }
        
    }
}
