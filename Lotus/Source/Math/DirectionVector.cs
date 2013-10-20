using System;

namespace Lotus {
	public class DirectionVector : IVector {
		public double Direction { get; set; }

		public double Magnitude { get; set; }

		public DirectionVector() {
			Direction = 0;
			Magnitude = 0;
		}

		public double GetMagnitude() {
			return Magnitude;
		}

		public double GetDirection() {
			return Direction;
		}

		public double GetX() {
			return Math.Cos(Direction * Math.PI / 180) * Magnitude;
		}

		public double GetY() {
			return Math.Sin(Direction * Math.PI / 180) * Magnitude;
		}

		public void OffsetDirection(double offset) {
			Direction += offset;

			if (Direction < 0) {
				Direction += 360;
			} else if (Direction > 360) {
				Direction -= 360;
			}
		}
	}
}