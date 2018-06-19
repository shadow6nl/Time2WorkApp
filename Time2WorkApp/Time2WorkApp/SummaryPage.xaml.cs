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

        DataContext dbcontext = new DataContext();
        Activiteit current_activity;
        Month current_month;
        Gebruiker current_user;
		public SummaryPage ()
		{
            InitializeComponent();
            if (dbcontext.db.Table<Activiteit>().FirstOrDefault() == null)
            {
                dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 1, activiteit = "Er zijn nog geen activiteiten opgeslagen." });
            }
        }


        int totaalUren, totaalMinuten, lastHours, lastMinutes;
        int pauzeUren, pauzeMinuten, lastPauzeHours, lastPauzeMinutes;

        double brutoLoon;
        double totaleLoon;
        double totaleLoonAfgerond;


        public void totaleLoonBerekening()
        {
            //Hiervoor is uit de database nodig: BRUTOLOON en TOTALE UREN en TOTALE MINUTEN
            //BRUTOLOON UIT DE DATABASE
            current_month = dbcontext.Get_Month("Juni");
            current_user = dbcontext.Get_Gebruiker(2);
            brutoLoon = current_user.brutoloon;

            totaleLoon = (brutoLoon * totaalUren) + (brutoLoon * (totaalMinuten / 60));
            totaleLoonAfgerond = Math.Round((Double)totaleLoon, 2);
            loonLabel.Text = "3333,33";
        }

        public void totaleTijdenWeergave()
        {
            //totaalgewerkte tijd UIT de database
            current_month = dbcontext.Get_Month("Juni");

            totaalUren = current_month.totaleTijdGewerktUur;
            totaalMinuten = current_month.totaleTijdgewerktMin;
             
            tijdGewerktLabel.Text = totaalUren.ToString() + " uur en " + totaalMinuten.ToString() + " minuten";

            //totalePAUZE tijd UIT de database
            pauzeUren = current_month.totaleTijdPauzeUur;
            pauzeMinuten = current_month.totaleTijdPauzeMin;
            tijdOpPauzeLabel.Text = pauzeUren.ToString() + " uur en " + pauzeMinuten.ToString() + " minuten";
        }

        public void refreshTemplate()
        {
            refreshDePaginaDatabase();
            totaleLoonBerekening();
            totaleTijdenWeergave();
        }


        public void refreshDePaginaDatabase()
        {
            current_activity = dbcontext.db.Table<Activiteit>().Last();
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




            //string NaamActiviteit1 = dbcontext.Get_Activiteit(2).activiteit;
            //string NaamActiviteit2 = dbcontext.Get_Activiteit(3).activiteit;
            //string NaamActiviteit3 = dbcontext.Get_Activiteit(4).activiteit;
            //string NaamActiviteit4 = dbcontext.Get_Activiteit(5).activiteit;
            //string NaamActiviteit5 = dbcontext.Get_Activiteit(6).activiteit;
            //string NaamActiviteit6 = dbcontext.Get_Activiteit(7).activiteit;
            //string NaamActiviteit7 = dbcontext.Get_Activiteit(8).activiteit;
            //string NaamActiviteit8 = dbcontext.Get_Activiteit(9).activiteit;
            //string NaamActiviteit9 = dbcontext.Get_Activiteit(10).activiteit;
            //string NaamActiviteit10 = dbcontext.Get_Activiteit(11).activiteit;

            //string TotaleTijdActiviteit1 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit2 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit3 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit4 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit5 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit6 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit7 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit8 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit9 = dbcontext.Get_Activiteit(2).datum.ToString();
            //string TotaleTijdActiviteit10 = dbcontext.Get_Activiteit(2).datum.ToString();

            //Activiteit1.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten1).activiteit;

            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten2) != null)
            //{
            //    Activiteit2.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten3) != null)
            //{
            //    Activiteit3.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten4) != null)
            //{
            //    Activiteit4.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5) != null)
            //{
            //    Activiteit5.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten5).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6) != null)
            //{
            //    Activiteit6.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten6).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7) != null)
            //{
            //    Activiteit7.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten7).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8) != null)
            //{
            //    Activiteit8.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten8).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9) != null)
            //{
            //    Activiteit9.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten9).activiteit;
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10) != null)
            //{
            //    Activiteit10.Text = dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == last_index_activiteiten10).activiteit;
            //}
        }


        private void Update_Clicked(object sender, EventArgs e)
        {
            refreshDePaginaDatabase();
            totaleLoonBerekening();
            totaleTijdenWeergave();
        }

        
        public void allButtonsInvisible()
        {
            maandKnoppen.IsVisible = false;
            overzichtLayout.IsVisible = true;
        }

        private void terugNaarKnoppenButton_Clicked()
        {
            maandKnoppen.IsVisible = true;
            overzichtLayout.IsVisible = false;
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