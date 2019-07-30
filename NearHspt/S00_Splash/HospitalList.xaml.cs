// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: HospitalList
// Vers: 3.0.0.0
//
// Find a hospital near by, draw a map, show details
// ..............................................................
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HospitalList : ContentPage
  {

		#region advertisement data, sub modules
		// LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL

		Label addFooter = new Label();
		StackLayout stackAd = new StackLayout();

		// LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
		#endregion



		// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		// Hospital Area Location
		// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		public HospitalList() //string strAddress)
    {
      InitializeComponent();

      this.Title = "Hospital List";
      BackgroundColor = Color.Black;

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


      // .........................................................................................
      // 1. we have a list of hospital pointers distances (from FindHospital"
      // 2. we will create a list (setList6) of hospitals, (distance, Name), keyed by distance
      // .........................................................................................
      ObservableCollection<HospitalListmach> listSource6s = new ObservableCollection<HospitalListmach>();

      string[] setList6 = new string[App.hospitalsInRangeCount];
      int inow = 0;
      int newIndex = 0;
      string newMilage = "";
      App.hospitalsShownCount = 0;
      int icheckdis = Convert.ToInt32((App.requestedHospitalRange) * 100.00);
      for (inow = 0; inow < App.hospitalsInRangeCount; inow++)
      {
        if ((Convert.ToInt32(App.hospitalsInRange[inow, 1])) < icheckdis)
        {
          newIndex = App.hospitalsInRange[inow, 0];
          newMilage = (((Convert.ToDouble(App.hospitalsInRange[inow, 1])) / 100.0)).ToString();
          if (newMilage == "0")
          {
            //break;
          }
          else
          {
            // need to add trailing blanks for single decimal numbers (5.66 vs 5.5"
            if ((newMilage.Length - newMilage.LastIndexOf(".")) == 2) newMilage = newMilage + "0";
            // preset the milage to "b999.99bb" / "bbb9.99bb"
            switch (newMilage.Length - 4)
            {
              case 0:
                newMilage = "   " + newMilage + "   ";
                break;
              case 1:
                newMilage = "  " + newMilage + "   ";
                break;
              case 2:
                newMilage = " " + newMilage + "   ";
                break;
              default:
                newMilage = " " + newMilage + "   ";
                break;
            }
            // need to add trailing blanks for single decimal numbers (5.66 vs 5.5"
            if ((newMilage.Length - newMilage.LastIndexOf(".")) == 2)
            {
              newMilage = newMilage + "   ";
            }
            else
            {
              newMilage = newMilage + "  ";
            }
            string strBeds = App.hospitalsDB[newIndex, 13];
            string strFiller1 = "  ";
            if (strBeds == "") strBeds = "N/R";
            int iTemp1 = 5 - strBeds.Length;
            if (iTemp1 == 1) strFiller1 = "  ";
            if (iTemp1 == 2) strFiller1 = "   ";
            if (iTemp1 == 3) strFiller1 = "     ";
            setList6[inow] = newMilage.ToString() + "  " + strBeds + strFiller1 + "- " + App.hospitalsDB[newIndex, 0];
          }
        }
        else
        {
          //
          // the list is from shortest to longest distance
          // the first time the listed milage is above the requested, we can leave the for loop
          break;
        }
      }


      ObservableCollection<HospitalListmach> listSource6 = new ObservableCollection<HospitalListmach>();

      int know = 0;
      for (know = 0; know < App.hospitalsInRangeCount; know++)
      {
          // 13.89  456  - name
          string[] strTemp = setList6[know].Split('-');
          string strName = strTemp[1].Substring(1, strTemp[1].Length - 1);
          int ipos1 = strTemp[0].IndexOf(".");
          string bedcount = strTemp[0].Substring(ipos1 + 3, strTemp[0].Length - (ipos1 + 3));
        string strbeds = "";
        try
        {
          strbeds = Convert.ToInt32(bedcount).ToString() + " beds";
        }
        catch (Exception e)
        {
          string aa = e.Message.ToString();
          strbeds =" N/A ";
        }
        string strmiles = strTemp[0].Substring(0, ipos1 + 2) + " miles     " + strbeds;
          string temp100 = strName + "\n" + strmiles;
          listSource6.Add(new HospitalListmach { DisplayName = temp100 }); // setList6[know] });
      }
      //

      listView6.Margin = new Thickness(0, 5, 0, 0);
      listView6.RowHeight = 55 ;
      //listView6.HasUnevenRows = true;
      listView6.ItemsSource = listSource6; //= setList6; 

      listView6.ItemSelected += async (sender, e) =>
      {
        var session = (HospitalListmach)e.SelectedItem;
        string sessionHit = session.DisplayName.ToString();

        // " 23.67    345  - Hospital One"  isolate Hospital One, get index into hospitalsInRange
        // " 23.67    N/R  - Hospital One"  isolate Hospital One, get index into hospitalsInRange
        string[] strTemp2 = sessionHit.Split('\n');
        string strselHospital = strTemp2[0].TrimStart(' ');

        for (int ii = 0; ii < App.hospitalsInRangeCount; ii++)
        {
          if (App.hospitalsDB[App.hospitalsInRange[ii, 0], 0] == strselHospital)
          {
            App.selectedHospital = App.hospitalsInRange[ii, 0];
            break;
          }
        }

        //await Navigation.PushAsync(new HospitalDetails());

        string searchStr = "https://www.google.com/search?q=%22";
        searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," + App.hospitalsDB[App.selectedHospital, 3] + "," + App.hospitalsDB[App.selectedHospital, 4];
        searchStr = searchStr + "%22";

        Device.OpenUri(new Uri(searchStr));

      };



      #region Advertisement

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
        WidthRequest = App.DisplayScaleMax, // App.DisplayScreenHeight
      };

      #endregion

      // Return button
      var stklistView6 = new StackLayout()
      {
        Margin = new Thickness(10, 0, 0, 0),
        Orientation = StackOrientation.Vertical,
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.White,
        Children =
           {
             listView6 //TB001
           }
      };


      #region Final Stacks

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
        BackgroundColor = Color.White,
        Children =
                {
                    stklistView6
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
      //    scroll Layout / View
      //         stack layout
      //
      // -------------------------------------------------------------------------
      App.CCMed FinalPageLayout = new App.CCMed();

      FinalPageLayout.TopStack.Children.Add(stackFinalHeader);
      //FinalPageLayout.TopStack.Children.Add(SPheader001);
      //FinalPageLayout.TopStack.Children.Add(FinalScrollView);
      FinalPageLayout.CenterStack.Children.Add(FinalScrollView);
      FinalPageLayout.BottomStack.Children.Add(stackAd); // App.contentstatusBaseline);App.contentstatusBaseline);

      // Assign to the page
      this.Content = FinalPageLayout;

      #endregion

    }


  }

  public class HospitalListmach
  {
    public string DisplayName { get; set; }
  }
}
