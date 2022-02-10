using MongoDB.Driver;
using System.Collections.Generic;

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

        public void InsertPurchases()
        {
            var listPurchase = new List<PurchaseDTO>();
            for (int i = 0; i < 10000; i++)
            {
                var purchase = new PurchaseDTO
                {
                    Placename = "nome " + i,
                    Create = "create " + i,
                    PurchaseCategoryNumber = 1
                };

                listPurchase.Add(purchase);
            }

            MyShoppingCollection.InsertMany(listPurchase.ToArray());
        }

        public PurchaseDTO[] FindPurchases()
        {
            var purchases = MyShoppingCollection.Find(FilterDefinition<PurchaseDTO>.Empty, null).ToList();
            return purchases.ToArray();
        }
    }
}
