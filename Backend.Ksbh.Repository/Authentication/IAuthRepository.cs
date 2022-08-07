using Backend.Ksbh.Domain.Models.Request;
using Backend.Ksbh.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.Repository.Authentication
{
    public interface IAuthRepository
    {
        Task<AuthResponse> Auth(AuthRequest model);
    }
}
