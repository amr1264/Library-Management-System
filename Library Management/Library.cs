using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Library_Management
{
    internal class Library
    {
        private static List <Book>BookList = new List <Book>();
        
        public static void Add(Book book)
        {
            BookList.Add(book);
            Console.WriteLine("Added Book Sucssfully ");
        }
        public static void Remove(string title)
        {
            Book bookremove = null;
            foreach (Book b in BookList)
            {
                if (b.Title.ToLower() == title.ToLower())
                {
                    bookremove = b;
                }
            }
            if (bookremove!=null)
            {
                BookList.Remove(bookremove);
                Console.WriteLine($"\n Sucess! {title}has been remove");
            }
            else
            {
                Console.WriteLine($"\nSorry, book {title}not found!");
            }
        }
        public static void Display()
        {
            if (BookList.Count==0)
            {
                Console.WriteLine("Library is Empty ");

            }
            else
            {
                Console.WriteLine("\n____List of available Books ");
            }
            foreach (Book p in BookList)
            {
                Console.WriteLine(p);
                Console.WriteLine("___________________________________");
            }
        }
        public static Book BorrowBookFromList(string title)
        {
            foreach (Book b in BookList)
            {

                if (b.Title.ToLower().Contains(title.ToLower().Trim()) && b.IsAvailable)
                {
                    b.IsAvailable = false;
                    return b;
                }
            }
                  
                        Console.WriteLine("\n Sorry, this book is already borrowed !");
                        return null;
                
            
            
        }
        public static void ReturnBookToList(string bookTitle)
        {
            foreach (Book b in BookList)
            {
                if (b.Title.ToLower() == bookTitle.ToLower())
                {
                    b.IsAvailable = true; 
                    break;
                }
            }
        }
    }
}
