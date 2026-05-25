using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management
{
    internal class LibraryUser:User
    {
        public LibraryCard Card { get; set; } = new LibraryCard();
        
        public LibraryUser(string name)
        {
            Name = name;
        }




    }
}
