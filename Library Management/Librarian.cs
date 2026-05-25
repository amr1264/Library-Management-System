using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management
{
    internal class Librarian:User
    {
        public int EmpolyeeNumber { get; set; }
        public Librarian(string name)
        {
            Name = name;
        }
        
    }
}
