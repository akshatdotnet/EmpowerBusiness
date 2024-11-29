using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class UserService : IUserOperations
    {
        private readonly UserRepository _repository = new();

        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }
    }

}
