using Android.Graphics;

namespace Lotus {
	public interface IDrawable : IEjectable {
		void Draw(Canvas canvas);
	}
}