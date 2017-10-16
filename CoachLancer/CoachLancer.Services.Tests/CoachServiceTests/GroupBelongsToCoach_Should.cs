using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachLancer.Data.Models;
using CoachLancer.Data.Models.Contracts;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;

namespace CoachLancer.Services.Tests.CoachServiceTests
{
    [TestFixture]
    public class GroupBelongsToCoach_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUsernameIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);
            var group = new Mock<IGroups>();
            int validId = 1;

            Assert.Throws<ArgumentNullException>(() => coachService.GroupBelongsToCoach(null, validId));
        }

        [Test]
        public void ThrowArgumentException_WhenUsernameIsEmpty()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);
            var group = new Mock<IGroups>();
            int validId = 1;

            Assert.Throws<ArgumentException>(() => coachService.GroupBelongsToCoach(string.Empty, validId));
        }

        [TestCase(0)]
        [TestCase(-42)]
        public void ThrowArgumentOutOfRangeException_WhenGroupIdIsInvalid(int invalidId)
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => coachService.GroupBelongsToCoach("not empty", invalidId));
        }

        [Test]
        public void ReturnTrue_WhenInputParameterAreValidWithObjectsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coach = new Mock<Coach>();
            var username = "username";
            coach.SetupGet(x => x.UserName).Returns(username);

            var validId = 1;
            var group = new Groups(){ Id=validId};

            var groupsList = new List<Groups>() { group };
            coach.SetupGet(x => x.Groups).Returns(groupsList);

            var coachesList = new List<Coach>() {coach.Object}.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(coachesList);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var result = coachService.GroupBelongsToCoach(username, validId);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenInputParameterAreNotValidForObjectsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();

            var coach = new Mock<Coach>();
            var username = "username";
            coach.SetupGet(x => x.UserName).Returns(username);

            var validId = 1;
            var group = new Groups() { Id = validId };

            var groupsList = new List<Groups>() { group };
            coach.SetupGet(x => x.Groups).Returns(groupsList);

            var coachesList = new List<Coach>() { coach.Object }.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(coachesList);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var invalidId = 2;
            var result = coachService.GroupBelongsToCoach(username, invalidId);

            Assert.IsFalse(result);
        }
    }
}
