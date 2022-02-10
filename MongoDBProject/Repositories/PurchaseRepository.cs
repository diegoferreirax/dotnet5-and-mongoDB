using MongoDB.Driver;
using MongoDBProject.Bsons;
using System.Collections.Generic;

namespace MongoDBProject.Repositories
{
    public class PurchaseRepository
    {
        private readonly MongoClient Connection;
        private readonly IMongoDatabase MongoDatabase;
        private readonly IMongoCollection<PurchaseBson> MyShoppingCollection;

        public PurchaseRepository()
        {
            Connection = MongoDBConfiguration.GetConnection();
            MongoDatabase = Connection.GetDatabase("MyShopping");
            MyShoppingCollection = MongoDatabase.GetCollection<PurchaseBson>("MyShopping");
        }

        public void DeleteAllPurchases()
        {
            MyShoppingCollection.DeleteMany(FilterDefinition<PurchaseBson>.Empty, null);
        }

        public void InsertPurchases()
        {
            var listPurchase = new List<PurchaseBson>();
            for (int i = 0; i < 10000; i++)
            {
                var purchase = new PurchaseBson
                {
                    Placename = "nome " + i,
                    Create = "create " + i,
                    PurchaseCategoryNumber = 1
                };

                listPurchase.Add(purchase);
            }

            MyShoppingCollection.InsertMany(listPurchase.ToArray());
        }

        public PurchaseBson[] FindPurchases()
        {
            var purchases = MyShoppingCollection.Find(FilterDefinition<PurchaseBson>.Empty, null).ToList();
            return purchases.ToArray();
        }
    }
}
