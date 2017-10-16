using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoachLancer.Data.Models;
using CoachLancer.Web.Infrastructure;

namespace CoachLancer.Web.Areas.Admin.Models.CoachViewModels
{
    public class CoachTableViewModel : IMapFrom<Data.Models.Coach>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public ICollection<Groups> Groups { get; set; }

        public double PricePerHourTraining { get; set; }
    }
}