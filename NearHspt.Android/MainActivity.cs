using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace NearHspt.Droid
{
  [Activity(Label = "Near EMS Hospitals", Icon = "@drawable/fng", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      //TabLayoutResource = Resource.Layout.Tabbar;
      //ToolbarResource = Resource.Layout.Toolbar;
      this.Title = "Find Phone by Speken Word";

      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState); // add this line to your code

      //###########################################################################################
      //# Android #################################################################################
      //###########################################################################################

      // Store off the device sizes, so we can access them within Xamarin Forms
      //  Screen Width = WidthPixels / Density
      //  Screen Height = HeightPixels / Density

      App.DisplayScreenWidth = Resources.DisplayMetrics.WidthPixels / (double)Resources.DisplayMetrics.Density;
      App.DisplayScreenHeight = (double)Resources.DisplayMetrics.HeightPixels / (double)Resources.DisplayMetrics.Density;
      App.DisplayScaleFactor = (double)Resources.DisplayMetrics.Density;
      App.DisplayScaleMax = App.DisplayScreenHeight;
      if (App.DisplayScreenHeight <= App.DisplayScreenWidth) App.DisplayScaleMax = App.DisplayScreenWidth;

      //###########################################################################################
      //###########################################################################################
      //###########################################################################################


      //grb//if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();

      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new App());
    }


    #region Essential Permission 'Catch'

    // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    // Catch Essentials permission(s)
    //
    // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
    #endregion


    // .............................................................................
    // Convert pixels to Dots/per/inch
    //
    // .............................................................................
    private int ConvertPixelsToDp(float pixelValue)
    {
      var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
      return dp;
    }


  }
}