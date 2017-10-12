using CoachLance.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
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

        public IEnumerable<Coach> GetAll()
        {
            return this.coachesRepository.All.ToList();
        }
    }
}
