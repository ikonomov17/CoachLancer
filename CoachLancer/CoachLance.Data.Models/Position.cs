using CoachLance.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachLance.Data.Models
{
    public class Position
    {
        private Position(PositionEnum @enum)
        {
            this.Id = (int)@enum;
            this.Name = @enum.ToString();
        }

        protected Position() { } //For EF

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public static implicit operator Position(PositionEnum @enum) => new Position(@enum);

        public static implicit operator PositionEnum(Position position) => (PositionEnum)position.Id;
    }
}
