using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System;

namespace CoachLancer.Services.Tests.CoachServiceTests
{
    [TestFixture]
    public class UpdateCoach_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenCoachIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => coachService.UpdateCoach(null));
        }

        [Test]
        public void CallRepositoryUpdateMethod_WhenExecuted()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);
            var player = new Mock<Coach>();

            // Act
            coachService.UpdateCoach(player.Object);

            // Assert
            efRepoMock.Verify(e => e.Update(player.Object), Times.Once);
        }

        [Test]
        public void CallContextCommitMethod_WhenExecuted()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);
            var player = new Mock<Coach>();

            // Act
            coachService.UpdateCoach(player.Object);

            // Assert
            contextMock.Verify(c => c.Commit(), Times.Once);
        }
    }
}
