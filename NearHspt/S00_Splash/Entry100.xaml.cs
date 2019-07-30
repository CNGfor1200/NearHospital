// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: Entry100
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

using System.Timers;
using System.Linq;
using System.Threading.Tasks;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Entry100 : ContentPage
  {


    Xamarin.Forms.Button btItemsAdult;
    Xamarin.Forms.Button btItemsHistory;

    Label lblReturn = new Label();
    Label lblHeader = new Label();

    Label lblYourText = new Label();
    Label textCaptured1 = new Label();
    Label textCaptured2 = new Label();

    StackLayout stkTop = new StackLayout();
    StackLayout contentstk = new StackLayout();

		#region advertisement data
		// LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL

		public static double deviceLatitude = 0.0;
		public static double deviceLongitude = 0.0;
		public static double aDspotLatitude = 0.0;
		public static double aDspotLongitude = 0.0;
		public static double azurewMiles = 0.0;
		public static int aDspotMiles = 0;

		public static string adString = "Published by CNG Internet Software, LLC\n" +
					"..publisher of the \"small app, helping BIG\" series of apps.";
		public static string adText = "";
		public static string adToday = DateTime.Now.ToString("dd/MM/yyyy");
		public static string adDate = DateTime.Now.ToString("dd/MM/yyyy");

		public static int azLoop = 100;

		Label addFooter = new Label();
		StackLayout stackAd = new StackLayout();


		// LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL

		#endregion


		public Entry100()
    {
      InitializeComponent();

      #region intro stuff
      this.Title = "Near Hospitals, ER's";
      BackgroundColor = Color.Black; // WhiteSmoke;
      Opacity = 0.9;
      //?//App.statusBaseLine.BackgroundColor = A_Util001.ColorInTraining();

      #endregion

      #region Toolbar 007
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
      ToolbarItems.Add(new ToolbarItem
      {
        Text = "Share this app",
        Order = ToolbarItemOrder.Secondary,
        Command = new Command(async () => await Navigation.PushAsync(new BaseShare()))
      });
			// Setup
			ToolbarItems.Add(new ToolbarItem
			{
				Text = "Setup",
				Order = ToolbarItemOrder.Secondary,
				Command = new Command(async () => await Navigation.PushAsync(new BaseSetup()))
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

      #region Startup labels, background


      Label lb001 = new Label()
      {
        Text = "Welcome\n\nList all Hospitals w/ EMS\nin 100 miles Surounding",
        Margin = new Thickness(5, -125, 0, 0),
        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
        //FontAttributes = FontAttributes.Bold,
        Style = Device.Styles.TitleStyle,
        Opacity = 0.5,
        HorizontalTextAlignment = TextAlignment.Center,
        BackgroundColor = Color.White, //.LightYellow,
        TextColor = Color.Black,
        //WidthRequest = App.DisplayScaleMax,
        HeightRequest = 140
      };

      Label lb003b = new Label()
      {
        Text = "Get Hospital Details, Get Driving Direction",
        Margin = new Thickness(10, -5, 0, 0),
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        HorizontalTextAlignment = TextAlignment.Center,
        //FontAttributes = FontAttributes.Bold,
        BackgroundColor = Color.White, //.LightYellow,
        TextColor = Color.Blue,
        WidthRequest = App.DisplayScaleMax,
        //HeightRequest = 60
      };

      var image001 = new Image
      {
        Source = "Splash_121618002.jpg",
        Opacity = 0.2,
        Margin = new Thickness(0, 0, 0, 0)
      };

      #endregion

      #region Start-It button

      btItemsAdult = new Button
      {
        Text = "Hospitals",
        Image = "techn.jpg",
        Margin = new Thickness(0, 0, 0, 0),
        BorderWidth = 2,
        CornerRadius = 10,
        BorderColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
        //Style = Device.Styles.TitleStyle,
        FontAttributes = FontAttributes.Italic,
        TextColor = Color.White,
        BackgroundColor = Color.DarkRed, //.DeepSkyBlue,
        HorizontalOptions = LayoutOptions.Center,
        HeightRequest = 55,
        WidthRequest = 160
      };
      btItemsAdult.Clicked += OnbtItemsAdultClickedAsync;


      btItemsHistory = new Button
      {
        Text = "Plain List Only",
        Image = "docitsmall.jpg",
        Margin = new Thickness(0, 10, 0, 0),
        BorderWidth = 2,
        CornerRadius = 10,
        BorderColor = Color.White,
        FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
        //Style = Device.Styles.TitleStyle,
        FontAttributes = FontAttributes.Italic,
        TextColor = Color.Black,
        BackgroundColor = Color.LightGray, //.DeepSkyBlue,
        HorizontalOptions = LayoutOptions.Center,
        HeightRequest = 50,
        WidthRequest = 200
      };
      btItemsHistory.Clicked += OnbtItemsHistoryClickedAsync;

      StackLayout stkSum2 = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.EndAndExpand,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        //BackgroundColor = Color.White,
        Spacing = 5,
        WidthRequest = App.DisplayScaleMax,
        Children =
                  {
                    btItemsAdult,
                    btItemsHistory,
                  }
      };

      Frame startframe = new Frame()
      {
        Content = stkSum2,
        BorderColor = Color.Blue,
        CornerRadius = 10,
        HasShadow = true,
        Margin = new Thickness(5, -10, 5, 5),
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HorizontalOptions = LayoutOptions.Center
      };


      #endregion

      #region Stack Layouts

      StackLayout selectionStack = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.Start,
        Margin = new Thickness(0, 15, 0, 0),
        BackgroundColor = Color.Snow, //.LightSlateGray, //.Silver, //.NavajoWhite,
        //WidthRequest = App.DisplayScreenHeight,
        WidthRequest = App.DisplayScaleMax,
        //Spacing = 8,
        Children =
     {
          startframe,
          }
      };


      StackLayout leftStack = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.Start,
        Margin = new Thickness(0, 0, 0, 0),
        BackgroundColor = Color.White, //Color.LightSkyBlue,
        //WidthRequest = App.DisplayScreenHeight,
        Spacing = 12,
        Children =
     {
          image001,
          lb001,
          lb003b,
          selectionStack,
          }
      };


      StackLayout centerStack = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightSkyBlue,
        WidthRequest = App.DisplayScreenHeight,
        Spacing = 12,
        Children =
          {
               leftStack,
          }
      };


			#endregion


			#region Advertisement on bottom
			//

			//  A. Ad-contract is renewable from month to month.
			//  B. An Ad-contract area size is a 'virtual' circle, with a center at Longitude / Latitude, and a radius of x miles
			//  C. Ad-contract areas do not overlap
			//
			// Upon the start of an app, the following steps are mtaken:
			//    1. establishes the devices geao location, 
			//    2. get count of ad-contracts
			//
			//       loop on all contracts
			//				3. reads the ad-contract DB, keyed by location and distance, called contract-location, contract - distance
			//				4. if todays date is not past expiration date:
			//				5. calculate the distance between the device location and the contract - location, called device-distance
			//				6. if the device - distance is less than the contract-distance a hit is found,
			//					7. the texts from the hit record are read and displayed.
			//			end loop
			//


			try
			{
				//    1. establishes its own location, deviceLatitude. deviceLongitude
				Entry100.GetDevLocationAsync();
				//    2. get count of ad-contracts
				Entry100.azLoop = A_Advertisement.GetAzLoopCount();
				Entry100.azLoop = 1;
				//
				// loop on all Azure records
				//
				for (int iL = 0; iL < Entry100.azLoop; iL++)
				{
					//	3. reads the ad-contract DB, keyed by location and distance, called contract-location, contract - distance
					string aa = Entry100.readAd_Azure(iL);
					//	4. if todays date is not past expiration date:

					DateTime dt2 = DateTime.Now; ;
					DateTime dt1 = DateTime.Parse("07/12/2021");

					if (dt1.Date > dt2.Date)
					{
						//	5. calculate the distance between the device location and the contract - location, called device-distance
						int idistance = Entry100.adSpotsDistance_Azure(Entry100.deviceLatitude, Entry100.deviceLongitude, Entry100.aDspotLatitude, Entry100.aDspotLongitude);
						//	6. if the device - distance is less than the contract-distance a hit is found,
						if (idistance <= Entry100.aDspotMiles)
						{
							Entry100.adText = Entry100.adString;
							break;
						}
					}
					else
					{
						//It's an earlier or equal date
					}
				}
				if (Entry100.adText.Length == 0) Entry100.adText = Entry100.adString;
				this.addFooter.Text = "  " + Entry100.adText + "  ";
			}
			catch (Exception ex)
			{
				string aa = ex.ToString();
				//////ib = true;
			}

			A_Advertisement.Adv_Set1(addFooter, 0);
			stackAd = new StackLayout()
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

			#endregion


			#region Final Stacks

			StackLayout stackFinalHeader = new StackLayout()
      {
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.Yellow, //.OldLace,
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
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.White, //.Green, //.Black,
        HeightRequest = App.DisplayScaleMax,
        Children =
            {
             centerStack
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
      // Stacklayout
      // scroll Layout / View
      //   stack layout
      //
      // -------------------------------------------------------------------------
      App.CCMed FinalPageLayout = new App.CCMed();

      FinalPageLayout.TopStack.Children.Add(stackFinalHeader);
      //FinalPageLayout.TopStack.Children.Add(SPheader001);
      //FinalPageLayout.TopStack.Children.Add(FinalScrollView);
      FinalPageLayout.CenterStack.Children.Add(FinalScrollView);
      FinalPageLayout.BottomStack.Children.Add(stackAd); // TopScreen1.contentstatusBaseline);

			// Assign to the page
			this.Content = FinalPageLayout;

      #endregion

      //
      // Setting Startup Values
      //
      //////Accelerometer.Stop();
      //////Preferences.Set("MonitorOnOff", "0");
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
      bool noBlockChain = false;
      Navigation.PushAsync(new FindHospital(noBlockChain));
      //


    }


		// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

		#region Dev Location


		// ===================================================================================================
		// GeoLocation fnc (geolocation)
		//
		// ===================================================================================================
		public static async Task GetDevLocationAsync() //async Task GetDevLocationAsync()
		{
			bool ib = true;
			try
			{
				// Get Latitude, Longitude, Altitude, Accuracy from current location
				var request = new GeolocationRequest(GeolocationAccuracy.Best);
				var results = await Geolocation.GetLocationAsync(request);
				var deviceLatitude = Convert.ToDouble(results.Latitude.ToString());
				var deviceLongitude = Convert.ToDouble(results.Longitude.ToString());
			}
			catch (Exception ex)
			{
				string aa = ex.ToString();
				ib = true;
			}
		}


		// ===================================================================================================
		// Read a single ad-contract
		//
		// ===================================================================================================
		public static string readAd_Azure(int iL)
		{
			bool iB = false;
			string adText = "";
			string adString = "";

			try
			{
				iL = iL;
				var aDspotLatitude = 37.783333;       // faked Azure result
				var aDspotLongitude = -122.416667;    // faked Azure result
				var aDspotMiles = 100;                // faked Azure adspot miles
				var adDate = DateTime.Now.ToString("dd/MM/yyyy");
				adText = "";
			}
			catch (Exception ex)
			{
				string aa = ex.ToString();
				iB = true;
			}
			return adText;
		}


		// ===================================================================================================
		// calculate distance between device location and ad-location just read from Azure
		//
		// ===================================================================================================
		public static int adSpotsDistance_Azure(Double indeviceLatitude, Double indeviceLongitude,
			Double inaDspotLatitude, Double inaDspotLongitude)
		{
			int imiles = 0;
			try
			{
				inaDspotLatitude = 37.783333;       // faked Azure result
				inaDspotLongitude = -122.416667;    // faked Azure result
				Location deviceLocation = new Location(indeviceLatitude, indeviceLongitude);
				Location adContractLocation = new Location(37.783333, -122.416667);
				double miles = Location.CalculateDistance(deviceLocation, adContractLocation, DistanceUnits.Miles);
				imiles = Convert.ToInt32(miles);
			}
			catch (Exception ex)
			{
				string aa = ex.ToString();
				imiles = 0;
			}
			return imiles;
		}


		#endregion

		// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



		// ======================================================================
		// Start It, Adult
		//
		// ======================================================================
		void OnbtItemsAdultClickedAsync(object sender, EventArgs e)
    {
      try
      {
        var duration = TimeSpan.FromMilliseconds(1000);
        Vibration.Vibrate(duration);
      }
      catch (FeatureNotSupportedException ex)
      {
        string Catchex = ex.Message.ToString();
      }
      bool inow = false;
      Navigation.PushAsync(new FindHospital(inow));
    }


    // ======================================================================
    // Start It, Child
    //
    // ======================================================================
    void OnbtItemsHistoryClickedAsync(object sender, EventArgs e)
    {
      try
      {
        var duration = TimeSpan.FromMilliseconds(1000);
        Vibration.Vibrate(duration);
      }
      catch (FeatureNotSupportedException ex)
      {
        string Catchex = ex.Message.ToString();
      }

      Navigation.PushAsync(new HospitalList());
    }


  }
}