using System.Linq;

using Android.App;
using Android.Views;

namespace MaterialProgressBar.Sample
{
    public static class ActivityExtensions
    {
        public static T[] BindViews<T>(this Activity activity, params int[] ids)
            where T : View
        {
            return ids.Select(id => activity.FindViewById<T>(id)).ToArray();
        }
    }
}