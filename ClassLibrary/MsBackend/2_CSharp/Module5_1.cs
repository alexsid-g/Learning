using System;
using System.Collections.Generic;

public class Module5_1
{
    private const int MaxLibrarySize = 5;
    private static readonly List<string> Books = new();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter an action ('add', 'remove', 'list', or 'exit'):");
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
                case "exit":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', 'list', or 'exit'.");
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
        string newBook = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newBook))
        {
            Books.Add(newBook);
            Console.WriteLine($"Book '{newBook}' added to the library.");
        }
        else
        {
            Console.WriteLine("Book title cannot be empty.");
        }
    }

    private static void RemoveBook()
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(removeBook) && Books.Remove(removeBook))
        {
            Console.WriteLine($"Book '{removeBook}' removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found or invalid input.");
        }
    }

    private static void ListBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            Console.WriteLine("Available books:");
            Books.ForEach(book => Console.WriteLine($"- {book}"));
        }
    }
}
