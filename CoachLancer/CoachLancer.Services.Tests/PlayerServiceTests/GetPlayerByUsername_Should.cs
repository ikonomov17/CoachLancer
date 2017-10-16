using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;

namespace CoachLancer.Services.Tests.PlayerServiceTests
{
    [TestFixture]
    public class GetPlayerByUsername_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenNoUsernameIsProvided()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => playerService.GetPlayerByUsername(null));
        }

        [Test]
        public void ReturnCorrectUser_WhenThereIsUserWithProvidedUsername()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Player>>();


            var username = "Dragan";
            var expectedCoach = new Player() { UserName = username };
            var coaches = new List<Player>()
                {
                    new Player() { UserName = "Petkan"},
                    expectedCoach,
                    new Player() { UserName = "Svetlin"}
                };

            efRepoMock.Setup(e => e.All).Returns(coaches.AsQueryable());

            var playerService = new PlayersService(efRepoMock.Object, contextMock.Object);

            Assert.AreSame(expectedCoach, playerService.GetPlayerByUsername(username));
        }


    }
}
