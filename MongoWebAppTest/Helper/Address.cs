using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWebAppTest.Helper
{
    public class Address
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string[] Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}