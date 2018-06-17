﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time2WorkApp.Model
{
    [Table("Activiteiten")]
    public class Activiteit //something
    {
        [PrimaryKey]
        public int id { get; set; }

        public string activiteit { get; set; }

        public DateTime startTijd { get; set; }

        public DateTime stopTijd { get; set; }

        public DateTime pauze { get; set; }
    }
}


