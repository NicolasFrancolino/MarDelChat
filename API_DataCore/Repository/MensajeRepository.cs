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

namespace API_DataCore.Repository
{
    public class MensajeRepository : GenericRepository<Mensaje>, IMensajeRepository
    {
        public MensajeRepository(ApplicationDbContext context, CustomLogger logger) : base(context, logger)
        {
        }
    }
}
