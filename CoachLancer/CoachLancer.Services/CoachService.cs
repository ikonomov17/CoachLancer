using CoachLance.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services
{
    public class CoachService : ICoachService
    {
        private readonly IEfRepository<Coach> coachesRepository;
        private readonly ISaveContext context;

        public CoachService(IEfRepository<Coach> coachesRepository, ISaveContext context)
        {
            this.coachesRepository = coachesRepository;
            this.context = context;
        }

        public IEnumerable<CoachModel> GetAll()
        {
            return this.coachesRepository
                .All
                .Select(CoachModel.Create)
                .ToList();
        }

        public IEnumerable<CoachModel> GetLastRegisteredCoaches(int count)
        {
            return this.coachesRepository
                .All
                .OrderByDescending(c => c.CreatedOn)
                .Take(count)
                .Select(CoachModel.Create)
                .ToList();
        }
    }
}
