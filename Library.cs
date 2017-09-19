using System;
using System.Collections.Generic;


namespace library
{
    public class Library
    {
        public List<Book> BookCollection = new List<Book>();
        public List<Book> rentedBooks = new List<Book>();

        public bool DisplayMenu = true;

        Book HarryPotter = new Book("Harry Potter", 1);
        Book MobyDick = new Book("Moby Dick", 2);
        Book AnarCook = new Book("The Anarchist's Cookbook", 3);

        public Library()
        {
            BookCollection.Add(HarryPotter);
            BookCollection.Add(MobyDick);
            BookCollection.Add(AnarCook);
        }

        public void Menu()
        {
            int UserSelection;
            do
            {
                Console.Clear();
                Console.WriteLine("Please select a book to check out:\n");
                ShowAvailableBooks();
                Console.WriteLine("\nEnter '0' to go back.\n");

                if (Int32.TryParse(Console.ReadLine().ToUpper(), out UserSelection))
                {
                    if (UserSelection == 0)
                    {
                        DisplayMenu = false; // return to previous menu
                    }
                    if (UserSelection > 0 && UserSelection <= BookCollection.Count)
                    {
                        FindAndRentBook(UserSelection);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Please make a valid selection");
                    continue;
                }

            } while (DisplayMenu);

        } // end of rent book menu

        public void Return()
        {
            Console.Clear();
            if (rentedBooks.Count != 0)
            {
                int ReturnSelection;
                ShowRentedBooks();
                // now all of the rented books are displaying on the screen
                if (Int32.TryParse(Console.ReadLine().ToUpper(), out ReturnSelection) && ReturnSelection > 0)
                {
                    FindAndReturnBook(ReturnSelection);
                    return;
                }
            }
            else
            {
                Console.WriteLine("You don't have any books checked out. \n\nPress ENTER to go back to the main menu\n");
                Console.ReadLine();
                return;
            }
        }

        private void ShowAvailableBooks()
        {
            int MenuPosition = 1;
            for (int i = 0; i < BookCollection.Count; i++)
            {
                if (!BookCollection[i].IsCheckedOut)
                {
                    BookCollection[i].ListPosition = MenuPosition;
                    Console.WriteLine($"{BookCollection[i].ListPosition}. {BookCollection[i].Title}");
                    MenuPosition++;
                }
            }
        }

        private void ShowRentedBooks()
        {
            int Position = 1;
            Console.WriteLine("\nPlease select the book you are returning by entering its number (1, 2, 3, etc)\n");
            for (int i = 0; i < BookCollection.Count; i++)
            {
                if (BookCollection[i].IsCheckedOut)
                {
                    BookCollection[i].ListPosition = Position;
                    Console.WriteLine($"{BookCollection[i].ListPosition}. {BookCollection[i].Title}");
                    Position++;
                }
            }

        }

        private void FindAndRentBook(int selection)
        {
            BookCollection.ForEach(Book =>
                {
                    if (Book.ListPosition == selection)
                    {
                        Book.Rent();
                        rentedBooks.Add(Book);
                        Book.ListPosition = 0;
                        Console.WriteLine($"\nYou have successfully rented {Book.Title}!\n");
                        Console.WriteLine("Press ENTER to continue");
                        DisplayMenu = false;
                        Console.ReadLine();
                    }
                });
        }

        private void FindAndReturnBook(int selection)
        {
            BookCollection.ForEach(Book =>
            {
                if (Book.IsCheckedOut == true)
                {
                    if (Book.ListPosition == selection)
                    {
                        Book.Return();
                        rentedBooks.Remove(Book);
                        Console.WriteLine($"You have successfully returned {Book.Title}!\nThank You!");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                    }
                }
            });

        }
    }
}