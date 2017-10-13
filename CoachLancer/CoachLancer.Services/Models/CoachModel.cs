using CoachLance.Data.Models;
using System;
using System.Linq.Expressions;

namespace CoachLancer.Services.Models
{
    public class CoachModel
    {
        public CoachModel()
        {

        }

        public CoachModel(Coach coach)
        {
            if (coach != null)
            {
                this.Username = coach.UserName;
                this.UserSince = coach.CreatedOn;
            }
        }
        public int MyProperty { get; set; }

        public string Username { get; set; }

        public DateTime? UserSince { get; set; }

        public static Expression<Func<Coach, CoachModel>> Create
        {
            get
            {
                return c => new CoachModel()
                {
                    Username = c.UserName,
                    UserSince = c.CreatedOn
                };
            }
        }
    }
}
