using System;

namespace MongoDBProject
{
    public class Menu
    {
        private readonly PurchaseRepository purchaseRepository;

        public Menu()
        {
            purchaseRepository = new PurchaseRepository();
        }

        public void Execute(string option)
        {
            var switchOption = (MenuOption)Convert.ToInt16(option);
            switch (switchOption)
            {
                case MenuOption.SearchPurchases:
                    var purchases = purchaseRepository.FindPurchases();
                    foreach (var purchase in purchases)
                    {
                        Console.WriteLine(purchase.Placename);
                    }

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

        public bool checkCloseOption(string option)
        {
            if (Convert.ToInt16(option) == (int)MenuOption.CloseMenu)
            {
                Console.Clear();
                return false;
            }
            return true;
        }
    }
}
