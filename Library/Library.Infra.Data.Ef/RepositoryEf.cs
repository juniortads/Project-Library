using System;
using System.Collections.Generic;
using System.Linq;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Infra.Data.Ef.Context;
using System.Data.Entity;

namespace Library.Infra.Data.Ef
{
    public class RepositoryEf<TEntity> : IRepositoryBase<TEntity> where TEntity : Identifier
    {
        protected readonly LibraryContext Context;

        public RepositoryEf():this(new LibraryContext())
        {

        }
        private RepositoryEf(LibraryContext context)
        {
            Context = context;
            ConfigureContext();
        }
        private void ConfigureContext()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            if (Context.Entry(obj).State == EntityState.Detached)
                Context.Set<TEntity>().Attach(obj);
            Context.Set<TEntity>().Remove(obj);
        }

        public List<TEntity> SearchFor(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            return query.ToList();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
