using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IPracticalTest
    {
        //1. Reverse a String
        //Problem: Write a method to reverse a string without using built-in reverse functions.
        void ReverseString();

        //2. Check for Palindrome
        //Problem: Write a method to check if a string is a palindrome.
        void Palindrome();

        //3.Find Duplicates in an Array
        //Problem: Write a method to find duplicate elements in an array.

        void FindDuplicates();

        //4. Print Fibonacci Series
        //Problem: Generate the first N Fibonacci numbers.

        void PrintFibonacci();

        //5. Implement Singleton Pattern
        //Problem: Create a thread-safe Singleton class.

        void SingletoneExample();

        //6. LINQ Query to Filter and Sort
        //Problem: Use LINQ to filter even numbers and sort them in descending order.

        void FilterAndSortExample();

        //7. Find the First Non-Repeating Character
        //Problem: Find the first non-repeating character in a string.
        void FirstNonRepeatingCharExample();

        //8. Multithreading Example
        //Problem: Use multithreading to print numbers from 1 to 10 in two threads.

        void PrintNumbersExample();

        //9. Dependency Injection Example
        //Problem: Demonstrate Dependency Injection using interfaces.
        void DependencyInjectionExample();

        //10. Calculate Factorial Using Recursion
        //Problem: Write a method to calculate the factorial of a number using recursion.
        void FactorialExample();

        //1. Sort a Custom Object Using LINQ
        //Problem: Sort a list of employees by their salary in ascending and descending order.

        void sortLinqExample();

        //2. Custom Exception Handling
        //Problem: Create a custom exception class and demonstrate its usage.
        void CustExcepExample();

        //Factory Pattern
        //Problem: Create a factory to generate different types of shapes.
        void factorygenerateExample();

        //Strategy Pattern
        //Problem: Implement different strategies for calculating discounts.
        void strategiescalculatingExample();


        //1. LINQ: Grouping and Aggregation
        //Problem: Given a list of sales data, calculate the total sales for each product category.
        void GetCalculateSalesExample();

        //2. Multithreading: Producer-Consumer Problem
        //Problem: Implement a thread-safe producer-consumer queue using BlockingCollection.
        void MultithreadingExample();

        //3. OOP: Implement Polymorphism with Virtual Methods
        //Problem: Create a system where employees can have different types of bonuses based on their roles.
        void EmpBasedRolesExample();

        //4. Event Handling with Delegates
        //Problem: Implement a notification system that triggers an event when a file is uploaded.
        void EvenExamHandDelExample();

        //5. Design Patterns: Repository Pattern with Dependency Injection
        //Problem: Create a repository layer for accessing user data with dependency injection.
        void repositoryDiExample();

        //6. Async/Await with Task
        //Problem: Fetch data asynchronously from a simulated API.
        void FechDataAsyncExample();

        //7. Generic Repository with LINQ
        //Problem: Create a generic repository to perform CRUD operations.
        void GenericRepoExample();

        //ListingNode Example
        void ListingNodeExample();

        //The method takes an input string (inputString = "DDAABCCA").
        //Loop through get characte count
        void inputStringExample();

        //A partial class in C# allows a class to be split across multiple files,
        //which are combined by the compiler into a single class, improving code organization and collaboration.
        void PartialClassExample();


    }
}
