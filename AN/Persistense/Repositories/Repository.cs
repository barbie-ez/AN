using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AN.Core.Repositories;
using AN.Data;
using Microsoft.EntityFrameworkCore;

namespace AN.Persistense.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        protected readonly DbSet<TEntity> _context;
        protected readonly DbContext Context;

        public Repository(ANDbContext context)
        {
            _context = context.Set<TEntity>();

            Context = context;
        }

        public TEntity Get(int id)
        {
            return _context.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.SingleOrDefault(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }
    }
}
