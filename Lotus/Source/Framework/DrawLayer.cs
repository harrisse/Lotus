using System;
using Android.Graphics;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Lotus {
	public class DrawLayer {
		private LinkedList<IDrawable> mDrawables = new LinkedList<IDrawable>();
		private ConcurrentQueue<IDrawable> mBackQueue = new ConcurrentQueue<IDrawable>();

		public void Add(IDrawable drawable) {
			mBackQueue.Enqueue(drawable);
		}

		public void Draw(Canvas canvas) {
			while (mBackQueue.Count > 0) {
				IDrawable drawable;
				mBackQueue.TryDequeue(out drawable);
				mDrawables.AddLast(drawable);
			}

			for (var node = mDrawables.First; node != null; node = node.Next) {
				if (node.Value.ShouldBeEjected) {
					mDrawables.Remove(node);
				} else {
					node.Value.Draw(canvas);
				}
			}
		}
	}
}