using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Common.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {

        IUnitOfWork UnitOfWork { get; }
       
    }


}
