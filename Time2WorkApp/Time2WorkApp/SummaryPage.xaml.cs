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

        double minutenDoorZestig;

        double brutoLoon;
        double totaleLoon;
        double totaleLoonAfgerond;


        public void totaleLoonBerekening(string maand)
        {
            //Hiervoor is uit de database nodig: BRUTOLOON en TOTALE UREN en TOTALE MINUTEN
            //BRUTOLOON UIT DE DATABASE
            current_month = dbcontext.Get_Month(maand);
            current_user = dbcontext.db.Table<Gebruiker>().FirstOrDefault();  
            brutoLoon = current_user.brutoloon;
            totaalUren = current_month.totaleTijdGewerktUur;
            totaalMinuten = current_month.totaleTijdgewerktMin;
            minutenDoorZestig = totaalMinuten;
            minutenDoorZestig = minutenDoorZestig / 60;

            totaleLoon = (brutoLoon * totaalUren) + (brutoLoon * minutenDoorZestig);
            totaleLoonAfgerond = Math.Round((Double)totaleLoon, 2);
            loonLabel.Text = totaleLoonAfgerond.ToString();     
        }

        public void totaleTijdenWeergave(string maand)
        {
            //totaalgewerkte tijd UIT de database
            current_month = dbcontext.Get_Month(maand);

            totaalUren = current_month.totaleTijdGewerktUur;
            totaalMinuten = current_month.totaleTijdgewerktMin;
             
            tijdGewerktLabel.Text = totaalUren.ToString() + " uur en " + totaalMinuten.ToString() + " minuten. ";

            //totalePAUZE tijd UIT de database
            pauzeUren = current_month.totaleTijdPauzeUur;
            pauzeMinuten = current_month.totaleTijdPauzeMin;
            tijdOpPauzeLabel.Text = pauzeMinuten.ToString() + " uur en " + pauzeUren.ToString() + " minuten. ";
        }

        public void refreshTemplate() //?
        {
            refreshDePaginaDatabase();
            //totaleLoonBerekening();
            //totaleTijdenWeergave();
        }

        public void alleValuesNul()
        {
            tijdGewerktLabel.Text = "0 " + " uur en " + "0" + " minuten. ";
            tijdOpPauzeLabel.Text = "0 " + " uur en " + "0" + " minuten. ";
            loonLabel.Text = "0";
        }


        public void refreshDePaginaDatabase()
        {
            current_activity = dbcontext.db.Table<Activiteit>().Last();
            int last_index_activiteiten1 = current_activity.id;
            int last_index_activiteiten2 = last_index_activiteiten1 - 1;
            int last_index_activiteiten3 = last_index_activiteiten2 - 1;
            int last_index_activiteiten4 = last_index_activiteiten3 - 1;
            int last_index_activiteiten5 = last_index_activiteiten4 - 1;
            
            
        }


        //private void Update_Clicked(object sender, EventArgs e)
        //{
        //    refreshDePaginaDatabase();
        //    if (maandLabel.Text ==  "Juni")
        //    {
        //        //totaleLoonBerekening();
        //        totaleTijdenWeergave();
        //    }
        //}

        private void Maand_button_clicked(object sender, EventArgs e)
        {
            alleValuesNul();
            //     Activiteiten

            string maand_string = ((Button)sender).Text;
            int maand_int = Convert.ToInt32(((Button)sender).ClassId);

            current_month = dbcontext.db.Table<Month>().FirstOrDefault(x => x.maand == maand_string);

            tijdGewerktLabel.Text = Convert.ToString(current_month.totaleTijdGewerktUur)+ "uur en " + Convert.ToString(current_month.totaleTijdgewerktMin) + "minuten.";
            tijdOpPauzeLabel.Text = Convert.ToString(current_month.totaleTijdPauzeUur) + "uur en " + Convert.ToString(current_month.totaleTijdPauzeMin) + "minuten.";




            TimeSpan Lesgeven_tijd;
            TimeSpan Nakijken_tijd;
            TimeSpan Vergaderen_tijd;
            TimeSpan Administratie_tijd;
            TimeSpan Voorbereiden_tijd;
            TimeSpan pauze_tijd;






            foreach (Activiteit activiteit in dbcontext.db.Table<Activiteit>().Where<Activiteit>(x => x.activiteit == "Lesgeven" && x.datum.Month == maand_int)) //nog filteren op maand
            {
                Lesgeven_tijd = Lesgeven_tijd + activiteit.totaleTijd;
            }
            foreach (Activiteit activiteit in dbcontext.db.Table<Activiteit>().Where<Activiteit>(x => x.activiteit == "Nakijken" && x.datum.Month == maand_int)) //nog filteren op maand
            {
                Nakijken_tijd = Nakijken_tijd + activiteit.totaleTijd;
            }
            foreach (Activiteit activiteit in dbcontext.db.Table<Activiteit>().Where<Activiteit>(x => x.activiteit == "Vergaderen" && x.datum.Month == maand_int)) //nog filteren op maand
            {
                Vergaderen_tijd = Vergaderen_tijd + activiteit.totaleTijd;
            }
            foreach (Activiteit activiteit in dbcontext.db.Table<Activiteit>().Where<Activiteit>(x => x.activiteit == "Administratie" && x.datum.Month == maand_int)) //nog filteren op maand
            {
                Administratie_tijd = Administratie_tijd + activiteit.totaleTijd;
            }
            foreach (Activiteit activiteit in dbcontext.db.Table<Activiteit>().Where<Activiteit>(x => x.activiteit == "Voorbereiden" && x.datum.Month == maand_int)) //nog filteren op maand
            {
                Voorbereiden_tijd = Voorbereiden_tijd + activiteit.totaleTijd;
            }
            foreach (Activiteit activiteit in dbcontext.db.Table<Activiteit>().Where<Activiteit>(x => x.activiteit == "Pauze" && x.datum.Month == maand_int)) //nog filteren op maand
            {
                pauze_tijd = pauze_tijd + activiteit.totaleTijd;
            }


            totaleLoonBerekening(maand_string);
            totaleTijdenWeergave(maand_string);


            ActiviteitenLabel.Text =
                " Lesgeven:" + Lesgeven_tijd.ToString(@"d\.hh\:mm")
                + "\n Nakijken:" + Nakijken_tijd.ToString(@"d\.hh\:mm")
                + "\n Vergaderen:" + Vergaderen_tijd.ToString(@"d\.hh\:mm")
                + "\n Administratie:" + Administratie_tijd.ToString(@"d\.hh\:mm")
                + "\n Voorbereiden:" + Voorbereiden_tijd.ToString(@"d\.hh\:mm")
                + "\n Pauze:" + pauze_tijd.ToString(@"d\.hh\:mm");





            



            allButtonsInvisible();
            
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


        

                   
    }
}

/*Check in de DB wat de laatste ID is en zet die in een variabale
int laatsteID = (LaatsteIDuitDB)
int iDdieWeNodigHebben;
bool weHebbenDeID = false;

for (int i = 2; i<laatsteID ; i++)
{
    if(weHebbenDeID = true)
    {
    
    }

    else if (naam van de activiteit = naam activiteit bij deze ID)
    {
    iDdieWeNodigHebben = i;
    weHebbenDeID = true;
    }
}

*/

//DAARNA DEZE FIXEN: ********************************************************************
/*activiteit laten stoppen wanneer pauze knop ingedrukt wordt
activiteiten zichtbaar maken met IsVisible wanneer er iets in de tabel staat
pauze timer resetten als je stopt met werken
*/


//activiteiten tabel met:
//naam van de activiteit
//totaal uren activiteit
//totaal minuten activiteit
//maand activiteit

