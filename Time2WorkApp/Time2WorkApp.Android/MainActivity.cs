using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;

namespace Time2WorkApp.Droid
{
    [Activity(Label = "Time2WorkApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            SetContentView(Resource.Layout.Main);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            DateTime randometime = new DateTime(2000, 12, 1, 1, 1, 1);
            DataContext dbcontext = new DataContext();
            dbcontext.Create_table_Activity();
            dbcontext.Create_table_user();
            dbcontext.Create_table_Month();
            //dbcontext.Insert_Activity_Into_Table(new Activiteit{ id = 1, startTijd = randometime, datum = randometime, stopTijd = randometime, totaleTijd = randometime, activiteit = "someactivity" });


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }

    public class DataContext
    {
        public string Database_Name = "Time2WorkApp.sqlite";
        public SQLiteConnection db;



        public DataContext()     //gets the path on the device and uses it to create a local DB file
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, Database_Name);

            db = new SQLiteConnection(path);
        }

        public void Create_table_Activity() // create a table of type <Activiteit> 
        {
            db.CreateTable<Activiteit>();
        }
        public void Insert_Activity_Into_Table(Activiteit activity) //inserts an instance of an 'Activiteit' object into the database 
        {
            db.Insert(activity);
        }
        public void Update_Activity_From_Table(Activiteit activity) // looks for the object in the DB where the object's id and ID argument match. changes the sometime atribute and then updates the new value
        {

            db.Update(activity);
        }

        public Activiteit Get_Activiteit(int ID) // returns an Activiteit object with the id that matches the ID argument. 
        {
            Activiteit activity = db.Find<Activiteit>(A => A.id == ID);

            return activity;
        }
        public void Delete_Activity_From_Table(Activiteit activity) // deletes an activiteit object from the db (probably looks at corresponding primary key) 
        {
            db.Delete(activity);
        }

        // functies voor de firstuse, login en optionspage
        public void Create_table_user() // create a table of type <Gebruiker> 
        {
            db.CreateTable<Gebruiker>();
        }
        public void Insert_User_Into_Table(Gebruiker user) //inserts an instance of an 'Gebruiker' object into the database 
        {
            db.Insert(user);
        }
        public void Update_User_From_Table(Gebruiker user) // looks for the object in the DB where the object's id and ID argument match. changes the sometime atribute and then updates the new value
        {

            db.Update(user);
        }

        public Gebruiker Get_Gebruiker(int ID) // returns an Activiteit object with the id that matches the ID argument. 
        {
            Gebruiker user = db.Find<Gebruiker>(A => A.id == ID);

            return user;
        }
        public void Delete_User_From_Table(Gebruiker user) // deletes an activiteit object from the db (probably looks at corresponding primary key) 
        {
            db.Delete(user);
        }






        // functies voor de Month table
        public void Create_table_Month() // create a table of type <Gebruiker> 
        {
            db.CreateTable<Month>();
        }
        public void Insert_Month_Into_Table(Month maand) //inserts an instance of an 'Gebruiker' object into the database 
        {
            db.Insert(maand);
        }
        public void Update_Month_From_Table(Month maand) // looks for the object in the DB where the object's id and ID argument match. changes the sometime atribute and then updates the new value
        {

            db.Update(maand);
        }

        public Month Get_Month(string ID) // returns a Month object with the id that matches the ID argument. 
        {
            Month user = db.Find<Month>(A => A.maand == ID);

            return user;
        }
        public void Delete_Month_From_Table(Month month) // deletes an Month object from the db (probably looks at corresponding primary key) 
        {
            db.Delete(month);
        }

    }
}
    //DAARNA DEZE FIXEN: ********************************************************************
    /*activiteit laten stoppen wanneer pauze knop ingedrukt wordt
    activiteiten zichtbaar maken met IsVisible wanneer er iets in de tabel staat
    loon fixen
    */


    //activiteiten tabel met:
    //naam van de activiteit
    //totaal uren activiteit
    //totaal minuten activiteit
    //maand activiteit


    [Table("Activiteiten")]
    public class Activiteit //something
    {
        [PrimaryKey]
        public int id { get; set; }

        public DateTime datum { get; set; }

        public string activiteit { get; set; }

        public DateTime startTijd { get; set; }

        public DateTime stopTijd { get; set; }

        public DateTime totaleTijd { get; set; }

        public DateTime pauze { get; set; }

        public DateTime activiteitUren { get; set; }
        public DateTime activiteitMinuten { get; set; }
    }

    [Table("Gebruikers")] // gebruikers tabel voor de firstuse, login en optionspage
    public class Gebruiker
    {
        [PrimaryKey]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public double brutoloon { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    [Table("Months")] // gebruikers tabel voor de firstuse, login en optionspage
    public class Month
{
    [PrimaryKey]
    public string maand { get; set; }
    public int totaleTijdGewerktUur { get; set; }
    public int totaleTijdgewerktMin { get; set; }
    public DateTime datum_tijd { get; set; }
    public int totaleTijdPauzeUur { get; set; }
    public int totaleTijdPauzeMin { get; set; }
}

