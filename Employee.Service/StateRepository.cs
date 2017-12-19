using EmpHRIS.Entities;
using EmpHRIS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpHRIS.Repository
{
    public class StateRepository : IStateRepository
    {

        private readonly EmployeeContext _context;
        public StateRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Add(State TEntity)
        {
            _context.Add(TEntity);
        }

        public void Delete(State Entity)
        {
            _context.Remove(Entity);
        }

        public bool Exists(object id)
        {
            return _context.State.Any(s => s.Id == (int)id);
        }

        public State Find(object id)
        {
            return _context.State.Where(s => s.Id == (int)id).SingleOrDefault();
        }

        public State FindByAbbr(string Abbr)
        {
            return _context.State.Where(s => s.Abbr == Abbr).SingleOrDefault();
        }

        public IEnumerable<State> List()
        {
            return _context.State.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(State Entity)
        {
            _context.Entry(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
