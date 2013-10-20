using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lotus {
	public class UpdateThread : Threadable {
		public static UpdateThread Main = new UpdateThread();
		private LinkedList<IUpdatable> mUpdatables = new LinkedList<IUpdatable>();
		private ConcurrentQueue<IUpdatable> mBackQueue = new ConcurrentQueue<IUpdatable>();

		public void Add(IUpdatable updatable) {
			mBackQueue.Enqueue(updatable);
		}

		public void Update(double elapsed) {
			while (mBackQueue.Count > 0) {
				IUpdatable updatable;
				mBackQueue.TryDequeue(out updatable);
				mUpdatables.AddLast(updatable);
			}

			for (var node = mUpdatables.First; node != null; node = node.Next) {
				if (node.Value.ShouldBeEjected) {
					mUpdatables.Remove(node);
				} else {
					node.Value.Update(elapsed / 1000);
				}
			}
		}

		protected override void Action() {

		}
	}
}