using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2WorkApp.UWP.Model
{
    class Profiel
    {
        public int id { get; set; }

        public string voornaam { get; set; }

        public string achternaam { get; set; }

        public string email { get; set; }

        public string wachtwoord { get; set; }

        public float brutoloon { get; set; }
    }
}
