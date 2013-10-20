namespace Lotus {
	public class MaxPointVector : PointVector {
		public double Max { get; set; }

		public MaxPointVector() : base() {
			Max = 0;
		}

		public override void Add(double x, double y) {
			base.Add(x, y);
			Limit();
		}

		public void Limit() {
			var magnitude = GetMagnitude();
			if (magnitude > Max) {
				Add(X - X * magnitude / Max, Y - Y * magnitude / Max);
			}
		}
	}
}