using System;
using Android.Widget;
using Android.Animation;
using Android.Views.Animations;

namespace MaterialProgressBar.Sample
{
    static class Animators
    {
        class DeterminateCircularPrimaryProgressAnimatorListener : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            ValueAnimator animator;
            ProgressBar[] progressBars;

            public DeterminateCircularPrimaryProgressAnimatorListener(ValueAnimator animator, ProgressBar[] progressBars)
            {
                this.animator = animator;
                this.progressBars = progressBars;
            }

            public void OnAnimationUpdate(ValueAnimator animation)
            {
                int value = (int)animator.AnimatedValue;

                foreach (var progressBar in progressBars)
                {
                    progressBar.Progress = value;
                }
            }
        }

        public static ValueAnimator MakeDeterminateCircularPrimaryProgressAnimator(ProgressBar[] progressBars)
        {
            ValueAnimator animator = ValueAnimator.OfInt(0, 150);
            animator.SetDuration(6000);
            animator.SetInterpolator(new LinearInterpolator());
            animator.RepeatCount = ValueAnimator.Infinite;

            animator.AddUpdateListener(new DeterminateCircularPrimaryProgressAnimatorListener(animator, progressBars));

            return animator;
        }

        class DeterminateCircularPrimaryAndSecondaryProgressAnimatorListener : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            ValueAnimator animator;
            ProgressBar[] progressBars;

            public DeterminateCircularPrimaryAndSecondaryProgressAnimatorListener(ValueAnimator animator, ProgressBar[] progressBars)
            {
                this.animator = animator;
                this.progressBars = progressBars;
            }

            public void OnAnimationUpdate(ValueAnimator animation)
            {
                int value = (int)Math.Round(1.25f * (int)animator.AnimatedValue);

                foreach (var progressBar in progressBars)
                {
                    progressBar.SecondaryProgress = value;
                }
            }
        }

        public static ValueAnimator MakeDeterminateCircularPrimaryAndSecondaryProgressAnimator(ProgressBar[] progressBars)
        {
            ValueAnimator animator = MakeDeterminateCircularPrimaryProgressAnimator(progressBars);

            animator.AddUpdateListener(new DeterminateCircularPrimaryAndSecondaryProgressAnimatorListener(animator, progressBars));

            return animator;
        }
    }
}