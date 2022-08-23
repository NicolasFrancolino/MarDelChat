using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_CoreBusiness;
using API_CoreBusiness.Entities;
using API_DataCore.PluginInterfaces;
using API_GenericCore.GenericRepository;
using API_GenericCore.GenericRepository.Interfaces;
using API_LoggerCore.CustomLogger;
using Microsoft.EntityFrameworkCore;

namespace API_DataCore.Repository
{
    public class ContactoRepository : GenericRepository<Contactos>, IContactoRepository
    {
        public ContactoRepository(ApplicationDbContext context, CustomLogger logger) : base(context, logger)
        {

        }

    }
}
