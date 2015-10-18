using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Infra.Data.Ef
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Identifier
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<TEntity> SearchFor(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
