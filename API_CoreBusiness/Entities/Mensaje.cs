using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.Entities
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }
        public string mensaje { get; set; }
        public DateTime time { get; set; }  
     }
}
