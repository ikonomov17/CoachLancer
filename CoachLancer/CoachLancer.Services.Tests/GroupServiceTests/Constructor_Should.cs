using CoachLancer.Data.Models;
using CoachLancer.Data.Repositories;
using CoachLancer.Data.SaveContext;
using Moq;
using NUnit.Framework;
using System;

namespace CoachLancer.Services.Tests.GroupServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIEfRepositoryIsNull()
        {
            var contextMock = new Mock<ISaveContext>();

            Assert.Throws<ArgumentNullException>(() => new GroupsService(null, contextMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenISaveContextIsNull()
        {
            var efRepoMock = new Mock<IEfRepository<Groups>>();

            Assert.Throws<ArgumentNullException>(() => new GroupsService(efRepoMock.Object, null));
        }

        [Test]
        public void ReturnInstaceOfGroupsServiceClass_WhenValidArgumentsArePassed()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            Assert.IsInstanceOf<GroupsService>(groupsService);
        }

    }
}
