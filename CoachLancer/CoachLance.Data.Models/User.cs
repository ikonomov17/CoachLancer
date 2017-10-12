using CoachLance.Data.Models.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using CoachLance.Data.Models.Enums;

namespace CoachLance.Data.Models
{
    public class User : IdentityUser, IDeletable, IAuditable
    {
        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        public virtual Gender Gender { get; set; }

        public string Location { get; set; }

        public ICollection<string> Languages { get; set; }

        public string Nationality { get; set; }

        public string AboutMe { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Roles", this.Roles.ToString()));
            return userIdentity;
        }
    }
}
