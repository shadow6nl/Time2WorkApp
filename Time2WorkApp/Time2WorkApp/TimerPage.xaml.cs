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
using Time2WorkApp.Helpers;

namespace Time2WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        //toggle values voor knoppen.       ipv omschachtig bools te gebruiken, gewoon even en oneven getallen voor het toggelen


        int activityButtonToggle = 1;
        int pauzeButtonToggle = 1;
        int startButtonToggle = 1;

        int totaalPauzeSec = 0;
        int totaalPauzeMin = 0;
        int totaalPauzeHrs = 0;

        string currentTimertime;
        string currentBreakTimertime;
        string systeemKlokTijdVerschil;
        string huidigeActiviteit = "";
        int uur, minuut, seconde;

        string totaalGewerkt, totaalPauze;
        string activiteit_naam = "Lesgeven"; //blijft lesgeven als er niets anders gekozen wordt


        int breakhours = 0, breakmins = 0, breaksecs = 0;
        int hours = 0, mins = 0, secs = 0;

        //boolean die aangeeft of werk is begonnen
        bool isWorking = false;
        bool workTimerRunning = false;
        bool breakTimerRunning = false;

        //stopwatches voor werktijden en pauzetijden
        Stopwatch workStopWatch = new Stopwatch();
        Stopwatch breakStopWatch = new Stopwatch();
        Stopwatch activityStopWatch = new Stopwatch();

        DateTime start_button_start_tijd;
        DataContext dbcontext = new DataContext();
        Activiteit current_activity;
        Month current_month;
        TimeSpan workingTs, breakTs;

        int totaalUren, totaalMinuten, lastHours, lastMinutes;
        int pauzeUren, pauzeMinuten, lastPauzeHours, lastPauzeMinutes;




        // Dictionary to get Color from color name.
        //Dictionary<string, Color> activityToUpdate = new Dictionary<string, Color>
        //{
        //    { "Lesgeven", Color.Aqua },
        //    { "Nakijken", Color.Black },
        //    { "Vergaderen", Color.Blue },     
        //    { "Administratie", Color.Gray },
        //    { "Voorbereiden", Color.Green },
        //};

        


        public TimerPage()
        {
            InitializeComponent();

            //dbcontext.Insert_User_Into_Table(new Gebruiker { id = 1, brutoloon = 10000, email = "A", password = "A" });

            //if(dbcontext.db.Table<Activiteit>().FirstOrDefault( x => x.id == 0 ) == null )  
            //{
            //    dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 0,  activiteit = "Lesgeven" });
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == 1) == null)
            //{
            //    dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 1,  activiteit = "Nakijken" });
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == 2) == null)
            //{
            //    dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 2, activiteit = "Vergaderen" });
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == 3) == null)
            //{
            //    dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 3,  activiteit = "Administratie" });
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == 4) == null)
            //{
            //    dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 4,  activiteit = "Voorbereiden" });
            //}
            //if (dbcontext.db.Table<Activiteit>().FirstOrDefault(x => x.id == 5) == null)
            //{
            //    dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 5,  activiteit = "Pauze" });
            //}          




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


            //Picker picker = new Picker
            //{
            //    Title = "Activiteit:",
            //    VerticalOptions = LayoutOptions.CenterAndExpand

            //};

            //foreach (string activityNumber in activityToUpdate.Keys)
            //{
            //    picker.Items.Add(activityNumber);
            //}

            // Create BoxView for displaying picked Color
            //BoxView boxView = new BoxView
            //{
            //    WidthRequest = 150,
            //    HeightRequest = 150,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.CenterAndExpand
            //};

            //picker.SelectedIndexChanged += (sender, args) =>
            //{
            //    if (picker.SelectedIndex == -1)
            //    {
            //        boxView.Color = Color.Default;
            //    }
            //    else
            //    {
            //        string activityNumber = picker.Items[picker.SelectedIndex];
            //        boxView.Color = activityToUpdate[activityNumber];
            //    }
            //};         




            //mainStackLayout.Children.Add(picker);
            //mainStackLayout.Children.Add(boxView);


            MyPicker.Items.Add("Lesgeven");
            MyPicker.Items.Add("Nakijken");
            MyPicker.Items.Add("Vergaderen");
            MyPicker.Items.Add("Administratie");
            MyPicker.Items.Add("Voorbereiden");

        }

        private void MyPicker_Clicked(object sender, EventArgs e)
        {
            activiteit_naam = MyPicker.Items[MyPicker.SelectedIndex];
        }







        

        public void totaalGewerkteUrenBerekening()
        {

            totaalUren = totaalUren + workingTs.Hours;
            totaalMinuten = totaalMinuten + workingTs.Minutes;
            if (totaalMinuten > 59)
            {
                totaalUren++;
                totaalMinuten = totaalMinuten - 60;
            }
        }


        public void totaalPauzeUrenBerekening()
        {
            pauzeUren = pauzeUren + breakTs.Hours;
            pauzeMinuten = pauzeMinuten + breakTs.Minutes;
            if (pauzeMinuten > 59)
            {
                pauzeUren++;
                pauzeMinuten = pauzeMinuten - 60;
            }

        }


        public void RunWorkTimer(Boolean Value)
        {
            Boolean excuteTimer = Value;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (Value)
                {
                    if (workTimerRunning)
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
                    }


                    return workTimerRunning;
                }
                // No longer need to recur. Stops firing task
                return false;
            });


        }

        public void RunBreakTimer(Boolean Value)
        {
            Boolean excuteTimer = Value;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (Value)
                {
                    if (breakTimerRunning)
                    {
                        breaksecs++;
                        if (breaksecs > 59)
                        {
                            breaksecs = 0;
                            breakmins++;
                        }
                        if (breakmins > 59)
                        {
                            breakmins = 0;
                            breakhours++;
                        }
                        currentBreakTimertime = String.Format("{0:00}:{1:00}:{2:00}",
                        breakhours, breakmins, breaksecs);
                        pauseTimerLabel.Text = currentBreakTimertime;
                    }
                    return breakTimerRunning;
                }
                // No longer need to recur. Stops firing task
                return false;
            });


        }







        //functie van de startknop
        private void startTimeButton_Clicked(object sender, EventArgs e)
        {
            

            
            //toggle naar even/oneven
            startButtonToggle += 1;
            //check of die even of oneven is
            isWorking = startButtonToggle % 2 == 0;
            //als de startknop de state verandert naar isWorking. Deze wordt dus true NA HET KLIKKEN
            if (isWorking == true)
            {
                workTimerRunning = true;
                RunWorkTimer(true);
                //het aanvragen van de huidige systeem tijd 
                DateTime now = DateTime.Now.ToLocalTime();
                //de dateTime uitfilteren van de datum en tijd naar TIJD ONLY
                uur = now.Hour;
                minuut = now.Minute;
                seconde = now.Second;
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
                //starttimeLabel.Text = "Tijd loopt";
                //de start knop wordt veranderd naar een stop knop
                startTimeButton.BackgroundColor = Color.Red;
                startTimeButton.Text = "Stop met Werken";     

                //vanaf nu kun je pauzes nemen, dus de pauze knop wordt actief
                pauseTimeButton.IsEnabled = true;
                pauseTimeButton.BackgroundColor = Color.DarkOrange;




                int last_activity_id = 0;
                if (dbcontext.db.Table<Activiteit>().Any() == true)
                {
                    last_activity_id = dbcontext.db.Table<Activiteit>().Last().id;
                }                
                
                dbcontext.Insert_Activity_Into_Table(new Activiteit { id = last_activity_id + 1, activiteit = activiteit_naam, startTijd = DateTime.Now, datum = DateTime.Now });   //insert new activiteit
            }


            //als de stopknop wordt geklikt
            else if (isWorking == false)
            {


                workTimerRunning = false;
                //label van begin tijd wordt verborgen aangezien je niet meer werkt
                beginWerkTijdLabel.IsVisible = false;
                //werktijd stopt
                workStopWatch.Stop();
                //hoeveelheid gewerkte tijd wordt opgenomen
                workingTs = workStopWatch.Elapsed;
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

                secs = 00;
                mins = 00;
                hours = 00;
                currentTimertime = String.Format("{0:00}:{1:00}:{2:00}",
                    hours, mins, secs);
                starttimeLabel.Text = currentTimertime;

                breaksecs = 00;
                breakmins = 00;
                breakhours = 00;
                currentBreakTimertime = String.Format("{0:00}:{1:00}:{2:00}",
                        breakhours, breakmins, breaksecs);
                pauseTimerLabel.Text = currentBreakTimertime;

                totaalPauze = String.Format("{0:00}:{1:00}:{2:00}",
                    totaalPauzeHrs, totaalPauzeMin, totaalPauzeSec);

                //update activiteit

                //if(activityIsUpdatedLabel.Text != "Activiteit:")
                //{
                //    activiteit_naam = activityIsUpdatedLabel.Text; //picker input 
                //}
                //else
                //{
                //    activiteit_naam = "Lesgeven";
                //}

                

                current_activity = dbcontext.db.Table<Activiteit>().LastOrDefault(x => x.activiteit != "Pauze");  //update laatste activiteit
                current_activity.activiteit = activiteit_naam;
                current_activity.stopTijd = DateTime.Now;
                current_activity.totaleTijd = current_activity.stopTijd - current_activity.startTijd;
                dbcontext.Update_Activity_To_Table(current_activity);




                totaalGewerkt = elapsedWorkTime;
                DisplayAlert("Overzicht", "Je hebt in totaal " + totaalGewerkt + " gewerkt en " + totaalPauze + " pauze gehad.  " + "  (UU:MM:SS)", "Doorgaan");


                //FUNCTIES VOOR GEWERKTE TIJD******************************************************************
                //functie die uren en minuten OPVRAAGT

                totaalGewerkteUrenBerekening();
                //functie die uren en minuten stuurt STUURT
                current_month = dbcontext.Get_Month("Juni");
                current_month.totaleTijdgewerktMin = totaalMinuten;
                if (totaalUren < 1) { }
                else
                    current_month.totaleTijdGewerktUur = totaalUren;

                dbcontext.Update_Month_From_Table(current_month);


                //FUNCTIES VOOR PAUZE TIJD******************************************************************
                //functie die uren en minuten OPVRAAGT

                totaalPauzeUrenBerekening();

                //functie die uren en minuten stuurt STUURT
                current_month.totaleTijdPauzeUur = pauzeUren;
                current_month.totaleTijdPauzeMin = pauzeMinuten;

                dbcontext.Update_Month_From_Table(current_month);


                workStopWatch.Reset();
                totaalPauzeSec = 0;
                totaalPauzeMin = 0;
                totaalPauzeHrs = 0;
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
                breaksecs = 0;
                breakmins = 0;
                breakhours = 0;
                breakTimerRunning = true;
                RunBreakTimer(true);
                workTimerRunning = false;
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



                current_activity = dbcontext.db.Table<Activiteit>().Last();
                int last_activity_id = current_activity.id;
                dbcontext.Insert_Activity_Into_Table(new Activiteit { id= last_activity_id+1 , activiteit = "Pauze", startTijd = DateTime.Now , datum=DateTime.Now });   //insert new pauze


                //tijd begint te lopen van de pauze
                breakStopWatch.Start();
                //pause label en knop worden aangepast
                //pauseTimerLabel.Text = "tijd loopt";
                pauseTimeButton.Text = "stop de pauze";
                pauseTimeButton.BackgroundColor = Color.OrangeRed;

            }


            //wanneer de pauze bezig was en nu gestopt wordt
            else if (pauzeIsBezig == false)
            {
                breakTimerRunning = false;
                workTimerRunning = true;
                RunWorkTimer(true);
                //Systeemtijd wanneer de pauze begint
                beginPauzeTijdLabel.IsVisible = false;
                //pausetijd stopt
                breakStopWatch.Stop();
                //tijd wordt geformat naar een string
                breakTs = breakStopWatch.Elapsed;
                string elapsedBreakTime = String.Format("{0:00}:{1:00}:{2:00}",
                breakTs.Hours, breakTs.Minutes, breakTs.Seconds);
                //de pause label weergeeft de verstreken tijd van de pauze
                pauseTimerLabel.Text = elapsedBreakTime;
                pauseTimeButton.Text = "Begin pauze";
                pauseTimeButton.BackgroundColor = Color.DarkOrange;

                //de tijd van het werken gaat weer verder
                workStopWatch.Start();
                //de werk knop en label worden aangepast en geenabled
                //starttimeLabel.Text = "Tijd loopt";
                startTimeButton.BackgroundColor = Color.Red;
                startTimeButton.Text = "Stop met Werken";
                startTimeButton.IsEnabled = true;

                int dezePauzeSec = breakTs.Seconds;
                int dezePauzeMin = breakTs.Minutes;
                int dezePauzeHrs = breakTs.Hours;


                totaalPauzeSec = totaalPauzeSec + dezePauzeSec;
                totaalPauzeMin = totaalPauzeMin + dezePauzeMin;
                totaalPauzeHrs = totaalPauzeHrs + dezePauzeHrs;
                if (totaalPauzeSec > 59)
                {
                    totaalPauzeMin++;
                }
                if (totaalPauzeMin > 59)
                {
                    totaalPauzeHrs++;
                }


                current_activity = dbcontext.db.Table<Activiteit>().LastOrDefault(x => x.activiteit == "Pauze");  //update laatste activiteit met naam "Pauze"
                current_activity.stopTijd = DateTime.Now;
                current_activity.totaleTijd = current_activity.stopTijd - current_activity.startTijd;               
                dbcontext.Update_Activity_To_Table(current_activity);

                breakStopWatch.Reset();
            }
        }










        //private void activityToggleButton_Clicked(object sender, EventArgs e)
        //{
        //    //toggle naar even/oneven
        //    activityButtonToggle += 1;
        //    //check of die even of oneven is
        //    bool activityVisible = activityButtonToggle % 2 == 0;
        //    //zichtbaarheid van activity elementen
        //    activityName.IsVisible = activityVisible;
        //   // updateActivityButton.IsVisible = activityVisible;
        //    //als activiteit wordt getoggled naar TRUE
        //    if (activityVisible == true)
        //    {
        //        //kleur van de knop wordt lichtgroen
        //        activityToggleButton.BackgroundColor = Color.LightGreen;
        //    }

        //    //wanneer de activiteit wordt getoggled naar FALSE
        //    if (activityVisible == false)
        //    {
        //        //kleur van de knop wordt lichtblauw
        //        activityToggleButton.BackgroundColor = Color.LightBlue;
        //        activityIsUpdatedLabel.IsVisible = false;
        //    }
        //}



























        ////updatefunctie van de activiteit knop
        //private void updateActivityButton_Clicked(object sender, EventArgs e)
        //{
        //    string elapsedTimeActiviteit;
        //    if (activityStopWatch.IsRunning == false)
        //    {
        //        if (activityName.Text == null)
        //        {
        //            DisplayAlert("Waarschuwing", "Vul eerst een activiteit in!", "Doorgaan");
        //        }
        //        else
        //        {
        //            activityStopWatch.Start();
        //            huidigeActiviteit = activityName.Text;
        //            //verander huidig activiteit + de entry
        //            activityIsUpdatedLabel.Text = "Huidig activiteit: " + activityName.Text;
        //            //weergeef dat de activiteit up to date is
        //            activityIsUpdatedLabel.IsVisible = true;
        //        }
        //    }
        //    else
        //    {
        //        if (activityName.Text == "")
        //        {
        //            DisplayAlert("Waarschuwing", "Vul eerst een activiteit in!", "Doorgaan");
        //        }
        //        else if (huidigeActiviteit == activityName.Text)
        //        {
        //            DisplayAlert("Waarschuwing", "Hey, je bent al bezig met deze activiteit", "Doorgaan");
        //        }
        //        else
        //        { 
                
        //            activityStopWatch.Stop();
        //            DateTime today = new DateTime();
        //            string maand = today.Month.ToString();
        //            TimeSpan elapsedActivityTime = activityStopWatch.Elapsed;
        //            elapsedTimeActiviteit = String.Format("{0:00}:{1:00}:{2:00}",
        //            elapsedActivityTime.Hours, elapsedActivityTime.Minutes, elapsedActivityTime.Seconds);



        //            if (dbcontext.Get_Activiteit(0).activiteit == "Lesgeven") 
        //            {
        //                dbcontext.Get_Activiteit(0).totaleTijd = elapsedTimeActiviteit;
        //            }

        //            if (dbcontext.Get_Activiteit(1).activiteit == "Nakijken")
        //            {
        //                dbcontext.Get_Activiteit(1).totaleTijd = elapsedTimeActiviteit;
        //            }

        //            if (dbcontext.Get_Activiteit(2).activiteit == "Vergaderen")
        //            {
        //                dbcontext.Get_Activiteit(2).totaleTijd = elapsedTimeActiviteit;
        //            }

        //            if (dbcontext.Get_Activiteit(3).activiteit == "Administratie")
        //            {
        //                dbcontext.Get_Activiteit(3).totaleTijd = elapsedTimeActiviteit;
        //            }

        //            if (dbcontext.Get_Activiteit(4).activiteit == "Voorbereiden")
        //            {
        //                dbcontext.Get_Activiteit(4).totaleTijd = elapsedTimeActiviteit;
        //            }
        //            dbcontext.Update_Activity_To_Table(current_activity);




        //            //dbcontext.Insert_Activity_Into_Table(new Activiteit { id = 1, datum = DateTime.Now, totaleTijd = elapsedTimeActiviteit, activiteit = dbcontext.Get_Activiteit(2).activiteit });






        //            //reset stopwatch en begin opnieuw
        //            activityStopWatch.Reset();
        //                activityStopWatch.Start();
        //                huidigeActiviteit = activityName.Text;
        //                //verander huidig activiteit + de entry
        //                activityIsUpdatedLabel.Text = "Huidig activiteit: " + activityName.Text;
        //                //weergeef dat de activiteit up to date is
        //                activityIsUpdatedLabel.IsVisible = true;
        //            }
               
        //        }




        //                //het opslaan naar de database:**************************************************************************************************************

        //                current_activity = dbcontext.db.Table<Activiteit>().Last();
        //                elapsedTimeActiviteit = totaalGewerkt;
        //                huidigeActiviteit = current_activity.activiteit;


        // }


                }
            }

        