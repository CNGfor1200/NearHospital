// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//                                                  
// Name: FindHospital
// Vers: 3.0.0.0
//
// Find a hospital near by from GPS, draw a map, show details
// ..............................................................
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class FindHospital : ContentPage
  {


    Xamarin.Forms.Button displayGoogle;
    Xamarin.Forms.Button btdisplayAllHospitals;

    // Geo Location
    Label lblLating;
    Label PrimlblDisplayAddress;

    Label lblMyAddress;

    Label nearestHspt;

    double deviceLatitude = 0.0;
    double deviceLongitude = 0.0;

		#region advertisement data, sub modules
		// LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL

		Label addFooter = new Label();
		StackLayout stackAd = new StackLayout();

		// LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
		#endregion



		// ......................................................................................................
		// Main Entry
		//
		// noblockchain = false (no data) = tru (have data, continue)
		// ......................................................................................................
		public FindHospital(bool noBlockChain)
    {
      InitializeComponent();

      this.Title = "Near Hospitals, ER"; // Hospital \n\r  <LineBreakMode.TailTruncation>  Location(s)";
      BackgroundColor = Color.LightGray;


      App.requestedHospitalRange = 1000;

      noBlockChain = false;
      GetHospitalDBAsync();

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
      // Share
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


      var boxViewbnew0 = new BoxView()
      {
        Margin = new Thickness(0, 8, 0, 0),
        HeightRequest = 2,
        WidthRequest = WidthRequest = App.DisplayScaleMax, // (App.DisplayScreenWidth),
        BackgroundColor = Color.LightBlue, //White
      };


      #region Nearest Hospital

      // Nearest Hospital label
      nearestHspt = new Label()
      {
        //Margin = new Thickness(0, 15, 0, 0),
        Text = "\n The Nearest Hospital / ER:\n",
        //FontAttributes = FontAttributes.Bold,
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.White,
        HorizontalTextAlignment = TextAlignment.Start,
        BackgroundColor = Color.Black, //Gray,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        WidthRequest = App.DisplayScaleMax // (App.DisplayScreenWidth)
      };


      // Display Info, nearest hospital
      displayGoogle = new Button
      {
        Text = "Loading Name",
        Margin = new Thickness(0, 0, 0, 0),
        CornerRadius = 8,
        BorderColor = Color.Red,
        BorderWidth = 2,
        TextColor = Color.Blue,
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
        BackgroundColor = Color.Yellow,
        HeightRequest = 85,
        WidthRequest = 300
      };
      displayGoogle.Clicked += DisplayGoogleClicked;


      // two buttons  [Hospital Info]    [Directions]
      var stckDisplayMap = new StackLayout()
      {
        Margin = new Thickness(0, -5, 0, 0),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.Black, //Gray, //.Black,
                                       //HeightRequest = 35,
        Spacing = 15,
        Children =
        {
            displayGoogle,
        }
      };


      var stckNearestHospitalHeader = new StackLayout()
      {
        Margin = new Thickness(0, 0, 0, 0),
        WidthRequest = App.DisplayScaleMax, // (App.DisplayScreenWidth),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.Black, //Gray, //LightGray, //.Black,
        Children =
        {
          nearestHspt
        }
      };

      // "Nearest ...", [Hospital Distance]
      var stckNearestHospital = new StackLayout()
      {
        Margin = new Thickness(0, 0, 0, 15),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.Black, //Gray, //LightGray, //.Black,
        Children =
        {
          stckDisplayMap
        }
      };

      #endregion

      #region Display Hospitals in Range

      Label lblHospitalDBHeader = new Label
      {
        Margin = new Thickness(25, 15, 0, 0),
        Text = "All other Hospitals / ER's  (in 100 Miles Range) \n\nTap the List-Button, and next select a Hospital for more information,\nas well as rating if available from Google.\n",
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
        //FontAttributes = FontAttributes.Bold,
        TextColor = Color.White,
        HorizontalTextAlignment = TextAlignment.Start,
        BackgroundColor = Color.SlateGray, //DarkGray,   //
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand, //,
        WidthRequest = 490
      };


      // Display all hospitals in Range
      btdisplayAllHospitals = new Button
      {
        Text = "List of all Hospitals",
        CornerRadius = 8,
        BorderColor = Color.Red,
        BorderWidth = 1,
        Font = Font.SystemFontOfSize(NamedSize.Small),
        BackgroundColor = Color.LightYellow,
        HorizontalOptions = LayoutOptions.Center,
        HeightRequest = 35,
        //WidthRequest = 180,
        TextColor = Color.Black
      };
      btdisplayAllHospitals.Clicked += async (sendernav, args) =>
      await Navigation.PushAsync(new HospitalList()); //       HospitalList()); // displayHospitals());

      var stckDisplayHospital = new StackLayout()
      {
        Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.SlateGray, //.Black,
        Children =
        {
          lblHospitalDBHeader
        }
      };

      // [List All] button
      var stckLoadHospitals = new StackLayout()
      {
        Margin = new Thickness(5, 5, 0, 20),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.SlateGray, //Color.Red, //Black,
        HeightRequest = 35,
        Children =
          {
            btdisplayAllHospitals
          }
      };


      #endregion

      #region MyAddress
      // Current Address Label
      lblMyAddress = new Label()
      {
        Margin = new Thickness(6, 0, 0, -25),
        Text = "My Address  (via GPS) ....................",
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.Black,
        BackgroundColor = Color.LightGray,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
      };

      Image MyAddressHelp = new Image
      {
        Margin = new Thickness(-10, 0, 0, 0),
        Source = "smallhelp.png"
      };
      // Mark label for tap event
      TapGestureRecognizer MyAddressHelp_tap = new TapGestureRecognizer();
      MyAddressHelp_tap.Tapped += async (s, e) =>
      {
        Boolean ans = await DisplayAlert("GPS Address generator", "Possible issues:\n" +
          "1) No data; blockchain error: NH14\n" +
          "     Please follow msg in address box\n\n" +
          "2) Slow to get GPS data:\n" +
          "     Other apps using GPS?\n" +
          "     Exit completely out of \n" +
          "      'NearHospital', try again.\n\n" +
          "3) No data, even after a minute:\n" +
          "      Go to Phone [Settings]\n" +
          "        Tap on - Connections, \n" +
          "        check \"Locations\" (must be ON)", "Got it", " ");
      };
      MyAddressHelp.GestureRecognizers.Add(MyAddressHelp_tap);

      var stckMyAddress = new StackLayout()
      {
        Margin = new Thickness(10, 10, 0, 0),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.LightGray, //.Black,
        Spacing = 10,
        Children =
                    {
                      lblMyAddress,MyAddressHelp
                    }
      };

      #endregion

      #region AddressDisplay
      PrimlblDisplayAddress = new Label
      {
        Margin = new Thickness(10, -5, 0, 0),
        Text = " No valid address data yet.... \n  " +
          "   synching the GPS satellites \n  " +
          "   can take a few seconds",
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
        TextColor = Color.Black,
        BackgroundColor = Color.LightYellow,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.Start
      };

      var MyLocation = new Image()
      {
        IsVisible = true,
        Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("aamylocation.png") : ImageSource.FromFile("Images/aamylocation.png"),
        HeightRequest = 30,
        WidthRequest = 30,
        Margin = new Thickness(10, -5, 0, 0),
      };
      // Mark label for tap event
      TapGestureRecognizer MyLocation_tap = new TapGestureRecognizer();
      MyLocation_tap.Tapped += (s, e) =>
      {
        AddressMap100();
      };
      MyLocation.GestureRecognizers.Add(MyLocation_tap);


      var stckDisplayAddress0 = new StackLayout()
      {
        Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.LightGray, //.Black,
        Spacing = 15,
        Children =
        {
         PrimlblDisplayAddress,
        }
      };

      var stckDisplayAddress = new StackLayout()
      {
        Margin = new Thickness(5, 4, 0, 0),
        Orientation = StackOrientation.Horizontal,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.Start,
        BackgroundColor = Color.LightGray, //.Black,
        Spacing = 15,
        Children =
        {
         stckDisplayAddress0, MyLocation
        }
      };

      #endregion

      #region Latitude / Longitude
      // Latitude / Longitude label
      lblLating = new Label
      {
        Margin = new Thickness(10, 0, 0, 0),
        Text = "Latitude:              Longitude:  ",
        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
        TextColor = Color.Black,
        BackgroundColor = Color.LightGray,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand

      };

      var stcklblLating = new StackLayout()
      {
        Margin = new Thickness(10, 5, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.LightGray, //.Black,
                                           //HeightRequest = 55,
                                           //Spacing = 10,
        Children =
        {
          lblLating,                // long - lat display}
        }
      };


      #endregion


      #region StackLayout
      // ------------------------------------------------------------------------
      // Collection 1 Stacklayout
      // -------------------------------------------------------------------------
      var CollectStack1 = new StackLayout()
      {
        Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand, //HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.LightGray, //.Black,
        Children =
                {
                    stckMyAddress,
                    stckDisplayAddress,
                    stcklblLating,
                }
      };
      var CollectStack2 = new StackLayout()
      {
        //Margin = new Thickness(0, 20, 0, 20),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand, //HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.Black, //Gray, //.Black,
        Children =
                {
                    stckNearestHospitalHeader,      // nearest hospital, [get distance button]
                    stckNearestHospital,            // nearest hospital, [get distance button]
                }
      };
      var CollectStack3 = new StackLayout()
      {
        //Margin = new Thickness(0, 0, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand, //HorizontalOptions = LayoutOptions.StartAndExpand,
        BackgroundColor = Color.SlateGray, //   .LightGray, //.Black,
        WidthRequest = App.DisplayScaleMax, // (App.DisplayScreenWidth),
        Children =
                {
                    stckDisplayHospital,
                    stckLoadHospitals,
                }
      };

			#endregion


			#region Advertisement on bottom

			Label addFooter = new Label()
			{
				Margin = new Thickness(0, 3, 0, 0),
				Text = "Published by CNG Internet Software, LLC\n" +
				"..publisher by/on mid-November 2018 of the 'CC Medical Emergency' app..",
				FontAttributes = FontAttributes.None,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				WidthRequest = App.DisplayScaleMax //  App.DisplayScreenHeight
			};

			StackLayout stackAd = new StackLayout()
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
        HorizontalOptions = LayoutOptions.CenterAndExpand, //.StartAndExpand,
        BackgroundColor = Color.Blue, //LightGray, //.OldLace,
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
        HorizontalOptions = LayoutOptions.CenterAndExpand, //StartAndExpand,
                                                           //BackgroundColor = Color.Chocolate, //LightGray, //.Black,
        Children =
                {
                    CollectStack2,
                    //boxViewbnew0,
                    CollectStack3,
                    CollectStack1
               }
      };

      ScrollView FinalScrollView = new ScrollView()
      {
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand, //HorizontalOptions = LayoutOptions.FillAndExpand,
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
      FinalPageLayout.BottomStack.Children.Add(stackAd); // App.contentstatusBaseline);App.contentstatusBaseline);

      // Assign to the page
      this.Content = FinalPageLayout;

      #endregion



      //
      GetDevLocationAsync();                                         // get deviceLatitude, deviceLongitude, and actual device address if any
      //

    }



    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    #region Dev Location


    // ===================================================================================================
    // GeoLocation fnc (geolocation)
    //
    // ===================================================================================================
    async Task GetDevLocationAsync()
    {

      bool ib = true;
      try
      {
        //
        // Get Latitude, Longitude, Altitude, Accuracy from current location
        // -------------------------------------------------------------------------
        var request = new GeolocationRequest(GeolocationAccuracy.Best);
        var results = await Geolocation.GetLocationAsync(request);
        deviceLatitude = Convert.ToDouble(results.Latitude.ToString());
        deviceLongitude = Convert.ToDouble(results.Longitude.ToString());


        //deviceLatitude = 37.783333;         SF, testing
        //deviceLongitude = -122.416667;



        string strAccuracyMeters = Convert.ToInt32(results.Accuracy).ToString();
        string strAccuracyFeet = (Convert.ToInt32(results.Accuracy) * 3.28).ToString();

        lblLating.Text = string.Format("Lat: {0}    Long: {1} \nLocation Accuracy ~ :  {2} {3}  or  {4} {5}",
        deviceLatitude, deviceLongitude, strAccuracyMeters, "m", strAccuracyFeet, "feet");

        //
        // Get address from Latitude, Longitude
        // -------------------------------------------------------------------------
        if (results != null)
        {
          var placemarks = await Geocoding.GetPlacemarksAsync(deviceLatitude, deviceLongitude);
          var placemark = placemarks?.FirstOrDefault();
          if (placemark != null)
          {
            PrimlblDisplayAddress.Text =
              "  " + placemark.FeatureName + " " + placemark.Thoroughfare + ",  \n"
              + "  " + placemark.Locality + "  \n"
              + "  " + placemark.AdminArea + ", " + placemark.CountryCode + "  " + placemark.PostalCode + "  ";
          }
        }


        //
        // Generate "minimum" address list (hospitals in range)
        // -------------------------------------------------------------------------

        int atemp = (Convert.ToInt32(App.defaultHospitalRange));
        atemp = atemp * 100;
        App.requestedHospitalRange = atemp;
        //
        // Now get the list
        // And at the end of the list-generation, show nearest hospital
        //
        Load_HospitalsInRage(deviceLatitude, deviceLongitude);
        //
        if (App.hospitalsInRangeCount == -1) App.hospitalsInRangeCount = 0;
        btdisplayAllHospitals.Text = "  " + App.hospitalsInRangeCount.ToString() + " Hospitals - Show List  ";
        if (App.hospitalsInRangeCount == 1) btdisplayAllHospitals.Text = "  " + App.hospitalsInRangeCount.ToString() + " Hospital - Show List  ";
        //

        //
        // Get Actual Nearest Hospital
        // -------------------------------------------------------------------------
        ShowHospitalDistance();
        ib = false;
      }
      catch (Exception ex)
      {
        string aa = ex.ToString();
        lblLating.Text = " Device NOT at a valid (Google) address";
        ib = true;
      }
      if (ib)
      {

        Boolean ans = await DisplayAlert("Internet Access", "Possible issues:\n\n" +
          "Assure you have FULL Internet Access:\n" +
          " 1) Go to your Phone's [Settings]\n" +
          " 2) Check CONNECTION TO Internet / WiFi\n" +
          "    or\n" +
          " 3) turn \"Data Usage\" on $$ fee !!\n" +
          "    you may also need to set\n" +
          " 4) LOCATION permission under\n" +
          "    --> Settings --> Google --> Location\n", "Got it", " ");

      }
    }


    // ===================================================================================================
    // Show hospital distance on first page
    //
    // get the first hospitalsInRange array element (is always the nearest)
    // ===================================================================================================
    void ShowHospitalDistance()
    {
      //
      if (App.hospitalsInRangeCount == 0)
      {
        displayGoogle.Text = " No near Hospital found yet.";
        return;
      }
      if (App.hospitalsInRangeCount == -1)
      {
        displayGoogle.Text = " Address Coordinates not inside the USA";
      }
      else
      {
        displayGoogle.Text = "  " + Convert.ToDouble(App.hospitalsInRange[0, 1] / 100.00).ToString() + " miles  --  " + App.hospitalsDB[App.hospitalsInRange[0, 0], 0] + "\n\n" +
          "  Tap this button for Info   -   Google Rating   -   Direction  ";
      }
      //displayGoogle.WidthRequest = Convert.ToInt32(displayGoogle.Text.Length + 2) * 7; ;  //   //

    }


    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Get hospital "DB"
    //
    //
    // 00 - biz_name
    // 01 - biz_info
    // 02 - e_address
    // 03 - e_city
    // 04 - e_state
    // 05 - e_postal
    // 06 - e_country
    // 07 - loc_county
    // 08 - loc_LAT_poly
    // 09 - loc_LONG_poly
    // 10 - biz_phone
    // 11 - web_url
    // 12 - f_emergency
    // 13 - biz_bedcount
    //
    //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    async System.Threading.Tasks.Task<bool> GetHospitalDBAsync()
    {

      bool iB = false;
      string strtext = "";

      try
      {

        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Entry100)).Assembly;  // AHeadSplash1)).Assembly;
        Stream stream = assembly.GetManifestResourceStream("NearHspt.kranken.txt");
        using (var reader = new System.IO.StreamReader(stream))
        {
          strtext = reader.ReadToEnd();
        }
        // Split into lines.
        strtext = strtext.Replace('\n', '\r');
        string[] hosplines = strtext.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

        App.hospitalsDBRowsCount = hosplines.Length;
        App.hospitalsDBColsCount = hosplines[0].Split(',').Length;
        //
        // split each record into fields ... hospitalsDBArray[inow, jnow] ...
        //
        App.hospitalsDB = new string[App.hospitalsDBRowsCount, App.hospitalsDBColsCount];
        for (int inow = 1; inow < App.hospitalsDBRowsCount; inow++)
        {
          string[] tempLine = hosplines[inow].Split(',');
          for (int jnow = 0; jnow < App.hospitalsDBColsCount; jnow++)
          {
            App.hospitalsDB[inow - 1, jnow] = tempLine[jnow];
          }
        }
        iB = false;
      }
      catch (Exception stre)
      {
        string aa = stre.Message.ToString();
        iB = true;
      }
      return iB;
    }


    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Load a two-dimensional array with 
    // 1) all indexes (into hospitalsDB )
    // 2) distance for that index
    //
    // 1. get distance from target to every hospital
    // 2. if < 10/20/30/40 save in index array <hospital pointer, distance>
    // 3. sort the helper arrays by distance. 
    //      We now have 5 arrays, sorted by distance, holding hospital pointers
    // 4. Fill the actual details arrays using the helper arrays
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    private void Load_HospitalsInRage(double inLatfrom, double inLongfrom)
    {
      //
      //
      bool iB = true;
      Location coord1 = new Location(inLatfrom, inLongfrom);
      Location coord2 = new Location(inLatfrom, inLongfrom);
      double distanceInRadius = 0.0f;
      Int32 intdistanceInRadius = 0;

      App.hospitalsInRangeCount = 0;
      if (inLatfrom <= 0.0) iB = false;
      if (inLongfrom <= 0.0) iB = false;

      try
      {
        //
        // Get Distance, and fill helper arrays 
        //
        App.hospitalsInRangeCount = 0;
        for (int innn = 0; innn < App.hospitalsDBRowsCount; innn++)
        {
          // There are some records that have no Latitude / Longitude
          // both cases will be handled by the abreviated catch {}
          try
          {
            // Get 'radian' distance, i.e. "Birdview" distance between device-address and array entry
            coord2 = new Location(Convert.ToDouble(App.hospitalsDB[innn, 8]), Convert.ToDouble(App.hospitalsDB[innn, 9]));
            distanceInRadius = Location.CalculateDistance(coord1, coord2, DistanceUnits.Miles);
            intdistanceInRadius = Convert.ToInt32((distanceInRadius) * 100);
            if (intdistanceInRadius < App.requestedHospitalRange)
            {
              App.hospitalsInRange[App.hospitalsInRangeCount, 0] = innn;
              App.hospitalsInRange[App.hospitalsInRangeCount, 1] = intdistanceInRadius;
              App.hospitalsInRangeCount++;
              iB = false;
            }

          }
          catch (Exception stre)
          {
            string aa = stre.Message.ToString();
          }
        }

      }
      catch (Exception stre)
      {
        string aa = stre.Message.ToString();
      }

      App.hospitalsInRangeCount = App.hospitalsInRangeCount - 1;


      //
      // sort helper arrays by distance
      //
      if (iB == false)
      {
        SorthospitalsInRange();
      }
    }


    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Sort the in-range array  App.hospitalsInRange  by distance  
    //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    private void SorthospitalsInRange()
    {
      // helper class
      Int32 tempPoint = 0;
      Int32 tempDis = 0;


      bool didSwap;
      do
      {
        didSwap = false;
        for (int i = 0; i < App.hospitalsInRangeCount; i++)
        {
          if (App.hospitalsInRange[i, 1] > App.hospitalsInRange[i + 1, 1])
          {
            tempPoint = App.hospitalsInRange[i + 1, 0];                       // save pointer 
            tempDis = App.hospitalsInRange[i + 1, 1];                         // save distance
            App.hospitalsInRange[i + 1, 0] = App.hospitalsInRange[i, 0];  // write next higher to lower
            App.hospitalsInRange[i + 1, 1] = App.hospitalsInRange[i, 1];
            App.hospitalsInRange[i, 0] = tempPoint;                   // write saved to higher
            App.hospitalsInRange[i, 1] = tempDis;
            didSwap = true;
          }
        }
      } while (didSwap);

    }


    #endregion


    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



    #region Standard functions


    // -----------------------------------------------------------------------------------
    // Display Google Map by address from an image
    // -----------------------------------------------------------------------------------
    async void AddressMap100()
    {
      try
      {

        //
        // get hospital
        //
        int hloc = App.hospitalsInRange[0, 0];
        double hLat = Convert.ToDouble(App.hospitalsDB[hloc, 8]);
        double hLong = Convert.ToDouble(App.hospitalsDB[hloc, 9]);
        var location = new Location(hLat, hLong);
        var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

        await Map.OpenAsync(location, options);

      }
      catch (Exception ex)
      {
        string aa = ex.Message.ToString();
      }

    }



    // -----------------------------------------------------------------------------------
    // Display Google Search Results
    // -----------------------------------------------------------------------------------
    async void DisplayGoogleClicked(object sender, EventArgs e)
    {
      App.selectedHospital = App.hospitalsInRange[0, 0];
      string searchStr = "https://www.google.com/search?q=%22";
      searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," + App.hospitalsDB[App.selectedHospital, 3] + "," + App.hospitalsDB[App.selectedHospital, 4];
      searchStr = searchStr + "%22";

      //Uri k5 = new Uri("Google.com/"); // \"Centrastate Hospital, Freehold, new Jersey\""); //"Google.com";
      //GetRatings.HospitalOpenBrowser(k5); //.   .HospitalOpenBrowser(k5); // "Google.com/ \"Centrastate Hospital, Freehold, new Jersey\"");
      //Device.OpenUri(new Uri("https://www.google.com/search?q=%22centrastate%20hospital,%20freehold,%20new%20jersey%22")); // https://www.Google.com/")); //\"Centrastate Hospital, Freehold, new Jersey\""); //   //"https://www.cnginternetsoftware.com/smart-phone-software"));
      //Device.OpenUri(new Uri("https://www.google.com/search?q=THE FINLEY HOSPITAL,Dubuque,IA"));

      Device.OpenUri(new Uri(searchStr));

      //THE FINLEY HOSPITAL,A,350 N Grandview Ave,Dubuque,IA,52001,USA,Dubuque,42.495399,-90.68744,(563) 582 - 1881,http://www.finleyhospital.org,TRUE,139

    }


    #endregion




  }



  // ====================================================================
  //
  //
  // ====================================================================
  public class LatLng
  {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public LatLng(double latin, double lngin)
    {
      this.Latitude = latin;
      this.Longitude = lngin;
    }
  }


  // ====================================================================
  //
  //
  // ====================================================================
  static class Utils888
  {
    public enum DistanceUnit { Miles, Kilometers };
    public static double ToRadian(this double value)
    {
      return (Math.PI / 180) * value;
    }

    public static double HaversineDistance(LatLng coord1, LatLng coord2, DistanceUnit unit)
    {
      double R = (unit == DistanceUnit.Miles) ? 3960 : 6371;
      var lat = (coord2.Latitude - coord1.Latitude).ToRadian();
      var lng = (coord2.Longitude - coord1.Longitude).ToRadian();

      var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
               Math.Cos(coord1.Latitude.ToRadian()) * Math.Cos(coord2.Latitude.ToRadian()) *
               Math.Sin(lng / 2) * Math.Sin(lng / 2);

      var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));

      return R * h2;
    }



  }











  public class GetRatings
  {
    public static async Task<bool> HospitalOpenBrowser(Uri uri)
    {
      return await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
  }





}
