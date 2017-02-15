using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;

using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;

namespace MaterialProgressBarXamarinAndroidBinding.Sample
{
	public static class AppUtils
	{
		public static void NavigateUp(Activity activity, Bundle extras = null)
		{
			Intent upIntent = NavUtils.GetParentActivityIntent(activity);
			if (upIntent != null)
			{
				if (extras != null)
				{
					upIntent.PutExtras(extras);
				}

				if (NavUtils.ShouldUpRecreateTask(activity, upIntent))
				{
					TaskStackBuilder.Create(activity)
									.AddNextIntentWithParentStack(upIntent)
									.StartActivities();
				}
				else
				{
					upIntent.AddFlags(ActivityFlags.ClearTop);
					activity.StartActivity(upIntent);
				}
			}
			activity.Finish();
		}
	}
}
