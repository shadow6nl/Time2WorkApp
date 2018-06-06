using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time2WorkApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstUsePage : ContentPage
	{
		public FirstUsePage ()
		{
			InitializeComponent ();
		}

        private void FirstUseSaveButton_Clicked(object sender, EventArgs e)
        {
            bool isFirstnameEmpty = string.IsNullOrEmpty(firstUseFirstname.Text);
            bool isLastnameEmpty = string.IsNullOrEmpty(firstUseLastname.Text);
            bool isBrutoEmpty = string.IsNullOrEmpty(firstUseBruto.Text);
            bool isEmailEmpty = string.IsNullOrEmpty(firstUseEmailEntry.Text);
            bool isPassword1Empty = string.IsNullOrEmpty(firstUsePassword1.Text);
            bool isPassword2Empty = string.IsNullOrEmpty(firstUsePassword2.Text);

            //Test no idea of this will work
            string password1 = firstUsePassword1.Text;
            string password2 = firstUsePassword2.Text;

            if (isFirstnameEmpty || isLastnameEmpty || isBrutoEmpty || isEmailEmpty || isPassword1Empty || isPassword2Empty)
            {
                DisplayAlert("Fout", "Vul alle tekstvakken in", "OK");

            }
            else if (password1 != password2)
            {
                DisplayAlert("Fout", "Wachtwoorden komen niet overeen.", "OK");
            }
            else
            {
                Navigation.PushAsync(new MenuPage());
            }
        }
    }
}