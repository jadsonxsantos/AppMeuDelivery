using Android.App;
using Android.Widget;
using DeLivre.Components;
using DeLivre.Droid.Components;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace DeLivre.Droid.Components
{
   public class MessageAndroid : IMessage
    {        
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}