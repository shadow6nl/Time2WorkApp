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
	public partial class SummaryPage : ContentPage
	{
		public SummaryPage ()
		{
			InitializeComponent ();
		}

        private void periodeEenButton_Clicked(object sender, EventArgs e)
        {
            overzichtPeriodesLayout.IsVisible = false;
            overzichtDetailsLayout.IsVisible = true;
        }

        private void terugNaarOverzichtButton_Clicked(object sender, EventArgs e)
        {
            overzichtPeriodesLayout.IsVisible = true;
            overzichtDetailsLayout.IsVisible = false;
        }
    }
}