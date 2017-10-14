using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CoachLancer.Services.Tests.CoachServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnAllElementsFromDb_WhenThereAreItemsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachesList = new List<Coach>() {new Coach(), new Coach(), new Coach()};
            var queryableCoaches = coachesList.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(queryableCoaches);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var expected = coachesList.Count;
            var result = coachService.GetAll().Count();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnInstancesOfCoachModelFromDb_WhenThereAreItemsInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var coachesList = new List<Coach>() {new Coach()};
            var queryableCoaches = coachesList.AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(queryableCoaches);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var result = coachService.GetAll();

            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Coach));
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNoCoachesInDb()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var emptyList = new List<Coach>().AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(emptyList);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            var result = coachService.GetAll();
            CollectionAssert.IsEmpty(result);
        }
    }
}
