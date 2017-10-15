using CoachLancer.Data.Models;
using System.Collections.Generic;

namespace CoachLancer.Services.Contracts
{
    public interface ICoachService
    {
        IEnumerable<Coach> GetAll();

        IEnumerable<Coach> GetLastRegisteredCoaches(int count);

        Coach GetCoachByUsername(string username);

        void UpdateCoach(Coach model);

        void AddGroupToCoach(string username, Groups group);

        bool GroupBelongsToCoach(string username, int groupId);
    }
}
