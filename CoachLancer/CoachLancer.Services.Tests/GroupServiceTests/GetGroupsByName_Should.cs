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

namespace CoachLancer.Services.Tests.GroupServiceTests
{
    [TestFixture]
    public class GetGroupsByName_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenNoNameIsProvided()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => groupsService.GetGroupsByName(null));
        }

        [Test]
        public void ReturnCorrectNumberOfItems_WhenThereAreGroupsInDbWithCorrectNames()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var name = "Name";
            var groupsList = new List<Groups>()
            {
                new Groups() {Name = name + "1"},
                new Groups() {Name = name + "2"},
                new Groups() {Name = name + "3"},
                new Groups() {Name = name + "4"},
            }.AsQueryable();

            efRepoMock.SetupGet(e => e.All).Returns(groupsList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var result = groupsService.GetGroupsByName(name).Count();
            var expected = groupsList.Count();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnNull_WhenThereAreNoGroupsInDbWithGivenNames()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var name = "Name";
            var groupsList = new List<Groups>()
            {
                new Groups() {Name = name + "1"},
                new Groups() {Name = name + "2"},
                new Groups() {Name = name + "3"},
                new Groups() {Name = name + "4"},
            }.AsQueryable();

            efRepoMock.SetupGet(e => e.All).Returns(groupsList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var wrongName = "not me";
            var result = groupsService.GetGroupsByName(wrongName).Count();
            var expected = 0;

            Assert.AreEqual(expected, result);
        }
    }
}
