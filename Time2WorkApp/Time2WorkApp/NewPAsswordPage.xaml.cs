using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time2WorkApp.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Time2WorkApp.Model;

namespace Time2WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPasswordPage : ContentPage
    {
        DataContext dbcontext = new DataContext();
        Gebruiker current_user;

        public NewPasswordPage()
        {


            InitializeComponent();
        }

        private void NewPasswordSaveButton_Clicked(object sender, EventArgs e)
        {   //check if fields are empty
            bool isoldPasswordEmpty = string.IsNullOrEmpty(oldPassword.Text);
            bool isnewPassword1Empty = string.IsNullOrEmpty(newPassword1.Text);
            bool isnewPassword2Empty = string.IsNullOrEmpty(newPassword2.Text);

            //preparing for DB stuff
            bool isoldPasswordinDB = string.IsNullOrEmpty(oldPassword.Text);
            bool isnewPassword1inDB = string.IsNullOrEmpty(newPassword1.Text);
            bool isnewPassword2inDB = string.IsNullOrEmpty(newPassword2.Text);

            if (isoldPasswordEmpty || isnewPassword1Empty || isnewPassword2Empty)
            {   //If a field is empty this will pop-up
                DisplayAlert("Waarschuwing", "Er is nog een tekstvak leeg.", "OK");
            }
            else if(isnewPassword1Empty == isnewPassword2Empty)
            {   

                current_user = dbcontext.db.Table<Gebruiker>().Last();
                current_user.password = newPassword1.Text;
                dbcontext.Update_User_From_Table(current_user);


                //if fields are correct this will pop-up
                DisplayAlert("Waarschuwing", "Uw wachtwoord is opgeslagen", "OK");
            }
            else
            {
                DisplayAlert("Waarschuwing", "Wachtwoorden komen niet overeen", "OK");
            }
            Navigation.PushAsync(new OptionsPage());

        }
    }
}