using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Mongo.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
