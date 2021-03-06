﻿using Bytes2you.Validation;
using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using CoachLancer.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IEfRepository<Player> playersRepository;
        private readonly ISaveContext context;

        public PlayersService(IEfRepository<Player> playersRepository,ISaveContext context)
        {
            Guard.WhenArgument(playersRepository, "players repository").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.playersRepository = playersRepository;
            this.context = context;
        }

        public IEnumerable<Player> GetAll()
        {
            return this.playersRepository.All;
        }

        public Player GetPlayerByUsername(string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();

            return this.playersRepository.All.FirstOrDefault(p => p.UserName == username);
        }

        public bool PlayerBelongsToGroup(string name, int id)
        {
            Guard.WhenArgument(name, "username").IsNullOrEmpty().Throw();
            Guard.WhenArgument(id, "group id").IsLessThanOrEqual(0).Throw();

            return this.playersRepository
                .All
                .FirstOrDefault(p => p.UserName == name)
                .Groups
                .FirstOrDefault(g => g.Id == id) != null;
        }

        public void UpdatePlayer(Player player)
        {
            Guard.WhenArgument(player, "player").IsNull().Throw();

            this.playersRepository.Update(player);
            this.context.Commit();
        }
    }
}
