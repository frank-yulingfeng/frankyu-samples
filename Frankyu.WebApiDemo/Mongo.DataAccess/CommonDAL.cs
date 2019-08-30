using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mongo.DataAccess.DataProvider;
using Mongo.Models;
using MongoDB.Driver;

namespace Mongo.DataAccess
{
    public class CommonDAL<T> where T : BaseModel
    {
        private IMongoCollection<T> _collection;

        public IMongoCollection<T> Collection
        {
            get { return _collection; }
        }

        public CommonDAL(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(typeof(T).Name);

            if (_collection == null)
                throw new Exception(typeof(T).Name + " collection is null");
        }

        public virtual void Insert(T t)
        {
            _collection.InsertOne(t);
        }

        public virtual void InsertMany(List<T> list)
        {
            _collection.InsertMany(list);
        }

        public virtual T FindOne(string _id)
        {
            return _collection.Find(f => f._id == _id).FirstOrDefault();
        }

        public virtual T FindOne(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }

        public virtual List<T> FindMany(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).ToList();
        }

        public virtual List<T> FindAll()
        {
            return _collection.Find(d => true).ToList();
        }

        public virtual void DeleteOne(Expression<Func<T, bool>> filter)
        {
            _collection.DeleteOne(filter);
        }
    }
}
