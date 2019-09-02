using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
