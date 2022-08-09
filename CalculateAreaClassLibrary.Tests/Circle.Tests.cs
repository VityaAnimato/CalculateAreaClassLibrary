namespace CalculateAreaClassLibrary.Tests
{
    [TestClass]
    public class CircleTests
    {
        private readonly double eps = CalculateAreaClassLibrary.Constants.CalcAccuracy;

        [TestMethod]
        public void GetSquare_CircleRadius_1_Returns_Pi()
        {
            var circle = new Circle(1d);
            var expected = Math.PI;
            var actual = circle.GetSquare();
            Assert.AreEqual(expected, actual);
        }

		[TestMethod]
		public void ZeroRadiusTest()
		{
			Assert.ThrowsException<ArgumentException>(() => new Circle(0d));
		}


		[TestMethod]
		public void NegativeRadiusTest()
		{
			Assert.ThrowsException<ArgumentException>(() => new Circle(-1d));
		}


		[TestMethod]
		public void LessMinRadiusTest()
		{
			Assert.ThrowsException<ArgumentException>(() => new Circle(Circle.MinRadius - 1e7));
		}


		[TestMethod]
		public void GetSquareTest()
		{
			var radius = 5;
			var circle = new Circle(radius);
			var expected = Math.PI * Math.Pow(radius, 2d);

			var square = circle.GetSquare();

			Assert.IsTrue(Math.Abs(square - expected) < eps);
		}
	}
}