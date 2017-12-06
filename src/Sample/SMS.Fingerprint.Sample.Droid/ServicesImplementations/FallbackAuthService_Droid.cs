using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using SMS.Fingerprint.Sample.Interfaces;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SMS.Fingerprint.Sample.Droid.ServicesImplementations.FallbackAuthService_Droid))]
namespace SMS.Fingerprint.Sample.Droid.ServicesImplementations
{
    public class FallbackAuthService_Droid : IFallbackAuthService
    {
        public const int REQUEST_CODE_CONFIRM_DEVICE_CREDENTIALS = 31;

        public void ShowFallbackAsync()
        {
            var mKeyguardManager = (KeyguardManager)Forms.Context.GetSystemService(Context.KeyguardService);

            var intent = mKeyguardManager.CreateConfirmDeviceCredentialIntent((string)null, null);
            if (intent != null)
            {
                ((Activity)Forms.Context).StartActivityForResult(intent, REQUEST_CODE_CONFIRM_DEVICE_CREDENTIALS);
            }
        }
    }
}
