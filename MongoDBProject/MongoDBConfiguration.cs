using MongoDB.Driver;

namespace MongoDBProject
{
    public static class MongoDBConfiguration
    {
        public static string ConnectionString = "";

        public static MongoClient GetConnection()
        {
            var connection = new MongoClient(ConnectionString);
            return connection;
        }
    }
}
