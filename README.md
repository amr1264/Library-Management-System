# 📚 Console Library Management System

A robust, enterprise-architected Console Application built with **C#** and **.NET**. This project showcases high-level proficiency in **Object-Oriented Programming (OOP)**, input validation defenses, dynamic memory architectures, and fluent string algorithms.

---

## 📐 System Architecture & OOP Principles

This system follows a clean **Service-Oriented Design**, strictly decoupling the Presentation Layer (UI) from the Core Business Logic.

mermaid
classDiagram
    class User {
        <<Abstract>>
        +int Id
        +string Name
    }
    class Librarian {
        +int EmployeeNumber
    }
    class LibraryUser {
        +LibraryCard Card
    }
    class LibraryCard {
        +int CardId
        +List~Book~ BorrowedBooks
    }
    class Book {
        +string Title
        +string Author
        +bool IsAvailable
    }
    class Library {
        <<Static>>
        +List~Book~ BooksList
        +Display()
        +BorrowBookFromList()
        +ReturnBookToList()
    }
    class LibraryService {
        +BorrowBook(LibraryUser, string)
        +ReturnBook(LibraryUser, string)
    }

    User <|-- Librarian : Inheritance
    User <|-- LibraryUser : Inheritance
    LibraryUser *-- LibraryCard : Composition (Has-A)
    LibraryCard "1" --> "0..*" Book : Aggregation
    LibraryService ..> Library : Uses
    LibraryService ..> LibraryUser : Processes


### 🧠 Core OOP Implementation:
 * **Abstraction & Inheritance:** The abstract class User acts as the secure foundational blueprint for both Librarian and LibraryUser.
 * **Composition (Has-A Relationship):** A LibraryUser strictly *has a* LibraryCard. The card instance lifecycle is bound directly to the user.
 * **Encapsulation & Service Layer:** Complete protection of internal state; all domain actions are safely contained within the LibraryService layer.
## 🛡️ The Engineering Journey: Challenges & Solutions
Building this project wasn't just about writing syntax; it was a battle against typical runtime pitfalls. Here is how core architectural roadblocks were solved:
### 1. The Application State & Memory Lifecycle Dilemma
 * **The Challenge:** While cycling between the Librarian role (to add books) and the LibraryUser role, the program initially exited the runtime context, instantly resetting the volatile static collections. Books would completely vanish.
 * **The Engineering Solution:** Encapsulated the entire role-selection framework inside a resilient while (true) event loop in the LibraryUI. This kept the process active within the same thread execution context, ensuring memory persistence across roles.
### 2. Guarding Against NullReferenceException
 * **The Challenge:** Attempting to append borrowed books to the user's collection crashed the environment because the BorrowedBooks list inside the nested property user.Card.BorrowedBooks was evaluated as null upon instantiation.
 * **The Engineering Solution:** Implemented greedy constructor instantiation inside LibraryCard. The inner list is now explicitly initialized upon card creation (BorrowedBooks = new List<Book>();), enforcing structural integrity.
### 3. Defending the Runtime Environment (int.TryParse Pattern)
 * **The Challenge:** Direct reliance on Convert.ToInt32() or integer casts triggered severe app crashes whenever a user mistakenly or maliciously typed string letters into numeric menus.
 * **The Engineering Solution:** Replaced unstable typecasting with the conditional **int.TryParse()** framework paired with an isolated iterative query flow:
   csharp
   int choice;
   while (!int.TryParse(Console.ReadLine(), out choice)) {
       Console.WriteLine("Invalid input execution. Numbers only.");
   }
   
   
   This cleanly catches formatting errors *before* the compiler triggers an exception.
### 4. Search Rigidity & String Normalization
 * **The Challenge:** Exact equality matches (==) forced users to guess the precise case and spacing of book titles, leading to false "Book Not Found" errors.
 * **The Engineering Solution:** Re-engineered the matching system utilizing fluent string chaining. Implemented .ToLower(), .Trim(), and replaced absolute matches with **.Contains()** to build a modern, case-insensitive partial search index.
## 🚀 Future Roadmap (.NET Backend Transformation)
This project serves as the foundational stepping stone for my transition into professional **.NET Backend Engineering**. The upcoming architectural phases will include:
 * [ ] **Phase 1:** Discarding transient in-memory lists and configuring a relational **SQL Server Database**.
 * [ ] **Phase 2:** Injecting **Entity Framework Core (EF Core)** to manage Object-Relational Mapping (ORM) and migrations.
 * [ ] **Phase 3:** Porting the logic from a Console UI into a modern **ASP.NET Core Web API** utilizing RESTful design pattern
