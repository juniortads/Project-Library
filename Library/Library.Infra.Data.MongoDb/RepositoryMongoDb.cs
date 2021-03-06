﻿using System;
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
    public class RepositoryMongoDb<TEntity> : IRepositoryBase<TEntity> where TEntity : Identifier
    {
        private static IMongoDatabase _Database;
        private static IMongoCollection<TEntity> _Collection;

        public RepositoryMongoDb()
            : this(GetDatabase())
        {

        }

        private RepositoryMongoDb(IMongoDatabase database)
        {
            _Database = database;
            _Collection = GetCollection();
        }

        private static IMongoDatabase GetDatabase()
        {
            var s = GetConnectionString();
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

        public async void Add(TEntity entity)
        {
            await _Collection.InsertOneAsync(entity);
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
