using Backend.Ksbh.Domain.Authentication;
using Backend.Ksbh.Repository.Authentication;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.Repository.SqlServer.Authentication
{
    public class MenuAuthRepository : IMenuAuthRepository
    {
        protected readonly IConfiguration _configuration;

        public MenuAuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<IList<MenuAuth>> Get_MenusPadres(int tipoUser)
        {
            IEnumerable<MenuAuth> lista = new List<MenuAuth>();

            string store = String.Format("{0};{1}", "Sistema.sp_Authenticado", (byte)1);

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbSistema")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@tipoUser", tipoUser);

                lista = await connection.QueryAsync<MenuAuth>(store, parameter, commandType: CommandType.StoredProcedure);
            }

            return lista.ToList();
        }

        public async Task<IList<MenuAuthHijo>> Get_MenusHijos(int tipoUser, int padre)
        {
            IEnumerable<MenuAuthHijo> lista = new List<MenuAuthHijo>();

            string store = String.Format("{0};{1}", "Sistema.sp_Authenticado", (byte)2);

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("dbSistema")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@tipoUser", tipoUser);
                parameter.Add("@padre", padre);

                lista = await connection.QueryAsync<MenuAuthHijo>(store, parameter, commandType: CommandType.StoredProcedure);
            }

            return lista.ToList();
        }

    }
}
