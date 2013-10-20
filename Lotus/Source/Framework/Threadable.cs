using System.Threading;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace Lotus {
	public abstract class Threadable {
		public double UpdateInterval { get; set; }

		private Thread mThread;
		private bool mIsRunning = true;
		private Stopwatch mStopwatch = new Stopwatch();
		protected double mElapsed;

		public Threadable() {
			mThread = new Thread(new ThreadStart(RunAction));
			UpdateInterval = 1000 / 120;
		}

		public void Start() {
			mStopwatch.Start();
			mThread.Start();
		}

		public void Join() {
			mIsRunning = false;
			mThread.Join();
		}

		private void RunAction() {
			while (mIsRunning) {
				mElapsed = (double)mStopwatch.Elapsed.Milliseconds;
				if (mElapsed < UpdateInterval) {
					Thread.Sleep((int)(UpdateInterval - mElapsed));
					mElapsed = UpdateInterval;
				}

				mStopwatch.Restart();

				Action();
			}
		}

		protected abstract void Action();
	}
}