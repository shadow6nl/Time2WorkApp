using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Time2WorkApp.Model;

namespace Time2WorkApp
{
	public partial class MainPage : ContentPage
	{
        DataContext dbcontext = new DataContext();
        Gebruiker current_user;

        public MainPage()
		{
			InitializeComponent();
		}
        //loginButton functions
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool ispasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || ispasswordEmpty)
            {


            }
            else
            {
                //comparing to DB
                
                Gebruiker current_user = dbcontext.Get_Gebruiker(2);
                if (current_user.email == emailEntry.Text && current_user.password == passwordEntry.Text)
                {
                    Navigation.PushAsync(new MenuPage());
                }

                else
                {
                    DisplayAlert("Fout", " Email of Wachtwoord niet correct", "OK");
                }
            }

        }
    }
}
