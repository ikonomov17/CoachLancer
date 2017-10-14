using CoachLancer.Web.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.Areas.Coach.ViewModels
{
    public class ProfileViewModel : IMapFrom<CoachLancer.Data.Models.Coach>
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Description = "Price per hour training", Name = "Price per hour training")]
        public double PricePerHourTraining { get; set; }

        public int Experience { get; set; }

        public DateTime? StartedCoaching { get; set; }
        
        public string Location { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        //public GenderEnum Gender { get; set; }

        //public ICollection<string> Licenses { get; set; }
    }
}