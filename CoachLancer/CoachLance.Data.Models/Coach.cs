using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachLance.Data.Models
{
    public class Coach : User
    {
        public virtual ICollection<Teams> Teams { get; set; }

        public virtual Rating Rating { get; set; }

        public ICollection<string> Licenses { get; set; }

        public double PricePerHourTraining { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartedCoaching { get; set; }
    }
}
