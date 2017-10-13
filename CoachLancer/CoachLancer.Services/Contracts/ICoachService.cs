using CoachLancer.Services.Models;
using System.Collections.Generic;

namespace CoachLancer.Services
{
    public interface ICoachService
    {
        IEnumerable<CoachModel> GetAll();

        IEnumerable<CoachModel> GetLastRegisteredCoaches(int count);
    }
}
