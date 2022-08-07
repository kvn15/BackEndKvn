using Backend.Ksbh.ApiRest.Models;
using Backend.Ksbh.BusinessLogic.Authentication.Interfaces;
using Backend.Ksbh.Domain.Models.Request;
using Backend.Ksbh.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Ksbh.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _service;

        public AuthController(IAuthBL service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Autentificar([FromBody] AuthRequest model)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var userresponseS = await _service.Auth(model);

                if (userresponseS == null)
                {
                    response.state = false;
                    response.Mensage = "Usuario y contraseña incorrecta";
                    return StatusCode(404,response);
                }

                response.state = true;
                response.Data = userresponseS;

                return StatusCode(200,response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
