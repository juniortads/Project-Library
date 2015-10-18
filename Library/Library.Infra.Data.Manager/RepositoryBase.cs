using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Infra.Data.Manager
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Identifier
    {
        private IRepositoryBase<TEntity> _repositoryManager;

        public RepositoryBase()
            : this(DataAccessManagerFactory.CreateRepository<TEntity>())
        {

        }

        private RepositoryBase(IRepositoryBase<TEntity> repository)
        {
            _repositoryManager = repository;
        }

        public void Add(TEntity entity)
        {
            _repositoryManager.Add(entity);
        }

        public TEntity GetById(int id)
        {
            return _repositoryManager.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryManager.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repositoryManager.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repositoryManager.Remove(obj);
        }

        public List<TEntity> SearchFor(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _repositoryManager.SearchFor(predicate);
        }

        public void Dispose()
        {
            _repositoryManager.Dispose();
        }
    }
}
