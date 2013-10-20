using System;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Graphics.Drawables;

namespace Lotus {
	public class Ship : MovableImage {
		private Ship mTarget;

		public Ship(Resources resources, int id, double maxVelocity, double maxAcceleration, double angularVelocity) : base(BitmapDrawable.Create(resources, id)) {
			Velocity.Max = maxVelocity;
			MaxAcceleration = maxAcceleration;
			AngularVelocity = angularVelocity;
		}

		public Ship GetTarget() {
			return mTarget;
		}

		public void SetTarget(Ship target) {
			mTarget = target;
		}
	}
}