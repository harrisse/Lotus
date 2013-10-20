using System;

namespace Lotus {
	public interface IController<T> {
		void RegisterControllable(IControllable<T> controllable);

		void SendControl(T control);
	}
}