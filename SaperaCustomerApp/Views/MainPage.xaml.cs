using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaperaCustomerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();  
        }

        async private void Btn_AccountCreateSubmit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccount());
        }

       async private void Btn_ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }

      private void Btn_LoginSubmit_Clicked(object sender, EventArgs e)
        {
            string email = ent_LoginEmail.Text;
            string password = ent_LoginPassword.Text;
            Login(email, password);
         
        }
        
      
     public void Login(string email, string password)
        {
           
            bool logincheck = false;
            foreach (var user in App.UserList)
            {
               
                if (user.Email == email && user.Password == password){ 
                    // We are now loggedin
                    logincheck = true; 
                    // we set the check varaible to true
                    // We save the userinfo in the applications local storage on the device. 
                    // this is for easy access to the data when the user is logged in. 
                    // With this we can also log the user in again when they have closed the app. 
                   
                    Application.Current.Properties["firstname"] = user.Firstname;
                    Application.Current.Properties["lastname"] = user.Lastname;
                    Application.Current.Properties["email"] = user.Email;
                    Application.Current.Properties["address"] = user.Address;
                    Application.Current.Properties["housenumber"] = user.Housenumber;
                    Application.Current.Properties["postal"] = user.Postal;
                    Application.Current.Properties["city"] = user.City;
                    Application.Current.Properties["dob"] = user.Birthdate;
                    Application.Current.Properties["gender"] = user.Gender;
                    Application.Current.Properties["password"] = user.Password;
                    Application.Current.Properties["points"] = user.Points;
                    Application.Current.Properties["customerID"] = user.CustomerID;
                    Application.Current.Properties["cellphonenumber"] = user.Cellphonenumber;
                    Application.Current.Properties["loggedIn"] = true;
                    Navigation.PushAsync(new Home());
                    break;
                }
                else {

                    logincheck = false;
                }
            }
            if (!logincheck) { // if our login attempt is failing, we will alert the user and tell them that the email or password was wrong.
               DisplayAlert("Fejl", "Email eller kodeord er forkert.", "Luk");
               
            }
        }
        
    }
    public class User{

        private string firstname;
        private string lastname;
        private string email;
        private string address;
        private string housenumber;
        private string city;
        private int postal;
        private string birthdate;
        private string gender;
        private string password;
        private int points;
        private long customerID;
        private string cellphonenumber;

        // Contructor
        public User(string firstname, string lastname, string email, string address, string housenumber, string city, int postal, string birthdate, string gender, string password, int points, long customerID, string cellphonenumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Address = address;
            Housenumber = housenumber;
            City = city;
            Postal = postal;
            Birthdate = birthdate;
            Gender = gender;
            Password = password;
            Points = points;
            CustomerID = customerID;
            Cellphonenumber = cellphonenumber;
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Housenumber
        {
            get { return housenumber; }
            set { housenumber = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public int Postal
        {
            get { return postal; }
            set { postal = value; }
        }
        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public long CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string Cellphonenumber
        {
            get { return cellphonenumber; }
            set { cellphonenumber = value; }
        }

    }
}
