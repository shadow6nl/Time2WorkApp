using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Time2WorkApp.Model;
using SQLite;

namespace Time2WorkApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SummaryPage : ContentPage
	{

        DataContext dbContext = new DataContext();
        Activiteit current_activity;

		public SummaryPage ()
		{

            InitializeComponent();




            

        }


        private void Update_Clicked(object sender, EventArgs e)
        {

            current_activity = dbContext.db.Table<Activiteit>().Last();
            int last_index_activiteiten1 = current_activity.id;
            int last_index_activiteiten2 = last_index_activiteiten1 - 1;
            int last_index_activiteiten3 = last_index_activiteiten2 - 1;
            int last_index_activiteiten4 = last_index_activiteiten3 - 1;
            int last_index_activiteiten5 = last_index_activiteiten4 - 1;
            int last_index_activiteiten6 = last_index_activiteiten5 - 1;
            int last_index_activiteiten7 = last_index_activiteiten6 - 1;
            int last_index_activiteiten8 = last_index_activiteiten7 - 1;
            int last_index_activiteiten9 = last_index_activiteiten8 - 1;
            int last_index_activiteiten10 = last_index_activiteiten9 - 1;



            Activiteit1.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten1).activiteit;
            Activiteit2.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten2).activiteit;
            Activiteit3.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten3).activiteit;
            Activiteit4.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten4).activiteit;
            Activiteit5.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            Activiteit6.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6).activiteit;
            Activiteit7.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7).activiteit;
            Activiteit8.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8).activiteit;
            Activiteit9.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9).activiteit;
            Activiteit10.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10).activiteit;
        }


    }
}