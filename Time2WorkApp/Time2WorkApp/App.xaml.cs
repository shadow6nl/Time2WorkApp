﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Time2WorkApp.Helpers;
using Xamarin.Forms;

namespace Time2WorkApp
{
	public partial class App : Application
	{
        public static string DatabaseLocation = string.Empty;
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

            // Check if the app is running for the first time
            if (IsFirstTime == "yes")
            {
                //if this is the first time, set it to "NO" and load the
                // Mainpage, which will show at the first time use

                IsFirstTime = "no";
                MainPage = new NavigationPage(new FirstUsePage());
            }
            else
            {
                //if this is not the first time,
                //go to loginpage

                MainPage = new NavigationPage(new MainPage());
            }

		}

        public App(string databaseLocation)
        {
            InitializeComponent();

            // Check if the app is running for the first time
            if (IsFirstTime == "yes")
            {
                //if this is the first time, set it to "NO" and load the
                // Mainpage, which will show at the first time use

                IsFirstTime = "no";
                MainPage = new NavigationPage(new FirstUsePage());
            }
            else
            {
                //if this is not the first time,
                //go to loginpage

                MainPage = new NavigationPage(new MainPage());
            }

            DatabaseLocation = databaseLocation;
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
