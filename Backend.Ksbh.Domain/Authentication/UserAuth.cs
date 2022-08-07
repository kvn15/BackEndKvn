using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.Domain.Authentication
{
    public class UserAuth
    {
        public int nIdUsuario { get; set; }
        public string sUser { get; set; }
        public string sNameUser { get; set; }
        public int nIdPersonal { get; set; }
        public int nTipoUser { get; set; }
    }
}
