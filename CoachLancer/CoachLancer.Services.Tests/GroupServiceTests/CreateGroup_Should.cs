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
    public class CreateGroup_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedModelIsNull()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            Assert.Throws<ArgumentNullException>(() => groupsService.CreateGroup(null));
        }

        [Test]
        public void CallIEfRepostiryAddMethod_WhenExecuted()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var groupModel = new Mock<Groups>();

            groupsService.CreateGroup(groupModel.Object);

            efRepoMock.Verify(e => e.Add(groupModel.Object), Times.Once);
        }

        [Test]
        public void CallContextCommitMethod_WhenExecuted()
        {
            var contextMock = new Mock<ISaveContext>();
            var efRepoMock = new Mock<IEfRepository<Groups>>();
            var groupsService = new GroupsService(efRepoMock.Object, contextMock.Object);

            var groupModel = new Mock<Groups>();

            groupsService.CreateGroup(groupModel.Object);

            contextMock.Verify(c => c.Commit(), Times.Once);
        }
    }
}
