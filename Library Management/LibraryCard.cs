using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management
{
    internal class LibraryCard
    {
         public int Number { get; set; }
        public  List<Book> Borrowbooks { get; set; } = new List<Book>();
    }
}
