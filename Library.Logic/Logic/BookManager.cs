using Library.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Library_Logic
{
    /// <summary>
    /// All the logic for taking/returning books
    /// </summary>
    public class BookManager
    {
         private UserBooks UserBooks { get; set; }
        private LibraryBooks LibraryBooks { get; set; }
        public BookManager()
        {
            UserBooks = new UserBooks();
            LibraryBooks = new LibraryBooks();
        }
        /// <summary>
        /// Returns list of all available books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAvailableBooks()
        {
            //return LibraryBooks.AvBooks
            //                 .Where(book => book.Copies > 0)
            //                 .OrderBy(book => book.Title)
            //                 .ToList();
            List<Book> result = new List<Book>();
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stephen\Documents\Natalija\Accenture .Net\Bootcamp1\LibraryDB.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                string query = "SELECT * FROM Books WHERE Copies > 0 ORDER BY Title";

                using (SqlCommand cm = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book()
                            {
                                Author = new Author()
                                {
                                    Name = Convert.ToString(reader["Author_Name"]),
                                    Surname = Convert.ToString(reader["Author_LastName"])
                                },
                                Title = Convert.ToString(reader["Title"]),
                                Year = Convert.ToInt32(reader["Year"]),
                                Copies = Convert.ToInt32(reader["Copies"]),
                            };
                            result.Add(book);
                        }
                    }
                }

                connection.Close();
            }
            return result;

            //    Console.WriteLine();
            //    using (BookManager bm = new BookManager())
            //    {

            //    }
            //    Console.WriteLine("2nd approach - Entity Framework");
            //    using (SampleDatabase db = new SampleDatabase())
            //    {
            //        List<Users> users = db.Users.OrderBy(u => u.RegisteredOn).ToList();
            //        foreach (var user in users)
            //        {
            //            Console.WriteLine("User {0} {1} created on {2}", user.FirstName, user.LastName, user.RegisteredOn);
            //        }

            //    }
            //}

        List<Book> GetUserBooks()
        {
            return UserBooks.Books.OrderBy(book => book.Title).ToList();
        }

        Book TakeBook(string title)
        {
            Book book = LibraryBooks.AvBooks.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null && book.Copies > 0)
            {
                book.Copies--;
                UserBooks.Books.Add(book);
                return book;
            }
            return null;    
        }
        Book ReturnBook(string title)
        {
            Book userBook = UserBooks.Books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (userBook != null)
            {
                
                UserBooks.Books.Remove(userBook);
                var libraryBook = LibraryBooks.AvBooks.Find(book => book.Title == userBook.Title);
                userBook.Copies++;
                return userBook;
            }            
            return null;
        }
        void BackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.Green;
        }
        void ForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
