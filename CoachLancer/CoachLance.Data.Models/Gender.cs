using CoachLance.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachLance.Data.Models
{
    public class Gender
    {
        private Gender(GenderEnum @enum)
        {
            this.Id = (int)@enum;
            this.Name = @enum.ToString();
        }

        protected Gender() { } //For EF

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public static implicit operator Gender(GenderEnum @enum) => new Gender(@enum);

        public static implicit operator GenderEnum(Gender gender) => (GenderEnum)gender.Id;
    }
}