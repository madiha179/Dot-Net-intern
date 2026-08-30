using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    internal class Librarian
    {
        private List<Book> books = new List<Book>();
        public void AddBook(Book book) {
            books.Add(book);
        }
        public Book findBookById(int id)
        {
            return books.Find(b => b.getId() == id);
        }
        public bool BorrowBook(int bookId, User user)
        {
            Book book = findBookById(bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return false;
            }

            if (!book.getisAvailable())
            {
                Console.WriteLine($"\"{book.getBookName()}\" is already borrowed.");
                return false;
            }

            book.setisAvailable(false);
            user.addBorrowedBook(book);
            Console.WriteLine($"{user.getName()} borrowed \"{book.getBookName()}\" successfully.");
            return true;
        }
        public void RemoveBook(int id) { 
            books.RemoveAll(b => b.getId() == id);
        }
        public List<Book> getAllBooks()
        {
            return books;
        }
        public bool ReturnBook(int bookId, User user)
        {
            Book book = findBookById(bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return false;
            }

            book.setisAvailable(true);
            user.removeBorrowedBook(book);
            Console.WriteLine($"{user.getName()} returned \"{book.getBookName()}\" successfully.");
            return true;
        }
        public void PrintAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("The library collection is empty.");
                return;
            }

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
