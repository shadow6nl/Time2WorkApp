using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2WorkApp.UWP.Model
{
    class Werk
    {
        public int id { get; set; }

        public DateTime datum { get; set; }

        public DateTime startTijd { get; set; }

        public DateTime stopTijd { get; set; }

        public DateTime gewerkteTijd { get; set; }
    }
}
    
