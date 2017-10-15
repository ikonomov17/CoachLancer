using CoachLancer.Data.Models.Contracts;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachLancer.Data.Models
{
    public class Groups : IDeletable, IAuditable
    {
        public Groups()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TrainingsPerWeek { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}