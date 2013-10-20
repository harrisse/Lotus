using System;

namespace Lotus {
	public interface IControllable<T> {
		void ReceiveControl(T control);
	}
}