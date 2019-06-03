using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaperaCustomerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Conditions : ContentPage
	{
		public Conditions ()
		{
			InitializeComponent ();
		}

        async private void Btn_Close_Conditions_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}