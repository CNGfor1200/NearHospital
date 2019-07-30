// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: BaseGuide
// Vers: 3.0.0.0
//
// Brief Users "manual"
// ..............................................................
using Xamarin.Forms;

using Xamarin.Forms.Xaml;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseGuide : ContentPage
  {

    //
    //
    Button spacerButton7;
    StackLayout contentstack = new StackLayout();


    Label Text1001 = new Label();
    Label Text1002 = new Label();
    Label Text1003 = new Label();
    Label Text1004 = new Label();

    public BaseGuide(int arg001)
    {
      InitializeComponent();


      this.Title = "User Guide";
      BackgroundColor = Color.White;



      // 1 ===============================================================================================

      Text1001.Margin = new Thickness(10, 0, 0, 0);
      Text1001.Text =
        " This app finds nearby Hospitals\n" +
        "   with ER dept's.  ( 100 miles range )\n" +
        "    using GPS";
      Text1001.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button));
      //Text1001.FontAttributes = FontAttributes.Bold;
      //Text1001.FontAttributes = FontAttributes.Bold;
      Text1001.TextColor = Color.Black;

      Text1002.Margin = new Thickness(10, -10, 0, 0);
      Text1002.Text = "\n" +
        "Usage ...................\n" +
        "- start the app, \n" +
        "- wait seconds for location / DB to load\n\n" +
        "   -- continue w/ Nearest Hospital\n" +
        "      tap on Large top Button\n" +
        "        to continue\n\n" +
        "   or tap on\n" +
        "   -- [Hospitals - Show List] for more Hospitals\n" +
        "      and tap on a list item for more info\n\n";
      Text1002.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button));
      //Text1002.FontAttributes = FontAttributes.Bold;
      Text1002.TextColor = Color.Black;

      Text1003.Margin = new Thickness(14, -10, 0, 0);
      Text1003.Text =
        "Additional Info includes:\n" +
        " -- DETAILS about the hospital\n" +
        " -- Google Ratings about the hospital\n" +
        " -- ability to CALL the hospital (preset #)\n" +
        " -- show Web Site\n" +
        " -- Driving Directions to the hospital\n";
  Text1003.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button));
      Text1003.FontAttributes = FontAttributes.Bold;
      Text1003.FontAttributes = FontAttributes.Bold;
      Text1003.TextColor = Color.Black;


      Text1004.Margin = new Thickness(10, -10, 0, 0);
      Text1004.Text = "  ...AND showing Driving Direction";
      Text1004.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button));
      Text1004.FontAttributes = FontAttributes.Bold;
      Text1004.FontAttributes = FontAttributes.Bold;
      Text1004.TextColor = Color.Black;


      spacerButton7 = new Xamarin.Forms.Button
      {
        Text = " ",
        CornerRadius = 1,
        BorderColor = Color.LightSkyBlue,
        BorderWidth = 2,
        TextColor = Color.LightSkyBlue,
        FontAttributes = FontAttributes.Bold,
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Xamarin.Forms.Button)),
        BackgroundColor = Color.LightSkyBlue,
        HeightRequest = 5,
        WidthRequest = App.DisplayScaleMax // (App.DisplayScreenHeight)
      };

      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      // Stack panel fields
      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      #region Summary Stack
      contentstack = new StackLayout()
      {
        //Margin = new Thickness(10, 0, 10, 0),
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.White,
        WidthRequest = App.DisplayScaleMax, // App.DisplayScreenHeight,
        Spacing = 2,
        Children =
            {
              // SPheader001, 002, Website, expla002
              new StackLayout()
              {
                Margin = new Thickness(0, 0, 0, 0),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                Children =
                  {
                    Text1001, Text1002,Text1003,Text1004,
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
                  Children = { spacerButton7 }
                }

          },

      };
      #endregion

      #region Final Stacks

      StackLayout stackFinalHeader = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.OldLace,
        //Spacing = 0,
        Children =
  {
  }
      };

      var stackFinalBody = new StackLayout()
      {
        Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.Black,
        Children =
    {
     contentstack
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
      FinalPageLayout.BottomStack.Children.Add(App.contentstatusBaseline);

      // Assign to the page
      this.Content = FinalPageLayout;

      #endregion


    }

  }
}
