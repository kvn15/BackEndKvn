using Backend.Ksbh.Domain.Models.Request;
using Backend.Ksbh.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.BusinessLogic.Authentication.Interfaces
{
    public interface IAuthBL
    {
        Task<AuthResponse> Auth(AuthRequest model);
    }
}
