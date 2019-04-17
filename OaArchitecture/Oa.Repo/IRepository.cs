namespace Oa.Repo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oa.Data;

    public interface IRepository<T>where T: BaseEntity
    {
        Task <IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}