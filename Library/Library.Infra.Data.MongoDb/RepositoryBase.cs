using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Infra.Data.MongoDb
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Identifier
    {
        private IMongoDatabase _Database;
        private IMongoCollection<TEntity> _Collection;

        public RepositoryBase()
            : this(GetDatabase())
        {

        }

        private RepositoryBase(IMongoDatabase database)
        {
            _Database = database;
            _Collection = GetCollection();
        }

        private static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            return client.GetDatabase(GetDatabaseName());
        }

        private static string GetDatabaseName()
        {
            return ConfigurationManager.AppSettings["MongoDbDatabaseName"];
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["MongoDbConnectionString"].Replace("{DB_NAME}", GetDatabaseName());
        }

        private IMongoCollection<TEntity> GetCollection()
        {
            return _Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity entity)
        {
            _Collection.InsertOneAsync(entity);
        }

        public TEntity GetById(int id)
        {
            return _Collection.Find<TEntity>(o => o.Id.Equals(id)).SingleAsync().Result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var filter = new BsonDocument();
            return _Collection.Find<TEntity>(filter).ToListAsync().Result;
        }

        public void Update(TEntity obj)
        {
        }

        public void Remove(TEntity obj)
        {
            _Collection.DeleteOneAsync<TEntity>(o => o.Id.Equals(obj.Id));
        }

        public List<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            var result = this.GetAll();
            return result.Where(predicate.Compile()).ToList();
        }

        public void Dispose()
        {
        }
    }
}
