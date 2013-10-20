using System;

namespace Lotus {
	public class Movable : IUpdatable, IControllable<DirectionVector> {
		public PointVector Position { get; set; }

		public MaxPointVector Velocity { get; set; }

		public DirectionVector Acceleration { get; set; }

		public double MaxAcceleration { get; set; }

		public double AngularVelocity { get; set; }

		public double Bearing { get; set; }

		public bool ShouldBeEjected { get; set; }

		public Movable() {
			Position = new PointVector();
			Velocity = new MaxPointVector();
			Acceleration = new DirectionVector();
			MaxAcceleration = 0;
			AngularVelocity = 0;
			Bearing = 0;
			ShouldBeEjected = false;

			UpdateThread.Main.Add(this);
		}

		public virtual void Update(double timeElapsed) {
			var bearingOffset = Bearing - Acceleration.Direction;
			if (bearingOffset <= -180) {
				bearingOffset += 360;
			} else if (bearingOffset > 180) {
				bearingOffset -= 360;
			}

			if (bearingOffset < 0) {
				Acceleration.OffsetDirection(Math.Max(-timeElapsed * AngularVelocity, bearingOffset));
			} else if (bearingOffset > 0) {
				Acceleration.OffsetDirection(Math.Min(timeElapsed * AngularVelocity, bearingOffset));
			}

			Velocity.Add(timeElapsed * Acceleration.GetX(), timeElapsed * Acceleration.GetY());
			Position.Add(timeElapsed * Velocity.GetX(), timeElapsed * Velocity.GetY());
		}

		public void ReceiveControl(DirectionVector control) {
			Bearing = control.Direction;
			Acceleration.Magnitude = MaxAcceleration * control.GetMagnitude();
		}
	}
}