//Q.What is Polymorphism and what are its types?
//Polymorphism is the ability of a variable, object, or function to take on MULTIPLE FORMS. 

Polymorphism obj = new Polymorphism();
int i = obj.Add(50, 60);
string str = obj.Add("Interview", "Happy");
Console.WriteLine(i + " - " + str);
Console.ReadLine();

public class Polymorphism
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public string Add(string str1, string str2)
    {
        return str1 + str2;
    }
}
