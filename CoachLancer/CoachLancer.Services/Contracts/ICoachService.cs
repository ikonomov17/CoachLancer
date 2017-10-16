using CoachLancer.Data.Models;
using CoachLancer.Data.Models.Contracts;
using System.Collections.Generic;

namespace CoachLancer.Services.Contracts
{
    public interface ICoachService
    {
        IEnumerable<Coach> GetAll();

        IEnumerable<Coach> GetLastRegisteredCoaches(int count);

        Coach GetCoachByUsername(string username);

        void UpdateCoach(Coach model);

        void AddGroupToCoach(string username, IGroups group);

        bool GroupBelongsToCoach(string username, int groupId);
    }
}
