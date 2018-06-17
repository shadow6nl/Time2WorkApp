using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace Time2WorkApp.Model
{
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
        public void Update_Activity_To_Table(Activiteit activity) // looks for the object in the DB where the object's id and ID argument match. changes the sometime atribute and then updates the new value
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
        public void Insert_Activity_Into_Table(Gebruiker user) //inserts an instance of an 'Gebruiker' object into the database 
        {
            db.Insert(user);
        }
        public void Update_Activity_From_Table(Gebruiker user) // looks for the object in the DB where the object's id and ID argument match. changes the sometime atribute and then updates the new value
        {

            db.Update(user);
        }

        public Gebruiker Get_Gebruiker(int ID) // returns an Activiteit object with the id that matches the ID argument. 
        {
            Gebruiker user = db.Find<Gebruiker>(A => A.id == ID);

            return user;
        }
        public void Delete_Activity_From_Table(Gebruiker user) // deletes an activiteit object from the db (probably looks at corresponding primary key) 
        {
            db.Delete(user);
        }
    }
}
