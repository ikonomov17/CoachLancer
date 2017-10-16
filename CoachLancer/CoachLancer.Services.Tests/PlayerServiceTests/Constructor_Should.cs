using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System;

namespace CoachLancer.Services.Tests.PlayerServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIEfRepositoryIsNull()
        {
            var contextMock = new Mock<ISaveContext>();

            Assert.Throws<ArgumentNullException>(() => new PlayersService(null, contextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenISaveContextIsNull()
        {
            var efRepoMock = new Mock<IEfRepository<Player>>();

            Assert.Throws<ArgumentNullException>(() => new PlayersService(efRepoMock.Object, null));
        }

        [Test]
        public void ReturnInstaceOfPlayersServiceClass_WhenValidArgumentsArePassed()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();
            var playersService = new PlayersService(efRepoMock.Object, contextMock.Object);

            Assert.IsInstanceOf<PlayersService>(playersService);
        }

    }
}

