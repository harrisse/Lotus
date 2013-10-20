using System;
using Android.Graphics;
using Android.Content.Res;
using System.Collections.Generic;

namespace Lotus {
	public class BitmapDrawable {
		private static Dictionary<int, BitmapDrawable> BitmapDictionary = new Dictionary<int, BitmapDrawable>();
		private Bitmap mBitmap;
		private Rect mBounds;

		private BitmapDrawable(Resources resources, int id) {
			mBitmap = BitmapFactory.DecodeResource(resources, id);
			mBounds = new Rect(-mBitmap.Width / 2, -mBitmap.Height / 2, mBitmap.Width / 2, mBitmap.Height / 2);
		}

		public BitmapDrawable(Resources resources, int id, double left, double top, double right, double bottom) {
			mBitmap = BitmapFactory.DecodeResource(resources, id, new BitmapFactory.Options {
				InDither = false,
				InPreferredConfig = Bitmap.Config.Argb8888
			});
			mBounds = new Rect((int)left, (int)top, (int)right, (int)bottom);
		}

		public static BitmapDrawable Create(Resources resources, int id) {
			if (BitmapDictionary.ContainsKey(id)) {
				return BitmapDictionary[id];
			} else {
				return new BitmapDrawable(resources, id);
			}
		}

		public void Draw(Canvas canvas) {
			canvas.DrawBitmap(mBitmap, null, mBounds, null);
		}
	}
}