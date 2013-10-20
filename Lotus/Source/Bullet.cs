using System;
using Android.Graphics.Drawables;
using Android.Content.Res;

namespace Lotus {
	public class Bullet : MovableImage {
		public Bullet(BitmapDrawable drawable, MaxPointVector velocity) : base(drawable) {
			Velocity = velocity;
		}
	}
}