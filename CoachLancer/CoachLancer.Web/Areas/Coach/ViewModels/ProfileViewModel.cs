using CoachLance.Data.Models.Enums;
using CoachLancer.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.Areas.Coach.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {

        }

        public ProfileViewModel(CoachModel coach)
        {
            this.FirstName = coach.FirstName;
            this.LastName = coach.LastName;
            this.Username = coach.Username;
            this.PricePerHourTraining = coach.PricePerHourTraining;
            var coachExperience = coach.StartedCoaching ?? DateTime.UtcNow;
            this.Experience = DateTime.UtcNow.Year - coachExperience.Year;
            //this.Licenses = coach.Licenses;
            this.Age = coach.Age;
            //this.Gender = coach.Gender;
            this.Location = coach.Location;
        }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Username { get; set; }

        [Display(Description ="Price per hour training", Name = "Price per hour training")]
        public double PricePerHourTraining { get; set; }

        public int Experience { get; set; }

        public ICollection<string> Licenses { get; set; }

        public int Age { get; set; }

        public GenderEnum Gender { get; set; }

        public string Location { get; set; }
    }
}