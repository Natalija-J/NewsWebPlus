using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic
{
   public class Book
    {
        //- Data
        // --- Book(title, year, author, copies)
        public string Title { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
        public Author Author { get; set; }

        public Book()
        {
            Copies = 1;
        }
        public Book(string title, Author author, int year, int copies)
        {
            Title = title;
            Author = author;
            Year = year;
            Copies = copies;
        }
        
        
    }
}
