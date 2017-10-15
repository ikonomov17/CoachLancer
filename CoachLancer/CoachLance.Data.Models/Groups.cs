using System.Collections.Generic;

namespace CoachLancer.Data.Models
{
    public class Groups
    {
        public Groups()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TrainingsPerWeek { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}