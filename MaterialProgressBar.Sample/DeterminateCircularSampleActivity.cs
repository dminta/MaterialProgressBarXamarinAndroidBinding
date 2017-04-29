using Android.Animation;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MaterialProgressBar.Sample
{
    [Activity(Label = "@string/determinate_circular_title", LaunchMode = LaunchMode.SingleTop)]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "MaterialProgressBarSample.MainActivity")]
    public class DeterminateCircularSampleActivity : AppCompatActivity
    {
        ProgressBar[] mPrimaryProgressBars;
        ProgressBar[] mPrimaryAndSecondaryProgressBars;

        ValueAnimator mPrimaryProgressAnimator;
        ValueAnimator mPrimaryAndSecondaryProgressAnimator;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.determinate_circular_sample_activity);

            mPrimaryProgressBars = this.BindViews<ProgressBar>(Resource.Id.normal_progress,
                Resource.Id.tinted_normal_progress,
                Resource.Id.dynamic_progress,
                Resource.Id.tinted_dynamic_progress);

            mPrimaryAndSecondaryProgressBars = this.BindViews<ProgressBar>(Resource.Id.normal_secondary_progress,
                Resource.Id.normal_background_progress,
                Resource.Id.tinted_normal_secondary_progress,
                Resource.Id.tinted_normal_background_progress,
                Resource.Id.dynamic_secondary_progress,
                Resource.Id.dynamic_background_progress,
                Resource.Id.tinted_dynamic_secondary_progress,
                Resource.Id.tinted_dynamic_background_progress);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            
            mPrimaryProgressAnimator = Animators.MakeDeterminateCircularPrimaryProgressAnimator(mPrimaryProgressBars);
            mPrimaryAndSecondaryProgressAnimator = Animators.MakeDeterminateCircularPrimaryAndSecondaryProgressAnimator(mPrimaryAndSecondaryProgressBars);
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            mPrimaryProgressAnimator.Start();
            mPrimaryAndSecondaryProgressAnimator.Start();
        }

        public override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();

            mPrimaryProgressAnimator.End();
            mPrimaryAndSecondaryProgressAnimator.End();
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
