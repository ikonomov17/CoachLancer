using Bytes2you.Validation;
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
            Guard.WhenArgument(coachesRepository, "coaches repository").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
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
            Guard.WhenArgument(count, "Coaches count").IsLessThan(0).Throw();
            return this.coachesRepository
                .All
                .OrderByDescending(c => c.CreatedOn)
                .Take(count)
                .Select(CoachModel.Create)
                .ToList();
        }

        public CoachModel GetCoachByUsername(string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();

            return this.coachesRepository.All
                .Where(c => c.UserName == username)
                .Select(CoachModel.Create)
                .FirstOrDefault();
        }

        //public void UpdateCoach(CoachModel model)
        //{
        //    this.coachesRepository.Update(model);
        //    this.context.Commit();
        //}
    }
}
