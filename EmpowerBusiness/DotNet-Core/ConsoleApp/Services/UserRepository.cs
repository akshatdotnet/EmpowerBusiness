using ConsoleApp.Models;
using System.Collections.Generic;


//Single Responsibility Principle (SRP)
//Each class should have only one reason to change.
//Example: Create a User model and a UserRepository for data operations.

public class UserRepository
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }
}
