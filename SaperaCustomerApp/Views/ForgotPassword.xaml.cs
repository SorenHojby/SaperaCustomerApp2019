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
	public partial class ForgotPassword : ContentPage
	{
		public ForgotPassword ()
		{
			InitializeComponent ();
		}

        private void Btn_ForgotEmailSubmit_Clicked(object sender, EventArgs e)
        {
            bool logincheck = false;
            foreach (var user in App.UserList)
            {
                if (!App.IsEmailValid(ent_ForgotEmail.Text))
                {
                    DisplayAlert("Ups.", "Den angivne email adresse ser ikke ud til at være angivet i det korrekt format.", "Luk");
                    logincheck = false;
                    break;
                }
                if (user.Email == ent_ForgotEmail.Text)
                {
                    DisplayAlert("Tillykke", "Din kode er nu nulstillet til: 123456", "Luk");
                    logincheck = true;
                    user.Password = "123456";
                    Navigation.PushAsync(new MainPage());
                    break;
                }
                else
                {
                    logincheck = false;
                }
            }
            if (!logincheck)
            { // if we dont find a email that matches. through an alert
                DisplayAlert("Fejl", "Emailen blev ikke fundet.", "Luk");

            }

        }
    }
}