// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: BasePrivacy
// Vers: 3.0.0.0
//
// Pointing to the CHG Internet Software Privacy page
// ..............................................................
using System;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BasePrivacy : ContentPage
  {

    StackLayout contentstack = new StackLayout();

    public BasePrivacy()
    {
      InitializeComponent();

      this.Title = "Privacy";
      BackgroundColor = Color.Black;


 
      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      // Stack panel fields
      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      #region Summary Stack
      contentstack = new StackLayout()
      {
        Margin = new Thickness(10, 0, 10, 0),
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.LightSkyBlue,
        WidthRequest = App.DisplayScaleMax, // App.DisplayScreenHeight,
        Spacing = 2,
        Children =
            {
              // SPheader001, 002, Website, expla002
              new StackLayout()
              {
                Margin = new Thickness(10, 5, 0, 0),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black,
                Children =
                  {
                   }
              },
           


              // Spacer
              new StackLayout()
                {
                  Margin=new Thickness(0,7,0,7),
                  VerticalOptions = LayoutOptions.StartAndExpand,
                  HorizontalOptions = LayoutOptions.CenterAndExpand,
                  BackgroundColor = Color.LightSkyBlue,
                  Spacing = 0,
                  Children = {  }
                }

          },

      };

      // ------------------------------------------------------------------------
      // Page -------------------------------------------------------------------
      // ------------------------------------------------------------------------
      Content = new StackLayout()
      {
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.OldLace,
        //Spacing = 0,
        Children =
            {
            //topHeaderStack,

            // scroll
            new ScrollView(){
              VerticalOptions = LayoutOptions.StartAndExpand,
              HorizontalOptions=LayoutOptions.FillAndExpand,
              Content = contentstack
            },

            // content Baseline
            //contentstatusBaseline
          }
      };
      #endregion

      Privacy100();

    }


    // ======================================================================
    // Web Site
    // ======================================================================
    void Privacy100()
    {
      switch (Device.RuntimePlatform)
      {
        case Device.iOS:
          Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/privacy-policy"));
          break;
        case Device.Android:
          Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/privacy-policy"));
          break;
        default:
          Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/privacy-policy"));
          break;

      }

    }




  }
}