using Backend.Ksbh.ApiRest.Models;
using Backend.Ksbh.BusinessLogic.Authentication.Interfaces;
using Backend.Ksbh.Domain.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Ksbh.ApiRest.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MenuAuthController : ControllerBase
    {
        private readonly IMenuAuthBL _service;

        public MenuAuthController(IMenuAuthBL service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<WebApiResponse<MenuAuth>>> get_menuAuth(int tipoUser)
        {
            WebApiResponse<MenuAuth> response = new WebApiResponse<MenuAuth>();
            try
            {
                if (String.IsNullOrEmpty(tipoUser.ToString()))
                {
                    response.Success = false;
                    response.Errors = new List<Error>();
                    response.Errors.Add(new Error()
                    {
                        Code = StatusCodes.Status404NotFound,
                        Message = $"No se esta enviando el Tipo de Usuario"
                    });

                    return StatusCode(404, response);
                }

                var lista = await _service.Get_MenusPadres(tipoUser);

                List<MenuAuth> data = (List<MenuAuth>)lista;

                foreach (var item in data)
                {
                    var listaHijo = await _service.Get_MenusHijos(tipoUser, item.nIdMenu);

                    List<MenuAuthHijo> list = (List<MenuAuthHijo>)listaHijo;

                    item.lHijoMenu = list;
                }

                response.Success = true;
                response.Response = new Response<MenuAuth>();
                response.Response.Data = new List<MenuAuth>();
                response.Response.Data = data;

                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors = new List<Error>();
                response.Errors.Add(new Error()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                });

                return StatusCode(500, response);
            }
        }

    }
}
