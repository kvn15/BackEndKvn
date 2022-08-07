using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Ksbh.Domain.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string sUser { get; set; }
        [Required]
        public string sPassword { get; set; }
    }
}
