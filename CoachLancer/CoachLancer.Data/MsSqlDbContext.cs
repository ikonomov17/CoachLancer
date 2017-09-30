using CoachLance.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CoachLancer.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}
