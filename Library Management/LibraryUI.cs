using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Library_Management
{
    internal class LibraryUI
    {
        public void start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("WELCOME MY LIBRARY".PadLeft(Console.WindowWidth / 2));
                Console.WriteLine("\n");
                Console.WriteLine("Are You Librarian or regular user (L/R)or Exit (E)");
                char usertype = Console.ReadLine().ToUpper()[0];
                if (usertype == 'L')
                {
                    LibrarianUI();
                }
                else if (usertype == 'R')
                {
                    UserUI();
                }
                else if (usertype=='E')
                {
                    Console.WriteLine("Thank You For using our library");
                    break;
                }
                else
                {
                    
                        Console.WriteLine("Please enter correct value(L or R)");
                    Console.ReadKey();
                }
               
            }
        }
           
        public void LibrarianUI()
        {
           
            
            Console.WriteLine("Welcome to Librarian ,Enter Your Name");
            string lbrarianname= Console.ReadLine();

            int empNum; 

            while (true) 
            {
                Console.Write("Enter Employee Number: ");

              
                if (int.TryParse(Console.ReadLine(), out empNum))
                {
                    break;
                }

                
                Console.WriteLine("Invalid Input! Please enter numbers only.");
            }

            Librarian L1 = new Librarian(lbrarianname);
            L1.EmpolyeeNumber = empNum;



            Console.WriteLine($"Welcome {lbrarianname}");
            while (true)
            {
                Console.WriteLine("\n\t\t--- Please choose an option ---\n" +
                 "\t\t[1] Add book\n" +
                 "\t\t[2] Remove book\n" +
                 "\t\t[3] Display books\n" +
                  "\t\t[4] Back To Main Menu\n" +
                 "\t\t-------------------------------");

                int choice;

                while (true)
                {
                  

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        break;
                    }


                    Console.WriteLine("Invalid Input! Please enter numbers only.");
                }

                LibraryService service = new LibraryService();
                switch (choice)
                {
                    case 1:
                        bool state = true;
                        while (state)
                        {
                            Console.WriteLine("Enter book name");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter book Author");
                            string author = Console.ReadLine();
                            int year;

                            while (true)
                            {
                                Console.WriteLine("Enter the Book publication date ");

                                if (int.TryParse(Console.ReadLine(), out year))
                                {
                                    break;
                                }


                                Console.WriteLine("Invalid Input! Please enter numbers only.");
                            }
                            service.NewBook(title, author, year);
                            Console.WriteLine("Do You want Add another book (Y/N)");
                            char statechoice = Console.ReadLine().ToUpper()[0];
                            if (statechoice == 'N')
                            {
                                state = false;

                            }
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the book to remove");
                        string bookname = Console.ReadLine();
                        service.Deletebook(bookname);
                        
                        break;
                    case 3:
                        Library.Display();
                        

                        break;
                    case 4:
                        Console.WriteLine("return To Main Menu");
                        return;
                    default:
                        Console.WriteLine("invalid choice!,please try again");
                        break;
                }
            }
        }
           
        public void  UserUI()
        {


                
           
                Console.WriteLine("\n--- Regular User Screen ---");
                Console.Write("Enter Your Name: ");
                string name = Console.ReadLine();

                LibraryUser regularUser = new LibraryUser(name);
               
                regularUser.Card = new LibraryCard();

                LibraryService service = new LibraryService();

                while (true)
                {
                    Console.WriteLine($"\nWelcome {name}!");
                    Console.WriteLine("\n\t\t--- Please choose an option ---\n" +
                                      "\t\t[1] Display All Available Books\n" +
                                      "\t\t[2] Borrow a Book\n" +
                                      "\t\t[3] Return a Book\n" +
                                      "\t\t[4] Display My Borrowed Books\n" +
                                      
                                       "\t\t[5] Back to Main Role Selection\n" +
                                      "\t\t-------------------------------");
                    
                int choice;

                while (true)
                {
                    Console.Write("Your Choice: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        break;
                    }


                    Console.WriteLine("Invalid Input! Please enter numbers only.");
                }

                if (choice == 5)
                    {
                        break;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Available Books in Library ---");
                            Library.Display();
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.WriteLine("\n--- Borrow a Book ---");
                            Console.Write("Enter the title of the book you want to borrow: ");
                            string titleToBorrow = Console.ReadLine();

                            service.BorrowBook(regularUser, titleToBorrow);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("\n--- Return a Book ---");
                        Console.Write("Enter the title of the book you want to return: ");
                        string titleToReturn = Console.ReadLine();
                        service.ReturnBook(regularUser, titleToReturn);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                            Console.WriteLine("\n--- Your Borrowed Books ---");
                            if (regularUser.Card.Borrowbooks.Count == 0)
                            {
                                Console.WriteLine("You haven't borrowed any books yet!");
                            }
                            else
                            {
                                foreach (Book b in regularUser.Card.Borrowbooks)
                                {
                                    Console.WriteLine($"Title: {b.Title} | Author: {b.Author}");
                                }
                            }
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                        default:
                            Console.WriteLine("Invalid choice!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
           

        }
    }
}
