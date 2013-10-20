using System;
using Android.Views;
using Android.Graphics.Drawables;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Graphics;

namespace Lotus {
	public abstract class ControlElement<T> : IDrawable, IControllable<MotionEvent>, IController<T> {
		public PointVector Center { get; set; }

		public double Radius { get; set; }

		public bool ShouldBeEjected { get; set; }

		private BitmapDrawable mDrawable;
		private List<IControllable<T>> mControllables = new List<IControllable<T>>();

		public ControlElement(Resources resources, int id, PointVector center, double radius) {
			Center = center;
			Radius = radius;
			ShouldBeEjected = false;
		
			mDrawable = new BitmapDrawable(resources, id, Center.X - Radius, Center.Y - Radius, Center.X + Radius, Center.Y + Radius);

			DrawThread.ControlLayer.Add(this);
		}

		public void Draw(Canvas canvas) {
			mDrawable.Draw(canvas);
		}

		public abstract void ReceiveControl(MotionEvent control);

		public void RegisterControllable(IControllable<T> controllable) {
			mControllables.Add(controllable);
		}

		public void SendControl(T control) {
			foreach (var controllable in mControllables) {
				controllable.ReceiveControl(control);
			}
		}
	}
}