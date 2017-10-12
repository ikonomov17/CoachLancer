using CoachLance.Data.Models;
using System.Collections.Generic;

namespace CoachLancer.Services
{
    public interface ICoachService
    {
        IEnumerable<Coach> GetAll();
    }
}
