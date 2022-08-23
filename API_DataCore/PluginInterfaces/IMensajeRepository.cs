using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_CoreBusiness.Entities;
using API_GenericCore.GenericRepository.Interfaces;

namespace API_DataCore.PluginInterfaces
{
    public interface IMensajeRepository : IGenericRepository<Mensaje>
    {
    }
}
