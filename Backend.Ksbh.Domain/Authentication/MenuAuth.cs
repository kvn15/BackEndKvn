using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.Domain.Authentication
{
    public class MenuAuth
    {
        public int nIdMenu { get; set; }
        public string sNomMenu { get; set; }
        public string sAbreviado { get; set; }
        public string sPath { get; set; }
        public int nMenuPadre { get; set; }
        public int totalHijos { get; set; }
    }
}
