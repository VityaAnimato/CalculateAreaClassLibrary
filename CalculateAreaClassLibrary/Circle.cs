namespace CalculateAreaClassLibrary
{
	public class Circle : IFigure
	{
		public const double MinRadius = 1e-6;

		public Circle(double radius)
		{
			if (radius - MinRadius < Constants.CalcAccuracy)
				throw new ArgumentException("Неверно указан радиус круга.", nameof(radius));
			Radius = radius;
		}

		public double Radius { get; }

		public double GetSquare()
		{
			return Math.PI * Math.Pow(Radius, 2d);
		}
	}
}