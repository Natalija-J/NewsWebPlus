using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic
{
    public class LibraryBooks
    {
        //--- LibraryBooks(list of all the available books)
        public string Name { get; set; }

        public List<Book> AvBooks { get; set; }
        
        public LibraryBooks()
        {
            AvBooks = new List<Book>();
            AvBooks.Add(new Book("Pride and Prejudice", new Author("Jane", "Austin"), 1813, 10));
            AvBooks.Add(new Book("To Kill a Mockingbird", new Author("Harper", "Lee"), 1960, 15));
            AvBooks.Add(new Book("Little Women", new Author("Louisa May", "Alcott"), 1868, 5));
            AvBooks.Add(new Book("Beartown", new Author("Frederik", "Backman"), 2016, 8));
            AvBooks.Add(new Book("Room", new Author("Emma", "Donoghue"), 2010, 2));
            AvBooks.Add(new Book("I Talk Like a River", new Author("Jordan", "Scott"), 2020, 3));
            AvBooks.Add(new Book("If You Come To Earth", new Author("Sophie", "Blackall"), 2020, 7));
            AvBooks.Add(new Book("A Christmas Carol", new Author("Charles", "Dickens"), 1843, 12));
        }


        public string AddBook(Book book)
        {
            if (book == null)
            {
                return "No book was added";
            }

            //if (string.IsNullOrEmpty(book.Title)
            //{
            //    return "The book must have a title!";
            //}

            AvBooks.Add(book);

            return $"The book {book.Title} was added to the library!";

        }

    }
}
