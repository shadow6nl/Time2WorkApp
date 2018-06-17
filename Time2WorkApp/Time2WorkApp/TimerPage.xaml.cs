using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Time2WorkApp.Model;

namespace Time2WorkApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimerPage : ContentPage
	{
		public TimerPage () 
		{
			InitializeComponent ();
            //datum opvragen
            DateTime now = DateTime.Now.ToLocalTime();
            //dag, maand en jaar eruit filteren
            int dag = now.Day;
            int maand = now.Month;
            int jaar = now.Year;
            //string format zodat de datum als string kan worden weergeven in formaat: dag-maand-jaar
            string systeemDatum = String.Format("{0:00}-{1:00}-{2:00}",
            dag, maand, jaar);
            //assign de string aan de label
            datumVanVandaag.Text = systeemDatum;
        }

        //toggle values voor knoppen.       ipv omschachtig bools te gebruiken, gewoon even en oneven getallen voor het toggelen
        bool activityButtonToggle = false;
        bool pauzeButtonToggle = false;
        bool startButtonToggle = false;

        

        string currentTimertime;
        string currentBreakTimertime;
        string systeemKlokTijdVerschil;
        int uur = 0;                         //begin van loop zet waardes op 0 , later kijk die naar verschil.
        int minuut = 0;
        int seconde = 0;

        string totaalGewerkt, totaalPauze;                     //niet belangrijk 

        int breakhours = 0, breakmins = 0, breaksecs = 0;

        //boolean die aangeeft of werk is begonnen
        bool isWorking = false;
        bool workTimerRunning = false;
        bool breakTimerRunning = false;

        //stopwatches voor werktijden en pauzetijden
        Stopwatch workStopWatch = new Stopwatch(); //ah .... ... eigenlijk niet nodig? 
        Stopwatch breakStopWatch = new Stopwatch();



        //mijn sectie
        DateTime start_button_start_tijd;
        DataContext dbcontext = new DataContext();
        Activiteit current_activity;






        public void RunWorkTimer()
        {

            int hours = 0, mins = 0, secs = 0;
            TimeSpan interval = new TimeSpan(0, 0, 1);

            
            
            

                Device.StartTimer(interval, () =>    //  moet  een false input krijgen..
                {
                    
                        secs++;
                        if (secs > 59)
                        {
                            secs = 0;
                            mins++;
                        }
                        if (mins > 59)
                        {
                            mins = 0;
                            hours++;
                        }

                        currentTimertime = String.Format("{0:00}:{1:00}:{2:00}",
                        hours, mins, secs);
                        starttimeLabel.Text = currentTimertime;


                        return workTimerRunning;
                    

                // No longer need to recur. Stops firing task
                });


        }

        


        //public TimeSpan Timer(bool clicked , DateTime start_time)    //ergens loopje callen die steeds deze functie oproept 
        //{
        //    //start timer , stop wanneer knop weer wordt gedrukt ...
        //    DateTime current_time = DateTime.Now;

        //    while (clicked == true )
        //    {
        //        current_time = DateTime.Now;
        //    }


        //    return Return_Total_Time(start_time, current_time);



        //}

        public TimeSpan Return_Total_Time(DateTime Begintijd , DateTime Eindtijd)
        {
            TimeSpan Total_time = Eindtijd - Begintijd;

            return Total_time;
        }




        //functie van de startknop
        private void startTimeButton_Clicked(object sender, EventArgs e) 
        {
            ////toggle naar even/oneven
            //startButtonToggle += 1;
            ////check of die even of oneven is
            //isWorking = startButtonToggle % 2 == 0;
            TimeSpan tijdverschil;

            //TOGGLE

            if (startButtonToggle == true )
            {
                startButtonToggle = false;
            }
            else
            {
                startButtonToggle = true;
            }



            
            if (startButtonToggle == true ) 
            {

                workTimerRunning = true;
                RunWorkTimer();

                start_button_start_tijd = DateTime.Now;
                
                   
                
                
                int last_index_id_activiteiten = dbcontext.db.Table<Activiteit>().Last().id; 
                dbcontext.Insert_Activity_Into_Table(new Activiteit { id = last_index_id_activiteiten + 1, startTijd = start_button_start_tijd , activiteit="unnamed" });
                current_activity = dbcontext.db.Table<Activiteit>().Last();

                

                

                

                uur = current_activity.startTijd.Hour;
                minuut = current_activity.startTijd.Minute;
                seconde = current_activity.startTijd.Second;

                string systeemKlokTijd = String.Format("{0:00}:{1:00}:{2:00}",
                uur, minuut, seconde);
                //assign de tijden aan de label
                beginWerkTijdLabel.Text = "Begin tijd: " + systeemKlokTijd;
                beginWerkTijdLabel.IsVisible = true;
                starttimeLabel.Text = "Tijd loopt";                                       
                //de start knop wordt veranderd naar een stop knop
                startTimeButton.BackgroundColor = Color.Red;                                        
                startTimeButton.Text = "Stop met activiteit";
                


                
                


            }
            else
            {

                workTimerRunning = false;
                //update current_activity with new eindtijd
                current_activity.stopTijd = DateTime.Now;
                dbcontext.Update_Activity_To_Table(current_activity);

                 
                tijdverschil = Return_Total_Time(current_activity.startTijd, current_activity.stopTijd);  //returned tijdverschil 

                string elapsedWorkTime = String.Format("{0:00}:{1:00}:{2:00}",
                tijdverschil.Hours, tijdverschil.Minutes, tijdverschil.Seconds);
                starttimeLabel.Text = elapsedWorkTime;
                startTimeButton.BackgroundColor = Color.ForestGreen;
                startTimeButton.Text = "Begin met activiteit";   
                beginWerkTijdLabel.IsVisible = false;

                
                


                DisplayAlert("Overzicht", "Totale tijd van " + current_activity.activiteit+ " " + elapsedWorkTime + "  (UU:MM:SS)", "Doorgaan");
            } 
            
            
             

            
        }

        
        
        



        










        private void activityToggleButton_Clicked(object sender, EventArgs e) 
        {

            if(activityButtonToggle == true )
            {
                activityButtonToggle = false;
            }
            else
            {
                activityButtonToggle = true;
            }

            //zichtbaarheid van activity elementen
            activityName.IsVisible = activityButtonToggle;
            updateActivityButton.IsVisible = activityButtonToggle;
            //als activiteit wordt getoggled naar TRUE
            if (activityButtonToggle == true)
            {
                //kleur van de knop wordt lichtgroen
                activityToggleButton.BackgroundColor = Color.LightGreen;
            }
            else //altijd false als die niet true is :P 
            {
                //kleur van de knop wordt lichtblauw
                activityToggleButton.BackgroundColor = Color.LightBlue;
                activityIsUpdatedLabel.IsVisible = false;
            }
        }


        //updatefunctie van de activiteit knop
        private void updateActivityButton_Clicked(object sender, EventArgs e)  //string als argument voor input ... hoort bij hierboven?  ja
        {

            current_activity.activiteit = activityName.Text; //even kijken hoe je een string vanuit axml stuurt
            dbcontext.Update_Activity_To_Table(current_activity);

            //verander huidig activiteit + de entry
            activityIsUpdatedLabel.Text = "Huidig activiteit: " + current_activity.activiteit; 
            //weergeef dat de activiteit up to date is
            activityIsUpdatedLabel.IsVisible = true;
        }

    }
}