using CoachLance.Data.Models.Enums;
using CoachLancer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoachLancer.Web.Areas.Coach.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {

        }

        public ProfileViewModel(CoachModel coach)
        {
            this.Username = coach.Username;
        }

        public string Username { get; set; }

        public double PricePerHourTraining { get; set; }

        public int Experience { get; set; }

        public ICollection<string> Licenses { get; set; }

        public int Age { get; set; }

        public GenderEnum Gender { get; set; }

        public string Location { get; set; }
    }
}