using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MaterialProgressBar.Sample
{
	[Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = LaunchMode.SingleTop)]
	public class MainActivity : AppCompatActivity
	{
        ProgressBar[] mDeterminateCircularProgressBars;
        ValueAnimator mDeterminateCircularProgressAnimator;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.main_activity);

            mDeterminateCircularProgressBars = this.BindViews<ProgressBar>(Resource.Id.determinate_circular_large_progress,
                Resource.Id.determinate_circular_progress,
                Resource.Id.determinate_circular_small_progress);

            mDeterminateCircularProgressAnimator = Animators.MakeDeterminateCircularPrimaryProgressAnimator(mDeterminateCircularProgressBars);
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            mDeterminateCircularProgressAnimator.Start();
        }

        public override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();

            mDeterminateCircularProgressAnimator.End();
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
                    return true;
                case Resource.Id.action_determinate_circular_sample:
                    StartActivity(new Intent(this, typeof(DeterminateCircularSampleActivity)));
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
		}
	}
}

