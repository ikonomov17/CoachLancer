using CoachLancer.Data.Models;
using CoachLancer.Data.Models.Contracts;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services.Tests.PlayerServiceTests
{
    [TestFixture]
    public class PlayerBelongsToGroup_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUsernameIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);
            var validId = 10;

            Assert.Throws<ArgumentNullException>(() => playerService.PlayerBelongsToGroup(null, validId));
        }

        [TestCase(0)]
        [TestCase(-91)]
        public void ThrowArgumentOutOfRangeException_WhenIdIsZeroOrLess(int invalidGroupId)
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);
            var validUsername = "username";

            Assert.Throws<ArgumentOutOfRangeException>(() => playerService.PlayerBelongsToGroup(validUsername, invalidGroupId));
        }

        [Test]
        public void ReturnTrue_WhenInputParametersAreValid()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var player = new Mock<Player>();
            var validUsername = "username";
            player.Setup(p => p.UserName).Returns(validUsername);

            var searchId = 21;
            var groupsList = new List<Groups>()
            {
                new Groups() { Id = 20 },
                new Groups() { Id = searchId }
            };

            player.SetupGet(p => p.Groups).Returns(groupsList);
            var players = new List<Player>() { player.Object }.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(players);

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);
            var result = playerService.PlayerBelongsToGroup(validUsername, searchId);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenUsernameIsCorrectAndGroupIdNot()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var player = new Mock<Player>();
            var validUsername = "username";
            player.Setup(p => p.UserName).Returns(validUsername);

            var groupsList = new List<Groups>()
            {
                new Groups() { Id = 20 },
                new Groups() { Id = 21 }
            };

            player.SetupGet(p => p.Groups).Returns(groupsList);
            var players = new List<Player>() { player.Object }.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(players); ;
            var invalidId = 1;
            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);
            var result = playerService.PlayerBelongsToGroup(validUsername, invalidId);

            Assert.IsFalse(result);
        }
    }
}
