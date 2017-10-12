using System;
using System.Collections.Generic;

namespace CoachLance.Data.Models
{
    public class Coach : User
    {
        public virtual ICollection<Teams> Teams { get; set; }

        public virtual Rating Rating { get; set; }

        public ICollection<string> Licenses { get; set; }

        public double PricePerHourTraining { get; set; }

        public DateTime StartedCoaching { get; set; }
    }
}
