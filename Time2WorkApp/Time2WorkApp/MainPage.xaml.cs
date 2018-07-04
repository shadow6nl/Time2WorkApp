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
        Gebruiker current_user = null;

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

                DisplayAlert("Waarschuwing", "Vul alle velden in", "OK");
            }
            else
            {
                //comparing to DB

                


                if(dbcontext.db.Table<Gebruiker>().FirstOrDefault(x => x.email == emailEntry.Text) != null) //checkt de database op user waarvan email overeenkomt
                {
                    current_user = dbcontext.db.Table<Gebruiker>().FirstOrDefault(x => x.email == emailEntry.Text);
                    current_user.logged_in = false;




                    if (current_user.password == passwordEntry.Text) //checkt het wachtwoord
                    {
                        current_user.logged_in = true;
                        Navigation.PushAsync(new MenuPage());

                    }

                    else
                    {
                        DisplayAlert("Fout", " Wachtwoord niet correct", "OK");
                    }


                }
                else
                {
                    DisplayAlert("Fout", " Email bestaat niet", "OK");
                }
                

                
            }

        }
    }
}
