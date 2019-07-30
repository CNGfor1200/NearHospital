// ..............................................................
// CPR Compression Simulation Application 1B-9
// CNG Internet Software, Manalapan, New Jesey, USA
//
// Copyright @ 2018, 2019 CNG Internet Software, LLC
//
// Name: Util001
// Vers: 3.1.0
//
// Base utilities
// .............................................................
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace NearHspt
{
	class A_Advertisement
	{
		public static string str555 = "";
		// ..........................................................................................
		//
		// ..........................................................................................
		public static void Adv_Set1(Label ADV00, int iPos)
		{

			ADV00.Margin = new Thickness(0, 3, 0, 7);
			//////ADV00.Text = setSTR;
			ADV00.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
			ADV00.TextColor = Color.Black;
			ADV00.HorizontalOptions = LayoutOptions.StartAndExpand;
			ADV00.VerticalOptions = LayoutOptions.CenterAndExpand;
			ADV00.HorizontalTextAlignment = TextAlignment.Center;
			ADV00.WidthRequest = App.DisplayScaleMax; //  App.DisplayScreenHeight

			return; // rt;
		}


		// ===================================================================================================
		// Get ad-contract count in Azure
		//
		// ===================================================================================================
		public static int GetAzLoopCount()
		{
			int azLoop = 0;

			try
			{
				//
				// loop on all Azure records
				//
				azLoop = 100;
			}
			catch (Exception ex)
			{
				string aa = ex.ToString();
			}
			return azLoop;
		}

	}
}
