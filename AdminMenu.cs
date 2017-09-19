using System;
using System.Collections.Generic;

namespace library
{
    public class AdminMenu
    {
        Library currentLib;

        public AdminMenu(Library lib)
        {
            currentLib = lib;
        }

        public void Execute()
        {
            bool RunMenu = true;

            do
            {
                int Selection;

                Console.Clear();
                Console.WriteLine("Hello Admin! Please select an admin option: ");
                Console.WriteLine("\n1. Add a book to the library\n2. Remove a book from the library\n");

                if (Int32.TryParse(Console.ReadLine().ToUpper(), out Selection))
                {
                    switch (Selection)
                    {
                        case 1:
                            AddBook();
                            return;
                        case 2:
                            RemoveBook();
                            return;
                        default:
                            Console.WriteLine("Not an option. Try again.");
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("Not a valid entry. Please select a valid number from the menu");
                }

            } while (RunMenu);
        } // End of Execute()

        private void AddBook()
        {
            Console.WriteLine("\nGreat! A new book!\n\nPlease enter the book title\n");
            string Title = Console.ReadLine();
            Book NewBook = new Book(Title, 0);
            currentLib.BookCollection.Add(NewBook);
            Console.WriteLine($"\nCongratulations, the book '{Title}' has been added to the library");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        private void RemoveBook()
        {
            int ToRemove;

            Console.WriteLine("\nNo problem, lets remove a book.\n");
            Console.WriteLine("Which book would you like to remove?\n");
            for(int i=0; i<currentLib.BookCollection.Count; i++) 
            {
                Book item = currentLib.BookCollection[i];
                item.ListPosition = i+1;
                Console.WriteLine($"{item.ListPosition}. {item.Title}");
            }

            if(Int32.TryParse(Console.ReadLine().ToUpper(), out ToRemove))
            {
                currentLib.BookCollection.ForEach(Book => {
                    if (Book.ListPosition == ToRemove)
                    {
                        currentLib.BookCollection.Remove(Book);
                        System.Console.WriteLine($"Book removal was successful.{Book.Title} has been blown away.\nPress ENTER to continue");
                        Console.ReadLine();
                    }
                });
            }
            else
            {
                System.Console.WriteLine("Hmm... that doesn't seem to be a valid book. Try again");
            }




        }
    }
}