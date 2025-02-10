using Empower.Business;
using Empower.Business.Account;
using Empower.Business.Email;
using Empower.Models.Account;
using Empower.Models.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Empower.Business.CommonUtilities.ConstantBL;

namespace Empower.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : BaseController
    {
        private readonly IAccountBL _serviceUser;
        private readonly IUserRoleBL _serviceUserRole;
        private readonly IEmailBL _serviceEmail;

        public ManageUserController(
            IEmailBL serviceEmail,
            IUserRoleBL serviceUserRole,
            IAccountBL serviceUser)
        {
            _serviceUser = serviceUser;
            _serviceUserRole = serviceUserRole;
            _serviceEmail = serviceEmail;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(string filter = "")
        {
            var users = await _serviceUser.GetAllUser(filter);
            return Ok(users);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _serviceUserRole.GetAllAdminRole();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserInputDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.Password = Randomize.GetRandomPassword();
            model.CreatedBy = 0; // Replace with actual user ID from context.

            var result = await _serviceUser.InsertUser(model);
            if (result.UserMobileAlredyExist)
                return Conflict(new { message = "Mobile number already exists." });

            if (result.UserEmailAlredyExist)
                return Conflict(new { message = "Email address already exists." });

            var mailRequest = new MailRequestInputDTO
            {
                ToEmail = model.UserEmail,
                Subject = EmailSubjectConstants.SendWelcomeEmailToNewAddedAdminUser,
                MailType = EmailTypeConstants.SendWelcomeEmailToNewAddedAdminUser,
                EmailTemplatePath = EmailTemplatePathConstants.SendWelcomeEmailToNewAddedAdminUser,
                Email = model.UserEmail,
                Password = model.Password
            };

            //To Do Template changes
            //var mailResult = await _serviceEmail.SendCommonEmail(mailRequest);
            //if (mailResult.IsError)
            //    return Ok(new { message = "User added, but email could not be sent.", mailResult.ErrorMessage });

            return Ok(new { message = "User successfully added.", user = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _serviceUser.GetUserById(id);
            if (user == null)
                return NotFound(new { message = "User not found." });

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInputDTO model)
        {
            if (id != model.Id)
                return BadRequest(new { message = "User ID mismatch." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.UpdatedBy = 1; // Replace with actual user ID from context.

            var result = await _serviceUser.UpdateUser(model);
            if (result.UserMobileAlredyExist)
                return Conflict(new { message = "Mobile number already exists." });

            if (result.UserEmailAlredyExist)
                return Conflict(new { message = "Email address already exists." });

            return Ok(new { message = "User successfully updated.", user = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var model = new UserDeleteInputDto
            {
                Id = id,
                UserId = 1 // Replace with actual user ID from context.
            };

            var result = await _serviceUser.RemoveUserById(model);
            if (!result.IsAdminUserDeleted)
                return BadRequest(new { message = "User could not be deleted." });

            return Ok(new { message = "User successfully deleted." });
        }


    }
}
