﻿//Q. What is “Static” class? When to use it?
//A static class is a class which object cannot be created, and which cannot be inherited.

//What is the use of creating Static classes?
//Static classes are used as containers for static members like methods, constructors and others.

Console.WriteLine(MyCollege.collegeName);
MyCollege.CollegeBranch();

Console.ReadLine();
public static class MyCollege
{
    //static fields 
    public static string collegeName;
    public static string address;

    //static constructor 
    static MyCollege()
    {
        collegeName = "ABC College";
    }

    // static method 
    public static void CollegeBranch()
    {
        Console.WriteLine("Computers");
    }

}