using FluentAssertions;
using FootballMatchHub.Controllers.API;
using FootballMatchHub.Core.Repositories;
using FootballMatchHub.Persistence;
using FootballMatchHub.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http.Results;

namespace FootballMatchHub.Test.Controllers.API
{
    [TestClass]
    public class GamesControllerTests
    {
        private MatchesController _controller;
        public GamesControllerTests()
        {
            var mockRepo = new Mock<IMatchRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Matches).Returns(mockRepo.Object);

            _controller = new MatchesController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com"); 
        }
        [TestMethod]
        public void Cancel_NoMatchWithGivenIdExists_ShouldReturnNotFound()
        {
            var result =  _controller.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
