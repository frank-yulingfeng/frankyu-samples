using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mongo.Models;

namespace Mongo.DataAccess
{
    public interface ICommonDAL<T> where T : BaseModel
    {
        void Insert(T t);

        void InsertMany(List<T> list);

        T FindOne(string _id);

        T FindOne(Expression<Func<T, bool>> filter);

        List<T> FindMany(Expression<Func<T, bool>> filter);

        List<T> FindAll();

        void DeleteOne(Expression<Func<T, bool>> filter);
    }
}
