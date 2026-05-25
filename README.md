# 📚 Console Library Management System

A robust, enterprise-architected Console Application built with C# and .NET. This project showcases high-level proficiency in Object-Oriented Programming (OOP), input validation defenses, dynamic memory architectures, and fluent string algorithms.

---

## 📐 System Architecture & OOP Principles

This system follows a clean Service-Oriented Design, strictly decoupling the Presentation Layer (UI) from the Core Business Logic.

`mermaid
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

    Core OOP Implementation:
