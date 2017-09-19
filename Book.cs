using System;
using System.Collections.Generic;

namespace library
{
    public class Book
    {
        public string Title;
        public bool IsCheckedOut = false; 
        public int ListPosition;
        public Book(string title, int listposition)
        {
            Title = title;
            ListPosition = listposition;
        }

        public void Rent()
        {
            IsCheckedOut = true;
        }
        
        public void Return()
        {
            IsCheckedOut = false;
        }
        
    }
}