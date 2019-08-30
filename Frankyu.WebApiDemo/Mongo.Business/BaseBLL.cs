using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Mongo.DataAccess;
using Mongo.Models;

namespace Mongo.Business
{
    public class BaseBLL<T> where T : BaseModel
    {
        protected CommonDAL<T> _dal;

        public BaseBLL(CommonDAL<T> commonDAL)
        {
            _dal = commonDAL;
        }

        public void Insert(T t)
        {
            _dal.Insert(t);
        }

        public void InsertMany(List<T> list)
        {
            _dal.InsertMany(list);
        }

        public T FindOne(string _id)
        {
            return _dal.FindOne(f => f._id == _id);
        }

        public T FindOne(Expression<Func<T, bool>> filter)
        {
            return _dal.FindOne(filter);
        }

        public List<T> FindMany(Expression<Func<T, bool>> filter)
        {
            return _dal.FindMany(filter);
        }

        public List<T> FindAll()
        {
            return _dal.FindAll();
        }

        //public void DeleteOne(Expression<Func<T, bool>> filter)
        //{
        //    _dal.DeleteOne(filter);
        //}
    }
}
