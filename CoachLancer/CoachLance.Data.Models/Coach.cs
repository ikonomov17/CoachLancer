using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Data.Models
{
    public class Coach : User
    {
        public virtual ICollection<Groups> Teams { get; set; }

        public double PricePerHourTraining { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartedCoaching { get; set; }
    }
}
