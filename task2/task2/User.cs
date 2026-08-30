using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    internal class User
    {
        private string name;
        private int libraryCard;
        private List<Book> borrowedBooks = new List<Book>();
        public string getName()
        {
            return name;
        }
        public int getLibraryCard() { 
        return libraryCard;
        }
        public List<Book> getBorrowedBooks()
        {
            return borrowedBooks;
        }
        public void addBorrowedBook(Book book)
        {
            borrowedBooks.Add(book);
        }
        public void setName(string name) {
            this.name = name;
        }
        public void removeBorrowedBook(Book book)
        {
            borrowedBooks.RemoveAll(b => b.getId() == book.getId());
        }
        public void setLibraryCard(int libraryCard) { 
        this.libraryCard = libraryCard;
        }
    }
}
