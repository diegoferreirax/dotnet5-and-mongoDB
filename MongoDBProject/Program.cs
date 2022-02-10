using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var purchaseRepository = new PurchaseRepository();

            /*
            purchaseRepository.DeleteAllPurchases();
            */

            InsertPuchases(purchaseRepository);

            /*
            var purchases = purchaseRepository.FindPurchases();
            foreach (var purchase in purchases)
            {
                Console.WriteLine(purchase.Placename);
            }
            */

            Console.ReadLine();
        }

        public static void InsertPuchases(PurchaseRepository purchaseRepository)
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

            purchaseRepository.InsertPurchases(listPurchase.ToArray());
        }
    }
}
