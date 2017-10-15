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
    public class GetAll_Should
    {
        [Test]
        public void ReturnAllGroupsFromDb_WhenThereAreGroupsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsList = new List<Groups>() { new Groups(), new Groups(), new Groups() };
            var queryableGroups = groupsList.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(queryableGroups);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var expected = groupsList.Count;
            var result = groupsService.GetAll().Count();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnInstancesOfGroupsModelFromDb_WhenThereAreGroupsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsList = new List<Groups>() { new Groups() };
            var queryableGroups = groupsList.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(queryableGroups);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var result = groupsService.GetAll();

            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Groups));
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNoGroupsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var emptyList = new List<Groups>().AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(emptyList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var result = groupsService.GetAll();
            CollectionAssert.IsEmpty(result);
        }
    }
}
