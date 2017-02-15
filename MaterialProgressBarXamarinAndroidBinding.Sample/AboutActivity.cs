using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using CheeseBind;

namespace MaterialProgressBarXamarinAndroidBinding.Sample
{
	[Activity(Label = "@string/about_title", LaunchMode = LaunchMode.SingleTop)]
	[MetaData("android.support.PARENT_ACTIVITY", Value="MaterialProgressBarSample.MainActivity")]
	public class AboutActivity : AppCompatActivity
	{
		[BindView(Resource.Id.version)]
		TextView mVersionText;

		[BindView(Resource.Id.github)]
		TextView mGithubText;

		[BindView(Resource.Id.xamarin_binding_github)]
		TextView mXamarinBindingGithub;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.about_activity);
			Cheeseknife.Bind(this);

			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			string version = GetString(Resource.String.about_version_format, Zhanghai.Android.MaterialProgressBar.BuildConfig.VersionName);
			mVersionText.Text = version;
			mGithubText.MovementMethod = LinkMovementMethod.Instance;
			mXamarinBindingGithub.MovementMethod = LinkMovementMethod.Instance;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					AppUtils.NavigateUp(this);
					return true;

				default:
					return base.OnOptionsItemSelected(item);
			}
		}
	}
}
