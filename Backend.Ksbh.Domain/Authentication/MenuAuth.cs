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

    public class MenuList
    {
        public int nIdMenu { get; set; }
        public string nombreMenu { get; set; }
        public string nombreRuta { get; set; }
        public int? nMenuPadre { get; set; }
        public string estado { get; set; }
        public int posicionMenu { get; set; }
    }
}
