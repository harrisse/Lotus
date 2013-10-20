using System;

namespace Lotus {
	public class PointVector : IVector {
		public double X { get; set; }

		public double Y { get; set; }

		public PointVector() {
			X = 0;
			Y = 0;
		}

		public virtual void Add(double x, double y) {
			X += x;
			Y += y;
		}

		public double GetMagnitude() {
			return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
		}

		public double GetDirection() {
			return Math.Atan2(Y, X) * 180 / Math.PI;
		}

		public double GetX() {
			return X;
		}

		public double GetY() {
			return Y;
		}

		public DirectionVector ToDirectionVector() {
			return new DirectionVector {
				Direction = GetDirection(),
				Magnitude = GetMagnitude()
			};
		}
	}
}