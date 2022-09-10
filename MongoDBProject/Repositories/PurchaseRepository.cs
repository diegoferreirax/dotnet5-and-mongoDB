using MongoDB.Driver;
using MongoDBProject.Repositories.Bsons;
using MongoDBProject.Repositories.Infrastructure;
using System.Collections.Generic;

namespace MongoDBProject.Repositories
{
    public class PurchaseRepository
    {
        private readonly IMongoCollection<PurchaseBson> MyShoppingCollection;

        public PurchaseRepository()
        {
            var mongoDBConfiguration = new MongoDBConfiguration();
            var mongoDatabase = mongoDBConfiguration.GetMongoDatabase();

            MyShoppingCollection = mongoDatabase.GetCollection<PurchaseBson>("Purchase");
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
            return MyShoppingCollection.Find(FilterDefinition<PurchaseBson>.Empty, null).ToList().ToArray();
        }
    }
}
