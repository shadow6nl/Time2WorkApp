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
        Month current_month;

		public SummaryPage ()
		{
            InitializeComponent();
            if (dbContext.db.Table<Activiteit>().FirstOrDefault() == null)
            {
                dbContext.Insert_Activity_Into_Table(new Activiteit { id = 1, activiteit = "Er zijn nog geen activiteiten opgeslagen." });
            }

            refreshDePaginaDatabase();
        }


        int totaalUren, totaalMinuten, lastHours, lastMinutes;

        public void totaalGewerkteUrenBerekening()
        {

            totaalUren = totaalUren + lastHours;
            totaalMinuten = totaalMinuten + lastMinutes;
            if (totaalMinuten > 59)
            {
                totaalUren++;
                totaalMinuten = totaalMinuten - 60;
            }
        }

        public void refreshDePaginaDatabase()
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




            //string NaamActiviteit1 = dbContext.Get_Activiteit(2).activiteit;
            //string NaamActiviteit2 = dbContext.Get_Activiteit(3).activiteit;
            //string NaamActiviteit3 = dbContext.Get_Activiteit(4).activiteit;
            //string NaamActiviteit4 = dbContext.Get_Activiteit(5).activiteit;
            //string NaamActiviteit5 = dbContext.Get_Activiteit(6).activiteit;
            //string NaamActiviteit6 = dbContext.Get_Activiteit(7).activiteit;
            //string NaamActiviteit7 = dbContext.Get_Activiteit(8).activiteit;
            //string NaamActiviteit8 = dbContext.Get_Activiteit(9).activiteit;
            //string NaamActiviteit9 = dbContext.Get_Activiteit(10).activiteit;
            //string NaamActiviteit10 = dbContext.Get_Activiteit(11).activiteit;

            //string TotaleTijdActiviteit1 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit2 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit3 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit4 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit5 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit6 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit7 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit8 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit9 = dbContext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit10 = dbContext.Get_Activiteit(2).datum.ToString();

            //Activiteit1.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten1).activiteit;

            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten2) != null)
            //{
            //    Activiteit2.Text = "" +  + dbContext.Get_Activiteit(2).totaleTijd.ToString();
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten3) != null)
            //{
            //    Activiteit3.Text = dbContext.Get_Activiteit(3).totaleTijd.ToString();
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten4) != null)
            //{
            //    Activiteit4.Text = dbContext.Get_Activiteit(4).totaleTijd.ToString();
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5) != null)
            //{
            //    Activiteit4.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6) != null)
            //{
            //    Activiteit6.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6).activiteit;
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7) != null)
            //{
            //    Activiteit7.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7).activiteit;
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8) != null)
            //{
            //    Activiteit8.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8).activiteit;
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9) != null)
            //{
            //    Activiteit9.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9).activiteit;
            //}
            //if (dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10) != null)
            //{
            //    Activiteit10.Text = dbContext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10).activiteit;
            //}
        }


        private void Update_Clicked(object sender, EventArgs e)
        {
            refreshDePaginaDatabase();
        }

        
        public void allButtonsInvisible()
        {
            maandKnoppen.IsVisible = false;
            overzichtLayout.IsVisible = true;
        }


        private void januariButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Januari";
        }

        private void februariButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Februari";
        }

        private void maartButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Maart";
        }

        private void aprilButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "April";
        }

        private void meiButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Mei";
        }

        private void juniButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Juni";
        }

        private void juliButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Juli";
        }

        private void augustusButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Augustus";
        }

        private void septemberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "September";
        }

        private void oktoberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "Oktober";
        }

        private void novemberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "November";
        }

        private void decemberButton_Clicked(object sender, EventArgs e)
        {
            allButtonsInvisible();
            maandLabel.Text = "December";
        }

                   
    }
}