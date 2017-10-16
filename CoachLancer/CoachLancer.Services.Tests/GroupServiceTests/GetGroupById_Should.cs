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

namespace CoachLancer.Services.Tests.GroupServiceTests
{
    [TestFixture]
    public class GetGroupById_Should
    {
        [TestCase(0)]
        [TestCase(-42)]
        public void ThrowArgumentOutOfRangeException_WhenIdIsEqualOrLessThanZero(int input)
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => groupsService.GetGroupById(input));
        }

        [Test]
        public void ReturnCorrectGroup_WhenThereIsGroupWithThisIdInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var validId = 1;
            var group = new Groups() {Id = validId};
            var groupsList = new List<Groups>() {group}.AsQueryable();

            efRepoMock.SetupGet(x => x.All).Returns(groupsList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var result = groupsService.GetGroupById(validId);

            Assert.AreEqual(validId, result.Id);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoGroupWithThisIdInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var validId = 1;
            var group = new Groups() { Id = validId };
            var groupsList = new List<Groups>() { group }.AsQueryable();

            efRepoMock.SetupGet(x => x.All).Returns(groupsList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var invalidId = 2;
            var result = groupsService.GetGroupById(invalidId);

            Assert.IsNull(result);
        }
    }
}
