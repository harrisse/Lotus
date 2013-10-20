using System;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Views;
using Android.Content;
using Android.OS;

namespace Lotus {
	public class ControlButton : ControlElement<bool> {
		public ControlButton(Resources resources, PointVector center, double radius) : base(resources, Resource.Drawable.controlPad, center, radius) {
		}

		public override void ReceiveControl(MotionEvent e) {
			var control = new PointVector {
				X = e.GetX() - Center.X,
				Y = e.GetY() - Center.Y
			}.ToDirectionVector();

			SendControl(control.Magnitude < Radius && e.Action != MotionEventActions.Up);
		}
	}
}