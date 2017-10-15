using CoachLancer.Web.CustomAttributes;
using CoachLancer.Web.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.Areas.Coach.ViewModels
{
    public class ProfileViewModel : IMapFrom<CoachLancer.Data.Models.Coach>
    {
        [Required]
        [StringLength(100, ErrorMessage = "First name should be between 1 and 100 symbols", MinimumLength = 1)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last name should be between 1 and 100 symbols", MinimumLength = 1)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Price per hour should be between 0 and 100")]
        [Display(Description = "Price per hour training", Name = "Price per hour training")]
        public double PricePerHourTraining { get; set; }

        public int Experience { get; set; }

        public DateTime? StartedCoaching { get; set; }

        public string Location { get; set; }

        [DateTypeRange]
        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        //public GenderEnum Gender { get; set; }

        //public ICollection<string> Licenses { get; set; }
    }
}