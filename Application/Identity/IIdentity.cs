using Application.Models;

namespace Application.Identity
{
    public interface IIdentity
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);


        //Task<Result<IUser>> Register(UserInputModel userInput);

        //Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        //Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
