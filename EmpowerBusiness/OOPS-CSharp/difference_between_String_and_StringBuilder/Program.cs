//String is IMMUTABLE in C#. That mean you couldn’t modify it after it is created. 
//StringBuilder is MUTABLE in C#. 


using System.Text;


    String str1 = "Interview";

    str1 = str1 + "Happy";

    Console.WriteLine(str1);

    StringBuilder str2 = new StringBuilder();

    str2.Append("Interview");

    str2.Append("Happy");

    Console.WriteLine(str2);

    Console.ReadLine();

