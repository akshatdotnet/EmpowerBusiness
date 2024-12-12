using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    /*
     * 1. Private Variable
     * 2. Constructor
     * 3. Public Method
     * 4. Private Mehtod (Internal Call)     * 
     */
    public class StringManipulation : IStringManipulation
    {
        

        #region Public Method
        public void StringManipulate()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            // String Manipulations
            Console.WriteLine("\nString Manipulations:");
            Console.WriteLine($"Original String: {input}");
            Console.WriteLine($"Reversed String: {ReverseString(input)}");
            Console.WriteLine($"Uppercase: {input.ToUpper()}");
            Console.WriteLine($"Lowercase: {input.ToLower()}");

            string replacedString = input.Replace("bad", "good");
            Console.WriteLine($"Replaced 'bad' with 'good': {replacedString}");

            Console.WriteLine($"Is Palindrome: {IsPalindrome(input)}");
        }

        public void CountDublicateCharacters()
        {
            string inputString = "DDAABCCA";
            string output = CountCharacters(inputString);
            Console.WriteLine(output);
        }

        #endregion

        #region Private Method
        // Method to check if a string is a palindrome
        private bool IsPalindrome(string str)
        {
            // Remove white spaces and convert to lowercase
            string cleanStr = str.Replace(" ", "").ToLower();
            string reversedStr = ReverseString(cleanStr);
            return cleanStr == reversedStr;

        }

        // Method to reverse a string
        private string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string CountCharacters(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            StringBuilder result = new StringBuilder(); // To store the final result
            int count = 1; // Counter for character occurrences

            // Loop through the string to count consecutive characters
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++; // Increment the count if the character matches the previous one
                }
                else
                {
                    result.Append(input[i - 1]); // Append the character
                    result.Append(count); // Append its count
                    count = 1; // Reset count
                }
            }

            // Append the last character and its count
            result.Append(input[input.Length - 1]);
            result.Append(count);

            return result.ToString();
        }
        #endregion

    }

    /*
Key String Manipulation Methods in C#:
ToUpper() / ToLower():
Converts all characters in a string to uppercase or lowercase.
Replace(oldValue, newValue):
Replaces all occurrences of oldValue with newValue.
Trim(), TrimStart(), TrimEnd():
Removes whitespace or specified characters from the start, end, or both sides of a string.
Substring(startIndex, length):
Extracts a substring from the original string.
Split() / Join():
Splits a string into an array or joins an array into a string.
Reverse():
Reverses the order of characters in a string.
IndexOf() / Contains():
Finds the position of a substring or checks if a string contains another string.
StringBuilder:
For efficient string manipulations when frequent modifications are required.
*/

}
