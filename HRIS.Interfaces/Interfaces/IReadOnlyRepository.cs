using System;
using System.Collections.Generic;
using System.Text;

namespace HRIS.Common.Interfaces
{
    public interface IReadOnlyRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        AggregateType FindBy(IdType id);
        IEnumerable<AggregateType> FindAll();
    }
}
