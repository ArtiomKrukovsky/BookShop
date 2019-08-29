using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.EF;
using WebProject.Domain.Interfaces;

namespace WebProject.Domain.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        EFContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(EFContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity Entity)
        {
            if (Entity!=null)
            {
                _dbSet.Add(Entity);
            }
        }

        public TEntity Get(int id)
        {
            if (id != 0)
            {
                return _dbSet.Find(id);
            }
            else return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Remove(int id)
        {
            if (id != 0)
            {
                 var entity=_dbSet.Find(id);
                if (entity!=null)
                {
                    _dbSet.Remove(entity);
                }
            }
        }

        public void Update(TEntity Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
