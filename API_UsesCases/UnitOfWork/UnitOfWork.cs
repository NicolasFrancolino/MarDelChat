using API_CoreBusiness;
using API_DataCore.PluginInterfaces;
using API_DataCore.Repository;
using API_LoggerCore.CustomLogger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_UsesCases.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        protected readonly ILogger _logger;

        public   CustomLogger loggerCustom { get; private set; }      
        public IUsuarioRepository UsuarioRepo { get; private set; }
        public IChatRepository ChatRepo { get; private set; }
        public IChatUsuarioRepository ChatUsuarioRepo { get; private set; }
        public IContactoRepository ContactoRepo { get; private set; }
        public IMensajeRepository MensajeRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");
            loggerCustom = new CustomLogger(_logger);
            
            UsuarioRepo = new UsuarioRepository(context, loggerCustom);
            ChatRepo = new ChatRepository(context, loggerCustom);
            ContactoRepo = new ContactoRepository(context, loggerCustom);
            ChatUsuarioRepo = new ChatUsuarioRepository(context, loggerCustom);
            MensajeRepo = new MensajeRepository(context, loggerCustom);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
