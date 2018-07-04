using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Time2WorkApp.Model;

namespace Time2WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstUsePage : ContentPage
    {
        DataContext dbcontext = new DataContext();
        Gebruiker current_user;
        int last_index_gebruiker = 0;

        public FirstUsePage()
        {          

            InitializeComponent();

        }

        private void FirstUseSaveButton_Clicked(object sender, EventArgs e)
        {
            
            if (dbcontext.db.Table<Gebruiker>().Any() == true)
            {
                last_index_gebruiker = dbcontext.db.Table<Gebruiker>().Last().id;
            }

            dbcontext.Insert_User_Into_Table(new Gebruiker { id = (last_index_gebruiker + 1) });

            bool isFirstnameEmpty = string.IsNullOrEmpty(firstUseFirstname.Text);
            bool isLastnameEmpty = string.IsNullOrEmpty(firstUseLastname.Text);
            bool isBrutoEmpty = string.IsNullOrEmpty(firstUseBruto.Text);
            bool isEmailEmpty = string.IsNullOrEmpty(firstUseEmailEntry.Text);
            bool isPassword1Empty = string.IsNullOrEmpty(firstUsePassword1.Text);
            bool isPassword2Empty = string.IsNullOrEmpty(firstUsePassword2.Text);


            //It works
            string password1 = firstUsePassword1.Text;
            string password2 = firstUsePassword2.Text;

            if (isFirstnameEmpty || isLastnameEmpty || isBrutoEmpty || isEmailEmpty || isPassword1Empty || isPassword2Empty) //checkt eerst als iets leeg is
            {
                DisplayAlert("Fout", "Vul alle tekstvakken in. Anders kan de app niet optimaal gebruikt worden.", "OK");


            }
            else
            {
                if (double.Parse(firstUseBruto.Text) < 0)  //checkt als brutoloon valid is
                {

                    DisplayAlert("Fout", "Vul een geldig brutoloonbedrag in.", "OK");

                }

                else
                {
                    if (password1 != password2) //checkt als wachtwoord valid is
                    {
                        DisplayAlert("Fout", "Wachtwoorden komen niet overeen.", "OK");
                    }

                    else
                    {
                        ////Updating new user

                        current_user = dbcontext.db.Table<Gebruiker>().Last();
                        current_user.firstname = firstUseFirstname.Text;
                        current_user.lastname = firstUseLastname.Text;
                        current_user.brutoloon = double.Parse(firstUseBruto.Text);
                        current_user.email = firstUseEmailEntry.Text;
                        current_user.password = firstUsePassword1.Text;
                        current_user.logged_in = true;


                        dbcontext.Update_User_From_Table(current_user);



                        Navigation.PushAsync(new MenuPage());


                    }
                }
            }
        }
    }
}