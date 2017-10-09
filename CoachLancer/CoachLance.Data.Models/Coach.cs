using System.Collections.Generic;

namespace CoachLance.Data.Models
{
    public class Coach : User
    {
        public virtual ICollection<Teams> Teams { get; set; }

        public virtual Rating Rating { get; set; }

        public ICollection<string> Licenses { get; set; }

        public double PriceForHourTraining { get; set; }

        public int Experience { get; set; }
    }
}
