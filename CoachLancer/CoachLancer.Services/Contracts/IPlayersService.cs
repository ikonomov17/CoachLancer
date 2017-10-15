using CoachLancer.Data.Models;
using System.Collections.Generic;

namespace CoachLancer.Services.Contracts
{
    public interface IPlayersService
    {
        IEnumerable<Player> GetAll();

        Player GetPlayerByUsername(string username);

        void UpdatePlayer(Player player);
    }
}
