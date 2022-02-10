using MongoDB.Driver;

namespace MongoDBProject.Repositories.Infrastructure
{
    public class MongoDBConfiguration
    {
        private string ConnectionString = "mongodb://localhost:27017";
        private readonly MongoClient Connection;
        private readonly IMongoDatabase MongoDatabase;

        public MongoDBConfiguration()
        {
            Connection = GetConnection();
            MongoDatabase = Connection.GetDatabase("MyShopping");
        }

        public MongoClient GetConnection()
        {
            var connection = new MongoClient(ConnectionString);
            return connection;
        }

        public IMongoDatabase GetMongoDatabase()
        {
            return MongoDatabase;
        }
    }
}
