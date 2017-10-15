using Microsoft.AspNet.Identity;
using System;
using System.Linq;

namespace CoachLancer.Web.Extensions
{
    public static class UserManagerExtensions
    {
        public static TUser FindByUsername<TUser, TKey>(this UserManager<TUser, TKey> manager, string userName)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            return manager.Users.Where(x => x.UserName == userName).FirstOrDefault();
        }
    }
}