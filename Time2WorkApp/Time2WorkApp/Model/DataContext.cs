using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Linq;

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

            Create_table_Activity();
            Create_table_user();
            Create_table_Month();
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


            if (db.Table<Month>().Any<Month>() == false)
            {

                Insert_Month_Into_Table(new Month { maand = "Januari", maand_ID = 1   ,totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "Februari", maand_ID = 2, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "Maart", maand_ID = 3, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "April", maand_ID = 4, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "Mei", maand_ID = 5, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });

                Insert_Month_Into_Table(new Month { maand = "Juni", maand_ID = 6, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });

                Insert_Month_Into_Table(new Month { maand = "Juli", maand_ID = 7, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "Augustus", maand_ID = 8, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "September", maand_ID = 9, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "Oktober", maand_ID = 10, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "November", maand_ID = 11, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });
                Insert_Month_Into_Table(new Month { maand = "December", maand_ID = 12, totaleTijdgewerktMin = 0, totaleTijdGewerktUur = 0, totaleTijdPauzeMin = 0, totaleTijdPauzeUur = 0 });

            }
        }
        public void Insert_Month_Into_Table(Month user) //inserts an instance of an 'Gebruiker' object into the database 
        {
            db.Insert(user);
        }
        public void Update_Month_From_Table(Month month) // looks for the object in the DB where the object's id and ID argument match. changes the sometime atribute and then updates the new value
        {

            db.Update(month);
        }

        public Month Get_Month(string ID)// returns a Month object with the id that matches the ID argument. 
        {
            Month month = db.Find<Month>(A => A.maand == ID);

            return month;
        }
        public void Delete_month_from_table(Month month) // deletes an Month object from the db (probably looks at corresponding primary key) 
        {
            db.Delete(month);
        }
    }
}
