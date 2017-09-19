using System;
using System.Collections.Generic;

namespace library
{
    public class MainMenu
    {
        public void Menu()
        {
            bool RunMenu = true;
            int UserAction;
            Library myLibrary = new Library();
            AdminMenu admin = new AdminMenu(myLibrary);
            Console.Clear();
            Console.WriteLine("Hello, and welcome to The Henze Public Library.\n\n");
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Console.WriteLine("\nPlease make a selection:\n\n1. Check out a book\n2. Return a book\n3. Admin Options\n4. Quit\n\n");
                if (Int32.TryParse(Console.ReadLine().ToUpper(), out UserAction))
                {
                    if (UserAction == 1)
                    {
                        myLibrary.Menu();
                    }
                    if (UserAction == 2)
                    {
                        myLibrary.Return();
                    }
                    if (UserAction == 3)
                    {
                        admin.Execute();
                    }

                    if (UserAction == 4)
                    {
                        RunMenu = false;
                    }

                }
                else
                {
                    Console.WriteLine("Please make a valid selection");
                }

            } while (RunMenu);

        }
    }
}