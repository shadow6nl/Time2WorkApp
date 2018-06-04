using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
        
        int activityButtonToggle = 1;

        private void activityToggleButton_Clicked(object sender, EventArgs e)
        {
            activityButtonToggle += 1;
            bool activityVisible = activityButtonToggle % 2 == 0;
            activityName.IsVisible = activityVisible;
            updateActivityButton.IsVisible = activityVisible;
            if (activityVisible == false)
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