using MongoDBProject.Core.Enuns;
using MongoDBProject.Repositories;
using System;

namespace MongoDBProject.Core
{
    public class Menu
    {
        private readonly PurchaseRepository purchaseRepository;

        public Menu()
        {
            purchaseRepository = new PurchaseRepository();
        }

        public void Execute(int option)
        {
            var switchOption = (MenuOption)option;
            switch (switchOption)
            {
                case MenuOption.SearchPurchases:
                    var purchases = purchaseRepository.FindPurchases();
                    Console.WriteLine("--> " + purchases.Length);
                    break;

                case MenuOption.InsertPuchase:
                    purchaseRepository.InsertPurchases();
                    break;

                case MenuOption.DeleteAllPurchases:
                    purchaseRepository.DeleteAllPurchases();
                    break;
            }
        }

        public void DrawMenu()
        {
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine((int)MenuOption.SearchPurchases + " - Search purchases");
            Console.WriteLine((int)MenuOption.InsertPuchase + "- Insert puchase");
            Console.WriteLine((int)MenuOption.DeleteAllPurchases + " - Delete all purchases");
            Console.WriteLine((int)MenuOption.CloseMenu + " - Close menu");

            Console.WriteLine();
        }

        public bool checkCloseMenu(int option)
        {
            if (option == (int)MenuOption.CloseMenu)
            {
                Console.Clear();
                return false;
            }
            return true;
        }
    }
}
