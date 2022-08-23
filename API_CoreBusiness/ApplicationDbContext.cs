using API_CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CoreBusiness
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chat> Chat {get; set;}
        public DbSet<ChatUsuario> ChatUsuario {get; set;}
        public DbSet<Contactos> Contactos { get; set;} 
        public DbSet<Mensaje> Mensaje {get; set;} 
         
    }
}
