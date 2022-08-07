using Backend.Ksbh.BusinessLogic.Authentication.Interfaces;
using Backend.Ksbh.Domain.Authentication;
using Backend.Ksbh.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.BusinessLogic.Authentication
{
    public class MenuAuthBL : IMenuAuthBL
    {
        private readonly IMenuAuthRepository _repository;
        public MenuAuthBL(IMenuAuthRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<MenuAuth>> Get_MenusHijos(int tipoUser, int padre)
        {
            return await _repository.Get_MenusHijos(tipoUser, padre);
        }

        public async Task<IList<MenuAuth>> Get_MenusPadres(int tipoUser)
        {
            return await _repository.Get_MenusPadres(tipoUser);
        }
    }
}
