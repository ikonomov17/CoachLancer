using CoachLancer.Data.Models;
using System.Collections.Generic;

namespace CoachLancer.Services.Contracts
{
    public interface IGroupsService
    {
        IEnumerable<Groups> GetAll();

        IEnumerable<Groups> GetLatestCreatedGroups(int count);

        void CreateGroup(Groups model);

        Groups GetGroupById(int id);
    }
}
