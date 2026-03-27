using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Models;

namespace TitleTrack.Tests
{
    public class UpdateTests : TitleAbstractControllerTestBase, IClassFixture<TitleAbstractControllerFixture>
    {
        public UpdateTests(TitleAbstractControllerFixture fx) : base(fx) { }

        [Fact]
        public async Task ReturnsBadRequest_WhenNull()
        {
            var result = await Controller.UpdateTitleAbstractAsync(null);

            result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("Title abstract cannot be null.");
        }

        [Fact]
        public async Task ReturnsNotFound_WhenMissing()
        {
            SetupNotFound(1);

            var result = await Controller.UpdateTitleAbstractAsync(
                new TitleAbstract { TitleAbstractID = 1 });

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ReturnsNoContent_WhenUpdated()
        {
            var entity = new TitleAbstract { TitleAbstractID = 1 };
            SetupFound(1, entity);

            Fx.RepoMock.Setup(r => r.UpdateTitleAbstractAsync(entity))
                       .Returns(Task.CompletedTask);

            var result = await Controller.UpdateTitleAbstractAsync(entity);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}
