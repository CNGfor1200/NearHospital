// ..............................................................
// Medical Emergency Application 1B-6
// CNG Internet Software, Manalapan, New Jesey, USA
//
// Copyright @ 2018, 2019 CNG Internet Software, LLC
//
// Name: Setup, Main
// Vers:
//
// 
// .............................................................
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseSetup : ContentPage
  {

    Label lblownersName;
    Entry ownersNameEntry;

    Label lblownersTelNumber;
    Entry ownersTelNumberEntry;

    Label lblownersEmail;
    Entry ownersEmailEntry;


    Label soundonoffLabel;

    Button getNotificationTel;


		Button Testx;
		Button Testy;

		public BaseSetup()
    {
      InitializeComponent();

      this.Title = "SETUP";
      BackgroundColor = Color.Black;


      #region Toolbar 007
      //
      // .......................................................................
      // Tool Bar
      // .......................................................................
      ToolbarItems.Clear();
      // set originator, the returning address/name


      //// To Do
      //ToolbarItem TBI_ToDo = new ToolbarItem
      //{
      //  Icon = "docit.png",
      //  Order = ToolbarItemOrder.Primary,
      //  Command = new Command(async () => await Navigation.PushAsync(new BaseToDo(1)))
      //};
      //ToolbarItems.Add(TBI_ToDo);

      //// Main
      //ToolbarItem TBI_Main = new ToolbarItem
      //{
      //  Icon = "ems.png",
      //  Order = ToolbarItemOrder.Primary,
      //  Command = new Command(async () => await Navigation.PushAsync(new TopScreen1()))
      //};
      //ToolbarItems.Add(TBI_Main);

      // .......................................................................
      //

      #endregion



      var boxViewbnew0 = new BoxView()
      {
        Margin = new Thickness(0, 8, 0, 0),
        HeightRequest = 2,
        WidthRequest = WidthRequest = (App.DisplayScreenWidth),
        BackgroundColor = Color.LightGray
      };


      #region owners name
      lblownersName = new Label
      {
        Margin = new Thickness(0, 5, 0, 0),
        Text = "Your Name.......:",
        FontSize = Device.GetNamedSize(NamedSize.Micro,  typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.CenterAndExpand, //,
        HeightRequest = 35,
        WidthRequest = 90
      };

      ownersNameEntry = new Entry()
      {
        Margin = new Thickness(3, 0, 0, 0),
        Text = Preferences.Get("notesOwnerName", "default_value"),
        BackgroundColor = Color.SlateGray, //.LightYellow,
        FontSize = Device.GetNamedSize(NamedSize.Micro,  typeof(Entry)),
        TextColor = Color.White,
        IsVisible = true,
        Keyboard = Keyboard.Create(KeyboardFlags.Suggestions),
        //Placeholder = "address or Latitude / Longitude",
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HeightRequest = 35,
        WidthRequest = 220 //(App.DisplayScreenWidth) - 115

      };
      ownersNameEntry.Completed += ownersNameEntry_Completed;
      //ownersNameEntry.Focused += ownersNameEntry_Focused;
      ownersNameEntry.TextChanged += ownersNameEntry_TextChanged;


      #endregion

      #region owners Tel Number
      lblownersTelNumber = new Label
      {
        Margin = new Thickness(0, 5, 0, 0),
        Text = "This Phone's #.:",
        FontSize = Device.GetNamedSize(NamedSize.Micro,  typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.CenterAndExpand, //,
        HeightRequest = 35,
        WidthRequest = 90
      };

      ownersTelNumberEntry = new Entry()
      {
        Margin = new Thickness(3, 0, 0, 0),
        Text = Preferences.Get("notesOwnerTelnum", "default_value"),
        BackgroundColor = Color.SlateGray, //.LightYellow,
        FontSize = Device.GetNamedSize(NamedSize.Micro,  typeof(Entry)),
        TextColor = Color.White,
        IsVisible = true,
        Keyboard = Keyboard.Telephone, //(KeyboardFlags.Suggestions),
        //Placeholder = "address or Latitude / Longitude",
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HeightRequest = 35,
        WidthRequest = 220 //(App.DisplayScreenWidth) - 115

      };
      ownersTelNumberEntry.Completed += ownersTelNumberEntry_Completed;
      //ownersTelNumberEntry.Focused += ownersTelNumberEntry_Focused;
      ownersTelNumberEntry.TextChanged += ownersTelNumberEntry_TextChanged;

      #endregion

      #region owners EMail
      lblownersEmail = new Label
      {
        Margin = new Thickness(0, 5, 0, 0),
        Text = "Your EMail........:",
        FontSize = Device.GetNamedSize(NamedSize.Micro,  typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.CenterAndExpand, //,
        HeightRequest = 35,
        WidthRequest = 90
      };

      ownersEmailEntry = new Entry()
      {
        Margin = new Thickness(3, 0, 0, 0),
        Text = Preferences.Get("notesOwnerEmail", "default_value"),
        BackgroundColor = Color.SlateGray, //.LightYellow,
        FontSize = Device.GetNamedSize(NamedSize.Micro,  typeof(Entry)),
        TextColor = Color.White,
        IsVisible = true,
        Keyboard = Keyboard.Email, // (KeyboardFlags.Suggestions),
        //Placeholder = "address or Latitude / Longitude",
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HeightRequest = 35,
        WidthRequest = 220 //(App.DisplayScreenWidth) - 115

      };
      ownersEmailEntry.Completed += ownersEmailEntry_Completed;
      //ownersEmailEntry.Focused += ownersEmailEntry_Focused;
      ownersEmailEntry.TextChanged += ownersEmailEntry_TextChanged;

      #endregion



			#region Grid Setup

			var controlGrid = new Grid { RowSpacing = 2, ColumnSpacing = 2 };

      //controlGrid.BackgroundColor = Color.Red;
      controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
      controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
      controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
      controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
      //controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(36) });
      //controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });
      //controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });
      //controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });

      controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
      controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
      controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });

      controlGrid.Children.Add(lblownersName, 0, 0);
      controlGrid.Children.Add(ownersNameEntry, 1, 0);
      Grid.SetColumnSpan(ownersNameEntry, 2);

      controlGrid.Children.Add(lblownersTelNumber, 0, 1);
      controlGrid.Children.Add(ownersTelNumberEntry, 1, 1);
      Grid.SetColumnSpan(ownersTelNumberEntry, 2);

      controlGrid.Children.Add(lblownersEmail, 0, 2);
      controlGrid.Children.Add(ownersEmailEntry, 1, 2);
      Grid.SetColumnSpan(ownersEmailEntry, 2);

      #endregion

      #region Grid 2 Setup

      var controlGrid2 = new Grid { RowSpacing = 2, ColumnSpacing = 2 };

      //controlGrid.BackgroundColor = Color.Red;
      controlGrid2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });
      controlGrid2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(90) });
      controlGrid2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });
      controlGrid2.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });

      controlGrid2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
      controlGrid2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
      controlGrid2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });

      //controlGrid2.Children.Add(soundonoffheader, 0, 0);
      //controlGrid2.Children.Add(soundonoffswitcher, 1, 0);
      //controlGrid2.Children.Add(soundonoffLabel, 2, 0);

      //controlGrid2.Children.Add(getNotificationTel, 0, 1);
      //controlGrid2.Children.Add(getNotificationTel, 1, 1);
			//controlGrid2.Children.Add(soundonoffLabel, 2, 1);
			#endregion

			#region Grid 3 Setup

			var controlGrid3 = new Grid { RowSpacing = 2, ColumnSpacing = 2 };

			//controlGrid.BackgroundColor = Color.Red;
			controlGrid3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });
			controlGrid3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(90) });
			controlGrid3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });
			controlGrid3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(26) });

			//controlGrid3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
			//controlGrid3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			//controlGrid3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });

			//controlGrid3.Children.Add(soundonoffheader, 0, 0);
			//controlGrid3.Children.Add(Testx, 1, 0);
			//controlGrid2.Children.Add(soundonoffLabel, 2, 0);

			//controlGrid3.Children.Add(getNotificationTel, 0, 1);
			//controlGrid3.Children.Add(Testy, 1, 1);
			//controlGrid3.Children.Add(soundonoffLabel, 2, 1);
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
              controlGrid,
              controlGrid2,
							controlGrid3,
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
      //FinalPageLayout.BottomStack.Children.Add(stackAd); // TopScreen1.contentstatusBaseline);

      // Assign to the page
      this.Content = FinalPageLayout;

      #endregion

      ownersNameEntry.Text = Preferences.Get("notesOwnerName", "default_value");
      if (ownersNameEntry.Text == "default_value") ownersNameEntry.Text = "no entry";
      ownersTelNumberEntry.Text = Preferences.Get("notesOwnerTelnum", "default_value"); // ownersTelNumberEntry.Text);
      if (ownersTelNumberEntry.Text == "default_value") ownersTelNumberEntry.Text = "no entry";
      ownersEmailEntry.Text = Preferences.Get("notesOwnerEmail", "default_value"); // ownersEmailEntry.Text);
      if (ownersEmailEntry.Text == "default_value") ownersEmailEntry.Text = "no entry";

    }

    #region owners Name

    // -----------------------------------------------------------------------------------
    // Owner Entry received focus
    //
    // -----------------------------------------------------------------------------------
    void ownersNameEntry_Focused(object sender, EventArgs e)
    {
      //ownersNameEntry.Text = "";
    }

    void ownersNameEntry_TextChanged(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersNameEntry.Text)) return;
      Preferences.Set("notesOwnerName", ownersNameEntry.Text);
    }

    void ownersNameEntry_Completed(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersNameEntry.Text)) return;
      Preferences.Set("notesOwnerName", ownersNameEntry.Text);
    }

    #endregion

    #region owners Tel Numbere

    // -----------------------------------------------------------------------------------
    // Name Entry received focus
    //
    // -----------------------------------------------------------------------------------
    void ownersTelNumberEntry_Focused(object sender, EventArgs e)
    {
      //ownersTelNumberEntry.Text = "";
    }

    void ownersTelNumberEntry_TextChanged(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersTelNumberEntry.Text)) return;
      Preferences.Set("notesOwnerTelnum", ownersTelNumberEntry.Text);
    }

    void ownersTelNumberEntry_Completed(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersTelNumberEntry.Text)) return;
      Preferences.Set("notesOwnerTelnum", ownersTelNumberEntry.Text);
    }


    #endregion

    #region owners Email

    // -----------------------------------------------------------------------------------
    // Name Entry received focus
    //
    // -----------------------------------------------------------------------------------
    void ownersEmailEntry_Focused(object sender, EventArgs e)
    {
      //ownersEmailEntry.Text = "";
    }

    void ownersEmailEntry_TextChanged(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersEmailEntry.Text)) return;
      Preferences.Set("notesOwnerEmail", ownersEmailEntry.Text);
    }

    void ownersEmailEntry_Completed(object sender, EventArgs e)
    {
      // check for input
      if (String.IsNullOrEmpty(ownersEmailEntry.Text)) return;
      Preferences.Set("notesOwnerEmail", ownersEmailEntry.Text);
    }

    #endregion



	}
}