using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaperaCustomerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
       

        private void Btn_CreateSubmit_Clicked(object sender, EventArgs e)
        {

            bool logincheck = false;
         
            foreach (var user in App.UserList)
            {
                if (!App.IsEmailValid(ent_Email.Text)) { 
                    DisplayAlert("Ups.", "Den angivne email adresse ser ikke ud til at være angivet i det korrekt format.", "Luk");
                    logincheck = false;
                    break;
                }

                if (!swi_acceptance.IsToggled)
                {
                    DisplayAlert("Ups.", "Du har glemt at accepter betingelserne.", "Luk");
                    logincheck = false;
                    break;
                }

                if (ent_Password.Text != ent_Password2.Text)
                {
                    DisplayAlert("Ups.", "Kodeordene er ikke ens.", "Luk");
                    logincheck = false;
                    break;

                }

                if (user.Email == ent_Email.Text)
                {
                    DisplayAlert("Ups.", "Din email er allerede i vores system.", "Luk");
                    logincheck = false;
                    Navigation.PushAsync(new MainPage());
                    break;
                }
                // if conditions and password and email is allright, we set the login check to true

                logincheck = true;
            }
           




            if (logincheck)
            {
                Random r = new Random();
                int randomnumber = r.Next(100000000, 999999999);
                User newuser = new User("", "", ent_Email.Text, "", "", "", 0000, "", "Ej oplyst", ent_Password.Text, 0, randomnumber, "");
                App.UserList.Add(newuser);
                DisplayAlert("Tillykke.", "Du kan nu logge ind med din nye konto.", "Luk");
                Navigation.PushAsync(new MainPage());
            }

        }



        async private void Btn_read_conditions_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Conditions());
        }
    }
}