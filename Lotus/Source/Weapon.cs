using System;
using Android.Graphics.Drawables;
using Android.Content.Res;

namespace Lotus {
	public class Weapon : IUpdatable, IControllable<bool> {
		public double Damage { get; set; }

		public double Cooldown { get; set; }

		public bool ShouldBeEjected { get; set; }

		private BitmapDrawable mBulletDrawable;
		private double mCooldown;
		private bool mIsFiring = false;
		private Ship mShip;

		public Weapon(Resources resources, int id, DrawThread drawThread) {
			mBulletDrawable = BitmapDrawable.Create(resources, id);

			Cooldown = .1;
			mCooldown = Cooldown;

			ShouldBeEjected = false;

			UpdateThread.Main.Add(this);
		}

		public void SetShip(Ship ship) {
			mShip = ship;
		}

		public void ReceiveControl(bool control) {
			mIsFiring = control;
		}

		public void Update(double timeElapsed) {
			mCooldown -= timeElapsed;

			if (mCooldown <= 0 && mIsFiring) {
				mCooldown = Cooldown;
				var bullet = new Bullet(mBulletDrawable, new MaxPointVector { X = 50, Y = 50, Max = 100 });
				UpdateThread.Main.Add(bullet);
				DrawThread.DynamicLayer.Add(bullet);
			}
		}
	}
}