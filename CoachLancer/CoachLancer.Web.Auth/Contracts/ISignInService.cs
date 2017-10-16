using CoachLancer.Data.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
namespace CoachLancer.Web.Auth.Contracts
{
    public interface ISignInService : IDisposable
    {
        Task SignInAsync(User user, bool isPersistent, bool rememberBrowser);

        Task<bool> HasBeenVerifiedAsync();

        Task<string> GetVerifiedUserIdAsync();

        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);

        Task<bool> SendTwoFactorCodeAsync(string provider);

        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent);
    }
}
