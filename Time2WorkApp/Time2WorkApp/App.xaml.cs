using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Time2WorkApp.Helpers;
using Xamarin.Forms;

namespace Time2WorkApp
{
	public partial class App : Application
	{   
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

		public App ()
		{
			InitializeComponent();
            //check if the app is running for the first time
            if (IsFirstTime == "yes")
            {
                //if this is the first time, set it to "No" and load the
                // mainpage, wich will show at the first time use
                IsFirstTime = "no";
                MainPage = new Time2WorkApp.OptionsPage();
            }
            else
            {
                // If this is not the first time,
                // Go to the login page
                MainPage = new NavigationPage(new MainPage());
            }
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
