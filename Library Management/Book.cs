using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Library_Management
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            return $"Title:{Title} | Author:{Author} | Year:{Year}";
        }
        public bool IsAvailable { get; set; } = true;
    }
}
