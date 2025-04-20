using System;
using System.Collections.Generic;

namespace LibraryManagementSystem;
class Module5
{
    static void Main(string[] args)
    {
        const int maxBooks = 5;
        string book1 = null, book2 = null, book3 = null, book4 = null, book5 = null;
        int bookCount = 0;

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (bookCount >= maxBooks)
                    {
                        Console.WriteLine("The library is full. Cannot add more books.");
                    }
                    else
                    {
                        Console.Write("Enter the title of the book to add: ");
                        string newBook = Console.ReadLine();
                        if (book1 == null) book1 = newBook;
                        else if (book2 == null) book2 = newBook;
                        else if (book3 == null) book3 = newBook;
                        else if (book4 == null) book4 = newBook;
                        else if (book5 == null) book5 = newBook;
                        bookCount++;
                        Console.WriteLine($"Book '{newBook}' added successfully.");
                    }
                    break;

                case "2":
                    Console.Write("Enter the title of the book to remove: ");
                    string bookToRemove = Console.ReadLine();
                    bool found = false;

                    if (book1 == bookToRemove) { book1 = null; found = true; }
                    else if (book2 == bookToRemove) { book2 = null; found = true; }
                    else if (book3 == bookToRemove) { book3 = null; found = true; }
                    else if (book4 == bookToRemove) { book4 = null; found = true; }
                    else if (book5 == bookToRemove) { book5 = null; found = true; }

                    if (found)
                    {
                        bookCount--;
                        Console.WriteLine($"Book '{bookToRemove}' removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{bookToRemove}' not found in the library.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\nBooks in the Library:");
                    if (bookCount == 0)
                    {
                        Console.WriteLine("No books available.");
                    }
                    else
                    {
                        if (book1 != null) Console.WriteLine($"- {book1}");
                        if (book2 != null) Console.WriteLine($"- {book2}");
                        if (book3 != null) Console.WriteLine($"- {book3}");
                        if (book4 != null) Console.WriteLine($"- {book4}");
                        if (book5 != null) Console.WriteLine($"- {book5}");
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}