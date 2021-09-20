using Application.Identity.Commands;
using Application.Identity.Commands.ChangePassword;
using Application.Identity.Commands.LoginUser;
using Application.Models;

namespace Application.Identity
{
    public interface IIdentity
    {
        Task<string> GetUserName(string userId);

        Task<bool> IsInRole(string userId, string role);

        Task<bool> Authorize(string userId, string policyName);

        Task<Result> DeleteUser(string userId);


        Task<Result<IUser>> Register(UserInputModel userInput);


        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);


        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
