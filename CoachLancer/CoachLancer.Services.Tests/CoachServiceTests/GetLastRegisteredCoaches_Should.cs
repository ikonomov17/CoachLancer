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
    public class GetLastRegisteredCoaches_Should
    {
        [Test]
        public void ThrowArgumentOutOfRangeException_WhenPassedValueIsNegative()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var emptyList = new List<Coach>().AsQueryable();

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => coachService.GetLastRegisteredCoaches(-1));
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNoCoachesInDb()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var emptyList = new List<Coach>().AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(emptyList);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            // Act
            var result = coachService.GetLastRegisteredCoaches(10);

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ReturnOrderedCollectionOfCoachModels_WhenThereAreCoachesInDb()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Coach>>();
            var unorderedList = new List<Coach>()
            {
                new Coach(){CreatedOn = new DateTime(2012,1,1)},
                new Coach(){CreatedOn = new DateTime(2010,1,1)},
                new Coach(){CreatedOn = new DateTime(2014,1,1)},
                new Coach(){CreatedOn = new DateTime(2011,1,1)},
            }.AsQueryable();

            var orderedList = new List<Coach>()
            {
                new Coach(){CreatedOn = new DateTime(2014,1,1)},
                new Coach(){CreatedOn = new DateTime(2012,1,1)},
                new Coach(){CreatedOn = new DateTime(2011,1,1)},
                new Coach(){CreatedOn = new DateTime(2010,1,1)},
            };

            efRepoMock.Setup(e => e.All).Returns(unorderedList);

            var coachService = new CoachService(efRepoMock.Object, contextMock.Object);

            // Act
            var result = coachService.GetLastRegisteredCoaches(unorderedList.Count());

            // Assert

            int index = 0;
            foreach (var coachModel in result)
            {
                Assert.AreEqual(orderedList[index].CreatedOn, coachModel.CreatedOn);
                index++;
            }
        }
    }
}
