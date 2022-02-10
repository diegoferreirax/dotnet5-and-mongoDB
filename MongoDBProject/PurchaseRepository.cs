using MongoDB.Driver;

namespace MongoDBProject
{
    public class PurchaseRepository
    {
        private readonly MongoClient Connection;
        private readonly IMongoDatabase MongoDatabase;
        private readonly IMongoCollection<PurchaseDTO> MyShoppingCollection;

        public PurchaseRepository()
        {
            Connection = MongoDBConfiguration.GetConnection();
            MongoDatabase = Connection.GetDatabase("MyShopping");
            MyShoppingCollection = MongoDatabase.GetCollection<PurchaseDTO>("MyShopping");
        }

        public void DeleteAllPurchases()
        {
            MyShoppingCollection.DeleteMany(FilterDefinition<PurchaseDTO>.Empty, null);
        }

        public void InsertPurchases(PurchaseDTO[] purchaseDTO)
        {
            MyShoppingCollection.InsertMany(purchaseDTO);
        }

        public PurchaseDTO[] FindPurchases()
        {
            var purchases = MyShoppingCollection.Find(FilterDefinition<PurchaseDTO>.Empty, null).ToList();
            return purchases.ToArray();
        }
    }
}
