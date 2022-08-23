using API_CoreBusiness;
using API_GenericCore.GenericRepository.Interfaces;
using API_LoggerCore.CustomLogger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_GenericCore.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        public readonly ApplicationDbContext context;
        private readonly CustomLogger logger;

        public GenericRepository(ApplicationDbContext context, CustomLogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void Insert(T entity)
        {
            
            logger.Info("INSERT METHOD => OK");
            context.Set<T>().Add(entity);
        }
        public void Update(T entity, int? id)
        {
            var type = GetById(id);
            if (type == null)
            {
                logger.Error("UPDATE EXCEPTION CATCH,OBJECT NO FOUND ");
                throw new Exception("OBJECT NOT FOUND");

            }
            logger.Info("UPLOADING METHOD => OK ");
            context.Set<T>().Update(entity);
        }
        public void Delete(int? id)
        {
            logger.Info("DELETING METHOD => OK ");
            var entity = GetById(id);
            if(entity == null){
                
                logger.Error("REMOVE EXCEPTION CATCH,OBJECT NO FOUND ");
                throw new Exception("OBJECT NOT FOUND");
            }
                           
                logger.Info("REMOVE => OK ");
                context.Set<T>().Remove(entity);  
        }
        public T GetById(int? id)
        {
            
            logger.Info("GET BY ID METHOD => OK ");
            var type = context.Set<T>().Find(id);
            return type;
        }
        public virtual IEnumerable<T> GetAll()
        {
            var type = context.Set<T>().ToList();
            if (type == null)
            {
                logger.Error("GETALL METHOD ID => NULL");
                return type;
            }

            logger.Info("GETALL METHOD ID => OK ");
             return type;
        } 
    }
}
