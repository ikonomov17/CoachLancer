using CoachLance.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachLance.Data.Models
{
    public class Rating
    {
        private Rating(RatingEnum @enum)
        {
            this.Id = (int)@enum;
            this.Name = @enum.ToString();
        }

        protected Rating() { } //For EF

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public static implicit operator Rating(RatingEnum @enum) => new Rating(@enum);

        public static implicit operator RatingEnum(Rating rating) => (RatingEnum)rating.Id;
    }
}