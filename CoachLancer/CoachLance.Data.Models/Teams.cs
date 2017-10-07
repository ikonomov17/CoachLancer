using System.Collections.Generic;

namespace CoachLance.Data.Models
{
    public class Teams
    {
        public int Id { get; set; }

        public int TeamSize { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}