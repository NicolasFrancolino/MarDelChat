using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_CoreBusiness.Authentication.Response;

namespace API_CoreBusiness.Entities
{
    public class Contactos
    {
        [Key]
        public int id { get; set; }
        public UserResponse Usuario { get; set; }
    }
}