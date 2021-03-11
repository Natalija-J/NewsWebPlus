using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic
{
    public class UserBooks
    {
        //--- UserBooks(list of user's books)
        public List<Book> Books { get; set; }

        public UserBooks()
        {
            Books = new List<Book>();
        }
    }
}
