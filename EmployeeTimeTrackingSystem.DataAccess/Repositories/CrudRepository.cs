namespace EmployeeTimeTrackingSystem.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using Common.Contracts.Repository;
    public abstract class CrudRepository<T> : IDisposable, IRepository<T> where T : class
    {
        private bool isDisposed = false;
        protected DbContext _context;
        public CrudRepository(DbContext context)
        {
            _context = context;
        }
        ~CrudRepository()
        {
            Dispose(false);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null ? orderBy(query) : query;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable().ToList();
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void InsertList(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            var sql = GetById(entity);
            _context.Set<T>().Remove(sql);
            SaveChanges();
        }
        public void DeleteList(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            _context.SaveChanges();
        }

        public virtual T GetById(T entity, params string[] includes)
        {
            object originalItem = null;
            var objectContext = ((IObjectContextAdapter)this._context).ObjectContext;
            System.Data.Entity.Core.EntityKey key = objectContext.CreateEntityKey(objectContext.CreateObjectSet<T>().EntitySet.Name, entity);
            if (objectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (T)originalItem;
            }
            else
            {
                return default(T);
            }
            //return _context.Set<T>().AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
