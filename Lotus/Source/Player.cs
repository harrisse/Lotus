using System;
using System.Collections.Generic;
using Android.Views;

namespace Lotus {
	public class Player : Java.Lang.Object, View.IOnTouchListener {
		private Ship mShip;
		private ControlPad mControlPad;
		private ControlButton mFireButton;

		public Player(ControlPad controlPad, ControlButton fireButton) {
			mControlPad = controlPad;
			mFireButton = fireButton;
		}

		public Ship GetShip() {
			return mShip;
		}

		public void RegisterWeapon(Weapon weapon) {
			weapon.SetShip(mShip);
			mFireButton.RegisterControllable(weapon);
		}

		public void RegisterShip(Ship ship) {
			mShip = ship;
			mControlPad.RegisterControllable(ship);
		}

		public bool OnTouch(View v, MotionEvent e) {
			mControlPad.ReceiveControl(e);
			mFireButton.ReceiveControl(e);
			return true;
		}
	}
}