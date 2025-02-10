using Empower.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.Business.Account
{
    public interface IAccountBL
    {
        Task<SignUpOutputDTO> AddUser(SignUpInputDTO login);
        Task<LoginOutputDTO?> GetValidUser(LoginInputDTO login);
        Task<string> GenerateUserForgotPasswordToken(string email);

        Task<bool> IsUserEmailExist(string email, int id = 0);
        Task<bool> IsUserMobileExist(string mobile, int id = 0);

        Task MarkUserActive(int userId);

        Task<List<UserDTO>> GetAllUser();
        Task<UserOutputDTO> GetAllUser(string filter = "");

        Task<UserInsertOutputDto> InsertUser(UserInputDTO model);

        Task<UserDTO?> GetUserById(int id);

        Task<UserUpdateOutputDto> UpdateUser(UserInputDTO model);

        Task<UserDeleteOutputDto> RemoveUserById(UserDeleteInputDto model);


    }
}
