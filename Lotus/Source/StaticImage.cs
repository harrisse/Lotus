using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace Lotus {
	public class StaticImage : IDrawable {
		private BitmapDrawable mBitmap;

		public bool ShouldBeEjected { get; set; }

		public StaticImage(Resources resources, int id) {
			mBitmap = BitmapDrawable.Create(resources, id);
			ShouldBeEjected = false;

			DrawThread.StaticLayer.Add(this);
		}

		public void Draw(Canvas canvas) {
			mBitmap.Draw(canvas);
		}
	}
}