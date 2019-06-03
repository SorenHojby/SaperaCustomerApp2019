using System;
using System.Collections.Generic;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SaperaCustomerApp
{
    public partial class App : Application
    {
        public static List<User> UserList = new List<User>
            {
                // Simulate Data
                new User("Søren", "Højby", "soer792e@edu.eal.dk", "Assensvej", "109", "Stenstrup", 5771, "03-10-1988", "Mand", "123456", 2345,4525322713,"+4525322713"),
                new User("Kim", "Knudsen", "kk@gmail.com", "Møllervangen", "118", "Nyborg", 5800, "23-03-1961", "Mand", "123456", 123,4525242322,"+4525242322"),
                new User("Harry", "Skov", "hs@gmail.com", "Heltzensgade", "8, 1 tv.", "Odense C", 5000, "07-12-1979", "Mand", "123456", 433,4588888888,"+4588888888"),
                new User("Torsten", "Haagensen", "th@gmail.com", "Agervangen", "12", "Galten", 8464, "05-07-1966", "Mand", "123456", 436,4512345678,"+4512345678"),
                new User("Oliver", "Bendtsen", "ob@gmail.com", "Stjær Bakker", "1", "Galten", 8464, "25-10-1955", "Mand", "123456", 1322,4513273225,"+4513273225"),
                new User("Elias", "Espersen", "ee@gmail.com", "Lundsgårds Vænge", "2", "Odense NV", 5210, "22-05-1991", "Mand", "123456", 6883,4587654321,"+4587654321")
            };
        // Borrowed from: https://lonewolfonline.net/validate-email-addresses/
        // STRAT
        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        // END
        public App()
        {
            

            InitializeComponent();
            // Handle when your app starts
            if (Application.Current.Properties.ContainsKey("loggedIn") && Application.Current.Properties.ContainsKey("email"))
            {
                MainPage = new NavigationPage(new Home());
            }
            else {
                MainPage = new NavigationPage(new MainPage());
            }
          
        }

        protected override void OnStart()
        {
          
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
