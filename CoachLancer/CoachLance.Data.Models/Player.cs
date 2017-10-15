using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Data.Models
{
    public class Player : User
    {
        public Player()
        {
            this.Groups = new HashSet<Groups>();
        }

        public double Height { get; set; }

        public double Weight { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }

        //public Position Position { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartedTraining { get; set; }
    }
}