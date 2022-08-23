using API_DataCore.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_UsesCases.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IChatRepository ChatRepo { get; }
        IChatUsuarioRepository ChatUsuarioRepo { get; }
        IContactoRepository ContactoRepo { get; }
        IMensajeRepository MensajeRepo { get; }
        IUsuarioRepository UsuarioRepo { get; }
        void Save();
    }
}
