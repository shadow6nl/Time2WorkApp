﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time2WorkApp.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time2WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPasswordPage : ContentPage
    {
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

            if (isoldPasswordEmpty || isnewPassword2Empty || isnewPassword2Empty)
            {   //If a field is empty this will pop-up
                DisplayAlert("Waarschuwing", "Er is nog een tekstvak leeg.", "OK");
            }
            else
            {   //if fields are correct this will pop-up
                DisplayAlert("Waarschuwing", "Uw wachtwoord is opgeslagen", "OK");
            }
    }
    }
}