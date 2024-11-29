
namespace ConsoleApp1
{
    [Serializable]
    internal class InvalidAgeException : Exception
    {
        public InvalidAgeException()
        {
        }

        public InvalidAgeException(string? message) : base(message)
        {
        }

        public InvalidAgeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}