using Backend.Ksbh.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.BusinessLogic.Authentication.Interfaces
{
    public interface IMenuAuthBL
    {
        Task<IList<MenuAuth>> Get_MenusPadres(int tipoUser);
        Task<IList<MenuAuth>> Get_MenusHijos(int tipoUser, int padre);
    }
}
