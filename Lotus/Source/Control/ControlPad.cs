using System;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Views;
using Android.Content;
using Android.OS;

namespace Lotus {
	public class ControlPad : ControlElement<DirectionVector> {
		public static readonly int EDGE_THRESHOLD = 35;

		public ControlPad(Resources resources, PointVector center, double radius) : base(resources, Resource.Drawable.controlPad, center, radius) {
		}

		public override void ReceiveControl(MotionEvent e) {
			var control = new PointVector {
				X = e.GetX() - Center.X,
				Y = e.GetY() - Center.Y
			}.ToDirectionVector();

			if (control.Magnitude < Radius + EDGE_THRESHOLD) {
				if (control.Magnitude > Radius || e.Action == MotionEventActions.Up) {
					control.Magnitude = 0;
				} else {
					control.Magnitude /= Radius;
				}

				SendControl(control);
			}
		}
	}
}