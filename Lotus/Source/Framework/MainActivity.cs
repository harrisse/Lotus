using Android.App;
using Android.OS;

namespace Lotus {
	[Activity (Label = "Lotus", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape, Theme = "@style/Lotus")]
	public class MainActivity : Activity {
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
		}
	}
}