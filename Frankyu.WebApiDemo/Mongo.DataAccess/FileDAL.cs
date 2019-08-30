using Mongo.DataAccess.DataProvider;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;

namespace Mongo.DataAccess
{
    public class FileDAL<T> where T : class
    {
        private IMongoDatabase _database;

        public FileDAL(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);            
        }

        /// <summary>
        /// 根据文件物理路径保存
        /// </summary>
        /// <param name="fileName">路径，例如：c:\1.txt</param>
        /// <returns></returns>
        public virtual string SaveFile(string fileName)
        {
            var bucket = new GridFSBucket(_database);
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                return bucket.UploadFromStream(Path.GetExtension(fileName), fs, new GridFSUploadOptions { }).ToString();
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
            var bucket = new GridFSBucket(_database);
            return bucket.UploadFromBytes(extensionName, bytes, new GridFSUploadOptions { }).ToString();
        }

        /// <summary>
        /// 通过ID获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual byte[] GetFile(string id)
        {
            var bucket = new GridFSBucket(_database);
            ObjectId oid = new ObjectId(id);
            return bucket.DownloadAsBytes(oid);
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
        /// 通过ID删除文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool DeleteFile(string id)
        {
            ObjectId oid = new ObjectId(id);
            var bucket = new GridFSBucket(_database);
            bucket.Delete(oid);
            return true;
        }
    }
}
