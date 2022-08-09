using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAreaClassLibrary
{

    public class Triangle : ITriangle
    {
        private double eps = Constants.CalcAccuracy;
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < eps)
                throw new ArgumentException("Неверно указана сторона.", nameof(sideA));

            if (sideB < eps)
                throw new ArgumentException("Неверно указана сторона.", nameof(sideB));

            if (sideC < eps)
                throw new ArgumentException("Неверно указана сторона.", nameof(sideC));

            var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
            var perimeter = sideA + sideB + sideC;
            if ((perimeter - maxSide) - maxSide < Constants.CalcAccuracy)
                throw new ArgumentException("Наибольшая сторона треугольника должна быть меньше суммы других сторон");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }

        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        private readonly Lazy<bool> _isRightTriangle;
        public bool IsRightTriangle => _isRightTriangle.Value;

        private bool GetIsRightTriangle()
        {
            double maxSide = SideA, b = SideB, c = SideC;
            if (b - maxSide > Constants.CalcAccuracy)
                Utils.Swap(ref maxSide, ref b);

            if (c - maxSide > Constants.CalcAccuracy)
                Utils.Swap(ref maxSide, ref c);

            return Math.Abs(Math.Pow(maxSide, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalcAccuracy;
        }

        public double GetSquare()
        {
            var halfP = (SideA + SideB + SideC) / 2d;
            var square = Math.Sqrt(
                halfP
                * (halfP - SideA)
                * (halfP - SideB)
                * (halfP - SideC)
            );

            return square;
        }
    }
}
