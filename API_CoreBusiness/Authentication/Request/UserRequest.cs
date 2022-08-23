using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.Authentication.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Este valor es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string Password { get; set; }
    }
}
