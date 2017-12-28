using EmpHRIS.Entities;
using HRIS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpHRIS.Repository
{


    public class Repository<T> : IRepository<T> where T : EntityData
    {
        private readonly EmployeeContext _context;
        private DbSet<T> dbSet;

        public Repository(EmployeeContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Add(T TEntity)
        {
            dbSet.Add(TEntity);
        }

        public void Delete(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public T Find(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> List()
        {
            return dbSet.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();  
        }

        public Task SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        public void Update(T Entity)
        {
            dbSet.Attach(Entity);
            _context.Entry(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            SaveChanges();
        }
    }
}
