using CoachLancer.Web.Infrastructure;
using System;

namespace CoachLancer.Web.Areas.Player.ViewModels
{
    public class PlayerViewModel : IMapFrom<CoachLancer.Data.Models.Player>
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}