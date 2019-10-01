using Microsoft.VisualStudio.TestTools.UnitTesting;
using LR3_UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TriangleExistingUnitTesting
    {
        [TestMethod]
        public void SumMoreThanSideLength()
        {
            Assert.IsTrue(Triangle.IsTriangleExisting(10, 20, 25));
        }

        [TestMethod]
        public void SumLessThanSideLength()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(2.5, 10, 7.5));
        }

        [TestMethod]
        public void SumEqualsSideLength()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(100, 200, 300));
        }

        [TestMethod]
        public void EquilateralTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangleExisting(15.6, 15.6, 15.6));
        }

        [TestMethod]
        public void IsoscelesTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangleExisting(40, 60, 40));
        }

        [TestMethod]
        public void ZeroLengthSide()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(30, 0, 12));
        }

        [TestMethod]
        public void ThreeZeroLengthSides()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(0, 0, 0));
        }

        [TestMethod]
        public void OneNegativeLengthSide()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(-2, 14, 7.5));
        }

        [TestMethod]
        public void TwoNegativeLengthSides()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(-34, 28, -32));
        }

        [TestMethod]
        public void ThreeNegativeLengthSides()
        {
            Assert.IsFalse(Triangle.IsTriangleExisting(-2, -4, -6));
        }
        
    }
}
