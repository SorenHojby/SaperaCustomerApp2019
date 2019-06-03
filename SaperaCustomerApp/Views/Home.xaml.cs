using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Application = Xamarin.Forms.Application;

namespace SaperaCustomerApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : Xamarin.Forms.TabbedPage
    {

        public Home()
        {
           
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
                         
            InitializeComponent();
            CurrentPage = Children[1];

          
            //Update labels
            lbl_CustomerID.Text = Application.Current.Properties["customerID"].ToString();
            lbl_Name.Text = Application.Current.Properties["firstname"].ToString() + " " + Application.Current.Properties["lastname"].ToString(); 
            lbl_Points.Text = Application.Current.Properties["points"].ToString();
            lbl_CustomerID2.Text = Application.Current.Properties["customerID"].ToString();

            //update entry fields
            ent_Firstname.Text = Application.Current.Properties["firstname"].ToString();
            ent_Lastname.Text = Application.Current.Properties["lastname"].ToString();
            ent_gender.Text = Application.Current.Properties["gender"].ToString();
            ent_roadname.Text = Application.Current.Properties["address"].ToString();
            ent_housenumber.Text = Application.Current.Properties["housenumber"].ToString();
            ent_postalnumber.Text = Application.Current.Properties["postal"].ToString();
            ent_cityname.Text = Application.Current.Properties["city"].ToString();
           
            ent_phonenumber.Text = Application.Current.Properties["cellphonenumber"].ToString();
            
            // disabled stuff
            //update date field
          //  int year = Convert.ToInt16(Application.Current.Properties["dob"].ToString().Substring(6, 4));
          //  int md = Convert.ToInt16(Application.Current.Properties["dob"].ToString().Substring(3, 2));
          //  int dag = Convert.ToInt16(Application.Current.Properties["dob"].ToString().Substring(0, 2));
          //  dp_Birthday.Date = new DateTime(year, md, dag);

           // Barcode
           // Switch for newsletter
           // Switch for SMS
        }
        
        private void Btn_save_Clicked(object sender, EventArgs e)
        {
            bool logincheck = false;
            foreach (var user in App.UserList)
            {
                if (user.Email == Application.Current.Properties["email"].ToString())
                {
                   

                    logincheck = true;
                    user.Firstname = ent_Firstname.Text;
                    user.Lastname = ent_Lastname.Text;
                    user.Gender = ent_gender.Text;
                    user.Address = ent_roadname.Text;
                    user.Housenumber = ent_housenumber.Text;
                    user.Postal = Convert.ToInt16(ent_postalnumber.Text);
                    user.City= ent_cityname.Text;
                    user.Cellphonenumber = ent_phonenumber.Text;




                    Application.Current.Properties["firstname"] = ent_Firstname.Text;
                    Application.Current.Properties["lastname"] = ent_Lastname.Text;
                    Application.Current.Properties["gender"] = ent_gender.Text;
                    Application.Current.Properties["address"] = ent_roadname.Text;
                    Application.Current.Properties["housenumber"] = ent_housenumber.Text;
                    Application.Current.Properties["postal"] = ent_postalnumber.Text;
                    Application.Current.Properties["city"] = ent_cityname.Text;
                    Application.Current.Properties["cellphonenumber"] = ent_phonenumber.Text;
                    //Application.Current.Properties["dob"] = dp_Birthday.ToString();

                    DisplayAlert("Gemt", "Dine ændringer er gemt!", "Luk");
                    Navigation.PushAsync(new Home());

                    break;
                }
                else
                {
                    logincheck = false;
                }
            }
            if (!logincheck)
            { // if we dont find a email that matches. through a alert
                DisplayAlert("Fejl", "Vi kunne ikke finde dig i systemet.", "Luk");
                Navigation.PushAsync(new MainPage());

            }
            
           
        }

        private void Btn_logout_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Logget ud", "Du er nu logget ud af appen", "Luk");
            Application.Current.Properties.Clear();
            Navigation.PushAsync(new MainPage());
        }

        private void Btn_change_password_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Beklager", "Det er ikke muligt at ændre koden lige pt", "Luk");

        }
    }
}