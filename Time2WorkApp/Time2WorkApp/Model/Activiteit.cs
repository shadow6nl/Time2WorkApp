﻿using SQLite;
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

        public TimeSpan totaleTijd { get; set; }

        public DateTime pauze { get; set; }

        public int activiteitUren { get; set; }
        public int activiteitMinuten { get; set; }
    }
}


