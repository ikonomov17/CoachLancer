using System;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Data.Models
{
    public class Coach : User
    {
        //public virtual ICollection<Teams> Teams { get; set; }

        public double PricePerHourTraining { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartedCoaching { get; set; }
    }
}
