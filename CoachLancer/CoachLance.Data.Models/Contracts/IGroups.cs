using System.Collections.Generic;

namespace CoachLancer.Data.Models.Contracts
{
    public interface IGroups : IDeletable, IAuditable
    {
        int Id { get; set; }

        string Name { get; set; }

        int TrainingsPerWeek { get; set; }

        ICollection<Player> Players { get; set; }
    }
}
