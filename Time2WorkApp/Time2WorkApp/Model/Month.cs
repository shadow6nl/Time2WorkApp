using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time2WorkApp.Model
{
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
}
