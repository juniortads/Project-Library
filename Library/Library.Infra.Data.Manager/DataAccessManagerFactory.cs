using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Infra.Data.Ef;
using Library.Infra.Data.MongoDb;

namespace Library.Infra.Data.Manager
{
    public sealed class DataAccessManagerFactory
    {
        private static TypeDataAccess _typeDataAccess;

        public static void Init(TypeDataAccess type)
        {
            _typeDataAccess = type;
        }

        public static TypeDataAccess GetTypeDataAccess
        {
            get
            {
                return _typeDataAccess;
            }
        }

        public static IRepositoryBase<TEntity> CreateRepository<TEntity>() where TEntity : Identifier
        {
            switch (_typeDataAccess)
            {
                case TypeDataAccess.EntityFramework:
                    return new RepositoryEf<TEntity>();
                case TypeDataAccess.MongoDb:
                    return new RepositoryMongoDb<TEntity>();
                default:
                    throw new ArgumentException("Type repository not support!");
            }
        }
    }

    public enum TypeDataAccess
    {
        EntityFramework = 0,
        MongoDb = 1
    }
}
