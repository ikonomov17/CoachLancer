namespace CoachLance.Data.Models
{
    public class CoachesRatings
    {
        public int CoachId { get; set; }

        public int PlayerId { get; set; }

        public Rating Rating { get; set; }
    }
}
