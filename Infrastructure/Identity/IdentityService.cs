using Application.Identity;
using Application.Identity.Commands;
using Application.Identity.Commands.ChangePassword;
using Application.Identity.Commands.LoginUser;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    internal class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly UserManager<User> userManager;
        private readonly IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory;
        private readonly IAuthorizationService authorizationService;

        public IdentityService(
            IJwtTokenGenerator jwtTokenGenerator,
            UserManager<User> userManager,
            IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userManager = userManager;
            this.userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            this.authorizationService = authorizationService;
        }

        public async Task<string> GetUserName(string userId)
        {
            var user = await userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<bool> IsInRole(string userId, string role)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            return await userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> Authorize(string userId, string policyName)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            var principal = await userClaimsPrincipalFactory.CreateAsync(user);

            var result = await authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<Result> DeleteUser(string userId)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }

            return Result.Success;
        }

        public async Task<Result<IUser>> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var token = this.jwtTokenGenerator.GenerateToken(user, roles);

            return new LoginSuccessModel(user.Id, token);
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(changePasswordInput.UserId);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }
}
