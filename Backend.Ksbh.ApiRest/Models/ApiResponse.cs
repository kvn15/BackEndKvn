using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Ksbh.ApiRest.Models
{
    public class ApiResponse
    {
        public bool state { get; set; }
        public object Data { get; set; }
        public string Mensage { get; set; }
    }

    public class WebApiResponse<T>
    {
        public bool Success { get; set; }
        public Response<T> Response { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Response<T>
    {
        public List<T> Data { get; set; }
        public List<T> Detail { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class CustomResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<Error> Errors { get; set; }
    }
}
