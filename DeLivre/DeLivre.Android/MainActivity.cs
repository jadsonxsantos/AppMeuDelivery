using Com.OneSignal;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Plugin.CurrentActivity;

namespace DeLivre.Droid
{
    [Activity(Label = "Meu Delivery", Icon = "@drawable/icon",
        Theme = "@style/MainTheme", MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
          
            ImageCircleRenderer.Init();
            OneSignal.Current.StartInit("aed63aa3-9fbf-4f23-a9b2-26ee4666d096").EndInit();
            global::Xamarin.Forms.FormsMaterial.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }
}