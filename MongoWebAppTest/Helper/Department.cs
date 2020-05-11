using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWebAppTest.Helper
{
    public class Department
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}