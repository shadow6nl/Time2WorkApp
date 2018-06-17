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

        public FirstUsePage()
        {
            InitializeComponent();
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
                DisplayAlert("Fout", "Vul alle tekstvakken in.", "OK");
            }
            else if (password1 != password2)
            {
                DisplayAlert("Fout", "Wachtwoorden komen niet overeen.", "OK");
            }

            

            else
            {
                double Bruto = double.Parse(firstUseBruto.Text);

                ////Writing it to the DB
                if (dbcontext.db.Table<Gebruiker>().FirstOrDefault() == null)
                {
                    dbcontext.Insert_User_Into_Table(new Gebruiker { id = 1, firstname = "John", lastname = "Doe" });
                }
                else
                {
                    int last_index_gebruiker = dbcontext.db.Table<Gebruiker>().Last().id;
                    dbcontext.Insert_User_Into_Table(new Gebruiker { id = last_index_gebruiker + 1, firstname = firstUseFirstname.Text, lastname = firstUseLastname.Text, brutoloon = Bruto, email = firstUseEmailEntry.Text, password = firstUsePassword1.Text });

                    current_user = dbcontext.db.Table<Gebruiker>().Last();
                    Navigation.PushAsync(new MenuPage());
                }
            }
        }
    }
}