using System;
using System.Collections.Generic;
using System.Diagnostics;
using Android.Views;
using Android.Graphics;
using Android.Content.Res;
using System.Threading;

namespace Lotus {
	public class DrawThread : Threadable {
		public static DrawLayer StaticLayer = new DrawLayer();
		public static DrawLayer DynamicLayer = new DrawLayer();
		public static DrawLayer ControlLayer = new DrawLayer();
		private ISurfaceHolder mHolder;
		private PointVector mScreenCenter;
		private Player mPlayer;

		public DrawThread(ISurfaceHolder holder, PointVector screenCenter, Player player) {
			mHolder = holder;
			mPlayer = player;
			mScreenCenter = screenCenter;
			UpdateInterval = 1000 / 60;
		}

		protected override void Action() {
			UpdateThread.Main.Update(mElapsed);
			var canvas = mHolder.LockCanvas();
			canvas.DrawColor(Color.White);
			canvas.Save();
			canvas.Translate((float)(mScreenCenter.X - mPlayer.GetShip().Position.X), (float)(mScreenCenter.Y - mPlayer.GetShip().Position.Y));
			StaticLayer.Draw(canvas);
			DynamicLayer.Draw(canvas);
			canvas.Restore();
			ControlLayer.Draw(canvas);
			mHolder.UnlockCanvasAndPost(canvas);
		}
	}
}