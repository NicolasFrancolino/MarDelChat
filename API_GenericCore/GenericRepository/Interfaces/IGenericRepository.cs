using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_GenericCore.GenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity, int? id);
        void Delete(int? id);
        T GetById(int? id);


    }
}
