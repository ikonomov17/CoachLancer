﻿using Bytes2you.Validation;
using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IEfRepository<Groups> groupsRepository;
        private readonly ISaveContext context;

        public GroupsService(IEfRepository<Groups> groupsRepository, ISaveContext context)
        {
            Guard.WhenArgument(groupsRepository, "groups repository").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.groupsRepository = groupsRepository;
            this.context = context;
        }

        public IEnumerable<Groups> GetAll()
        {
            return this.groupsRepository
                .All
                .ToList();
        }

        public IEnumerable<Groups> GetLatestCreatedGroups(int count)
        {
            Guard.WhenArgument(count, "count").IsLessThan(0).Throw();

            return this.groupsRepository
                .All
                .OrderByDescending(g => g.CreatedOn)
                .Take(count)
                .ToList();
        }

        public void CreateGroup(Groups model)
        {
            Guard.WhenArgument(model, "group model").IsNull().Throw();

            this.groupsRepository.Add(model);
            this.context.Commit();
        }

        public Groups GetGroupById(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThanOrEqual(0).Throw();

            return this.groupsRepository.All.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Groups> GetGroupsByName(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            return this.groupsRepository.All.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
