// See https://aka.ms/new-console-template for more information
using ConsoleApp;



string sentence = "I am Tim";

// Split the sentence into words
string[] words = sentence.Split(' ');

// Reverse the array of words
Array.Reverse(words);

// Join the reversed words back into a sentence
string reversedSentence = string.Join(" ", words);

// Output the result
Console.WriteLine("Original Sentence: " + sentence);
Console.WriteLine("Reversed Sentence: " + reversedSentence);

//try
//{
//    int x = 0; int y = 0;
//   // int x = 5 / 0; // This will throw a DivideByZeroException
//    //Console.WriteLine(x);
//   // throw new Exception();
//    throw new DivideByZeroException("This is a divide by zero exception.");

//}
//catch (DivideByZeroException ex)
//{
//    Console.WriteLine("Caught DivideByZeroException: " + ex.Message); // Specific exception handling
//}
//catch (NullReferenceException ex)
//{
//    Console.WriteLine("Caught NullReferenceException: " + ex.Message); // Specific exception handling
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Caught Exception: " + ex.Message); // General exception handling
//}



//Q1
//var greetingService = new GreetingService();
//var program = new Question1(greetingService);
//program._greetingService.Greet("John");

