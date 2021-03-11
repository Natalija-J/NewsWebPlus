using System;
using Library.Logic;
using Library_Logic;

namespace Library.Console
{
   public class Program
    {
        static BookManager manager = new BookManager();
        static void Main(string[] args)
        {
            manager.BackgroundColor();
            manager.ForegroundColor();
            System.Console.WriteLine("Welcome to the library!");
            System.Console.WriteLine("Books available:");
            System.Console.ResetColor();
            System.Console.WriteLine();


            var books = manager.GetAvailableBooks();
            if (books.Count == 0)
            {
                System.Console.WriteLine("There are no available books at the moment.");                
            }
            else
            {                
                books.ForEach(book =>
                {
                    System.Console.WriteLine("{0}({1}{2}){3}(Available copies:{4})", book.Title, book.Author.Name, book.Author.Surname, book.Year, book.Copies);
                });
            }
            System.Console.WriteLine();
            while (true)
            {
                System.Console.WriteLine("Please enter a title of a book you wish to borrow " +
                    "(or 'stop' to quit): ");
                string input = System.Console.ReadLine();

                if (input == "stop" || input == "STOP" || input == "Stop")
                {
                    break;
                }

                var bookBorrowed = manager.TakeBook(input);
                if (bookBorrowed == null)
                {
                    System.Console.WriteLine("The book is not available!");
                }
                else
                {
                    System.Console.WriteLine("The book '{0}' was successfully checked out!", bookBorrowed.Title);
                    System.Console.WriteLine();
                }
            }
            System.Console.WriteLine();
            manager.BackgroundColor();
            manager.ForegroundColor();
            System.Console.WriteLine("Your books: ");
            System.Console.ResetColor();
            var myList = manager.GetUserBooks();
            
            if (myList.Count == 0)
            {
                System.Console.WriteLine("You have not checked out any books.");
            }
            else
            {
                foreach (var book in myList)
                {
                    System.Console.WriteLine("'{0}' by {1}. {2} ({3} - copies left)",
                        book.Title, book.Author.Name.Substring(0, 1), book.Author.Surname, book.Copies);
                }
                System.Console.WriteLine();
                manager.BackgroundColor();
                manager.ForegroundColor();
                System.Console.WriteLine("Returning books.");
                System.Console.ResetColor();
                
                while (true)
                {
                    System.Console.WriteLine("Please enter a book title that you wish to return" +
                        "(or 'stop' to exit): ");
                    string input2 = System.Console.ReadLine();
                    if (input2 == "stop" || input2 == "STOP" || input2 == "Stop")
                    {
                        break;
                    }

                    var returned = manager.ReturnBook(input2);
                    if (returned == null)
                    {
                        System.Console.WriteLine("Sorry, this book has not been checked out by you!");
                    }
                    else
                    {
                        System.Console.WriteLine("'{0}' by {1}. {2} has been returned to the library (available copies: {3})",
                        returned.Title, returned.Author.Name.Substring(0, 1), returned.Author.Surname, returned.Copies);
                    }
                }
                System.Console.WriteLine();
                manager.BackgroundColor();
                manager.ForegroundColor();
                System.Console.WriteLine("Books that have not been returned yet: ");
                System.Console.ResetColor();

                foreach (var book in manager.GetUserBooks())
                {
                    System.Console.WriteLine("'{0}' by {1}. {2} ({3} - copies left)",
                        book.Title, book.Author.Name.Substring(0, 1), book.Author.Surname, book.Copies);
                }
                
            }
            System.Console.WriteLine();
            manager.BackgroundColor();
            manager.ForegroundColor();
            System.Console.Write("Thank you for using our library!");
            System.Console.ResetColor();
        }
    }
}
