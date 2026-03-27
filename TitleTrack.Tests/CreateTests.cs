using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TitleTrack.Server.Models;

namespace TitleTrack.Tests
{
    public class CreateTests : TitleAbstractControllerTestBase, IClassFixture<TitleAbstractControllerFixture>
    {
        public CreateTests(TitleAbstractControllerFixture fixture) : base(fixture) { }

        [Fact]
        public async Task ReturnsBadRequest_WhenNull()
        {
            var result = await Controller.CreateTitleAbstractAsync(null);

            result.Result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("Title abstract cannot be null.");
        }

        [Fact]
        public async Task ReturnsCreated_WhenValid()
        {
            var entity = new TitleAbstract { TitleAbstractID = 10 };

            Fx.RepoMock.Setup(r => r.AddTitleAbstractAsync(entity))
                       .Returns(Task.CompletedTask);

            var result = await Controller.CreateTitleAbstractAsync(entity);

            result.Result.Should().BeOfType<CreatedAtActionResult>()
                .Which.Value.Should().Be(entity);
        }

    }
}
