using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time2WorkApp.Model
{
    [Table("Activiteiten")]
    public class Activiteit
    {
        [PrimaryKey]
        public int id { get; set; }

        public DateTime datum { get; set; }

        public string activiteit { get; set; }

        public DateTime startTijd { get; set; }

        public DateTime stopTijd { get; set; }

        public string totaleTijd { get; set; }

        public DateTime pauze { get; set; }
    }
}


