using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services.Tests.PlayerServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnAllPlayersFromDb_WhenThereArePlayersInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();
            var playersList = new List<Player>() { new Player(), new Player(), new Player() };
            var queryablePlayers = playersList.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(queryablePlayers);

            var playersService = new PlayersService(efRepoMock.Object, contextMock.Object);

            var expected = playersList.Count;
            var result = playersService.GetAll().Count();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnInstancesOfPlayersModelFromDb_WhenThereArePlayersInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();
            var playersList = new List<Player>() { new Player() };
            var queryablePlayers = playersList.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(queryablePlayers);

            var playersService = new PlayersService(efRepoMock.Object, contextMock.Object);

            var result = playersService.GetAll();

            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Player));
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNoPlayersInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();
            var emptyList = new List<Player>().AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(emptyList);

            var playersService = new PlayersService(efRepoMock.Object, contextMock.Object);

            var result = playersService.GetAll();
            CollectionAssert.IsEmpty(result);
        }
    }
}
