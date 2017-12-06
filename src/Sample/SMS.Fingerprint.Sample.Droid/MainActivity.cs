using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using SMS.Fingerprint.Sample.Droid.ServicesImplementations;

namespace SMS.Fingerprint.Sample.Droid
{
    [Activity(Label = "SMS.Fingerprint.Sample", Icon = "@drawable/xamarin_fingerprint", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == FallbackAuthService_Droid.REQUEST_CODE_CONFIRM_DEVICE_CREDENTIALS)
            {
                if(resultCode == Result.Ok)
                {
                    Toast.MakeText(this, "Fallback OK", ToastLength.Long);
                }
                else
                    Toast.MakeText(this, "Fallback error", ToastLength.Long);
            }
        }
    }
}

