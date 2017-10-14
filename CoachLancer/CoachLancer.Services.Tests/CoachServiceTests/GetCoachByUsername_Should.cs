using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services.Tests.CoachServiceTests
{
    [TestFixture]
    public class GetCoachByUsername_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenNoUsernameIsProvided()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => coachService.GetCoachByUsername(null));
        }

        [Test]
        public void ReturnCorrectUser_WhenThereIsUserWithProvidedUsername()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();


            var username = "Dragan";
            var expectedCoach = new Coach() { UserName = username };
            var coaches = new List<Coach>()
            {
                new Coach() { UserName = "Petkan"},
                expectedCoach,
                new Coach() { UserName = "Svetlin"}
            };

            efRepoMock.Setup(e => e.All).Returns(coaches.AsQueryable());

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            Assert.AreSame(expectedCoach, coachService.GetCoachByUsername(username));
        }

    }
}
