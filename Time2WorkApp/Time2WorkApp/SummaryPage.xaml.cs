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
            //refreshDePaginaDatabase();
        }

        public void refreshDePaginaDatabase()
        {
            
        }


        private void Update_Clicked(object sender, EventArgs e)
        {
            //refreshDePaginaDatabase();

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

            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten2) != null)
            {
                Activiteit2.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten2).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten3) != null)
            {
                Activiteit3.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten3).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten4) != null)
            {
                Activiteit4.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten4).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5) != null)
            {
                Activiteit4.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6) != null)
            {
                Activiteit6.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7) != null)
            {
                Activiteit7.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8) != null)
            {
                Activiteit8.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9) != null)
            {
                Activiteit9.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9).activiteit;
            }
            if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10) != null)
            {
                Activiteit10.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10).activiteit;
            }
        }

        
        public void allButtonsInvisible()
        {
            maandKnoppen.IsVisible = false;
            overzichtLayout.IsVisible = true;
        }


        private void januariButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void februariButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void maartButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void aprilButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void meiButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void juniButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void juliButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void augustusButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void septemberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void oktoberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void novemberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }

        private void decemberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
        }
        

    }
}