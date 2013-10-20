using Android.Views;
using Android.Content;
using Android.Util;
using System;
using Android.OS;

namespace Lotus {
	public class LotusView : SurfaceView, ISurfaceHolderCallback {
		private DrawThread mDrawThread;

		public LotusView(Context context, IAttributeSet attrs) : base (context, attrs) {
			Holder.AddCallback(this);

			var screenCenter = new PointVector {
				X = Resources.DisplayMetrics.WidthPixels / 2,
				Y = Resources.DisplayMetrics.HeightPixels / 2
			};

			var controlPadRadius = 225;
			var controlPad = new ControlPad(Resources, new PointVector {
				X = controlPadRadius,
				Y = screenCenter.Y * 2 - controlPadRadius
			}, controlPadRadius);
			var fireButtonRadius = 125;
			var fireButton = new ControlButton(Resources, new PointVector {
				X = screenCenter.X * 2 - fireButtonRadius,
				Y = screenCenter.Y * 2 - fireButtonRadius
			}, fireButtonRadius);

			var player = new Player(controlPad, fireButton);
			mDrawThread = new DrawThread(Holder, screenCenter, player);

			player.RegisterShip(new Ship(Resources, Resource.Drawable.t1, 600, 1200, 720));
			player.RegisterWeapon(new Weapon(Resources, Resource.Drawable.t1, mDrawThread));

			new StaticImage(Resources, Resource.Drawable.background);

			SetOnTouchListener(player);
		}

		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int width, int height) {
		}

		public void SurfaceCreated(ISurfaceHolder holder) {
			mDrawThread.Start();
			UpdateThread.Main.Start();
		}

		public void SurfaceDestroyed(ISurfaceHolder holder) {
			mDrawThread.Join();
			UpdateThread.Main.Join();
		}
	}
}