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
	public partial class TimerPage : ContentPage
	{
		public TimerPage ()
		{
			InitializeComponent ();
		}

        private void activitySwtich_OnToggled(object sender, ToggledEventArgs e)
        {
            bool activityToggled = e.Value;
            activityName.IsVisible = activityToggled;
            updateActivityButton.IsVisible = activityToggled;
            if (activityToggled == false)
            {
                activityIsUpdatedLabel.IsVisible = false;
            }
        }

        private void updateActivityButton_Clicked(object sender, EventArgs e)
        {
            activityIsUpdatedLabel.Text = "Huidig activiteit: " + activityName.Text;
            activityIsUpdatedLabel.IsVisible = true;
        }
    }
}