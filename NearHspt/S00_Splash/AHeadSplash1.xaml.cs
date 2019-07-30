// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Project: Near Hospital, EMS
//
// Name: AHeadSplash1
// Vers: 3.0.0.0
//
// The actual start of all data and control flows
// .............................................................
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using static Android.InputMethodServices.InputMethodService;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AHeadSplash1 : ContentPage
  {

    Xamarin.Forms.Label lbl_btTHosp;
    Xamarin.Forms.Button btTHosp;
    Xamarin.Forms.Label lbl_btQHosp1;
    Xamarin.Forms.Button btQHosp;

    StackLayout contentstk = new StackLayout();
    bool noBlockChain = false;

    public AHeadSplash1()
    {
      InitializeComponent();

      #region intro stuff
      Title = "Near Hospitals, ER's";
      BackgroundColor = Color.LightGreen;
      #endregion

      //??//noBlockChain = false;
      //??//GetHospitalDBAsync();


      #region Toolbar 006
      //
      // .......................................................................
      // Tool Bar
      // .......................................................................
      ToolbarItems.Clear();
      // set originator, the returning address/name


      // How To Do
      ToolbarItem TBI_ToDo = new ToolbarItem
      {
        Icon = "help.png",
        Order = ToolbarItemOrder.Primary,
        Command = new Command(async () => await Navigation.PushAsync(new BaseGuide(1)))
      };
      ToolbarItems.Add(TBI_ToDo);

      // User Guide
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "User Guide",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new BaseGuide(1)))
      });
      // Share
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "Share this app",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new BaseShare()))
      });
      // Legal Disclaimer
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "Legal Disclaimer",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new BaseDisclaimer()))
      });
      // Privacy
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "Privacy",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new BasePrivacy()))
      });
      // About
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "About -- References",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new StatAbout()))
      });
      // Contact Us
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "Contact Us",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new BaseContactUs()))
      });
      // .......................................................................
      //

      #endregion




      #region Lines (lightgray)

      var boxViewbnew0 = new BoxView()
      {
        HeightRequest = 1,
        WidthRequest = 170,
        BackgroundColor = Color.Black
      };
      StackLayout n0_Underline = new StackLayout()
      {
        Margin = new Thickness(2, 2, 0, 2),
        BackgroundColor = Color.LightGray,
        WidthRequest = 170,
        HeightRequest = 1,
        Children = { boxViewbnew0 }
      };

      var boxViewbnew0444 = new BoxView()
      {
        HeightRequest = 1,
        WidthRequest = 170,
        BackgroundColor = Color.LightGray
      };
      var boxViewbnew02 = new BoxView()
      {
        HeightRequest = 15,
        WidthRequest = 28,
        BackgroundColor = Color.LightSkyBlue,
        Opacity = 100
      };

      StackLayout n555_Underline = new StackLayout()
      {
        //Margin = new Thickness(0, 8, 0, 8),
        //BackgroundColor = Color.LightGray,
        //HeightRequest = 40,
        //WidthRequest=40,
        Children = { boxViewbnew02 }
      };
      #endregion

      #region GPS based nearest
      
      // Nearest GPS Hospital label
      lbl_btTHosp = new Label()
      {
        Margin = new Thickness(0, 35, 0, 0),
        Text = " Near Hospitals / ER Location:",
        FontAttributes = FontAttributes.Bold,
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.Black,
        HorizontalTextAlignment = TextAlignment.Start,
        BackgroundColor = Color.LightSkyBlue,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        //WidthRequest = App.DisplayScaleMax // (App.DisplayScreenWidth)
      };

 
      Image standardHelp = new Image
      {
        Margin = new Thickness(0, 35, 0, 0),
        //AdvancedHelp.Scale = 50; // (50,50);
        Source = "smallhelp.png"
      };
      // Mark label for tap event
      TapGestureRecognizer standardHelp_tap = new TapGestureRecognizer();

      standardHelp_tap.Tapped += async (s, e) =>
      {
        Boolean ans = await DisplayAlert("Instructions.", "Click the [Hospitals ...GPS] button\n\n" +
          "Next Page will show:\n\n" +

          " --- 'Nearest Hospital' from your GPS position... [Details] / [Phone-Dialer] & [Direction]\n\n" +

          " --- [Slider] ... selecting more Hospitals within a Range of your GPS position\n\n" +

          " --- [Show List Button] ... list all Hospitals in selected Range (Details, Phone-Dialer, Direction)", "Got it", " ");
      };
      standardHelp.GestureRecognizers.Add(standardHelp_tap);


      var stckstandard = new StackLayout()
      {
        //Margin = new Thickness(0, 0, 10, 0),
        //Margin = new Thickness(0, 50, 0, 0),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightSkyBlue, //.Black,
        //WidthRequest = App.DisplayScaleMax,
        //Spacing = 10,
        Children =
                    {
                      lbl_btTHosp,standardHelp
                    }
      };

      btTHosp = new Button
      {
        Text = "Hospitals\n\nFROM MY\nGPS Position",
        //Margin = new Thickness(0, 0, 0, 0),
        Image = "nhospital.png",
        BorderWidth = 3,
        CornerRadius = 10,
        BorderColor = Color.Red,
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
        TextColor = Color.White,
        BackgroundColor = Color.LightSlateGray,
        HeightRequest = 85,
        WidthRequest = 190
      };
      btTHosp.Clicked += OnbtTHospClickedAsync;

      var stckGPSLabel = new StackLayout()
      {
        //Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.LightSkyBlue,
        Children =
        {
          stckstandard
        }
      };

      // [List All] button
      var stckGPS = new StackLayout()
      {
        //Margin = new Thickness(0, 5, 0, 20),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightSkyBlue,
        //WidthRequest = 160,
        Children =
          {
            btTHosp
          }
      };

      #endregion


      #region Advertisement

      Label addFooter = new Label()
      {
        Margin = new Thickness(0, 3, 0, 0),
        Text = "Published by CNG Internet Software, LLC\n" +
        "..publisher by/on mid-November 2018 of the 'C's Medical Emergency' app..",
        FontAttributes = FontAttributes.None,
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
        TextColor = Color.Black,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HorizontalTextAlignment = TextAlignment.Center,
        WidthRequest = App.DisplayScaleMax, // App.DisplayScreenHeight
      };

      #endregion

      #region Stack Layouts


      StackLayout centerStack = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightSkyBlue,
        WidthRequest = App.DisplayScaleMax, // App.DisplayScreenHeight,
        //Spacing = 12,
        Children =
            {
              stckGPSLabel,
              stckGPS,
              //??//leftStack
           }
      };


      #endregion


      #region Final Stacks

      StackLayout stackFinalHeader = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.OldLace,
        //Spacing = 0,
        Children =
            {
            }
      };


      var stackFinalBody = new StackLayout()
      {
        //Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.Black,
        Children =
              {
               centerStack
              }
      };

      StackLayout addAd = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.OldLace,
        //Spacing = 0,
        Children =
            {
             addFooter
            }
      };

      ScrollView FinalScrollView = new ScrollView()
      {
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        Content = stackFinalBody
      };


      // ------------------------------------------------------------------------
      // Page -------------------------------------------------------------------
      // ------------------------------------------------------------------------
      App.CCMed FinalPageLayout = new App.CCMed();

      FinalPageLayout.TopStack.Children.Add(stackFinalHeader);
      //FinalPageLayout.TopStack.Children.Add(SPheader001);
      //FinalPageLayout.TopStack.Children.Add(FinalScrollView);
      FinalPageLayout.CenterStack.Children.Add(FinalScrollView);
      FinalPageLayout.BottomStack.Children.Add(addAd); // App.contentstatusBaseline);

      // Assign to the page
      this.Content = FinalPageLayout;

      #endregion


      //
      // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      // This will "blitz" through this page, and immidiately put up the next pag.
      // ... but if you pewaa <Return>, it will show this page for some advertisement
      // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      //
      try
      {
        var duration = TimeSpan.FromMilliseconds(1000);
        Vibration.Vibrate(duration);
      }
      catch (FeatureNotSupportedException ex)
      {
        string aa = ex.Message.ToString();
      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
      }

      Navigation.PushAsync(new FindHospital(noBlockChain));
      //


    }


    #region Button processes

    // ======================================================================
    // Vibrate for a short time, NORMAL
    // ======================================================================
    void OnbtTHospClickedAsync(object sender, EventArgs e)
    {
      try
      {
        var duration = TimeSpan.FromMilliseconds(1000);
        Vibration.Vibrate(duration);
      }
      catch (FeatureNotSupportedException ex)
      {
        // Feature not supported on device
      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
      }

      Navigation.PushAsync(new FindHospital(noBlockChain));
      //
    }


    #endregion

  }
}

