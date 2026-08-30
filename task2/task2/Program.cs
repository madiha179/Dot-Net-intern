using System;
using System.Collections.Generic;

namespace task2
{
    internal class Program
    {
        static Librarian librarian = new Librarian();
        static List<User> users = new List<User>();
        static int nextBookId = 1;
        static int nextCardId = 1;

        static void Main(string[] args)
        {
            SeedData(); 

            bool running = true;
            while (running)
            {
                PrintMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateUser(); break;             
                    case "2": AddBook(); break;                 
                    case "3": RemoveBook(); break;               
                    case "4": librarian.PrintAllBooks(); break; 
                    case "5": BorrowBook(); break;              
                    case "6": ReturnBook(); break;
                    case "7": ListUsers(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
                Console.WriteLine();
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("===== Library Menu =====");
            Console.WriteLine("1. Register new user (get a library card)");
            Console.WriteLine("2. Add a book (librarian)");
            Console.WriteLine("3. Remove a book (librarian)");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. Borrow a book");
            Console.WriteLine("6. Return a book");
            Console.WriteLine("7. List all users");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
        }

        static void CreateUser()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();

            User user = new User();
            user.setName(name);
            user.setLibraryCard(nextCardId++);
            users.Add(user);

            Console.WriteLine($"User created: {user}");
        }

        static void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            Book book = new Book();
            book.setId(nextBookId++);
            book.setTitle(title);
            book.setAutherName(author);
            book.setisAvailable(true);

            librarian.AddBook(book);
            Console.WriteLine($"Book added: {book}");
        }

        static void RemoveBook()
        {
            Console.Write("Enter book id to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                librarian.RemoveBook(id);
                Console.WriteLine("Book removed (if it existed).");
            }
            else
            {
                Console.WriteLine("Invalid id.");
            }
        }

        static void BorrowBook()
        {
            User user = SelectUser();
            if (user == null) return;

            Console.Write("Enter book id to borrow: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                librarian.BorrowBook(id, user);
            }
            else
            {
                Console.WriteLine("Invalid id.");
            }
        }

        static void ReturnBook()
        {
            User user = SelectUser();
            if (user == null) return;

            Console.Write("Enter book id to return: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                librarian.ReturnBook(id, user);
            }
            else
            {
                Console.WriteLine("Invalid id.");
            }
        }

        static User SelectUser()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No users registered yet. Register one first (option 1).");
                return null;
            }

            Console.Write("Enter your library card number: ");
            if (int.TryParse(Console.ReadLine(), out int card))
            {
                User user = users.Find(u => u.getLibraryCard() == card);
                if (user == null)
                    Console.WriteLine("No user with that card number.");
                return user;
            }

            Console.WriteLine("Invalid card number.");
            return null;
        }

        static void ListUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No users registered.");
                return;
            }

            foreach (User user in users)
            {
                Console.WriteLine($"{user} - Borrowed: {user.getBorrowedBooks().Count} book(s)");
            }
        }

        static void SeedData()
        {
            Book b1 = new Book();
            b1.setId(nextBookId++);
            b1.setTitle("Clean Code");
            b1.setAutherName("Robert C. Martin");
            b1.setisAvailable(true);
            librarian.AddBook(b1);

            Book b2 = new Book();
            b2.setId(nextBookId++);
            b2.setTitle("The Pragmatic Programmer");
            b2.setAutherName("Andrew Hunt");
            b2.setisAvailable(true);
            librarian.AddBook(b2);
        }
    }
}