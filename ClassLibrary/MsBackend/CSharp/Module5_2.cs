using System;
using System.Collections.Generic;
using System.Linq;

public class Module5_2
{
    private static int NextBookID = 1;

    // Define the Book class
    private class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsCheckedOut { get; set; }
    }

    private const int MaxLibrarySize = 5;
    private const int MaxBorrowedBooks = 3;

    private static readonly List<Book> Books = new();
    private static readonly Dictionary<string, List<int>> BorrowedBooks = new(); // Store book IDs instead of Book objects

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter an action ('add', 'remove', 'list', 'search', 'borrow', 'return', 'list-users', or 'exit'):");
            string action = Console.ReadLine()?.Trim().ToLower();

            switch (action)
            {
                case "add":
                    AddBook();
                    break;
                case "remove":
                    RemoveBook();
                    break;
                case "list":
                    ListBooks();
                    break;
                case "search":
                    SearchBook();
                    break;
                case "borrow":
                    BorrowBook();
                    break;
                case "return":
                    ReturnBook();
                    break;
                case "list-users":
                    ListAllUsers();
                    break;
                case "exit":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', 'list', 'search', 'borrow', 'return', or 'exit'.");
                    break;
            }
        }
    }

    private static void AddBook()
    {
        if (Books.Count >= MaxLibrarySize)
        {
            Console.WriteLine("Library is full. Cannot add more books.");
            return;
        }

        Console.WriteLine("Enter the title of the book to add:");
        string newBookTitle = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newBookTitle))
        {
            Books.Add(new Book { ID = NextBookID++, Title = newBookTitle, IsCheckedOut = false });
            Console.WriteLine($"Book '{newBookTitle}' added to the library.");
        }
        else
        {
            Console.WriteLine("Book title cannot be empty.");
        }
    }

    private static void RemoveBook()
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string removeBookTitle = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(removeBookTitle))
        {
            Console.WriteLine("Book title cannot be empty.");
            return;
        }

        var bookToRemove = Books.Find(book => book.Title.Equals(
            removeBookTitle, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove == null)
        {
            Console.WriteLine("Book not found in the library.");
            return;
        }

        if (bookToRemove.IsCheckedOut)
        {
            Console.WriteLine($"Cannot remove the book '{removeBookTitle}' because it is currently checked-out.");
            return;
        }

        Books.Remove(bookToRemove);
        Console.WriteLine($"Book '{removeBookTitle}' removed from the library.");
    }

    private static void ListBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Console.WriteLine("Books in the library:");
        foreach (var book in Books)
        {
            string status = book.IsCheckedOut ? "(Checked-out)" : "(Available)";
            Console.WriteLine($"- ID: {book.ID}, Title: {book.Title} {status}");
        }
    }

    private static void SearchBook()
    {
        Console.WriteLine("Enter a a book title to search for:");
        string title = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Search title cannot be empty.");
            return;
        }

        var isBookFound = Books.Any(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (isBookFound)
        {
            Console.WriteLine("Book is in the collection.");
        }
        else
        {
            Console.WriteLine("No book found in the collection.");
        }
    }

    private static void BorrowBook()
    {
        Console.WriteLine("Enter your name:");
        string userName = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("User name cannot be empty.");
            return;
        }

        if (BorrowedBooks.ContainsKey(userName) &&
            BorrowedBooks[userName].Count >= MaxBorrowedBooks)
        {
            Console.WriteLine("You have reached the maximum borrowing limit of 3 books.");
            return;
        }

        Console.WriteLine("Enter the title of the book to borrow:");
        string bookTitle = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(bookTitle))
        {
            Console.WriteLine("Book title cannot be empty.");
            return;
        }

        var bookToBorrow = Books.Find(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase) && !book.IsCheckedOut);
        if (bookToBorrow == null)
        {
            Console.WriteLine("Book not available in the library.");
            return;
        }

        // Add the user to the dictionary only if they successfully borrow a book
        if (!BorrowedBooks.ContainsKey(userName))
        {
            BorrowedBooks[userName] = new List<int>();
        }

        bookToBorrow.IsCheckedOut = true;
        BorrowedBooks[userName].Add(bookToBorrow.ID);
        Console.WriteLine($"Book '{bookTitle}' borrowed successfully.");
    }

    private static void ReturnBook()
    {
        Console.WriteLine("Enter your name:");
        string userName = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(userName) || !BorrowedBooks.ContainsKey(userName))
        {
            Console.WriteLine("No borrowed books found for this user.");
            return;
        }

        Console.WriteLine("Enter the title of the book to return:");
        string bookTitle = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(bookTitle))
        {
            Console.WriteLine("Book title cannot be empty.");
            return;
        }

        var bookToReturn = Books.Find(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (bookToReturn == null || !BorrowedBooks[userName].Contains(bookToReturn.ID))
        {
            Console.WriteLine("Book not found in your borrowed list.");
            return;
        }

        bookToReturn.IsCheckedOut = false;
        BorrowedBooks[userName].Remove(bookToReturn.ID);
        Console.WriteLine($"Book '{bookTitle}' returned successfully.");

        if (BorrowedBooks[userName].Count == 0)
        {
            BorrowedBooks.Remove(userName);
        }
    }

    private static void ListAllUsers()
    {
        if (BorrowedBooks.Count == 0)
        {
            Console.WriteLine("No users have borrowed any books.");
            return;
        }

        Console.WriteLine("Users and their borrowed books:");
        var userBookDetails = BorrowedBooks
            .Select(entry => new
            {
                UserName = entry.Key,
                Books = Books
                    .Where(x => entry.Value.Contains(x.ID))
                    .ToList()
            });

        foreach (var user in userBookDetails)
        {
            Console.WriteLine($"User: {user.UserName}");
            Console.WriteLine($"Books borrowed: {user.Books.Count}");
            Console.WriteLine("Borrowed books:");
            foreach (var book in user.Books)
            {
                Console.WriteLine($"- ID: {book.ID}, Title: {book.Title}");
            }
            Console.WriteLine(); // Add a blank line for better readability
        }
    }
}