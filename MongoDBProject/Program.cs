using MongoDBProject.Core;
using System;

namespace MongoDBProject
{
    class Program
    {
        private static bool MenuLoop = true;

        static void Main(string[] args)
        {
            while (MenuLoop)
            {
                var menu = new Menu();
                menu.DrawMenu();

                var selectedOption = Convert.ToInt32(Console.ReadLine());

                MenuLoop = menu.checkCloseOption(selectedOption);

                if (MenuLoop)
                {
                    menu.Execute(selectedOption);
                }
            }
        }
    }
}
