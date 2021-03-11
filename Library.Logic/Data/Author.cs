using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic
{
    public class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pseudonym { get; set; }

        public Author()
        {

        }

        public Author(string name, string surname, string pseudonym = "")
        {
            Name = name;
            Surname = surname;
            Pseudonym = pseudonym;
        }
    }
}
