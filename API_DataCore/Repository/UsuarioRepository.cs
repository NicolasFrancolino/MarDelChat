using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_CoreBusiness;
using API_CoreBusiness.Entities;
using API_DataCore.PluginInterfaces;
using API_GenericCore.GenericRepository;
using API_LoggerCore.CustomLogger;
using Microsoft.Extensions.Logging;

namespace API_DataCore.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context, CustomLogger logger) : base(context, logger)
        {
        }

        public Usuario GetByEmail(string email)
        {
            return context.Usuario.FirstOrDefault(a => a.Email == email);
        }
        public bool ExisteUsuario(string email)
        {
            return context.Usuario.Any(a => a.Email == email);
        }

        public bool ExisteNombre(string nombre)
        {
            return context.Usuario.Any(a => a.Nombre == nombre);
        }
    }
}
