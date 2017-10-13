using CoachLance.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System;

namespace CoachLancer.Services.Tests.CoachServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIEfRepositoryIsNull()
        {
            var contextMock = new Mock<ISaveContext>();

            Assert.Throws<ArgumentNullException>(() => new CoachService(null, contextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenISaveContextIsNull()
        {
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            Assert.Throws<ArgumentNullException>(() => new CoachService(efRepoMock.Object,null));
        }

        [Test]
        public void ReturnInstaceOfCoachServiceClass_WhenValidArgumentsArePassed()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            Assert.IsInstanceOf<CoachService>(coachService);
        }

    }
}
