using CoachLancer.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CoachLancer.Web.Auth.Contracts
{
    public interface IUserService : IDisposable
    {
        User GetByEmail(string email);

        User GetByUserName(string userName);

        Task<IdentityResult> CreateAsync(User user);

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<User> FindByNameAsync(string userName);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);

        Task<string> GenerateEmailConfirmationTokenAsync(string userId);

        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);

        Task<bool> IsEmailConfirmedAsync(string userId);

        Task SendEmailAsync(string userId, string subject, string body);

        Task<string> GeneratePasswordResetTokenAsync(string userId);

        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);

        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);
    }
}