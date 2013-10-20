using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content.Res;

namespace Lotus {
	public class MovableImage : Movable, IDrawable {
		public static readonly int ROTATION_OFFSET = 135;
		private BitmapDrawable mDrawable;

		public MovableImage(BitmapDrawable drawable) : base() {
			mDrawable = drawable;
			DrawThread.DynamicLayer.Add(this);
		}

		public void Draw(Canvas canvas) {
			canvas.Save();
			canvas.Translate((float)Position.X, (float)Position.Y);
			canvas.Rotate((float)Acceleration.Direction + ROTATION_OFFSET);
			mDrawable.Draw(canvas);
			canvas.Restore();
		}
	}
}