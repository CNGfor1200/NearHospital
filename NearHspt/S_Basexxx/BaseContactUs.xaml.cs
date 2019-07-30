// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: ContactUs
// Vers: 3.0.0.0
//
// Contact us. Short version
// .............................................................
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseContactUs : ContentPage
  {

    Button websiteMD;

    Button spacerButton7;
    StackLayout contentstack = new StackLayout();

    public BaseContactUs()
    {
      InitializeComponent();

      Title = "Contact Us";
      BackgroundColor = Color.Black;


      Label Text001 = new Label()
      {
        Margin = new Thickness(20, 0, 20, 0),
        Text =
        "CNG Internet Software, LLC.\n\n" +
        "   21 Nottingham Rd.\n" +
        "   Manalapan, NJ, 07726\n" +
        "\n" +
        "   Support@cngInternet.com\n\n" +
        "   (732) 536-8414\n" +
        "   (973) 287-9862\n\n" +
        "   App Id: CCNearHospital 2.1.4\n\n" +
        "Copyright\n" +
        "(2018) CNG Internet Software, LLC. All rights reserved.",
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      Label Text002 = new Label()
      {
        Margin = new Thickness(20, 0, 20, 0),
        Text = "",
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };

      websiteMD = new Button
      {
        Text = "  CNG Internet Web Sites  ",
        CornerRadius = 12,
        BorderColor = Color.Blue,
        BorderWidth = 2,
        TextColor = Color.Black,
        FontAttributes = FontAttributes.Bold,
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
        BackgroundColor = Color.LightGray,
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.Center,
        HeightRequest = 35
        //WidthRequest = 220
      };
      websiteMD.Clicked += OnAbout_WebSiteClickedAsync;

      #region Simple email

      // ==========================================================
      // Simple Email
      // ==========================================================
      Button emailButton = new Xamarin.Forms.Button
      {
        Text = " Sending a Note ",
        CornerRadius = 8,
        BorderColor = Color.Red,
        BorderWidth = 2,
        TextColor = Color.White,
        FontAttributes = FontAttributes.Bold,
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
        BackgroundColor = Color.Gray,
        HeightRequest = 35
      };
      emailButton.Clicked += OnbtItems001ClickedAsync;


      StackLayout stkBut1But2 = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.EndAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.WhiteSmoke,
        Spacing = 5,
        WidthRequest = App.DisplayScaleMax,
        Children =
                  {
                    websiteMD,
                    emailButton,
                  }
      };

      Frame startframe2 = new Frame()
      {
        Content = stkBut1But2,
        BorderColor = Color.Blue,
        CornerRadius = 10,
        HasShadow = true,
        Margin = new Thickness(5, -10, 5, 5),
        WidthRequest = App.DisplayScaleMax,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HorizontalOptions = LayoutOptions.Center
      };


      #endregion


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

      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      // Stack panel fields
      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      #region Summary Stack
      contentstack = new StackLayout()
      {
        Margin = new Thickness(10, 0, 10, 0),
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.LightSkyBlue, //.Red, //.White, .Maron
                                              //MinimumWidthRequest = 1234567890,
        WidthRequest = App.DisplayScreenHeight,
        Spacing = 2,
        Children =
            {
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
                    Text002,

                    // WebSite ---> AppSpringGo
                    new StackLayout()
                    {
                      Margin = new Thickness(0, 30, 0, 40),
                      Orientation = StackOrientation.Vertical,
                      VerticalOptions = LayoutOptions.StartAndExpand,
                      HorizontalOptions = LayoutOptions.CenterAndExpand,
                      BackgroundColor = Color.Black,
                      Spacing=15,
                      Children =
                        {
                          startframe2

                        }
                    },

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

      // ------------------------------------------------------------------------
      // Page -------------------------------------------------------------------
      // ------------------------------------------------------------------------
      Content = new StackLayout()
      {
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.OldLace,
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

    }


    // ======================================================================
    // Web Site
    // ======================================================================
    async void OnAbout_WebSiteClickedAsync(object sender, EventArgs e)
    {
      switch (Device.RuntimePlatform)
      {
        case Device.iOS:
          Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/smart-phone-software"));
          break;
        case Device.Android:

          var action = await DisplayActionSheet("CNG Support Web Sites........", "Not Now", null, "CNGSoftware  --  Builder's website", "Blockchain Explanation", "Purchase of app - after free trial");
          switch (action)
          {
            case "CNGSoftware  --  Builder's website":
              Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/smart-phone-software"));
              break;
            case "Blockchain Explanation":
              Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/howto_blockchain"));
              break;
            case "Purchase of app - after free trial":
              Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/payment-process"));
              break;
          }

          break;
        default:
          Device.OpenUri(new Uri("https://www.cnginternetsoftware.com/smart-phone-software"));
          break;

      }
    }




    // ======================================================================
    // Plain Text, right now
    //
    // ======================================================================
    void OnbtItems001ClickedAsync(object sender, EventArgs e)
    {
      try
      {
        Process_Email();
      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
      }
    }



    // ====================================================================================================================================
    // Process plain email
    // ====================================================================================================================================
    async Task Process_Email()
    {
      try
      {


        //ccWait(5);

        string nowTime = DateTime.Now.ToString();

        string subject11 = ("CPR done right!");
        string body11 = (nowTime + "\nPlease check this out.");

        List<string> toAddress11 = new List<string>();
        toAddress11.Add("gunter.r.beck@gmail.com");
        await SendEmail(subject11, body11, toAddress11);    //txtSubject.Text, txtBody.Text, toAddress);

      }
      catch (Exception ex)
      {
        // Unable to get location
      }

    }



    // .......................................................................................
    //
    // .......................................................................................
    public async Task SendEmail(string subject, string body, List<string> recipients)
    {
      try
      {
        var message = new EmailMessage
        {
          Subject = subject,
          Body = body,
          To = recipients,
          //Cc = ccRecipients,
          //Bcc = bccRecipients
        };
        await Email.ComposeAsync(message);
      }
      catch (Exception ex)
      {
        // Some other exception occurred  
      }

    }



    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Wait loop
    //
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    void ccWait(int iwaitthislong)
    {
      bool iB = true;
      var startTime = DateTime.Now;
      //do until true or timeout reached.
      while (iB)
      {
        if (DateTime.Now - startTime > TimeSpan.FromSeconds(Convert.ToInt32(iwaitthislong)))
          break;
      }
      var endTime = DateTime.Now;
    }




  }
}