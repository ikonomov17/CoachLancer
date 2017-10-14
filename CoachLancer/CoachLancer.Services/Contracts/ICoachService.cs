﻿using CoachLancer.Data.Models;
using System.Collections.Generic;

namespace CoachLancer.Services
{
    public interface ICoachService
    {
        IEnumerable<Coach> GetAll();

        IEnumerable<Coach> GetLastRegisteredCoaches(int count);

        Coach GetCoachByEmail(string email);

        void UpdateCoach(Coach model);
    }
}
