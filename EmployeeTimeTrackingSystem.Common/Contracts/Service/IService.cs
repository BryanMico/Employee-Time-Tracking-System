namespace EmployeeTimeTrackingSystem.Common.Contracts.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public interface IService<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void InsertList(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteList(IEnumerable<T> entity);
        T GetById(T entity);
    }
}
