using Backend.Ksbh.BusinessLogic.Authentication.Interfaces;
using Backend.Ksbh.Domain.Models.Request;
using Backend.Ksbh.Domain.Models.Response;
using Backend.Ksbh.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.BusinessLogic.Authentication
{
    public class AuthBL: IAuthBL
    {
        protected readonly IAuthRepository _repository;

        public AuthBL(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthResponse> Auth(AuthRequest model)
        {
            try
            {
                return await _repository.Auth(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
