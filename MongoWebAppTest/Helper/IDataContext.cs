using System.Collections.Generic;
using MongoDB.Driver;
using MongoWebAppTest.Models;

namespace MongoWebAppTest.Helper
{
    public interface IDataContext<c, vm>
    {
        IMongoCollection<c> Employees { get; }
        void Add(vm vm);
        IEnumerable<vm> Get(string id = null);
        void Update(vm vm);

    }
}