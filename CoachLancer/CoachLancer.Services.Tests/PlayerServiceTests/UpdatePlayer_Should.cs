using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;

namespace CoachLancer.Services.Tests.PlayerServiceTests
{
    [TestFixture]
    public class UpdatePlayer_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPlayerIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => playerService.UpdatePlayer(null));
        }

        [Test]
        public void CallRepositoryUpdateMethod_WhenExecuted()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);
            var player = new Mock<Player>();

            // Act
            playerService.UpdatePlayer(player.Object);

            // Assert
            efRepoMock.Verify(e => e.Update(player.Object), Times.Once);
        }

        [Test]
        public void CallContextCommitMethod_WhenExecuted()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);
            var player = new Mock<Player>();

            // Act
            playerService.UpdatePlayer(player.Object);

            // Assert
            contextMock.Verify(c => c.Commit(), Times.Once);
        }
    }
}
