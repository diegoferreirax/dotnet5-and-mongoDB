using MongoDBProject.Core.Enuns;
using MongoDBProject.Repositories;
using System;

namespace MongoDBProject.Core
{
    public class Menu
    {
        private readonly PurchaseRepository purchaseRepository;
        private readonly PersonRepository personRepository;

        public Menu()
        {
            purchaseRepository = new PurchaseRepository();
            personRepository = new PersonRepository();
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

                case MenuOption.InsertPersons:
                    personRepository.InsertPersons();
                    break;

                case MenuOption.SearchPersons:
                    var persons = personRepository.FindPersons();
                    Console.WriteLine("--> " + persons.Length);
                    break;

                case MenuOption.DeleteAllPersons:
                    personRepository.DeleteAllPersonsAndAddress();
                    break;

                case MenuOption.FindPersonByKey:
                    var key = Console.ReadLine();
                    var person = personRepository.FindPersonsByKey(key);
                    Console.WriteLine("--> " + person.Name);

                    var addresses = personRepository.FindAddressesByPerson(person.Id);
                    foreach (var address in addresses)
                    {
                        Console.WriteLine("--> " + address.Street);
                    }

                    break;

                case MenuOption.InsertPersonsWithAddress:
                    personRepository.InsertPersonsWithAddress();
                    break;
            }
        }

        public void DrawMenu()
        {
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine((int)MenuOption.SearchPurchases + " - Search purchases");
            Console.WriteLine((int)MenuOption.InsertPuchase + "- Insert puchase");
            Console.WriteLine((int)MenuOption.DeleteAllPurchases + " - Delete all purchases");
            Console.WriteLine(" - - - - - ");
            Console.WriteLine((int)MenuOption.InsertPersons + " - Insert persons");
            Console.WriteLine((int)MenuOption.SearchPersons + " - Search persons");
            Console.WriteLine((int)MenuOption.DeleteAllPersons + " - Delete all persons");
            Console.WriteLine((int)MenuOption.FindPersonByKey + " - Find person by key");
            Console.WriteLine((int)MenuOption.InsertPersonsWithAddress + " - Insert person with address");
            Console.WriteLine((int)MenuOption.CloseMenu + " - Close menu");

            Console.WriteLine();
        }

        public bool checkCloseMenu(int option)
        {
            if (option == (int)MenuOption.CloseMenu)
            {
                return false;
            }
            Console.Clear();
            return true;
        }
    }
}
