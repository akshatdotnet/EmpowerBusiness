//Extension method concept allows you to add new methods in the existing class,
//WITHOUT MODIFYING the source code of the original class.

string test = "HelloWorld";

string left = test.Substring(0, 5);

Console.WriteLine(left);

string right = test.RightSubstring(5);

Console.WriteLine(right);

//Output: Hello World

public static class StringExtensions
{
    public static string RightSubstring(this String s, int count)
    {
        return s.Substring(s.Length - count, count);
    }
}