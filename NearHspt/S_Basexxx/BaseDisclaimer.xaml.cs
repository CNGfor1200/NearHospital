// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: Disclaimer
// Vers: 3.0.0.0
//
// Legal Disclaimer, short version
// ..............................................................
using System;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseDisclaimer : ContentPage
  {
    //
    //
    Button spacerButton7;
    StackLayout contentstack = new StackLayout();


    public BaseDisclaimer()
    {
      InitializeComponent();

      Title = "Legal Disclaimer";
      BackgroundColor = Color.Black;



      #region Label setup
      Label Text1001 = new Label()
      {
        FontAttributes = FontAttributes.Bold,
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1002 = new Label()
      {
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1003 = new Label()
      {
        FontAttributes = FontAttributes.Bold,
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1004 = new Label()
      {
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1005 = new Label()
      {
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1006 = new Label()
      {
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1007 = new Label()
      {
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };
      Label Text1008 = new Label()
      {
        TextColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
      };

      #endregion

      Text1001.Margin = new Thickness(10, 0, 0, 0);
      Text1001.Text =
        "This application provides general information trying to help in medical emergency situations.\n\n" +
        "The material provided by this app is not medical advice. Only appropriately licensed " +
        "medical professionals, including physicians, are capabaple to offer and manage medical advise.\n\n";

      Text1002.Margin = new Thickness(10, 0, 0, 0);
      Text1002.Text =
        "The views expressed in this app are in no way related to any medical instutution, " +
        "training facilities, or academic institutions that the author is affiliated with.";

      Text1003.Margin = new Thickness(10, 0, 0, 0);
      Text1003.Text = "\n " +
        "Terms of Use Aggreement:";


      Text1004.Margin = new Thickness(10, 0, 0, 0);
      Text1004.Text = 
        "This [aggreement] is entered between and by you and the author of this app. The use " +
        "of the app is subject to the terms amd conditions of this aggreement.\n\n";

      Text1005.Margin = new Thickness(10, 10, 00, 0);
      Text1005.Text = "The information contained on these application pages is for informational purposes " +
      "only and no warranty is made that the information is error-free.\n"+
      "The information contained " +
      "within the application pages may be, at any time, outdated and may include inaccuracies and/or errors. " +
      "Information may change at any time without notice.\n\n";

      Text1006.Margin = new Thickness(10, 10, 00, 0);
      Text1006.Text = "NEITHER COMPANY, NOR ANY OF ITS SUBSIDIARIES, AFFILIATES, EMPLOYEES, AGENTS, LICENSORS OR CONTENT PROVIDERS " +
        "MAKES ANY REPRESENTATIONS OR WARRANTIES OF ANY KIND REGARDING ITS APPLICATION," +
        "THE CONTENT OR ANY SERVICE PROVIDED HEREIN.THE CONTENT AND SERVICES ARE PROVIDED ON AN 'AS IS' BASIS AND COMPANY " +
        "SPECIFICALLY DISCLAIMS ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING WITHOUT LIMITATION," +
        "WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, WARRANTIES OF MERCHANTABILITY OR WARRANTIES AGAINST INFRINGEMENT.COMPANY," +
        "ITS SUBSIDIARIES, AFFILIATES, EMPLOYEES, AGENTS, LICENSORS AND CONTENT PROVIDERS SHALL NOT BE LIABLE FOR ANY DAMAGES OR LOSSES," +
        "MEDICAL EMERGENCIES, INJURIES, OR DEATH, WITHOUT LIMITATION, INDIRECT, CONSEQUENTIAL, SPECIAL, RESULTING FROM OR CAUSED" +
        "BY THE COMPANY’S APPLICATION, THEIR CONTENT, ANY SERVICES PROVIDED HEREIN OR THE DELAY OR INABILITY TO USE THE COMPANY’S APPLICATION," +
        "OR ANY INFORMATION, MATERIALS, SOFTWARE, PRODUCTS AND SERVICES OBTAINED THROUGH THIS APPLICATION," +
        "OR OTHERWISE ARISING OUT OF THE USE OF THIS APPLICATION FOR ANY PRODUCTS OR SERVICES OR HYPERTEXT LINKS TO THIRD " +
        "PARTIES OR FOR ANY BREACH OF SECURITY ASSOCIATED WITH THE TRANSMISSION OF SENSITIVE INFORMATION THROUGH THE APPLICATION, " +
        "IN - USE DATABASE, OR ANY LINKED WEBSITE.WHETHER BASED ON CONTRACT, TORT, STRICT LIABILITY OR OTHERWISE," +
        "EVEN IF COMPANY HAS BEEN ADVISED OF THE POSSIBILITY OF DAMAGES.\n\n";

      Text1007.Margin = new Thickness(10, 10, 00, 0);
      Text1007.Text = "THE COMPANY DOES NOT REPRESENT OR ENDORSE THE ACCURACY OR RELIABILITY OF ANY ADVICE, OPINION, STATEMENT," +
        "OR OTHER INFORMATION DISPLAYED OR DISTRIBUTED THROUGH THE APPLICATION.YOU ACKNOWLEDGE THAT ANY RELIANCE UPON SUCH OPINION," +
        "ADVICE, STATEMENT, MEMORANDUM, OR INFORMATION SHALL BE AT YOUR SOLE RISK.THE COMPANY RESERVES THE RIGHT AT ALL TIMES " +
        "TO DISCLOSE ANY INFORMATION AS NECESSARY TO SATISFY ANY LAW, REGULATION OR GOVERNMENT REQUEST, OR TO EDIT, " +
        "REFUSE TO POST OR TO REMOVE ANY INFORMATION OR MATERIALS, IN WHOLE OR IN PART, THAT IN COMPANY’S SOLE " +
        "DISCRETION ARE OBJECTIONABLE OR IN VIOLATION OF THIS AGREEMENT.\n\n";

      Text1008.Margin = new Thickness(10, 10, 00, 0);
      Text1008.Text = "Company does not assume any responsibility or risk for your use of the Company's application content, " +
        "websites, or mobile application(s), and will in no event be liable to you or anyone else for any decision made " +
        "or action taken by you or anyone else in reliance upon the information provided through Company's application " +
        "content, websites, or mobile application(s).";


      Label explanation002 = new Label()
      {
        Margin = new Thickness(45, 0, 45, 10),
        Text = "Please, call for professional, competent Help as soon as the injured person is " +
        "stabilized.",
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.Red,
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };

      // ......................................................................

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
                    Text1001,
                    Text1002,
                    Text1003,
                    Text1004,
                    Text1005,
                    Text1006,
                    Text1007,

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
        //Spacing = 0,
        Children =
            {
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


    }


  }
}
