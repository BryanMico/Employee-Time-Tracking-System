namespace InvenTree.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Common.Contracts.Service;
    using Common.Contracts.Repository;

    public class BaseService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            return _repository.Get(filter, orderBy, includeProperties);
        }
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual void Insert(T entity)
        {
            _repository.Insert(entity);
        }
        public void InsertList(IEnumerable<T> entity)
        {
            _repository.InsertList(entity);
        }
        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }
        public void DeleteList(IEnumerable<T> entity)
        {
            _repository.DeleteList(entity);
        }
        public T GetById(T entity)
        {
            return _repository.GetById(entity);
        }
    }
}
