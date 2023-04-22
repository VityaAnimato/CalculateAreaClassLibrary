namespace CalculateAreaClassLibrary.Tests
{
    [TestClass]
    public class TriangleTests
    {
        private readonly double eps = Constants.CalcAccuracy;

        [TestMethod]
        public void InitTriangleWithErrorTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(-1d, 1d, 1d));
        }

        [TestMethod]
        public void InitTriangleTest()
        {
            // arrange
            double a = 3d, b = 4d, c = 5d;

            // act
            var triangle = new Triangle(a, b, c);

            // assert
            Assert.IsNotNull(triangle);
            Assert.IsTrue(Math.Abs(triangle.SideA - a) < eps);
            Assert.IsTrue(Math.Abs(triangle.SideB - b) < eps);
            Assert.IsTrue(Math.Abs(triangle.SideC - c) < eps);
        }

        [TestMethod]
        public void GetSquareTest()
        {
            // arrange
            double a = 3d, b = 4d, c = 5d;
            double result = 6d;
            var triangle = new Triangle(a, b, c);

            // act
            var square = triangle?.GetSquare();

            // assert
            Assert.IsNotNull(square);
            Assert.IsTrue(Math.Abs(square.Value - result) < eps);
        }

        [TestMethod]
        public void InitNotTriangleTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 1, 4));
        }


        [TestMethod]
        public bool NotRightTriangle()
        {
            // arrange
            var triangle = new Triangle(3, 4, 3);

            // act
            var isRight = triangle.IsRightTriangle;

            // assert 
            return isRight;
        }
    }
}
