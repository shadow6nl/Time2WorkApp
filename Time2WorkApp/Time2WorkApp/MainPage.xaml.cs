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
                //if (dbcontext.db.Table<Gebruiker>().FirstOrDefault() == null)
                //{
                //    dbcontext.Get_Gebruiker();
                //}
                Navigation.PushAsync(new MenuPage());
            }
             
        }
    }
}
