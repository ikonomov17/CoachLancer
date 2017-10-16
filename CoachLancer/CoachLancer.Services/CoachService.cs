using Bytes2you.Validation;
using CoachLancer.Data.Models;
using CoachLancer.Data.Models.Contracts;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services.Contracts;
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

        public IEnumerable<Coach> GetAll()
        {
            return this.coachesRepository
                .All
                .ToList();
        }

        public IEnumerable<Coach> GetLastRegisteredCoaches(int count)
        {
            Guard.WhenArgument(count, "Coaches count").IsLessThan(0).Throw();

            return this.coachesRepository
                .All
                .OrderByDescending(c => c.CreatedOn)
                .Take(count)
                .ToList();
        }

        public Coach GetCoachByUsername(string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();

            return this.coachesRepository.All
                .Where(c => c.UserName == username)
                .FirstOrDefault();
        }

        public void UpdateCoach(Coach model)
        {
            Guard.WhenArgument(model, "coach model").IsNull().Throw();

            this.coachesRepository.Update(model);
            this.context.Commit();
        }

        public void AddGroupToCoach(string username, IGroups group)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();
            Guard.WhenArgument(group, "group").IsNull().Throw();

            var coach = this.coachesRepository
                .All
                .Where(c => c.UserName == username)
                .FirstOrDefault();

            coach.Groups.Add(group as Groups);
            this.coachesRepository.Update(coach);
            this.context.Commit();
        }

        public bool GroupBelongsToCoach(string username, int groupId)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();
            Guard.WhenArgument(groupId, "group Id").IsLessThanOrEqual(0).Throw();

            return this.coachesRepository
                .All
                .FirstOrDefault(x => x.UserName == username)
                .Groups
                .FirstOrDefault(x => x.Id == groupId) != null;
        }
    }
}
