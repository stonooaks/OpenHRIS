using MediatR;
using System;
using System.Collections.Generic;

namespace empHRIS.Domain.SeedWork
{
    public abstract class EntityData
    {
        int? _requestHashCode;
                
        public int Id { get; set; }
        private List<INotification> _domainEvents;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public List<INotification> DomainEvents => _domainEvents;

        #region Public Methods
        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        
        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }
      
        #endregion
        
        #region override/static methods
        public override bool Equals(object obj)
        {
            return obj != null
                 && obj is EntityData
                 && this == (EntityData)obj;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestHashCode.HasValue)
                    _requestHashCode = this.Id.GetHashCode() ^ 31;
                return _requestHashCode.Value;
            }
            else
            return base.GetHashCode();
        }

        public static bool operator ==(EntityData left, EntityData right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(EntityData left, EntityData right)
        {
            return (!(left == right));
        }
        #endregion
    }
}
