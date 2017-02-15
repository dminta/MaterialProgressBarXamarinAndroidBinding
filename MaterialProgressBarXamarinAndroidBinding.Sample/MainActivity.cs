using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace MaterialProgressBarXamarinAndroidBinding.Sample
{
	[Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTop)]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.main_activity);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.action_about:
					StartActivity(new Intent(this, typeof(AboutActivity)));
					break;
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}

