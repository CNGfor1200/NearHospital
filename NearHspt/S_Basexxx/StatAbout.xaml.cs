// ..............................................................
// Copyright @ 2018, 2019  CNG Internet Software, LLC
//
// Project: Near Hospital, EMS
//
// Name: StatAbout
// Vers: 3.0.0.0
//
// Brief [About] and [Reference] page
// .............................................................
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class StatAbout : ContentPage
  {


    public StatAbout()
    {
      InitializeComponent();


      Title = "About";
      BackgroundColor = Color.Black;


      Label Text001 = new Label()
      {
        Margin = new Thickness(20, 0, 20, 0),
        Text =
         "App Name.......: NearHospital \n" +
         "   Release Date: June 15, 2018 \n" +
         "   App Version..: 2.1.4 CCNearHospital\n" +
         "   ID Key............: M56-778 \n \n" +
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
        Text = " This app will get your current location(1) and gives you:\n" +
        " * the name and location of the nearest Hospital, and\n" +

                "Additional Info includes:\n" +
        " -- DETAILS about the hospital\n" +
        " -- Google Ratings about the hospital\n" +
        " -- ability to CALL the hospital (preset #)\n" +
        " -- show Web Site\n" +
        " -- Driving Directions to the hospital\n\n"+
        "You may also get an expanded list of hospitals inside a circle of up to 100 miles.\n",
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };

      Label Text003 = new Label()
      {
        Margin = new Thickness(20, 15, 20, 0),
        Text = "Acknowledgements",
        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      Label Text004 = new Label()
      {
        Margin = new Thickness(20, 5, 20, 0),
        Text = "American Red Cross. First Aid/ CPR / AED Participant's Manual. 2nd ed. Dallas, TX: American Red Cross; 2016.\n" +
            "Kleinman ME, Brennan EE, Goldberger ZD, et al.\n" +
            "American Heart Association guidelines update for " +
            "cardiopulmonary resuscitation and emergency cardiovascular care.Circulation. 2015; 132(18 Suppl 2):S414 - S435.PMID: 26472993 www.ncbi.nlm.nih.gov / pubmed / 26472993.\n\n" +
            "Review Date 3 / 31 / 2017 by Editorial team.\n\n" +
            "***Material published by Mayo Clinic Staff\n" +
            "Chief medical editor  •	Sandhya Pruthi, M.D.\n\n" +
            "***Dorland's Illustrated Medical Dictionary. 32nd ed. \n" +
            "Philadelphia, Pa.: W.B. Saunders; 2011. https://www.dorlands.com/index.jsp. Accessed Feb. 3, 2018.",
        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
        TextColor = Color.White,
        HorizontalOptions = LayoutOptions.StartAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };



      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      // Stack panel fields
      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      #region Summary Stack
      var contentstack = new StackLayout()
      {
        BackgroundColor = Color.Black,
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
                Text003,
                Text004,


             }
     }

             }
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