using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Se requiere un usuario")]
        public string? Nombre { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public ICollection<Contactos> contactos { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}