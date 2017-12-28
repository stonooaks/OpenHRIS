using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        T Find(object id);
        void Add(T TEntity);
        void Update(T Entity);
        void Delete(T Entity);
        void SaveChanges();
        Task SaveChangesAsync();

    }


}
