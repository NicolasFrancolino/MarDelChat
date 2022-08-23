using API_CoreBusiness.Entities;
using API_GenericCore.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DataCore.PluginInterfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario GetByEmail(string email);
        bool ExisteUsuario(string email);
        bool ExisteNombre(string nombre);
    }
}
