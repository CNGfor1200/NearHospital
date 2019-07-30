// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: BaseShare
// Vers: 3.0.0.0
//
// Share your app experience
// ..............................................................
//??//using Plugin.Messaging;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseShare : ContentPage
  {

    Button spacerButton7;
    StackLayout contentstack = new StackLayout();

    public BaseShare() //string[] jumpfromto)
    {
      InitializeComponent();

      //string xxffmutter = jumpfromto[0];
      this.Title = "Share this App";
      BackgroundColor = Color.Black;


      Label Text001 = new Label()
      {
        Margin = new Thickness(10, 0, 0, 0),
        Text = "\n" +
        "If you think that this app could be of Use to someone else, why not send a brief note and let that person know.",

        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };


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
        WidthRequest = 15
      };

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
                Margin = new Thickness(10, 5, 10, 0),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Black,
                Children =
                  {
                    Text001,
                   }
              },

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
            // scroll
            new ScrollView(){
              VerticalOptions = LayoutOptions.StartAndExpand,
              HorizontalOptions=LayoutOptions.FillAndExpand,
              Content = contentstack
            },

          }
      };
      #endregion



      string subText = "I found this new app\n" +
        "[Near Hospitals / EMS]. " +
        "This app has a great way to simmulate and train how to do this compression thing for proper CPR.\nIt's fun to do.; " +
        "I am sending you the link to get it for yourself.\n" +
        " https://www.cnginternetsoftware.com/smart-phone-software ";
      ShareTest.ShareText(subText);
      //ShareTest.ShareUri()

    }

  }

  public class ShareTest
  {
    public static async Task ShareText(string text)
    {
      await Share.RequestAsync(new ShareTextRequest
      {
        Text = text,
        Title = "Share Text"
      });
    }

    public static async Task ShareUri(string uri)
    {
      await Share.RequestAsync(new ShareTextRequest
      {
        Uri = uri,
        Title = "Share Web Link"
      });
    }
  }


}
