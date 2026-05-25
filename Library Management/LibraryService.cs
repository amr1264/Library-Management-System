using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management
{
    internal class LibraryService
    {
        
       
        public void NewBook(string title, string author, int year)
        {
            Book B1 = new Book();
            B1.Title = title;
            B1.Author = author;
            B1.Year = year;
            Library.Add(B1);
        }
        public void Deletebook(string title)
        {
            Library.Remove(title);
        }

        public void BorrowBook(LibraryUser user, string bookTitle)
        {
            Book book = Library.BorrowBookFromList(bookTitle);

            if (book != null)
            {
                user.Card.Borrowbooks.Add(book);
                Console.WriteLine($"\n[CONFIRMED]: You have successfully borrowed '{book.Title}'!");
            }
            else
            {
                Console.WriteLine($"\n[SORRY]: '{book}'is either not found or already borrowed ");
            }
        }
        public void ReturnBook(LibraryUser user,string bookTitle)
        {
            int removedCount = user.Card.Borrowbooks.RemoveAll(b => b.Title.ToLower() == bookTitle.ToLower());
            if (removedCount > 0)
            {

                Library.ReturnBookToList(bookTitle);
                Console.WriteLine($"\n[SUCCESS]: You have successfully returned '{bookTitle}'.");
            }
            else
            {
                Console.WriteLine("\n[ERROR]: You haven't borrowed this book!");
            }
        }
    }
    
}
