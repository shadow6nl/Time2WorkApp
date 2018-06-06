using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

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
        int activityButtonToggle = 1;
        int pauzeButtonToggle = 1;
        int startButtonToggle = 1;

        //boolean die aangeeft of werk is begonnen
        bool isWorking = false;

        //stopwatches voor werktijden en pauzetijden
        Stopwatch workStopWatch = new Stopwatch();
        Stopwatch breakStopWatch = new Stopwatch();

        private void activityToggleButton_Clicked(object sender, EventArgs e)
        {
            //toggle naar even/oneven
            activityButtonToggle += 1;
            //check of die even of oneven is
            bool activityVisible = activityButtonToggle % 2 == 0;
            //zichtbaarheid van activity elementen
            activityName.IsVisible = activityVisible;
            updateActivityButton.IsVisible = activityVisible;
            //als activiteit wordt getoggled naar TRUE
            if (activityVisible == true)
            {
                //kleur van de knop wordt lichtgroen
                activityToggleButton.BackgroundColor = Color.LightGreen;
            }

            //wanneer de activiteit wordt getoggled naar FALSE
            if (activityVisible == false)
            {
                //kleur van de knop wordt lichtblauw
                activityToggleButton.BackgroundColor = Color.LightBlue;
                activityIsUpdatedLabel.IsVisible = false;
            }
        }


        //updatefunctie van de activiteit knop
        private void updateActivityButton_Clicked(object sender, EventArgs e)
        {
        //verander huidig activiteit + de entry
        activityIsUpdatedLabel.Text = "Huidig activiteit: " + activityName.Text;
        //weergeef dat de activiteit up to date is
        activityIsUpdatedLabel.IsVisible = true;
        }


        //functie van de startknop
        private void startTimeButton_Clicked(object sender, EventArgs e)
        {
            //toggle naar even/oneven
            startButtonToggle += 1;
            //check of die even of oneven is
            bool isWorking = startButtonToggle % 2 == 0;
            //als de startknop de state verandert naar isWorking. Deze wordt dus true NA HET KLIKKEN
            if (isWorking == true)
            {
                //het aanvragen van de huidige systeem tijd 
                DateTime now = DateTime.Now.ToLocalTime();
                //de dateTime uitfilteren van de datum en tijd naar TIJD ONLY
                int uur = now.Hour;
                int minuut = now.Minute;
                int seconde = now.Second;
                //string format naar Uur:minuut:seconde
                string systeemKlokTijd = String.Format("{0:00}:{1:00}:{2:00}",
                uur, minuut, seconde);
                //assign de tijden aan de label
                beginWerkTijdLabel.Text = "Begin tijd: " + systeemKlokTijd;
                //maak de label zichtbaar
                beginWerkTijdLabel.IsVisible = true;

                //werktijd start
                workStopWatch.Start();
                //label weergeeft dat de tijd in is gegaan
                starttimeLabel.Text = "Tijd loopt";
                //de start knop wordt veranderd naar een stop knop
                startTimeButton.BackgroundColor = Color.Red;
                startTimeButton.Text = "Stop met Werken";

                //vanaf nu kun je pauzes nemen, dus de pauze knop wordt actief
                pauseTimeButton.IsEnabled = true;
                pauseTimeButton.BackgroundColor = Color.DarkOrange;
            }
            //als de stopknop wordt geklikt
            else if (isWorking == false)
            {
                //label van begin tijd wordt verborgen aangezien je niet meer werkt
                beginWerkTijdLabel.IsVisible = false;
                //werktijd stopt
                workStopWatch.Stop();
                //hoeveelheid gewerkte tijd wordt opgenomen
                TimeSpan workingTs = workStopWatch.Elapsed;
                //string wordt geformat zodat de gewerkte tijd kan worden weergeven
                string elapsedWorkTime = String.Format("{0:00}:{1:00}:{2:00}",
                workingTs.Hours, workingTs.Minutes, workingTs.Seconds);
                //label wordt aangepast met de gewerkte tijd
                starttimeLabel.Text = elapsedWorkTime;
                //starttijdknop wordt aangepast
                startTimeButton.BackgroundColor = Color.ForestGreen;
                startTimeButton.Text = "begin met werken";

                //pause knop wordt gedisabled aangezien je niet meer bezig bent met werken
                pauseTimeButton.IsEnabled = false;
                pauseTimeButton.BackgroundColor = Color.Gray;
            }
        }
        

        private void pauseTimeButton_Clicked(object sender, EventArgs e)
        {
                pauzeButtonToggle += 1;
                //check of die even of oneven is
                bool pauzeIsBezig = pauzeButtonToggle % 2 == 0;
                //wanneer de knop wordt geklikt en de pauze begint
                if (pauzeIsBezig == true)
                {
                    //datum en tijd van de pauze worden weergeven
                    DateTime now = DateTime.Now.ToLocalTime();
                    int uur = now.Hour;
                    int minuut = now.Minute;
                    int seconde = now.Second;
                    string systeemKlokTijd = String.Format("{0:00}:{1:00}:{2:00}",
                    uur, minuut, seconde);
                    beginPauzeTijdLabel.Text = "Begin tijd: " + systeemKlokTijd;
                    beginPauzeTijdLabel.IsVisible = true;

                    //stopwatch wordt stop gezet
                     workStopWatch.Stop();
                    //timespan wordt berekent
                    TimeSpan workingTs = workStopWatch.Elapsed;
                    string elapsedWorkTime = String.Format("{0:00}:{1:00}:{2:00}",
                    workingTs.Hours, workingTs.Minutes, workingTs.Seconds);
                    //label onder de startknop weergeeft de totale tijd tot nu toe
                    starttimeLabel.Text = elapsedWorkTime;
                    //startknop verandert van kleur, text en wordt gedisabled
                    startTimeButton.Text = "korte break";
                    startTimeButton.BackgroundColor = Color.Gray;
                    startTimeButton.IsEnabled = false;

                    
                    //tijd begint te lopen van de pauze
                    breakStopWatch.Start();
                    //pause label en knop worden aangepast
                    pauseTimerLabel.Text = "tijd loopt";
                    pauseTimeButton.Text = "stop de pauze";
                    pauseTimeButton.BackgroundColor = Color.OrangeRed;
                    
                }
                //wanneer de pauze bezig was en nu gestopt wordt
                else if (pauzeIsBezig == false)
                {
                    //Systeemtijd wanneer de pauze begint
                    beginPauzeTijdLabel.IsVisible = false;
                    //pausetijd stopt
                    breakStopWatch.Stop();
                    //tijd wordt geformat naar een string
                    TimeSpan breakTs = breakStopWatch.Elapsed;
                    string elapsedBreakTime = String.Format("{0:00}:{1:00}:{2:00}",
                    breakTs.Hours, breakTs.Minutes, breakTs.Seconds);
                    //de pause label weergeeft de verstreken tijd van de pauze
                    pauseTimerLabel.Text = elapsedBreakTime;
                    pauseTimeButton.Text = "Begin pauze";
                    pauseTimeButton.BackgroundColor = Color.DarkOrange;

                    //de tijd van het werken gaat weer verder
                    workStopWatch.Start();
                    //de werk knop en label worden aangepast en geenabled
                    starttimeLabel.Text = "Tijd loopt";
                    startTimeButton.BackgroundColor = Color.Red;
                    startTimeButton.Text = "Stop met Werken";
                    startTimeButton.IsEnabled = true;
                }
        }

    }
}