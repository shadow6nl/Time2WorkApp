using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time2WorkApp.Model
{
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
}
