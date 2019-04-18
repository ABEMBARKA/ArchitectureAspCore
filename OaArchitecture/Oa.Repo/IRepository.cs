namespace Oa.Repo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oa.Data;

    public interface IRepository<T>where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        bool SaveChanges();
    }
}