using Backend.Ksbh.Common;
using Backend.Ksbh.Common.Encrypt;
using Backend.Ksbh.Domain.Authentication;
using Backend.Ksbh.Domain.Models.Request;
using Backend.Ksbh.Domain.Models.Response;
using Backend.Ksbh.Repository.Authentication;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.Repository.SqlServer.Authentication
{
    public class AuthRepository: IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        public AuthRepository(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthResponse> Auth(AuthRequest model)
        {
            AuthResponse response = new AuthResponse();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbSistema")))
            {
                String sPassword = EncryptSha256.GetSHA256(model.sPassword);

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@sUser", model.sUser);
                parameters.Add("@sPass", sPassword);

                UserAuth usuario = await connection.QueryFirstOrDefaultAsync<UserAuth>("Sistema.sp_Authentication", parameters, commandType: CommandType.StoredProcedure);

                if (usuario == null) return null;

                response.sUser = usuario.sUser;
                response.Token = GetToken(usuario);
            }

            return response;
        }

        private string GetToken(UserAuth usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]{
                        new Claim(ClaimTypes.PrimarySid, usuario.nIdUsuario.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, usuario.nIdPersonal.ToString()),
                        new Claim(ClaimTypes.GivenName, usuario.sUser.ToString()),
                        new Claim(ClaimTypes.Name, usuario.sNameUser.ToString()),
                        new Claim(ClaimTypes.Role, usuario.nTipoUser.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
