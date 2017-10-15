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
    class GetLatestCreatedGroups_Should
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ShouldReturnCorrectNumberOfElements_WhenThereAreEnoughRecordsInDb(int input)
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsList = new List<Groups>()
            {
                new Groups(),
                new Groups(),
                new Groups(),
                new Groups(),
            }.AsQueryable();
            efRepoMock.Setup(x => x.All).Returns(groupsList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var expected = groupsService.GetLatestCreatedGroups(input).Count();

            Assert.AreEqual(input, expected);
        }

        [Test]
        public void ThrowArgumentOutOfRangeException_WhenPassedValueIsNegative()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => groupsService.GetLatestCreatedGroups(-1));
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNoGroupsInDb()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var emptyList = new List<Groups>().AsQueryable();
            efRepoMock.Setup(e => e.All).Returns(emptyList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            // Act
            var result = groupsService.GetLatestCreatedGroups(10);

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ReturnOrderedCollection_WhenThereAreGroupsInDb()
        {
            // Arrange
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var unorderedList = new List<Groups>()
            {
                new Groups(){CreatedOn = new DateTime(2012,1,1)},
                new Groups(){CreatedOn = new DateTime(2010,1,1)},
                new Groups(){CreatedOn = new DateTime(2014,1,1)},
                new Groups(){CreatedOn = new DateTime(2011,1,1)},
            }.AsQueryable();

            var orderedList = new List<Groups>()
            {
                new Groups(){CreatedOn = new DateTime(2014,1,1)},
                new Groups(){CreatedOn = new DateTime(2012,1,1)},
                new Groups(){CreatedOn = new DateTime(2011,1,1)},
                new Groups(){CreatedOn = new DateTime(2010,1,1)},
            };

            efRepoMock.Setup(e => e.All).Returns(unorderedList);

            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            // Act
            var result = groupsService.GetLatestCreatedGroups(unorderedList.Count());

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
