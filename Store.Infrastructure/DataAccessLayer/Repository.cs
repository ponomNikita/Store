using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Contracts;
using Store.Domain.Models;

namespace Store.Infrastructure.DataAccessLayer
{
    public class Repository<T> : IRepository<T>
        where T : TEntity
    {
        readonly DataBaseContext _db;
        readonly DbSet<T> _dbSet;

        public Repository(DataBaseContext db)
        {
            this._db = db;
            this._dbSet = this._db.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public T Create(T item)
        {
            return _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.FirstOrDefault(o => o.EntityId == id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public T Get(int id)
        {
            return _dbSet.FirstOrDefault(o => o.EntityId == id);
        }

        public virtual IQueryable<T> Get()
        {
            return _dbSet;
        }

        public IQueryable<T> Include(Expression<Func<T, object>> predicate)
        {
            return _dbSet.Include(predicate);
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
