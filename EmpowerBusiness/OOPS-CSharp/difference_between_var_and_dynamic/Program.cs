//Q. What is the difference between “var” and “dynamic” in C#?
//VAR - The type of the variable is decided by the compiler at compile time.
//DYNAMIC - The type of the variable is decided by the compiler at run time.
//When to use what?

var a = 10;

//a = "Interview";

dynamic b = 10;

b = "Happy";

Console.WriteLine(b);