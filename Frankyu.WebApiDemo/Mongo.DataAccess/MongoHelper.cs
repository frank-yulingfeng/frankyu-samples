using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mongo.DataAccess
{
    public class MongoHelper<T> where T : class
    {
        public IMongoCollection<T> collection;
        public IMongoDatabase database;       

        /// <summary>
        /// 根据文件物理路径保存
        /// </summary>
        /// <param name="fileName">路径，例如：c:\1.txt</param>
        /// <returns></returns>
        public virtual string SaveFile(string fileName)
        {
            var bucket = new GridFSBucket(database);
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                return bucket.UploadFromStream(Path.GetExtension(fileName), fs, new GridFSUploadOptions { }).ToString();
            }

        }

        /// <summary>
        /// 异步根据文件物理路径保存
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public virtual async Task<string> SaveFileAsync(string fileName)
        {
            var bucket = new GridFSBucket(database);
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var oid = await bucket.UploadFromStreamAsync(Path.GetExtension(fileName), fs, new GridFSUploadOptions { }); ;
                return oid.ToString();
            }

        }

        /// <summary>
        /// 保存文件二进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="extensionName">扩展名，例如：.pdf</param>
        /// <returns></returns>
        public virtual string SaveFile(byte[] bytes, string extensionName)
        {
            var bucket = new GridFSBucket(database);
            return bucket.UploadFromBytes(extensionName, bytes, new GridFSUploadOptions { }).ToString();
        }

        /// <summary>
        /// 异步保存文件二进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="extensionName">扩展名，例如：.pdf</param>
        /// <returns></returns>
        public virtual async Task<string> SaveFileAsync(byte[] bytes, string extensionName)
        {
            var bucket = new GridFSBucket(database);
            var oid = await bucket.UploadFromBytesAsync(extensionName, bytes, new GridFSUploadOptions { });
            return oid.ToString();
        }


        /// <summary>
        /// 通过ID获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual byte[] GetFile(string id)
        {
            var bucket = new GridFSBucket(database);
            ObjectId oid = new ObjectId(id);
            return bucket.DownloadAsBytes(oid);
        }

        /// <summary>
        /// 异步通过ID获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<byte[]> GetFileAsync(string id)
        {
            var bucket = new GridFSBucket(database);
            ObjectId oid = new ObjectId(id);
            return await bucket.DownloadAsBytesAsync(oid);
        }


        /// <summary>
        /// 通过ID获取文件并保存到指定路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newFilePath">指定路径，例如：c:\1.txt</param>
        /// <returns></returns>
        public virtual bool GetFile(string id, string newFilePath)
        {
            ObjectId oid = new ObjectId(id);
            byte[] bytes = GetFile(id);
            File.WriteAllBytes(newFilePath, bytes);
            return true;
        }

        /// <summary>
        /// 异步通过ID获取文件并保存到指定路径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newFilePath"></param>
        /// <returns></returns>
        public virtual async Task<bool> GetFileAsync(string id, string newFilePath)
        {
            ObjectId oid = new ObjectId(id);
            byte[] bytes = await GetFileAsync(id);
            File.WriteAllBytes(newFilePath, bytes);
            return true;
        }


        /// <summary>
        /// 通过ID删除文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool DeleteFile(string id)
        {
            ObjectId oid = new ObjectId(id);
            var bucket = new GridFSBucket(database);
            bucket.Delete(oid);
            return true;
        }

        /// <summary>
        /// 异步通过ID删除文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteFileAsync(string id)
        {
            ObjectId oid = new ObjectId(id);
            var bucket = new GridFSBucket(database);
            await bucket.DeleteAsync(oid);
            return true;
        }



        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="t">需要插入数据库的实体</param>
        /// <returns></returns>
        public virtual void Insert(T t)
        {
            collection.InsertOne(t);
        }

        /// <summary>
        /// 异步插入单个实体
        /// </summary>
        /// <param name="t"></param>
        public virtual async Task InsertAsync(T t)
        {
            await collection.InsertOneAsync(t);
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <typeparam name="T">需要插入数据库的实体类型</typeparam>
        /// <param name="list">需要插入数据的列表</param>
        public virtual void Insert(List<T> list)
        {
            collection.InsertMany(list);
        }

        /// <summary>
        /// 异步批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task InsertAsync(List<T> list)
        {
            await collection.InsertManyAsync(list);
        }

        /// <summary>
        /// Bson格式保存数据，数据存在即更新，不存在即插入
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public virtual bool Save(BsonDocument doc)
        {
            FilterDefinition<T> filter = new BsonDocument("_id", doc.GetValue("_id"));
            UpdateDefinition<T> update = new BsonDocument("$set", doc);
            UpdateResult result = collection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
            return result.IsAcknowledged;
        }

        /// <summary>
        ///  Bson格式保存数据，数据存在即更新，不存在即插入
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>使用result.IsAcknowledged判断成功还是失败</returns>
        public virtual async Task<bool> SaveAsync(BsonDocument doc)
        {
            FilterDefinition<T> filter = new BsonDocument("_id", doc.GetValue("_id"));
            UpdateDefinition<T> update = new BsonDocument("$set", doc);
            var result = await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 领域模型格式保存数据，数据存在即更新，不存在即插入
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool Save(T t)
        {
            var doc = t.ToBsonDocument<T>();
            FilterDefinition<T> filter = new BsonDocument("_id", doc.GetValue("_id"));
            UpdateDefinition<T> update = new BsonDocument("$set", doc);
            UpdateResult result = collection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
            return result.IsAcknowledged;
        }

        public virtual async Task<bool> SaveAsync(T t)
        {
            var doc = t.ToBsonDocument<T>();
            FilterDefinition<T> filter = new BsonDocument("_id", doc.GetValue("_id"));
            UpdateDefinition<T> update = new BsonDocument("$set", doc);
            var result = await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
            return result.IsAcknowledged;
        }


        /// <summary>
        /// 通过查询条件判断记录是否存在
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual bool IsExit(Expression<Func<T, bool>> query)
        {

            var modele = GetModelsCount(query);
            return modele == 0 ? false : true;
        }


        /// <summary>
        /// 异步通过查询条件判断记录是否存在
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        public virtual async Task<bool> IsExitAsync(Expression<Func<T, bool>> query)
        {

            var modele = await GetModelsCountAsync(query);
            return modele == 0 ? false : true;
        }

        /// <summary>
        /// 通过ID判断记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool IsExit(string id)
        {
            return collection.CountDocuments(Builders<T>.Filter.Eq("_id", id)) > 0;
        }

        /// <summary>
        /// 异步通过ID判断记录是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> IsExitAsync(string id)
        {
            var count = await collection.CountDocumentsAsync(Builders<T>.Filter.Eq("_id", id));
            return count > 0;
        }

        /// <summary>
        /// 通过条件更新指定字段
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public virtual bool Update(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            var result = collection.UpdateMany(filter, update, new UpdateOptions { IsUpsert = false });
            return result.ModifiedCount > 0;
        }

        /// <summary>
        /// 异步通过条件更新指定字段
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            var result = await collection.UpdateManyAsync(filter, update, new UpdateOptions { IsUpsert = false });
            return result.ModifiedCount > 0;
        }


        /// <summary>
        /// 通过查询条件删除记录
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual long Delete(Expression<Func<T, bool>> filter)
        {
            var result = collection.DeleteMany(filter);
            return result.DeletedCount;

        }

        /// <summary>
        /// 异步通过查询条件删除记录
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<long> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var result = await collection.DeleteManyAsync(filter);
            return result.DeletedCount;

        }


        /// <summary>
        /// 通过ID删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual long Delete(string id)
        {
            var filter = new BsonDocument("_id", id);
            return collection.DeleteOne(filter).DeletedCount;
        }

        /// <summary>
        /// 异步通过ID删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<long> DeleteAsync(string id)
        {
            var filter = new BsonDocument("_id", id);
            var result = await collection.DeleteOneAsync(filter);
            return result.DeletedCount;
        }

        /// <summary>
        /// 通过查询条件查询单个实体
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual T Signle(Expression<Func<T, bool>> filter)
        {
            return collection.Find<T>(filter).FirstOrDefault();

        }

        /// <summary>
        /// 异步通过查询条件查询单个实体
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<T> SignleAsync(Expression<Func<T, bool>> filter)
        {
            return await collection.Find<T>(filter).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 通过ID查询单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Signle(string id)
        {
            var filter = new BsonDocument("_id", id);
            return collection.Find<T>(filter).FirstOrDefault();

        }

        /// <summary>
        /// 异步通过ID查询单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> SignleAsync(string id)
        {
            var filter = new BsonDocument("_id", id);
            return await collection.Find<T>(filter).FirstOrDefaultAsync();

        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="filter">查询条件为null则查询所有</param>
        /// <returns></returns>
        public virtual long GetModelsCount(Expression<Func<T, bool>> filter)
        {
            return filter != null ? collection.CountDocuments(filter) : collection.Find<T>(_ => true).CountDocuments();
        }

        /// <summary>
        /// 异步查询记录数
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual async Task<long> GetModelsCountAsync(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
                return await collection.CountDocumentsAsync(filter);
            else
                return await collection.Find<T>(_ => true).CountDocumentsAsync();
        }



        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <param name="sortBy">排序条件为null则不排序</param>
        /// <param name="field">字段条件为null则返回所有字段</param>
        /// <returns></returns>
        public virtual List<T> FindAll(SortDefinition<T> sortBy, ProjectionDefinition<T> field)
        {
            if (sortBy != null && field != null)
                return collection.Find<T>(_ => true).Project<T>(field).Sort(sortBy).ToList();
            else if (sortBy == null && field == null)
                return collection.Find<T>(_ => true).ToList();
            else if (sortBy != null)
                return collection.Find<T>(_ => true).Project<T>(field).ToList();
            else
                return collection.Find<T>(_ => true).Sort(sortBy).ToList();
        }

        /// <summary>
        /// 异步查询所有记录
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> FindAllAsync(SortDefinition<T> sortBy, ProjectionDefinition<T> field)
        {
            if (sortBy != null && field != null)
                return await collection.Find<T>(_ => true).Project<T>(field).Sort(sortBy).ToListAsync();
            else if (sortBy == null && field == null)
                return await collection.Find<T>(_ => true).ToListAsync();
            else if (sortBy != null)
                return await collection.Find<T>(_ => true).Project<T>(field).ToListAsync();
            else
                return await collection.Find<T>(_ => true).Sort(sortBy).ToListAsync();
        }



        /// <summary>
        /// 查询单个记录并更新（先返回再更新）
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="update">更新字段</param>
        /// <returns></returns>
        public virtual T FindAndModify(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            return collection.FindOneAndUpdate<T>(filter, update, new FindOneAndUpdateOptions<T, T> { ReturnDocument = ReturnDocument.Before });
        }

        /// <summary>
        /// 异步查询单个记录并更新（先返回再更新）
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAndModifyAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            return await collection.FindOneAndUpdateAsync<T>(filter, update, new FindOneAndUpdateOptions<T, T> { ReturnDocument = ReturnDocument.Before });
        }


        /// <summary>
        /// 排序查询
        /// </summary>
        /// <param name="query">查询条件为null则查询所有</param>
        /// <param name="sort">排序条件为null则不排序</param>
        /// <param name="field">字段条件为null则返回所有字段</param>
        /// <returns></returns>
        public virtual List<T> GetModels(Expression<Func<T, bool>> filter, ProjectionDefinition<T> field, SortDefinition<T> sortBy)
        {

            if (field == null && sortBy == null)
                return collection.Find<T>(filter).ToList();
            else if (field != null && sortBy != null)
                return collection.Find<T>(filter).Project<T>(field).Sort(sortBy).ToList();
            else if (field != null)
                return collection.Find<T>(filter).Project<T>(field).ToList();
            else
                return collection.Find<T>(filter).Sort(sortBy).ToList();
        }

        /// <summary>
        /// 异步排序查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="field"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetModelsAsync(Expression<Func<T, bool>> filter, ProjectionDefinition<T> field, SortDefinition<T> sortBy)
        {

            if (field == null && sortBy == null)
                return await collection.Find<T>(filter).ToListAsync();
            else if (field != null && sortBy != null)
                return await collection.Find<T>(filter).Project<T>(field).Sort(sortBy).ToListAsync();
            else if (field != null)
                return await collection.Find<T>(filter).Project<T>(field).ToListAsync();
            else
                return await collection.Find<T>(filter).Sort(sortBy).ToListAsync();
        }



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件为null则查询所有</param>
        /// <param name="field">字段条件为null则返回所有字段</param>
        /// <param name="sortBy">排序条件为null则不排序</param>
        /// <param name="skipnum"></param>
        /// <param name="takenum"></param>
        /// <param name="pageCount">总记录数</param>
        /// <returns></returns>
        public virtual List<T> GetPageModels(Expression<Func<T, bool>> filter, ProjectionDefinition<T> field, SortDefinition<T> sortBy, int skipnum, int takenum, out long pageCount)
        {
            //pageCount = 0;
            //return collection.Find<T>(filter,);
            pageCount = GetModelsCount(filter);

            if (field == null && sortBy == null)
                return collection.Find<T>(filter).Skip(skipnum).Limit(takenum).ToList();
            else if (field != null && sortBy != null)
                return collection.Find<T>(filter).Project<T>(field).Skip(skipnum).Limit(takenum).Sort(sortBy).ToList();
            else if (field != null)
                return collection.Find<T>(filter).Project<T>(field).Skip(skipnum).Limit(takenum).ToList();
            else
                return collection.Find<T>(filter).Sort(sortBy).Skip(skipnum).Limit(takenum).ToList();
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件为null则查询所有</param>
        /// <param name="field">字段条件为null则返回所有字段</param>
        /// <param name="sortBy">排序条件为null则不排序</param>
        /// <param name="skipnum"></param>
        /// <param name="takenum"></param>
        /// <param name="skipnum"></param>
        /// <param name="takenum"></param>
        /// <returns></returns>
        public virtual List<T> GetPageModels(Expression<Func<T, bool>> filter, ProjectionDefinition<T> field, SortDefinition<T> sortBy, int skipnum, int takenum)
        {

            if (field == null && sortBy == null)
                return collection.Find<T>(filter).Skip(skipnum).Limit(takenum).ToList();
            else if (field != null && sortBy != null)
                return collection.Find<T>(filter).Project<T>(field).Skip(skipnum).Limit(takenum).Sort(sortBy).ToList();
            else if (field != null)
                return collection.Find<T>(filter).Project<T>(field).Skip(skipnum).Limit(takenum).ToList();
            else
                return collection.Find<T>(filter).Sort(sortBy).Skip(skipnum).Limit(takenum).ToList();
        }

        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="field"></param>
        /// <param name="sortBy"></param>
        /// <param name="skipnum"></param>
        /// <param name="takenum"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetPageModelsAsync(Expression<Func<T, bool>> filter, ProjectionDefinition<T> field, SortDefinition<T> sortBy, int skipnum, int takenum)
        {

            if (field == null && sortBy == null)
                return await collection.Find<T>(filter).Skip(skipnum).Limit(takenum).ToListAsync();
            else if (field != null && sortBy != null)
                return await collection.Find<T>(filter).Project<T>(field).Skip(skipnum).Limit(takenum).Sort(sortBy).ToListAsync();
            else if (field != null)
                return await collection.Find<T>(filter).Project<T>(field).Skip(skipnum).Limit(takenum).ToListAsync();
            else
                return await collection.Find<T>(filter).Sort(sortBy).Skip(skipnum).Limit(takenum).ToListAsync();
        }


        /// <summary>
        /// 分页查询-性能最好，大数据量建议使用。一般的可以选用sortdocument方式（where-limit）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件为null则查询所有</param>
        ///  <param name="field">字段条件为null则返回所有字段</param>
        /// <param name="indexName">排序字段</param>
        /// <param name="lastKeyValue">关键字</param>
        /// <param name="tabkenum"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public virtual List<T> GetPageModels(FilterDefinition<T> filter, ProjectionDefinition<T> field, string indexName, object lastKeyValue, int tabkenum, int sortType)
        {
            FilterDefinition<T> query = null;
            FilterDefinition<T> filter1 = null;
            if (sortType > 0)
                filter1 = Builders<T>.Filter.Gt(indexName, lastKeyValue);
            else
                filter1 = Builders<T>.Filter.Lt(indexName, lastKeyValue);

            if (filter == null)
                query = filter1;
            else
                query = Builders<T>.Filter.And(new FilterDefinition<T>[] { filter, filter1 });

            if (field == null)
                return collection.Find<T>(query).Sort(new BsonDocument(indexName, sortType)).Limit(tabkenum).ToList();
            else
                return collection.Find<T>(query).Project<T>(field).Sort(new BsonDocument(indexName, sortType)).Limit(tabkenum).ToList();
        }

        /// <summary>
        /// 异步分页查询-性能最好，大数据量建议使用。一般的可以选用sortdocument方式（where-limit）
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="field"></param>
        /// <param name="indexName"></param>
        /// <param name="lastKeyValue"></param>
        /// <param name="tabkenum"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetPageModelsAsync(FilterDefinition<T> filter, ProjectionDefinition<T> field, string indexName, object lastKeyValue, int tabkenum, int sortType)
        {
            FilterDefinition<T> query = null;
            FilterDefinition<T> filter1 = null;
            if (sortType > 0)
                filter1 = Builders<T>.Filter.Gt(indexName, lastKeyValue);
            else
                filter1 = Builders<T>.Filter.Lt(indexName, lastKeyValue);

            if (filter == null)
                query = filter1;
            else
                query = Builders<T>.Filter.And(new FilterDefinition<T>[] { filter, filter1 });

            if (field == null)
                return await collection.Find<T>(query).Sort(new BsonDocument(indexName, sortType)).Limit(tabkenum).ToListAsync();
            else
                return await collection.Find<T>(query).Project<T>(field).Sort(new BsonDocument(indexName, sortType)).Limit(tabkenum).ToListAsync();
        }

    }
}
