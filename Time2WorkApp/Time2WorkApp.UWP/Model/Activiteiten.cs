﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2WorkApp.UWP.Model
{
    class Activiteiten
    {
        public int id { get; set; }

        public DateTime datum { get; set; }

        public string activiteit { get; set; }

        public DateTime startTijd { get; set; }

        public DateTime stopTijd { get; set; }

        public DateTime totaleTijd { get; set; }
    }
}
