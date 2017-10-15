using CoachLancer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Bytes2you.Validation;

namespace CoachLancer.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IEfRepository<Player> playersRepository;
        private readonly ISaveContext context;

        public PlayersService(IEfRepository<Player> playersRepository,ISaveContext context)
        {
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

        public void UpdatePlayer(Player player)
        {
            Guard.WhenArgument(player, "player").IsNull().Throw();

            this.playersRepository.Update(player);
            this.context.Commit();
        }
    }
}
