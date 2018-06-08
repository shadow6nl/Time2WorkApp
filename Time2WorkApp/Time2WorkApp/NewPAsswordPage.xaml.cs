using System;
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
            //Geeft error als ik uncomment

            //InitializeComponent();
        }

        private void NewPasswordSaveButton_Clicked(object sender, EventArgs e)
        {
            // save to database logic
        }
    }
}