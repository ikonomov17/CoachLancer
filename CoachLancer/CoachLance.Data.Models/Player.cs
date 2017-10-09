using System.Collections.Generic;

namespace CoachLance.Data.Models
{
    public class Player : User
    {
        public double Height { get; set; }

        public double Weight { get; set; }

        public Position Position { get; set; }

        public ICollection<string> Achievements { get; set; }
    }
}