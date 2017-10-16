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
using CoachLancer.Data.Models.Contracts;

namespace CoachLancer.Services.Tests.CoachServiceTests
{
    [TestFixture]
    public class AddGroupToCoach_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUsernameIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);
            var group = new Mock<IGroups>();

            Assert.Throws<ArgumentNullException>(() => coachService.AddGroupToCoach(null, group.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenUsernameIsEmpty()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);
            var group = new Mock<IGroups>();

            Assert.Throws<ArgumentException>(() => coachService.AddGroupToCoach(string.Empty, group.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGroupIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => coachService.AddGroupToCoach("not empty", null));
        }

        [Test]
        public void AddGroupToCoach_WhenCoachIsFound()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coach = new Mock<Coach>();
            var username = "username";
            coach.SetupGet(x => x.UserName).Returns(username);
            coach.SetupGet(x => x.Groups).Returns(new List<Groups>());

            var coaches = new List<Coach>() {coach.Object}.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(coaches);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var group = new Mock<IGroups>();

            coachService.AddGroupToCoach(username, group.Object);

            Assert.AreEqual(1, coach.Object.Groups.Count);
        }

        [Test]
        public void CallRepositoryUpdate_WhenExecutedWithValidParameters()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coach = new Mock<Coach>();
            var username = "username";
            coach.SetupGet(x => x.UserName).Returns(username);
            coach.SetupGet(x => x.Groups).Returns(new List<Groups>());

            var coaches = new List<Coach>() { coach.Object }.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(coaches);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var group = new Mock<IGroups>();

            coachService.AddGroupToCoach(username, group.Object);

            efRepoMock.Verify(e => e.Update(coach.Object), Times.Once);
        }

        [Test]
        public void CallContextCommit_WhenExecutedWithValidParameters()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coach = new Mock<Coach>();
            var username = "username";
            coach.SetupGet(x => x.UserName).Returns(username);
            coach.SetupGet(x => x.Groups).Returns(new List<Groups>());

            var coaches = new List<Coach>() { coach.Object }.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(coaches);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var group = new Mock<IGroups>();

            coachService.AddGroupToCoach(username, group.Object);

            contextMock.Verify(c => c.Commit(), Times.Once);
        }
    }
}
