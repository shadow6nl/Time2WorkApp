using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time2WorkApp.Helpers;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Time2WorkApp.Model;

namespace Time2WorkApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsPage : ContentPage
	{
        DataContext dbcontext = new DataContext();
        Gebruiker current_user;
        public OptionsPage ()
		{
			InitializeComponent ();
            
        }

        private void OptionSaveButton_Clicked(object sender, EventArgs e)
        {
            bool isFirstnameEmpty = string.IsNullOrEmpty(optionFirstname.Text);
            bool isLastnameEmpty = string.IsNullOrEmpty(optionLastname.Text);
            bool isBrutoEmpty = string.IsNullOrEmpty(optionBruto.Text);
            bool isEmailEmpty = string.IsNullOrEmpty(optionEmailEntry.Text);
            bool isPassword1Empty = string.IsNullOrEmpty(optionPassword.Text);

            if (isFirstnameEmpty || isLastnameEmpty || isBrutoEmpty || isEmailEmpty || isPassword1Empty)
            {
                DisplayAlert("Waarschuwing", "Er is nog een tekstvak leeg.", "OK");
            }
            else
            {

            }
        }

        //reset function first time use
        public string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set
            {
                if (Settings.GeneralSettings == value)
                    return;

                Settings.GeneralSettings = value;
                OnPropertyChanged();
            }
        }

        private void ResetFirstTimeSetup_Clicked(object sender, EventArgs e)
        {
            current_user = dbcontext.db.Table<Gebruiker>().Last();
            dbcontext.Delete_User_From_Table(current_user);
            IsFirstTime = "yes";
        }
        private void ResetPassword_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Waarschuwing", "U gaat nu uw wachtwoord aanpassen!", "OK");
            Navigation.PushAsync(new NewPasswordPage());
        }
    }
}