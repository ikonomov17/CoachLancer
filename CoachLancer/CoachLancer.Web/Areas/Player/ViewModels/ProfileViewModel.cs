using CoachLancer.Web.CustomAttributes;
using CoachLancer.Web.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.Areas.Player.ViewModels
{
    public class ProfileViewModel : IMapFrom<CoachLancer.Data.Models.Player>
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

        public int Height { get; set; }

        public int Weight { get; set; }

        public DateTime? StartedTraining { get; set; }

        public string Location { get; set; }

        [DateTypeRange]
        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }

        //public GenderEnum Gender { get; set; }

    }
}