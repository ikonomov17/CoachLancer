using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachLance.Data.Models
{
    public class Player : User
    {
        public double Height { get; set; }

        public double Weight { get; set; }

        //public Position Position { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartedTraining { get; set; }
    }
}