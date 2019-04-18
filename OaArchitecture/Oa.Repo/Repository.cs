namespace Oa.Repo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using Oa.Data;

    public class Repository<T>:IRepository<T> where T: BaseEntity 
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;
        //string _errorMessage = string.Empty;

        public Repository(DataContext context )
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return  _entities.ToList();
         
        }

        public T Get(Guid id)
        {
            return  _entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity); 
        }

        public bool SaveChanges()
        {
           return  _context.SaveChanges()>0;
        }
    }
}