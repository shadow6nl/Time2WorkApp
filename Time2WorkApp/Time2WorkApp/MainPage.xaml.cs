using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Time2WorkApp
{
	public partial class MainPage : ContentPage
	{
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
                DisplayAlert("Het werkt", Navigation.ToString(), "Nigguuh");
                Navigation.PushAsync(new MenuPage());
                
            }
             
        }
    }
}
